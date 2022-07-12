using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMvcPagination.Models;

namespace WebMvcPagination.Services
{
    public class DataService : IDataService
    {
        
        public IQueryable<Product> GetProducts()
        {
            var productFaker = new Faker<Product>("en")
           .RuleFor(i => i.Id, i => i.IndexFaker)
           .RuleFor(i => i.Name, i => i.Commerce.ProductName())
           .RuleFor(i => i.Description, i => i.Commerce.ProductDescription())
           .RuleFor(i => i.PictureUri, i => i.Image.PicsumUrl())
           .RuleFor(i => i.Price, i => Convert.ToDecimal(i.Commerce.Price(4, 5000, 2)))
           .RuleFor(i => i.Category, i => i.Commerce.Categories(1)[0]);

            List<Product> products = productFaker.Generate(1000);

            return products.AsQueryable();  
        }

       
    }
}
