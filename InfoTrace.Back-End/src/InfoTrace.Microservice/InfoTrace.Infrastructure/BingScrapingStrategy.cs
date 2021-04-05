using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace InfoTrace.Infrastructure
{
    public class BingScrapingStrategy : IScrapingStrategy
    {
        public List<int> Scrape(string content, string site)
        {
            List<int> rs = new List<int>();
            MatchCollection matches = Regex.Matches(content, "<ol id=\"b_results\">([\\s\\S]*)?</ol>");
            Match match = matches.FirstOrDefault();
            if (match != default)
            {
                string _content = Regex.Replace(content, "<li class=\"b_ans b_mop\"[\\s\\S]*?</li>", "");
                matches = Regex.Matches(_content, "<li class=\"b_algo\"[\\s\\S]*?</li>");
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
            return rs;
        }
    }
}
