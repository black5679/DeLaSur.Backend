using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeLaSur.Backend.Domain.Services
{
    public interface IScrapingService
    {
        Task<List<Product>> CaratOnline();
    }
    public class Product
    {
        public string? Name { get; set; }
        public decimal Precio { get; set; }
        public decimal Peso { get; set; }
        public string? Color { get; set; }
        public string? Forma { get; set; }
        public string? Clarity { get; set; }
        public decimal Largo { get; set; }
        public decimal Ancho { get; set; }
        public decimal Alto { get; set; }
    }
}
