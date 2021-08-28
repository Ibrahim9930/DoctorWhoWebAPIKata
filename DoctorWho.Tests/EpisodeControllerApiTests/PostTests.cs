using System;
using System.Net;
using System.Threading.Tasks;
using DoctorWho.Tests.Utils;
using DoctorWho.Web;
using DoctorWho.Web.Models;
using FluentAssertions;
using Xunit;

namespace DoctorWho.Tests.EpisodeControllerApiTests
{
    public class PostTests : ApiTests
    {
        public PostTests(InMemDbWebApplicationFactory<Startup> fixture) : base(fixture)
        {
        }
        
        [Fact]
        public async Task POST_EpisodeController_EpisodeWithValidData_StatusCode_Should_201StatusCode()
        {
            var client = Fixture.CreateClient();

            var creationDto = new EpisodeForCreationWithPostDto()
            {
                Title = "some title with more than 10 characters",
                AuthorId = 1,
                DoctorId = 1,
                EpisodeNumber = 1,
                SeriesNumber = 1,
            };
            var response = await client.PostAsync("/api/episodes",
                ResponseParser.GetResponseBody(creationDto));

            response.StatusCode.Should().Be(HttpStatusCode.Created);
        }

        [Fact]
        public async Task
            POST_EpisodeController_EpisodeWithInvalidData_ShortTitle_StatusCode_Should_422StatusCode()
        {
            var client = Fixture.CreateClient();

            var creationDto = new EpisodeForCreationWithPostDto()
            {
                Title = "short",
                AuthorId = 1,
                DoctorId = 1,
                EpisodeNumber = 1,
                SeriesNumber = 1,
            };
            var response = await client.PostAsync("/api/episodes",
                ResponseParser.GetResponseBody(creationDto));

            response.StatusCode.Should().Be(HttpStatusCode.UnprocessableEntity);
        }

        [Fact]
        public async Task
            POST_EpisodeController_EpisodeWithInvalidData_NoIds_StatusCode_Should_422StatusCode()
        {
            var client = Fixture.CreateClient();

            var creationDto = new EpisodeForCreationWithPostDto()
            {
                Title = "short",
                EpisodeNumber = 1,
                SeriesNumber = 1,
            };
            var response = await client.PostAsync("/api/episodes",
                ResponseParser.GetResponseBody(creationDto));

            response.StatusCode.Should().Be(HttpStatusCode.UnprocessableEntity);
        }

        [Fact]
        public async Task
            POST_EpisodeController_EpisodeWithInvalidData_NoNumbers_StatusCode_Should_422StatusCode()
        {
            var client = Fixture.CreateClient();

            var creationDto = new EpisodeForCreationWithPostDto()
            {
                Title = "some title with more than 10 characters",
                AuthorId = 1,
                DoctorId = 1,
            };
            
            var response = await client.PostAsync("/api/episodes",
                ResponseParser.GetResponseBody(creationDto));

            response.StatusCode.Should().Be(HttpStatusCode.UnprocessableEntity);
        }

        [Fact]
        public async Task
            POST_EpisodeController_EpisodeWithInvalidData_EpisodeNumberZero_StatusCode_Should_422StatusCodee()
        {
            var client = Fixture.CreateClient();

            var creationDto = new EpisodeForCreationWithPostDto()
            {
                Title = "some title with more than 10 characters",
                AuthorId = 1,
                DoctorId = 1,
                EpisodeNumber = 0,
                SeriesNumber = 1,
            };
            var response = await client.PostAsync("/api/episodes",
                ResponseParser.GetResponseBody(creationDto));

            response.StatusCode.Should().Be(HttpStatusCode.UnprocessableEntity);
        }

        [Fact]
        public async Task
            POST_EpisodeController_EpisodeWithInvalidData_LocatorExists_StatusCode_Should_409StatusCode()
        {
            var client = Fixture.CreateClient();

            var creationDto = new EpisodeForCreationWithPostDto()
            {
                Title = "some title with more than 10 characters",
                AuthorId = 1,
                DoctorId = 1,
                SeriesNumber= 5,
                EpisodeNumber=  12,
            };
            var response = await client.PostAsync("/api/episodes",
                ResponseParser.GetResponseBody(creationDto));

            response.StatusCode.Should().Be(HttpStatusCode.Conflict);
        }
    }
}