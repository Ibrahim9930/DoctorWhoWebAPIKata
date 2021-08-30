using System.Net;
using System.Threading.Tasks;
using DoctorWho.Tests.Utils;
using DoctorWho.Web;
using FluentAssertions;
using Xunit;

namespace DoctorWho.Tests.DoctorControllerApiTests
{
    public class DeleteTests : ApiTests
    {
        public DeleteTests(InMemDbWebApplicationFactory<Startup> fixture) : base(fixture)
        {
        }
        
        [Fact]
        public async Task DELETE_DoctorController_DoctorExists_StatusCode_Should_204StatusCode()
        {
            var client = Fixture.CreateClient();
            
            var response = await client.DeleteAsync("/api/doctors/2");

            response.StatusCode.Should().Be(HttpStatusCode.NoContent);
        }
        
        [Fact]
        public async Task DELETE_DoctorController_DoctorDoesNotExist_StatusCode_Should_404StatusCode()
        {
            var client = Fixture.CreateClient();
            
            var response = await client.DeleteAsync("/api/doctors/1");

            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }
        
        [Fact]
        public async Task DELETE_DoctorController_DoctorExists_GetDoctorStatusCode_Should_404StatusCode()
        {
            var client = Fixture.CreateClient();
            
            await client.DeleteAsync("/api/doctors/9");
            
            var response = await client.GetAsync("/api/doctors/9");

            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }
    }
}