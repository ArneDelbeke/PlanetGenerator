using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using HtmlAgilityPack;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GodCheckerScraper
{
    class Program
    {
        static void Main(string[] args)
        {
            new Program()
                .MainAsync()
                .GetAwaiter()
                .GetResult();
        }

        private readonly List<KeyValuePair<string, string>> _pantheonsList = new();
        private readonly JObject _resultJson = new();

        async Task MainAsync()
        {
            Console.WriteLine("Godchecker.com Scraper");
            Console.WriteLine("");
            Console.WriteLine("+ Parsing pantheons");

            if (await ParseGods())
            {
                Console.WriteLine($"- {_pantheonsList.Count} pantheons");
                Console.WriteLine("+ Getting all gods");
                if (await GetAllData())
                {
                    Console.WriteLine("+ Writing to one json file");
                    await WriteToFile();
                }
            }
        }

        async Task<bool> ParseGods()
        {
            const string dataUrl = "https://www.godchecker.com/";
            HttpClient client = new();
            var response = await client.GetStringAsync(dataUrl);
            try
            {
                HtmlDocument htmlDocument = new();
                htmlDocument.LoadHtml(response);

                var nav = htmlDocument.DocumentNode.SelectNodes("//nav[@id='drop-panel-pantheons']/ul");

                foreach (HtmlNode htmlNode in nav)
                {
                    HtmlDocument childDocument = new();
                    childDocument.LoadHtml(htmlNode.OuterHtml);

                    var children = childDocument.DocumentNode.SelectNodes("//li");

                    foreach (HtmlNode child in children)
                    {
                        HtmlDocument mythology = new();
                        mythology.LoadHtml(child.OuterHtml);

                        var name = mythology.DocumentNode.SelectSingleNode("//a//text()").InnerText;
                        var urlnode = mythology.DocumentNode.SelectSingleNode("//a[@href]");
                        var url = urlnode.GetAttributeValue("href", string.Empty);

                        _pantheonsList.Add(new KeyValuePair<string, string>(name, $"{url}pantheon/"));
                    }
                }
                
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private async Task<bool> GetAllData()
        {
            try
            {
                foreach (var (name, url) in _pantheonsList)
                {
                    HttpClient client = new();
                    var htmlBody = await client.GetStringAsync(url);
                    HtmlDocument htmlDocument = new();
                    htmlDocument.LoadHtml(htmlBody);

                    var gods = htmlDocument.DocumentNode.SelectNodes("//div[@class='search-result clickable-panel']");

                    List<God> godList = new();

                    foreach (HtmlNode god in gods)
                    {
                        HtmlDocument godStats = new();
                        godStats.LoadHtml(god.OuterHtml);

                        var title = godStats.DocumentNode.SelectSingleNode("//h1").InnerText;
                        var description = godStats.DocumentNode.SelectSingleNode("//p").InnerText;

                        godList.Add(new God
                        {
                            Name = title.Trim(),
                            Description = description
                        });
                    }

                    _resultJson.Add(new JProperty(name.Normalize(false, true, true).Replace(" ", ""), JToken.FromObject(godList)));

                    Console.WriteLine($"- {name}: {gods.Count}");
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private async Task WriteToFile()
        {
            var rootPath = $"{Environment.CurrentDirectory}/export";

            if (!Directory.Exists(rootPath)) Directory.CreateDirectory(rootPath);

            try
            {
                var path = $"{rootPath}/result.json";

                await File.WriteAllTextAsync(path, _resultJson.ToString(Formatting.Indented));

                Console.WriteLine("! Done");
            }
            catch (Exception e)
            {
                Console.WriteLine($"! Failure : {e.Message}");
            }
        }
    }
}