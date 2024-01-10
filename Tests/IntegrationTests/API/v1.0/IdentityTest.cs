using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc.Testing;
using Public.DTO.v1._0.Identity;
using Xunit.Abstractions;

namespace Tests.IntegrationTests.API.v1._0;

public class IdentityTest : IClassFixture<CustomWebAppFactory<Program>>
{
    private readonly HttpClient _client;
    private readonly ITestOutputHelper _testOutputHelper;
    private readonly string _registerURL;
    private readonly string _signinURL;

    public IdentityTest(CustomWebAppFactory<Program> factory, ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
        _client = factory.CreateClient(new WebApplicationFactoryClientOptions
        {
            AllowAutoRedirect = false
        });
        _registerURL = "/api/v1.0/identity/account/register";
        _signinURL = "/api/v1.0/identity/account/signin";
    }

    [Fact(DisplayName = "POST - register new user failure, only admin")]
    public async Task TestRegisterNewUserFailed()
    {
        var registerData = new
        {
            Email = "test@app.com",
            Password = "a",
            FirstName = "Test",
            LastName = "App"
        };
        var data = JsonContent.Create(registerData);

        var response = await _client.PostAsync(_registerURL, data);

        Assert.False(response.IsSuccessStatusCode);
        Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
    }

    [Fact(DisplayName = "POST - login user")]
    public async Task TestLoginUser()
    {
        var adminLoginData = new
        {
            Email = "admin@opusportal.com",
            Password = "Foo.bar1"
        };
        var data = JsonContent.Create(adminLoginData);

        var response = await _client.PostAsync(_signinURL, data);

        _testOutputHelper.WriteLine(await response.Content.ReadAsStringAsync());
        response.EnsureSuccessStatusCode();
    }

    [Fact(DisplayName = "POST - login failed")]
    public async Task TestLoginFailed()
    {
        var adminLoginData = new
        {
            Email = "admin@opusportal.com",
            Password = "wrong-pass123"
        };
        var data = JsonContent.Create(adminLoginData);

        var response = await _client.PostAsync(_signinURL, data);

        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact(DisplayName = "POST - register new user")]
    public async Task TestRegisterNewUser()
    {
        var adminLoginData = new
        {
            Email = "admin@opusportal.com",
            Password = "Foo.bar1"
        };
        var adminLoginDataJsonContent = JsonContent.Create(adminLoginData);

        var adminLoginResponse = await _client.PostAsync(_signinURL, adminLoginDataJsonContent);
        var responseObject = await adminLoginResponse.Content.ReadAsStringAsync();
        Assert.NotNull(responseObject);
        _testOutputHelper.WriteLine(responseObject);
        var jwtResponse = System.Text.Json.JsonSerializer.Deserialize<JWTResponse>(responseObject);
        Assert.NotNull(jwtResponse);
        _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtResponse.JWT);
        
        var registerData = new
        {
            Email = "test@app.com",
            Password = "Foo.bar1",
            FirstName = "Test",
            LastName = "App"
        };
        var data = JsonContent.Create(registerData);

        var response = await _client.PostAsync(_registerURL, data);

        Assert.True(response.IsSuccessStatusCode);

        var responseContent = await response.Content.ReadAsStringAsync();
        var JWTResponse = System.Text.Json.JsonSerializer.Deserialize<RefreshTokenModel>(responseContent);
        
        Assert.NotNull(JWTResponse);
    }

    [Fact(DisplayName = "POST - JWT expired")]
    public async Task TestJWTExpired()
    {
        
    }

    [Fact(DisplayName = "POST - JWT renewal")]
    public async Task TestJWTRenewal()
    {
        
    }

    [Fact(DisplayName = "POST - JWT logout")]
    public async Task JWTLogout()
    {
        
    }
}