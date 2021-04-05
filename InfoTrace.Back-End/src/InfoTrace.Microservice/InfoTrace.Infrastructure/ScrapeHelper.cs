using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoTrace.Infrastructure
{
    public static class ScrapeHelper
    {
        public static string Scrape(List<IScrapingContext> list)
        {
            List<int> rs = new List<int>();
            int i = 0;
            foreach(IScrapingContext context in list)
            {
                List<int> l = context.Scrape();
                l = l.Select(r => r + i * 10).ToList();
                if (l.Count>0)
                {
                    rs = rs.Concat(l).ToList();
                }
                i++;
            }
            return String.Join(',', rs.FindAll(r => r <= 50).ToArray());
        }
    }
}
