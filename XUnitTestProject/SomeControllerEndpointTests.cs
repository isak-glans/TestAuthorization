using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Xunit;
using XUnitTestProject.Factories;

namespace XUnitTestProject
{
    public class SomeControllerEndpointTests : IClassFixture<AppInstance>
    {
        private readonly AppInstance appInstance;

        public SomeControllerEndpointTests(AppInstance appInstance)
        {
            this.appInstance = appInstance;
        }

        [Fact]
        public async Task IndexPage()
        {
            var client = appInstance.CreateClient(new()
            {
                AllowAutoRedirect = false
            });
            var result = await client.GetAsync("/index");
            Assert.Equal(System.Net.HttpStatusCode.OK, result.StatusCode);
        }

        [Fact]
        public async Task PrivacyPage()
        {
            var client = appInstance.CreateClient(new()
            {
                AllowAutoRedirect = false
            });
            var result = await client.GetAsync("/privacy");
            Assert.Equal(System.Net.HttpStatusCode.OK, result.StatusCode);
        }

        [Fact]
        public async Task AdminPage()
        {
            var client = appInstance.CreateClient(new()
            {
                AllowAutoRedirect = false
            });
            var result = await client.GetAsync("/admin");
            var content = result.Content.ReadAsStringAsync();
            Assert.Equal(System.Net.HttpStatusCode.OK, result.StatusCode);
        }
    }
}