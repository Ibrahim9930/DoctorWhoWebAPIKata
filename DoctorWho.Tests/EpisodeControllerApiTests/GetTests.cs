using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using DoctorWho.Tests.Utils;
using DoctorWho.Web;
using DoctorWho.Web.Models;
using FluentAssertions;
using Xunit;

namespace DoctorWho.Tests.EpisodeControllerApiTests
{
    public class GetTests : ApiTests
    {
        public GetTests(InMemDbWebApplicationFactory<Startup> fixture) : base(fixture)
        {
        }
        
        [Theory]
        [InlineData("/api/episodes")]
        [InlineData("/api/episodes/S01:E02")]
        public async Task GET_EpisodeController_StatusCode_Should_200StatusCode(string uri)
        {
            var client = Fixture.CreateClient();

            var response = await client.GetAsync(uri);

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
        
        [Fact]
        public async Task GET_EpisodeController_ResourceDoesNotExist_StatusCode_Should_404StatusCode()
        {
            var client = Fixture.CreateClient();

            var response = await client.GetAsync("/api/episodes/S20:E20");

            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }
        
        [Fact]
        public async Task GET_EpisodeController_AllEpisodes_ResponseCollection_Should_Has10Elements()
        {
            var client = Fixture.CreateClient();
            
            var response = await client.GetAsync("/api/episodes");
            var episodes = await ResponseParser.GetObjectFromResponse<ICollection<EpisodeDto>>(response);
            
            episodes.Should().HaveCount(10);
        }
        
        [Fact]
        public async Task GET_EpisodeController_Episode_Response_Should_HasNumberSeries1()
        {
            var client = Fixture.CreateClient();
            
            var response = await client.GetAsync("/api/episodes/S01:E02");
            var episode = await ResponseParser.GetObjectFromResponse<EpisodeDto>(response);
            
            episode.SeriesNumber.Should().Be(1);
        }
    }
}