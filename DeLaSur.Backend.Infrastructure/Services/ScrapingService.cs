using DeLaSur.Backend.Domain.Services;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using CsvHelper;
using HtmlAgilityPack;
using System.Globalization;
using System.Xml.Linq;

namespace DeLaSur.Backend.Infrastructure.Services
{
    public class ScrapingService : IScrapingService
    {
        public ScrapingService() { }
        public async Task<List<Product>> CaratOnline()
        {

            //List<string> programmerLinks = new List<string>();

            //var options = new ChromeOptions();

            //options.AddArguments(new List<string>() {
            //    "headless",
            //    "disable-gpu"
            //});

            //var browser = new ChromeDriver(options);
            //List<Product> products = new List<Product>();
            //int page = 1;
            //while (100 > products.Count)
            //{

            //    string fullUrl = "https://www.carat-online.at/se?page="+page+"&lang=1&g_1=1&g_2=1&g_3=1";
            //    browser.Navigate().GoToUrl(fullUrl);
            //    var totalRowsString = browser.FindElement(By.CssSelector("div.three.columns.offer-count")).FindElement(By.TagName("span")).GetAttribute("innerText").Trim();
            //    totalRowsString = totalRowsString.Remove(totalRowsString.IndexOf(" "));
            //    int totalRows = int.Parse(totalRowsString);
            //    var elements = browser.FindElements(By.CssSelector("article.category-item"));
            //    foreach (var element in elements)
            //    {
            //        Product p = new();
            //        var container = element.FindElement(By.CssSelector("div.row"));
            //        var cells = container.FindElement(By.CssSelector("div.item-description")).FindElement(By.TagName("table")).FindElement(By.TagName("tbody")).FindElements(By.TagName("tr"));
            //        foreach (var cell in cells)
            //        {
            //            var e = cell.FindElements(By.TagName("td"));
            //            var text = e[0].GetAttribute("innerText").ToLower();
            //            if (text.Contains("color"))
            //            {
            //                p.Color = e[1].GetAttribute("innerText");
            //            }
            //            if (text.Contains("clarity"))
            //            {
            //                p.Clarity = e[1].GetAttribute("innerText");
            //            }
            //        }
            //        var name = container.FindElement(By.CssSelector("div.item-description")).FindElement(By.CssSelector("h2.item-title")).GetAttribute("innerText");
            //        var price = container.FindElement(By.CssSelector("div.cat-margin")).FindElement(By.CssSelector("div.price-kategorie")).FindElement(By.TagName("ul")).FindElements(By.TagName("li"))[2].GetAttribute("innerText");
            //        price = price.Replace("€", "");
            //        price = price.Remove(price.IndexOf("."));
            //        decimal priceDecimal = decimal.Parse(price.Trim());
            //        p.Name = name;
            //        p.Price = priceDecimal;
            //        products.Add(p);
            //    }
            //    page++;
            //}

            //return products;
            // creating the list that will keep the scraped data 
            var products = new List<Product>();
            // visiting the target web page 

            // getting the list of HTML product nodes 

            DownloadHtml(1, products);

            // crating the CSV output file 
            using (var writer = new StreamWriter("pokemon-products.csv"))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                // populating the CSV file 
                csv.WriteRecords(products);
            }
            return products;
        }

        private void DownloadHtml(int page, List<Product> products)
        {
            var web = new HtmlWeb();
            string url = "https://www.carat-online.at/se?page=" + page + "&lang=1&g_1=1&g_2=1&g_3=1";
            var document = web.Load(url);
            var elements = document.DocumentNode.QuerySelectorAll("article.category-item");
            // iterating over the list of product HTML elements 
            foreach (var element in elements)
            {
                var product = new Product();
                var container = element.QuerySelector("div.row");
                var cells = container.QuerySelector("div.item-description").QuerySelector("table").QuerySelector("tbody").QuerySelectorAll("tr");
                foreach (var cell in cells)
                {
                    var e = cell.QuerySelectorAll("td");
                    var text = e[0].InnerText.ToLower();
                    if (text.Contains("color"))
                    {
                        product.Color = e[1].InnerText;
                    }
                    if (text.Contains("clarity"))
                    {
                        product.Clarity = e[1].InnerText;
                    }
                }
                var name = container.QuerySelector("div.item-description").QuerySelector("h2.item-title").InnerText;
                var price = container.QuerySelector("div.cat-margin").QuerySelector("div.price-kategorie").QuerySelector("ul").QuerySelectorAll("li")[2].InnerText;
                price = price.Replace("€", "");
                price = price.Replace("&euro;", "");
                price = price.Remove(price.IndexOf("."));
                decimal priceDecimal = decimal.Parse(price.Trim());
                product.Name = name;
                product.Price = priceDecimal;

                products.Add(product);
            }

            if (elements.Count == 25)
            {
                DownloadHtml(page + 1, products);
            }
        }
    }
}
