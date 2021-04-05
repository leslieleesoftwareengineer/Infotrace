using InfoTrace.API;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace InfoTrace.Tests
{
    public class InfoTraceAPITester
    {
		private readonly TestServer _server;
		private readonly HttpClient _client;
		public InfoTraceAPITester()
        {
			_server = new TestServer(new WebHostBuilder()
		   .UseStartup<Startup>());
			_client = _server.CreateClient();
		}
		[Fact]
		public async System.Threading.Tasks.Task V1_API_Google_Trace()
		{
			HttpContent content = new StringContent(JsonConvert.SerializeObject(new { 
				keyword = "online title search",
				site = "https://www.infotrack.com.au"
			}), Encoding.UTF8, "application/json");
			// Act
			var response = await _client.PostAsync("/v1/api/Trace/google", content);
			response.EnsureSuccessStatusCode();
			var responseString = await response.Content.ReadAsStringAsync();
			Assert.Equal(responseString, "1");
		}
		[Fact]
		public async System.Threading.Tasks.Task V1_API_Bing_Trace()
		{
			HttpContent content = new StringContent(JsonConvert.SerializeObject(new
			{
				keyword = "online title search",
				site = "https://www.infotrack.com.au"
			}), Encoding.UTF8, "application/json");
			// Act
			var response = await _client.PostAsync("/v1/api/Trace/bing", content);
			response.EnsureSuccessStatusCode();
			var responseString = await response.Content.ReadAsStringAsync();
			Assert.Equal(responseString, "31");
		}
	}
}
