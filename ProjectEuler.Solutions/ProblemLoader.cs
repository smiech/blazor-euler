using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using HtmlAgilityPack.CssSelectors.NetCore;

namespace ProjectEuler.Solutions
{
    public class ProblemLoader
    {
        public ProblemLoader()
        {
        }

        public async Task<IEnumerable<IProblem>> LoadProblems(int start, int end)
        {
            List<Task<IProblem>> problems = new List<Task<IProblem>>();
            for (int i = start; i <= end; i++)
            {
                  problems.Add(Load(i));
            }
            return await Task.WhenAll(problems);
        }

        public async Task<IProblem> Load(int number)
        {
            using (WebClient client = new WebClient())
            {
                Uri pageUri = new Uri($"https://projecteuler.net/problem={number}");
                string html = await client.DownloadStringTaskAsync(pageUri);
                var doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(html);
                var selectedNode = doc.QuerySelector("#content");
                var title = selectedNode.QuerySelector("h2").InnerText;
                var content = selectedNode.QuerySelector(".problem_content").InnerText;
                return new Problem(title, content, number);
            }
        }
    }
}
