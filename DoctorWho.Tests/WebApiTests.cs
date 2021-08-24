using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using DoctorWho.Web;
using DoctorWho.Web.Models;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using Xunit;

namespace DoctorWho.Tests
{
    public class WebApiTests : IClassFixture<InMemDbWebApplicationFactory<Web.Startup>>
    {
        private readonly InMemDbWebApplicationFactory<Startup> _fixture;

        public WebApiTests(InMemDbWebApplicationFactory<Web.Startup> fixture)
        {
            _fixture = fixture;
        }

        [Theory]
        [InlineData("/api/doctors")]
        [InlineData("/api/doctors/Michael%20Fadel")]
        public async Task GET_DoctorController_ResourceExist_StatusCode_Should_200StatusCode(string uri)
        {
            var client = _fixture.CreateClient();

            var response = await client.GetAsync(uri);

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Theory]
        [InlineData("/api/doctors/Not%20Found")]
        public async Task GET_DoctorController_ResourceDoesNotExist_StatusCode_Should_404StatusCode(string uri)
        {
            var client = _fixture.CreateClient();

            var response = await client.GetAsync(uri);

            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task GET_DoctorController_AllDoctors_ResponseCollection_Should_Has10Elements()
        {
            var client = _fixture.CreateClient();


            var response = await client.GetAsync("/api/doctors");

            var body = await response.Content.ReadAsStringAsync();
            var doctors = JsonConvert.DeserializeObject<ICollection<DoctorDto>>(body);


            doctors.Should().HaveCount(10);
        }

        [Fact]
        public async Task GET_DoctorController_Doctor_Response_Should_HasNumber2()
        {
            var client = _fixture.CreateClient();


            var response = await client.GetAsync("/api/doctors/Michael%20Fadel");

            var body = await response.Content.ReadAsStringAsync();
            var doctor = JsonConvert.DeserializeObject<DoctorDto>(body);


            doctor.DoctorNumber.Should().Be(2);
        }

        [Fact]
        public async Task POST_DoctorController_DoctorWithValidData_NoDates_StatusCode_Should_201StatusCode()
        {
            var client = _fixture.CreateClient();


            var creationDto = new DoctorForCreationWithPostDto()
            {
                DoctorName = "new doctor",
                DoctorNumber = 20,
            };

            var data = JsonConvert.SerializeObject(creationDto);

            var response = await client.PostAsync("/api/doctors",
                new StringContent(data, Encoding.UTF8, "application/json"));

            response.StatusCode.Should().Be(HttpStatusCode.Created);
        }

        [Fact]
        public async Task
            POST_DoctorController_DoctorWithInvalidData_LastDateBeforeFirstDate_StatusCode_Should_422StatusCode()
        {
            var client = _fixture.CreateClient();


            var creationDto = new DoctorForCreationWithPostDto()
            {
                DoctorName = "new doctor",
                DoctorNumber = 20,
                FirstEpisodeDate = new DateTime(2021, 2, 1),
                LastEpisodeDate = new DateTime(2020, 2, 1)
            };

            var data = JsonConvert.SerializeObject(creationDto);

            var response = await client.PostAsync("/api/doctors",
                new StringContent(data, Encoding.UTF8, "application/json"));

            response.StatusCode.Should().Be(HttpStatusCode.UnprocessableEntity);
        }

        [Fact]
        public async Task
            POST_DoctorController_DoctorWithInvalidData_LastDateWithNoFirstDate_StatusCode_Should_422StatusCode()
        {
            var client = _fixture.CreateClient();


            var creationDto = new DoctorForCreationWithPostDto()
            {
                DoctorName = "new doctor",
                DoctorNumber = 20,
                LastEpisodeDate = new DateTime(2020, 2, 1)
            };

            var data = JsonConvert.SerializeObject(creationDto);

            var response = await client.PostAsync("/api/doctors",
                new StringContent(data, Encoding.UTF8, "application/json"));

            response.StatusCode.Should().Be(HttpStatusCode.UnprocessableEntity);
        }
        
        [Fact]
        public async Task
            POST_DoctorController_DoctorWithInvalidData_NoName_StatusCode_Should_422StatusCode()
        {
            var client = _fixture.CreateClient();


            var creationDto = new DoctorForCreationWithPostDto()
            {
                DoctorNumber = 20,
            };

            var data = JsonConvert.SerializeObject(creationDto);

            var response = await client.PostAsync("/api/doctors",
                new StringContent(data, Encoding.UTF8, "application/json"));

            response.StatusCode.Should().Be(HttpStatusCode.UnprocessableEntity);
        }
        
        [Fact]
        public async Task
            POST_DoctorController_DoctorWithInvalidData_NoNumber_StatusCode_Should_422StatusCodee()
        {
            var client = _fixture.CreateClient();


            var creationDto = new DoctorForCreationWithPostDto()
            {
                DoctorName = "some name",
            };

            var data = JsonConvert.SerializeObject(creationDto);

            var response = await client.PostAsync("/api/doctors",
                new StringContent(data, Encoding.UTF8, "application/json"));

            response.StatusCode.Should().Be(HttpStatusCode.UnprocessableEntity);
        }
        
        [Fact]
        public async Task
            POST_DoctorController_DoctorWithInvalidData_NameExists_StatusCode_Should_409StatusCode()
        {
            var client = _fixture.CreateClient();


            var creationDto = new DoctorForCreationWithPostDto()
            {
                DoctorName = "Michael Fadel",
                DoctorNumber = 1
            };

            var data = JsonConvert.SerializeObject(creationDto);

            var response = await client.PostAsync("/api/doctors",
                new StringContent(data, Encoding.UTF8, "application/json"));

            response.StatusCode.Should().Be(HttpStatusCode.Conflict);
        }
    }
}