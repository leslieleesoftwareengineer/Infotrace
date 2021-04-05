using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoTrace.Infrastructure
{
    public interface IScrapingStrategy
    {
        public List<int> Scrape(string content,string site);
    }
}
