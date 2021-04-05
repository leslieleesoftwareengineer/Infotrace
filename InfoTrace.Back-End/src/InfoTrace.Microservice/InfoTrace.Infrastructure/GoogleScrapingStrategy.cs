using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace InfoTrace.Infrastructure
{
    public class GoogleScrapingStrategy : IScrapingStrategy
    {
        public List<int> Scrape(string content, string site)
        {
            List<int> rs = new List<int>();
            MatchCollection matches = Regex.Matches(content, "<div class=\"r\">.*?</div>");
            matches.Select((m, i) =>
            {
                if (m.Value.Contains(site))
                {
                    rs.Add(i+1);
                }
                return m;
            }).ToList();
            return rs;
        }
    }
}
