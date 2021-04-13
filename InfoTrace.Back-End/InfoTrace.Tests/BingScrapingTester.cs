using InfoTrace.Infrastructure;
using System;
using System.Collections.Generic;
using System.Net.Http;
using Xunit;

namespace InfoTrace.Tests
{
    public class BingScrapingTester
	{
		ScrapingContext context = new ScrapingContext();
		HttpClient httpClient = new HttpClient();

        public BingScrapingTester()
		{
			context.SetStrategy(new BingScrapingStrategy());
		}

		[Fact]
		public async System.Threading.Tasks.Task BingScraping_Page1()
		{
			HttpResponseMessage response = await httpClient.GetAsync("https://infotrack-tests.infotrack.com.au/Bing/Page01.html");
			response.EnsureSuccessStatusCode();
			string content = await response.Content.ReadAsStringAsync();
			context.SetContent(content);
			context.SetSite("https://www.infotrack.com.au");
			List<int> l = context.Scrape();
			Assert.Equal(l.Count, 0);
		}


		[Fact]
		public async System.Threading.Tasks.Task BingScraping_Page2()
		{
			HttpResponseMessage response = await httpClient.GetAsync("https://infotrack-tests.infotrack.com.au/Bing/Page02.html");
			response.EnsureSuccessStatusCode();
			string content = await response.Content.ReadAsStringAsync();
			context.SetContent(content);
			context.SetSite("https://www.infotrack.com.au");
			List<int> l = context.Scrape();
			Assert.Equal(l.Count, 0);
		}
		[Fact]
		public async System.Threading.Tasks.Task BingScraping_Page3()
		{
			HttpResponseMessage response = await httpClient.GetAsync("https://infotrack-tests.infotrack.com.au/Bing/Page03.html");
			response.EnsureSuccessStatusCode();
			string content = await response.Content.ReadAsStringAsync();
			context.SetContent(content);
			context.SetSite("https://www.infotrack.com.au");
			List<int> l = context.Scrape();
			Assert.Equal(l.Count, 0);
		}
		[Fact]
		public async System.Threading.Tasks.Task BingScraping_Page4()
		{
			HttpResponseMessage response = await httpClient.GetAsync("https://infotrack-tests.infotrack.com.au/Bing/Page04.html");
			response.EnsureSuccessStatusCode();
			string content = await response.Content.ReadAsStringAsync();
			context.SetContent(content);
			context.SetSite("https://www.infotrack.com.au");
			List<int> l = context.Scrape();
			Assert.Equal(l.Count, 1);
			Assert.Equal(l[0], 0);
		}
		[Fact]
		public async System.Threading.Tasks.Task BingScraping_Page5()
		{
			HttpResponseMessage response = await httpClient.GetAsync("https://infotrack-tests.infotrack.com.au/Bing/Page05.html");
			response.EnsureSuccessStatusCode();
			string content = await response.Content.ReadAsStringAsync();
			context.SetContent(content);
			context.SetSite("https://www.infotrack.com.au");
			List<int> l = context.Scrape();
			Assert.Equal(l.Count, 0);
		}
		[Fact]
		public async System.Threading.Tasks.Task BingScraping_Page6()
		{
			HttpResponseMessage response = await httpClient.GetAsync("https://infotrack-tests.infotrack.com.au/Bing/Page06.html");
			response.EnsureSuccessStatusCode();
			string content = await response.Content.ReadAsStringAsync();
			context.SetContent(content);
			context.SetSite("https://www.infotrack.com.au");
			List<int> l = context.Scrape(); 
			Assert.Equal(l.Count, 0);
		}
		[Fact]
		public async System.Threading.Tasks.Task BingScraping_Page7()
		{
			HttpResponseMessage response = await httpClient.GetAsync("https://infotrack-tests.infotrack.com.au/Bing/Page07.html");
			response.EnsureSuccessStatusCode();
			string content = await response.Content.ReadAsStringAsync();
			context.SetContent(content);
			context.SetSite("https://www.infotrack.com.au");
			List<int> l = context.Scrape();
			Assert.Equal(l.Count, 1);
			Assert.Equal(l[0], 3);
		}
		[Fact]
		public async System.Threading.Tasks.Task BingScraping_Page8()
		{
			HttpResponseMessage response = await httpClient.GetAsync("https://infotrack-tests.infotrack.com.au/Bing/Page08.html");
			response.EnsureSuccessStatusCode();
			string content = await response.Content.ReadAsStringAsync();
			context.SetContent(content);
			context.SetSite("https://www.infotrack.com.au");
			List<int> l = context.Scrape();
			Assert.Equal(l.Count, 0);
		}
		[Fact]
		public async System.Threading.Tasks.Task BingScraping_Page9()
		{
			HttpResponseMessage response = await httpClient.GetAsync("https://infotrack-tests.infotrack.com.au/Bing/Page09.html");
			response.EnsureSuccessStatusCode();
			string content = await response.Content.ReadAsStringAsync();
			context.SetContent(content);
			context.SetSite("https://www.infotrack.com.au");
			List<int> l = context.Scrape();
			Assert.Equal(l.Count, 0);
		}
		[Fact]
		public async System.Threading.Tasks.Task BingScraping_Page10()
		{
			HttpResponseMessage response = await httpClient.GetAsync("https://infotrack-tests.infotrack.com.au/Bing/Page10.html");
			response.EnsureSuccessStatusCode();
			string content = await response.Content.ReadAsStringAsync();
			context.SetContent(content);
			context.SetSite("https://www.infotrack.com.au");
			List<int> l = context.Scrape();
			Assert.Equal(l.Count, 0);
		}
		[Fact]
		public async System.Threading.Tasks.Task BingScrapingHelper()
		{
			List<IScrapingContext> list = new List<IScrapingContext>();
			for (var i = 0; i < 10; i++)
			{
				var index = (i+1).ToString("00");
				var request = new HttpRequestMessage(HttpMethod.Get,
					$"https://infotrack-tests.infotrack.com.au/Bing/Page{index}.html");
				var response = await httpClient.SendAsync(request);
				if (response.IsSuccessStatusCode)
				{
					string content = await response.Content.ReadAsStringAsync();
					ScrapingContext context = new ScrapingContext();
					context.SetContent(content);
					context.SetSite("https://www.infotrack.com.au");
					context.SetStrategy(new BingScrapingStrategy());
					list.Add(context);
				}
			}
			string rs = ScrapeHelper.Scrape(list);
			Assert.Equal(rs, "31");
		}
	}
}
