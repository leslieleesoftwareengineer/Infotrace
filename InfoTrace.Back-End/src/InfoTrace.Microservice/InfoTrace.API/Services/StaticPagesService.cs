using InfoTrace.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace InfoTrace.API.Services
{
    public interface IStaticPagesService
    {
        public Task<string> GetGoogleStaticPagesAsync(string keyword, string site);
        public Task<string> GetBingStaticPagesAsync(string keyword, string site);
    }

    public class StaticPagesService : IStaticPagesService
    {
        private readonly IHttpClientFactory clientFactory;

        public StaticPagesService(IHttpClientFactory clientFactory)
        {
            this.clientFactory = clientFactory;
        }

        public async Task<string> GetGoogleStaticPagesAsync(string keyword, string site)
        {
            var client = clientFactory.CreateClient();
            List<IScrapingContext> list = new List<IScrapingContext>();
            for (var i=0; i< 10; i++)
            {
                var index = (i + 1).ToString("00");
                var request = new HttpRequestMessage(HttpMethod.Get,
                    $"https://infotrack-tests.infotrack.com.au/Google/Page{index}.html");
                var response = await client.SendAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    string content = await  response.Content.ReadAsStringAsync();
                    ScrapingContext context = new ScrapingContext();
                    context.SetContent(content);
                    context.SetSite(site);
                    context.SetStrategy(new GoogleScrapingStrategy());
                    list.Add(context);
                }
            }
            return ScrapeHelper.Scrape(list);
        }

        public async Task<string> GetBingStaticPagesAsync(string keyword, string site)
        {
            var client = clientFactory.CreateClient();
            List<IScrapingContext> list = new List<IScrapingContext>();
            for (var i = 0; i < 10; i++)
            {
                var index = (i + 1).ToString("00");
                var request = new HttpRequestMessage(HttpMethod.Get,
                    $"https://infotrack-tests.infotrack.com.au/Bing/Page{index}.html");
                var response = await client.SendAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    ScrapingContext context = new ScrapingContext();
                    context.SetContent(content);
                    context.SetSite(site);
                    context.SetStrategy(new BingScrapingStrategy());
                    list.Add(context);
                }
            }
            return ScrapeHelper.Scrape(list);
        }

    }
}
