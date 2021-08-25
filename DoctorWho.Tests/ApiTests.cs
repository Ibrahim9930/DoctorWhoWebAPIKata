using DoctorWho.Web;
using Xunit;

namespace DoctorWho.Tests
{
    public class ApiTests : IClassFixture<InMemDbWebApplicationFactory<Web.Startup>>
    {
        protected InMemDbWebApplicationFactory<Startup> Fixture { get; }

        public ApiTests(InMemDbWebApplicationFactory<Web.Startup> fixture)
        {
            Fixture = fixture;
        }
    }
}