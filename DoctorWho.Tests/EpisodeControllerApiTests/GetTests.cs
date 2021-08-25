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
        
        [Fact]
        public async Task GET_EpisodeController_StatusCode_Should_200StatusCode()
        {
            var client = Fixture.CreateClient();

            var response = await client.GetAsync("api/episodes");

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
        
        [Fact]
        public async Task GET_EpisodeController_AllEpisodes_ResponseCollection_Should_Has10Elements()
        {
            var client = Fixture.CreateClient();
            
            var response = await client.GetAsync("/api/episodes");
            var episodes = await ResponseParser.GetObjectFromResponse<ICollection<EpisodeDto>>(response);
            
            episodes.Should().HaveCount(10);
        }
    }
}