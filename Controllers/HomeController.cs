using BuyBooks.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BuyBooks.Models.ViewModels;

namespace BuyBooks.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private IBuyBooksRepository _repository;

        public int PageSize = 5; 

        public HomeController(ILogger<HomeController> logger, IBuyBooksRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public IActionResult Index(string category, int page = 1)
        {
            //Gets the Iqueryable Libraries to pass to the view
            return View(new LibraryListViewModel
            {
                Libraries = _repository.Libraries
                        .Where(p => category == null || p.Category == category)
                        .OrderBy(p => p.BookId)
                        .Skip((page - 1) * PageSize)
                        .Take(PageSize)
                        ,
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    //gets number of pages to display and takes into account any category filter
                    TotalNumItems = category == null ? _repository.Libraries.Count() :
                        _repository.Libraries.Where(x => x.Category == category).Count()
                },
                CurrentCategory = category
            });
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
};
