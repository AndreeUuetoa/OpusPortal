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

    [Fact(DisplayName = "POST - register new user fails, only admin allowed")]
    public async Task TestRegisterNewUserFails()
    {
        var registerData = new
        {
            Email = "test@app.com",
            Password = "a",
            FirstName = "Test",
            LastName = "App",
            AppRoleName = "Student"
        };
        var data = JsonContent.Create(registerData);

        var response = await _client.PostAsync(_registerURL, data);

        _testOutputHelper.WriteLine(await response.Content.ReadAsStringAsync());
        Assert.False(response.IsSuccessStatusCode);
        Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
    }

    [Fact(DisplayName = "POST - user signs in")]
    public async Task TestUserSignIn()
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

    [Fact(DisplayName = "POST - sign-in fails, incorrect credentials")]
    public async Task TestUserSignInFails()
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
        adminLoginResponse.EnsureSuccessStatusCode();
        var jwtResponse = System.Text.Json.JsonSerializer.Deserialize<JWTResponse>(responseObject);
        Assert.NotNull(jwtResponse);
        _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtResponse.JWT);
        
        var registerData = new RegistrationData
        {
            Email = "test@app.com",
            Password = "Foo.bar1",
            FirstName = "Test",
            LastName = "App",
            AppRoleName = "Student"
        };
        var data = JsonContent.Create(registerData);

        var response = await _client.PostAsync(_registerURL, data);

        response.EnsureSuccessStatusCode();
    }

    [Fact(DisplayName = "POST - user signs out")]
    public async Task TestUserSignOut()
    {
        var adminSigninData = new
        {
            Email = "admin@opusportal.com",
            Password = "Foo.bar1"
        };
        var adminSigninDataJson = JsonContent.Create(adminSigninData);
        var signinResponse = await _client.PostAsync(_signinURL, adminSigninDataJson);
        signinResponse.EnsureSuccessStatusCode();
        var signinResponseObject = await signinResponse.Content.ReadAsStringAsync();
        var jwtResponse = System.Text.Json.JsonSerializer.Deserialize<JWTResponse>(signinResponseObject);
        Assert.NotNull(jwtResponse);
        _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtResponse.JWT);

        var refreshToken = jwtResponse.RefreshToken;
        var signOutDataJson = JsonContent.Create(new {refreshToken});
        var signOutURL = "/api/v1.0/identity/account/signout";
        var signOutResponse = await _client.PostAsync(signOutURL, signOutDataJson);

        signOutResponse.EnsureSuccessStatusCode();
    }
}