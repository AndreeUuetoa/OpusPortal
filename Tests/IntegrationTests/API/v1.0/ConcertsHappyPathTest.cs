using System.Net.Http.Headers;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc.Testing;
using Public.DTO.v1._0.Competitions;
using Public.DTO.v1._0.Concerts;
using Public.DTO.v1._0.Identity;
using Xunit.Abstractions;

namespace Tests.IntegrationTests.API.v1._0;

public class ConcertsHappyPathTest : IClassFixture<CustomWebAppFactory<Program>>
{
    private readonly HttpClient _client;
    private readonly ITestOutputHelper _testOutputHelper;
    private readonly string _signinURL;

    public ConcertsHappyPathTest(CustomWebAppFactory<Program> factory, ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
        _client = factory.CreateClient(new WebApplicationFactoryClientOptions
        {
            AllowAutoRedirect = false
        });
        _signinURL = "/api/v1.0/identity/account/signin";
    }

    [Fact(DisplayName = "GET - get all concerts")]
    public async Task TestGetAllConcerts()
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
        var response = await _client.GetAsync("api/v1.0/concerts");

        response.EnsureSuccessStatusCode();
        
        _testOutputHelper.WriteLine(await response.Content.ReadAsStringAsync());
    }

    [Fact(DisplayName = "POST - add a concert")]
    public async Task TestAddConcert()
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

        var concertData = new Concert
        {
            Name = "Jõuluteenistus",
            Location = "Tallinna Jaani kirik",
            From = DateTime.UtcNow
        };
        var concertDataJsonContent = JsonContent.Create(concertData);

        var concertsURL = "/api/v1.0/concerts";
        var postConcertResponse = await _client.PostAsync(concertsURL, concertDataJsonContent);
        postConcertResponse.EnsureSuccessStatusCode();
    }

    [Fact(DisplayName = "POST - add a concert as part of a competition")]
    public async Task TestAddConcertOfCompetition()
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
        var createdCompetition = await CreateExampleCompetition();
        var concertData = new Concert
        {
            Name = "Esimene voor",
            Location = "Tallinna Muusika- ja Balletikool",
            From = DateTime.UtcNow,
            CompetitionId = createdCompetition.Id
        };
        var concertDataJsonContent = JsonContent.Create(concertData);

        var concertsURL = "/api/v1.0/concerts";
        var postBookResponse = await _client.PostAsync(concertsURL, concertDataJsonContent);
        postBookResponse.EnsureSuccessStatusCode();
    }

    private async Task<Competition> CreateExampleCompetition()
    {
        var competition = new Competition
        {
            Name = "Eesti Kõla XII"
        };
        var competitionData = JsonContent.Create(competition);
        var competitionsURL = "/api/v1.0/competitions";

        var addCompetitionResponse = await _client.PostAsync(competitionsURL, competitionData);

        addCompetitionResponse.EnsureSuccessStatusCode();
        var createdCompetitionContent = await addCompetitionResponse.Content.ReadAsStringAsync();
        var createdCompetitionObject = System.Text.Json.JsonSerializer.Deserialize<Competition>(createdCompetitionContent);
        if (createdCompetitionObject == null) throw new ApplicationException("Could not serialize competition object.");
        return createdCompetitionObject;
    }
}