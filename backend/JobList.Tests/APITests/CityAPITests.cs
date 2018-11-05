using JobList.Common.DTOS;
using JobList.Common.Requests;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace JobList.Tests.APITests
{
    [TestFixture]
    public class CityAPITests
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;

        public CityAPITests()
        {
            _server = new TestServer(new WebHostBuilder()
                            .UseStartup<Startup>());
            _client = _server.CreateClient();
        }
        [Test]
        public async Task Cities_Should_Get_All()
        {
            // Act
            var response = await _client.GetAsync("/cities");
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            var cities = JsonConvert.DeserializeObject<List<CityDTO>>(responseString);

            // Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsTrue(cities.Count() > 0);
        }
        [Test]
        public async Task Cities_Should_Get_Specific()
        {
            // Arrange
            var responseForArrange = await _client.GetAsync("/cities");
            responseForArrange.EnsureSuccessStatusCode();
            var responseStringForArrange = await responseForArrange.Content.ReadAsStringAsync();
            var cities = JsonConvert.DeserializeObject<List<CityDTO>>(responseStringForArrange);

            // Act
            var response = await _client.GetAsync($"/cities/{cities[cities.Count() - 1].Id}");
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            var city = JsonConvert.DeserializeObject<CityDTO>(responseString);

            // Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual(cities[cities.Count() - 1].Id, city.Id);
        }

        [Test, Order(1)]
        public async Task Cities_Should_Post_Specific()
        {
            // Arrange
            var cityToAdd = new CityRequest
            {
                Id = 13,
                Name = "Lviv"
            };
            var content = JsonConvert.SerializeObject(cityToAdd);
            var stringContent = new StringContent(content, Encoding.UTF8, "application/json");

            // Act
            var response = await _client.PostAsync("/cities", stringContent);

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            var responseString = await response.Content.ReadAsStringAsync();
            var city = JsonConvert.DeserializeObject<CityDTO>(responseString);

            Assert.AreEqual(cityToAdd.Id, city.Id);
            Assert.AreEqual(cityToAdd.Name, city.Name);
        }

        [Test]
        public async Task Cities_Post_Specific_Invalid()
        {
            // Arrange
            var cityToAdd = new CityDTO { Name = "Kiyv" };
            var content = JsonConvert.SerializeObject(cityToAdd);
            var stringContent = new StringContent(content, Encoding.UTF8, "application/json");

            // Act
            var response = await _client.PostAsync("/cities", stringContent);

            // Assert
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Test]
        public async Task Cities_Put_Specific()
        {
            // Arrange
            var responseForArrange = await _client.GetAsync("/cities");
            responseForArrange.EnsureSuccessStatusCode();
            var responseStringForArrange = await responseForArrange.Content.ReadAsStringAsync();
            var cities = JsonConvert.DeserializeObject<List<CityDTO>>(responseStringForArrange);

            var cityToChange = new CityRequest
            {
                Id = 13,
                Name = "Kiyv"
            };
            var content = JsonConvert.SerializeObject(cityToChange);
            var stringContent = new StringContent(content, Encoding.UTF8, "application/json");

            // Act
            var response = await _client.PutAsync($"/sities/{cities[cities.Count() - 1].Id}", stringContent);

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            var responseString = await response.Content.ReadAsStringAsync();
            var city = JsonConvert.DeserializeObject<CityDTO>(responseString);

            Assert.AreEqual(cityToChange.Name, city.Name);
        }

        [Test, Order(7)]
        public async Task Cities_Delete_Specific()
        {
            // Arrange
            var responseGet = await _client.GetAsync("/cities");
            responseGet.EnsureSuccessStatusCode();
            var responseString = await responseGet.Content.ReadAsStringAsync();
            var cities = JsonConvert.DeserializeObject<List<CityDTO>>(responseString);

            // Act
            var response = await _client.DeleteAsync($"/cities/{cities[cities.Count() - 1].Id}");

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.AreEqual(HttpStatusCode.NoContent, response.StatusCode);
        }
    }
}
