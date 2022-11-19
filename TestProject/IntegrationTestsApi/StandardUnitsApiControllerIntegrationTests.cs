using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using TestProject.Helpers;
using WebApp;
using Xunit;
using Xunit.Abstractions;

namespace TestProject.IntegrationTestsApi
{
    public class StandardUnitsApiControllerIntegrationTests : IClassFixture<CustomWebApplicationFactory<WebApp.Startup>>
    {
        private readonly CustomWebApplicationFactory<WebApp.Startup> _factory;
        private readonly HttpClient _client;
        private readonly ITestOutputHelper _testOutputHelper;
        /*private readonly AppDbContext _ctx;*/


        public StandardUnitsApiControllerIntegrationTests(CustomWebApplicationFactory<Startup> factory,
            ITestOutputHelper testOutputHelper)
        {
            _factory = factory;
            _testOutputHelper = testOutputHelper;
            _client = factory
                .WithWebHostBuilder(builder =>
                {
                    builder.UseSetting("test_database_name", Guid.NewGuid().ToString()); 
                })
                .CreateClient(new WebApplicationFactoryClientOptions()
                    {
                        // dont follow redirects
                        AllowAutoRedirect = false
                    }
                );
        }

        [Fact]
        public async Task Api_Get_StandardUnits()
        {
            // ARRANGE
            var uri = "/api/v1/standardunits";
            
            // ACT
            var getTestResponse = await _client.GetAsync(uri);
            
            // ASSERT
            getTestResponse.EnsureSuccessStatusCode();

            var body = await getTestResponse.Content.ReadAsStringAsync();
            _testOutputHelper.WriteLine(body);
            var options = new JsonSerializerOptions(JsonSerializerDefaults.Web);

            
            var data = JsonHelper.DeserializeWithWebDefaults<List<DAL.App.DTO.StandardUnit>>(body);
            Assert.NotNull(data);
            Assert.NotNull(data);
            Assert.Single(data);
            Assert.Equal("Title 0", data![0].Title);
        }
        
        [Fact]
        public async Task Api_HappyFlow()
        {
            // Register admin user
            // login with admin user
            // create standard unit using token
            // fetch created standard units
            var uri = "/api/v1/account/register";
            
            var uriRegister = "/api/v1/account/register";
            var uriLogin = "/api/v1/account/login";
            var uriStandardUnits = "/api/v1/standardunits";
            
            var userRegister = new PublicApi.DTO.v1.Register()
            {
                AccountType = "admin",
                Email = "testadmin@test.test",
                Password = "Abracadabra909Mellon999Kek!"
            };
            
            var stringContentUserRegister = JsonContent.Create(userRegister);
            var getTestResponse = await _client.PostAsync(uriRegister, stringContentUserRegister);
            var isSuccessStatusCode = getTestResponse.EnsureSuccessStatusCode();
            Assert.True(getTestResponse.StatusCode.Equals(HttpStatusCode.OK));
            var body = await getTestResponse.Content.ReadAsStringAsync();
            _testOutputHelper.WriteLine(body);


            // ASSERT
            /*var data = JsonHelper.DeserializeWithWebDefaults<List<DAL.App.DTO.StandardUnit>>(body);*/
            //Assert.False(isSuccessStatusCode);
            
            var userLogin = new PublicApi.DTO.v1.Login()
            {
                Email = "testadmin@test.test",
                Password = "Abracadabra909Mellon999Kek!"
            };
            var stringContentUserLogin = JsonContent.Create(userLogin);
            var res = await _client.PostAsync(uriLogin, stringContentUserLogin);
            isSuccessStatusCode = res.EnsureSuccessStatusCode();
            _testOutputHelper.WriteLine(isSuccessStatusCode.ToString());
            Assert.True(res.StatusCode.Equals(HttpStatusCode.OK));
            body = await res.Content.ReadAsStringAsync();
            var b1 = body.Remove(0, 8);
            var b2 = b1.Substring(2, b1.Length - 4);
            _testOutputHelper.WriteLine(b2);
            
            var standardunit = new PublicApi.DTO.v1.StandardUnitAddPut()
            {   
                Title = "kek",
                Symbol = "k"
            };
            
            var stringContent = JsonContent.Create(standardunit);
            /*HttpClient client = new HttpClient();*/
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", b2);
            
            res = await _client.PostAsync(uriStandardUnits, stringContent);
            isSuccessStatusCode = res.EnsureSuccessStatusCode();
            _testOutputHelper.WriteLine(isSuccessStatusCode.ToString());
            Assert.True(isSuccessStatusCode.StatusCode.Equals(HttpStatusCode.Created));
            _testOutputHelper.WriteLine(getTestResponse.StatusCode.ToString());
            //_testOutputHelper.WriteLine(isSuccessStatusCode.ToString());
            body = await res.Content.ReadAsStringAsync();
            _testOutputHelper.WriteLine(body);
            
            res = await _client.GetAsync(uriStandardUnits);
            isSuccessStatusCode = res.EnsureSuccessStatusCode();
            Assert.True(isSuccessStatusCode.StatusCode.Equals(HttpStatusCode.OK));
            body = await res.Content.ReadAsStringAsync();
            _testOutputHelper.WriteLine(body);
            
        }

    }
}