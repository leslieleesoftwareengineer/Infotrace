using System;
using System.Collections.Generic;

namespace InfoTrace.Infrastructure
{
    public interface IScrapingContext
    {
        public void SetSite(string site);
        public void SetContent(string content);
        public void SetStrategy(IScrapingStrategy strategy);
        public List<int> Scrape();
    }
}
