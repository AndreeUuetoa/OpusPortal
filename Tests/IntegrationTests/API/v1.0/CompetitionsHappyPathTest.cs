using System.Net.Http.Headers;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc.Testing;
using Public.DTO.v1._0.Competitions;
using Public.DTO.v1._0.Identity;
using Xunit.Abstractions;

namespace Tests.IntegrationTests.API.v1._0;

public class CompetitionsHappyPathTest : IClassFixture<CustomWebAppFactory<Program>>
{
    private readonly HttpClient _client;
    private readonly ITestOutputHelper _testOutputHelper;
    private readonly string _signinURL;

    public CompetitionsHappyPathTest(CustomWebAppFactory<Program> factory, ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
        _client = factory.CreateClient(new WebApplicationFactoryClientOptions
        {
            AllowAutoRedirect = false
        });
        _signinURL = "/api/v1.0/identity/account/signin";
    }

    [Fact(DisplayName = "GET - get all competitions")]
    public async Task TestGetAllCompetitions()
    {
        var adminLoginData = new SignInData
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
        var response = await _client.GetAsync("api/v1.0/competitions");

        response.EnsureSuccessStatusCode();
        
        _testOutputHelper.WriteLine(await response.Content.ReadAsStringAsync());
    }

    [Fact(DisplayName = "POST - add a competition")]
    public async Task TestAddCompetition()
    {
        var adminLoginData = new SignInData
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

        var competitionData = new Competition
        {
            Name = "Eesti kõla XII"
        };
        var competitionsData = JsonContent.Create(competitionData);

        var competitionsURL = "/api/v1.0/competitions";
        var postConcertResponse = await _client.PostAsync(competitionsURL, competitionsData);
        postConcertResponse.EnsureSuccessStatusCode();
    }
}