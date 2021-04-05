using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoTrace.Infrastructure
{
    public class ScrapingContext : IScrapingContext
    {
        private IScrapingStrategy strategy { get; set; }
        private string content { get; set; }
        private string site { get; set; }
        public void SetContent(string content)
        {
            this.content = content;
        }

        public void SetSite(string site)
        {
            this.site = site;
        }

        public void SetStrategy(IScrapingStrategy strategy)
        {
            this.strategy = strategy;
        }

        public List<int> Scrape()
        {
            return this.strategy.Scrape(content, site);
        }
    }
}
