using System;
using System.Net;
using System.Threading.Tasks;
using DoctorWho.Tests.Utils;
using DoctorWho.Web.Models;
using FluentAssertions;
using Xunit;

namespace DoctorWho.Tests.AuthorControllerApiTests
{
    public class PutTests : ApiTests
    {
        public PutTests(InMemDbWebApplicationFactory<Web.Startup> fixture) : base(fixture)
        {
        }

        [Fact]
        public async Task
            PUT_AuthorController_Update_ResourceExists_StatusCode_Should_204StatusCode()
        {
            var client = Fixture.CreateClient();

            var creationDto = new AuthorForUpdate()
            {
                AuthorName = "a new author name"
            };

            var response = await client.PutAsync($"/api/authors/Ida%20Gibson",
                ResponseParser.GetResponseBody(creationDto));

            response.StatusCode.Should().Be(HttpStatusCode.NoContent);
        }

        [Fact]
        public async Task
            PUT_AuthorController_Update_ResourceDoesNotExists_StatusCode_Should_404StatusCode()
        {
            var client = Fixture.CreateClient();

            var creationDto = new AuthorForUpdate()
            {
                AuthorName = "a new author name"
            };

            var response = await client.PutAsync($"/api/authors/Non%20Existent",
                ResponseParser.GetResponseBody(creationDto));

            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }
    }
}