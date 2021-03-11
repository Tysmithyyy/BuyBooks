using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuyBooks.Infrastructure;
using BuyBooks.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BuyBooks.Pages
{
    public class BuyModel : PageModel
    {

        private IBuyBooksRepository repository;

        //constructor
        public BuyModel(IBuyBooksRepository repo, Cart cartservice)
        {
            repository = repo;
            Cart = cartservice;
        }

        //properties
        public Cart Cart { get; set; }

        public string ReturnUrl { get; set; }

        //methods
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
            //Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
        }

        public IActionResult OnPost(long bookID, string returnURL)
        {
            Library library = repository.Libraries.FirstOrDefault(p => p.BookId == bookID);

            //Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();

            Cart.AddItem(library, 1);

            //HttpContext.Session.SetJson("cart", Cart);

            return RedirectToPage(new { returnUrl = returnURL });
        }

        public IActionResult OnPostRemove(long bookId, string returnUrl)
        {
            Cart.RemoveLine(Cart.Lines.First(p =>
                p.Library.BookId == bookId).Library);
            return RedirectToPage(new { returnUrl = returnUrl });
        }
    }
}
