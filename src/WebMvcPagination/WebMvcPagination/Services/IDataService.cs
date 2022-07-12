using WebMvcPagination.Models;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebMvcPagination.Services
{
    public interface IDataService
    {
        IQueryable<Product> GetProducts();
    }
}
