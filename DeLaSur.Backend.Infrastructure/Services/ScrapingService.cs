using DeLaSur.Backend.Domain.Services;
using HtmlAgilityPack;
using System.Text.RegularExpressions;

namespace DeLaSur.Backend.Infrastructure.Services
{
    public class ScrapingService : IScrapingService
    {
        public ScrapingService() { }
        public async Task<List<Product>> CaratOnline()
        {
            // creating the list that will keep the scraped data 
            var products = new List<Product>();
            // visiting the target web page 
            var web = new HtmlWeb();
            string url = "https://www.carat-online.at/se?page=1&lang=1&g_1=1&g_2=1&g_3=1";
            var document = await web.LoadFromWebAsync(url);
            var count = document.DocumentNode.QuerySelector("div.row.category-header.uppercase").QuerySelector("div.three.columns.offer-count").QuerySelector("span.u-pull-right").InnerText.Trim();
            count = count.Remove(count.IndexOf(" "));
            int totalRows = int.Parse(count.Trim());
            // getting the list of HTML product nodes 
            int page = 1;
            while(totalRows > products.Count)
            {
                web = new HtmlWeb();
                url = "https://www.carat-online.at/se?page=" + page + "&lang=1&g_1=1";
                document = await web.LoadFromWebAsync(url);
                var elements = document.DocumentNode.QuerySelectorAll("article.category-item");
                // iterating over the list of product HTML elements 
                foreach (var element in elements)
                {
                    var product = new Product();
                    var container = element.QuerySelector("div.row");
                    var cells = container.QuerySelector("div.item-description").QuerySelector("table").QuerySelector("tbody").QuerySelectorAll("tr");
                    foreach (var cell in cells)
                    {
                        Regex regex = new("[a-zA-Z-]");
                        var e = cell.QuerySelectorAll("td");
                        var text = e[0].InnerText.ToLower();
                        if (text.Contains("weight"))
                        {
                            var peso = e[1].InnerText.ToLower().Replace("ct."," ").Replace("ca."," ").Replace("ct", " ").Replace("ca", " ").Trim();
                            if(peso.Contains("-")) peso = peso.Remove(peso.IndexOf("-")); // En caso de rango de peso
                            if (peso != "") product.Peso = decimal.Parse(peso);
                        }
                        if (text.Contains("color"))
                        {
                            product.Color = e[1].InnerText.Trim();
                        }
                        if (text.Contains("shape"))
                        {
                            product.Forma = e[1].InnerText.Trim();
                        }
                        if (text.Contains("clarity"))
                        {
                            product.Clarity = e[1].InnerText.Trim();
                        }
                        if (text.Contains("measures"))
                        {
                            var measures = e[1].InnerText.ToLower().Trim();
                            
                            measures = regex.Replace(measures, " ");
                            regex = new Regex(@"\d+\.\d+");

                            // Encontrar coincidencias en la cadena
                            MatchCollection matches = regex.Matches(measures);

                            // Convertir coincidencias a decimal
                            //decimal[] numbers = matches
                            //    .Cast<Match>()
                            //    .Select(match => decimal.Parse(match.Value))
                            //    .ToArray();
                            //if (numbers.Length > 0)
                            //{
                            //    product.Largo = numbers[0];
                            //}
                            //if (numbers.Length > 1)
                            //{
                            //    product.Ancho = numbers[1];
                            //}
                            //if (numbers.Length > 2)
                            //{
                            //    product.Alto = numbers[2];
                            //}
                        }
                    }
                    var name = container.QuerySelector("div.item-description").QuerySelector("h2.item-title").InnerText;
                    var price = container.QuerySelector("div.cat-margin").QuerySelector("div.price-kategorie").QuerySelector("ul").QuerySelectorAll("li")[2].InnerText;
                    price = price.Replace("€", "");
                    price = price.Replace("&euro;", "");
                    price = price.Remove(price.IndexOf("."));
                    price = price.Replace(",", ".");
                    decimal priceDecimal = decimal.Parse(price.Trim());
                    product.Name = name;
                    product.Precio = priceDecimal;

                    products.Add(product);
                }
                page++;
            }
            return products;
        }
    }
}
