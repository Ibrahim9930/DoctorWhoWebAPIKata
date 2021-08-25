using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using DoctorWho.Tests.Utils;
using DoctorWho.Web.Models;
using FluentAssertions;
using Newtonsoft.Json;
using Xunit;

namespace DoctorWho.Tests.DoctorControllerApiTests
{
    public class GetTests : ApiTests
    {
        public GetTests(InMemDbWebApplicationFactory<Web.Startup> fixture) : base(fixture)
        {
        }

        [Theory]
        [InlineData("/api/doctors")]
        [InlineData("/api/doctors/2")]
        public async Task GET_DoctorController_ResourceExist_StatusCode_Should_200StatusCode(string uri)
        {
            var client = Fixture.CreateClient();

            var response = await client.GetAsync(uri);

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task GET_DoctorController_ResourceDoesNotExist_StatusCode_Should_404StatusCode()
        {
            var client = Fixture.CreateClient();

            var response = await client.GetAsync("/api/doctors/200");

            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task GET_DoctorController_AllDoctors_ResponseCollection_Should_Has10Elements()
        {
            var client = Fixture.CreateClient();
            
            var response = await client.GetAsync("/api/doctors");
            var doctors = await ResponseParser.GetObjectFromResponse<ICollection<DoctorDto>>(response);
            
            doctors.Should().HaveCount(10);
        }

        [Fact]
        public async Task GET_DoctorController_Doctor_Response_Should_HasNumber2()
        {
            var client = Fixture.CreateClient();
            
            var response = await client.GetAsync("/api/doctors/2");
            var doctor = await ResponseParser.GetObjectFromResponse<DoctorDto>(response);
            
            doctor.DoctorNumber.Should().Be(2);
        }
    }
}