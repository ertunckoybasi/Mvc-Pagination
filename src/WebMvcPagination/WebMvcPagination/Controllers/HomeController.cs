using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PagedList.Core;
using System.Diagnostics;
using WebMvcPagination.Models;
using WebMvcPagination.Services;
using WebMvcPagination.ViewModels;

namespace WebMvcPagination.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IDataService _dataService;

        public HomeController(ILogger<HomeController> logger, IDataService dataService)
        {
            _logger = logger;
            _dataService = dataService;
        }

        public IActionResult Index(int? pageNumber)
        {
            int pageSize = 5;
            var source = _dataService.GetProducts();
            return View( PaginatedList<Product>.CreatePage(source.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        public IActionResult Index2(int page = 1, int pageSize = 3)
        {
            var source = _dataService.GetProducts();
            PagedList<Product> model = new PagedList<Product>(source, page, pageSize);
            return View("Index2", model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
