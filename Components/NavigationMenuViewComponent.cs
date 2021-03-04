using BuyBooks.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuyBooks.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {

        private IBuyBooksRepository repository;

        public NavigationMenuViewComponent (IBuyBooksRepository r)
        {
            repository = r;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["category"];
            return View(repository.Libraries
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x =>x));
        }
    }
}
