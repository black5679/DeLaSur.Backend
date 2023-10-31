using DeLaSur.Backend.Domain.Services;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace DeLaSur.Backend.Infrastructure.Services
{
    public class ScrapingService : IScrapingService
    {
        public ScrapingService() { }
        public async Task<List<Product>> CaratOnline()
        {
            
            string fullUrl = "https://www.carat-online.at/se?page=1&lang=1&g_1=1&g_2=1&g_3=1";
            List<string> programmerLinks = new List<string>();

            var options = new ChromeOptions();

            options.AddArguments(new List<string>() {
                "headless",
                "disable-gpu"
            });

            var browser = new ChromeDriver(options);
            List<Product> products = new List<Product>();
            browser.Navigate().GoToUrl(fullUrl);
            var totalRowsString = browser.FindElement(By.CssSelector("div.three.columns.offer-count")).FindElement(By.TagName("span")).GetAttribute("innerText").Trim();
            totalRowsString = totalRowsString.Remove(totalRowsString.IndexOf(" "));
            int totalRows = int.Parse(totalRowsString);
            var elements = browser.FindElements(By.CssSelector("article.category-item"));
            while (totalRows > products.Count)
            {
                foreach (var element in elements)
                {
                    Product p = new();
                    var container = element.FindElement(By.CssSelector("div.row"));
                    var cells = container.FindElement(By.CssSelector("div.item-description")).FindElement(By.TagName("table")).FindElement(By.TagName("tbody")).FindElements(By.TagName("tr"));
                    foreach (var cell in cells)
                    {
                        var e = cell.FindElements(By.TagName("td"));
                        var text = e[0].GetAttribute("innerText").ToLower();
                        if (text.Contains("color"))
                        {
                            p.Color = e[1].GetAttribute("innerText");
                        }
                        if (text.Contains("clarity"))
                        {
                            p.Clarity = e[1].GetAttribute("innerText");
                        }
                    }
                    var name = container.FindElement(By.CssSelector("div.item-description")).FindElement(By.CssSelector("h2.item-title")).GetAttribute("innerText");
                    var price = container.FindElement(By.CssSelector("div.cat-margin")).FindElement(By.CssSelector("div.price-kategorie")).FindElement(By.TagName("ul")).FindElements(By.TagName("li"))[2].GetAttribute("innerText");
                    price = price.Replace("€", "");
                    price = price.Remove(price.IndexOf("."));
                    decimal priceDecimal = decimal.Parse(price.Trim());
                    p.Name = name;
                    p.Price = priceDecimal;
                    products.Add(p);
                }
            }

            return products;
        }
    }
}
