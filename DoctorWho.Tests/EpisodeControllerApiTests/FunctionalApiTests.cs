using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using DoctorWho.Web;
using DoctorWho.Web.Models;
using FluentAssertions;
using Xunit;

namespace DoctorWho.Tests.EpisodeControllerApiTests
{
    public class FunctionalApiTests : ApiTests
    {
        public FunctionalApiTests(InMemDbWebApplicationFactory<Startup> fixture) : base(fixture)
        {
        }

        [Fact]
        public async Task OPTIONS_EpisodeController_AddCompanion_EpisodeExists_StatusCode_Should_200StatusCode()
        {
            var client = Fixture.CreateClient();

            var content = new CompanionForCreationDto()
            {
                CompanionName = "Some Companion",
                WhoPlayed = 1
            };

            var request = new HttpRequestMessage(HttpMethod.Options, "/api/episodes/S01:E02/addCompanion")
            {
                Content = JsonContent.Create(content, content.GetType(), MediaTypeHeaderValue.Parse("application/json"))
            };

            var response = await client.SendAsync(request);

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task OPTIONS_EpisodeController_AddCompanion_EpisodeDoesNotExists_StatusCode_Should_404StatusCode()
        {
            var client = Fixture.CreateClient();

            var content = new CompanionForCreationDto()
            {
                CompanionName = "Some Companion",
                WhoPlayed = 1
            };

            var request = new HttpRequestMessage(HttpMethod.Options, "/api/episodes/S20:E20/addCompanion")
            {
                Content = JsonContent.Create(content, content.GetType(), MediaTypeHeaderValue.Parse("application/json"))
            };

            var response = await client.SendAsync(request);

            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task OPTIONS_EpisodeController_AddEnemy_EpisodeExists_StatusCode_Should_200StatusCode()
        {
            var client = Fixture.CreateClient();

            var content = new EnemyForCreationDto()
            {
                EnemyName = "Some_enemy",
                Description = "an enemy"
            };

            var request = new HttpRequestMessage(HttpMethod.Options, "/api/episodes/S01:E02/addEnemy")
            {
                Content = JsonContent.Create(content, content.GetType(), MediaTypeHeaderValue.Parse("application/json"))
            };

            var response = await client.SendAsync(request);

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task OPTIONS_EpisodeController_AddEnemy_EpisodeDoesNotExists_StatusCode_Should_404StatusCode()
        {
            var client = Fixture.CreateClient();

            var content = new EnemyForCreationDto()
            {
                EnemyName = "Some_enemy",
                Description = "an enemy"
            };

            var request = new HttpRequestMessage(HttpMethod.Options, "/api/episodes/S20:E20/addEnemy")
            {
                Content = JsonContent.Create(content, content.GetType(), MediaTypeHeaderValue.Parse("application/json"))
            };

            var response = await client.SendAsync(request);

            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }
    }
}