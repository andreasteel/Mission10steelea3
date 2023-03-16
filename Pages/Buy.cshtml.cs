using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Mission9steelea3.Infrastructure;
using Mission9steelea3.Models;

namespace Mission9steelea3.Pages
{
    public class BuyModel : PageModel
    {
        private IBookstoreRepository repo { get; set; }
        public Basket basket { get; set; }
        public string ReturnUrl { get; set; }

        public BuyModel (IBookstoreRepository temp, Basket b)
        {
            repo = temp;
            basket = b;
        }



        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
        }

        public IActionResult OnPost(string title, string returnUrl)
        {
            Book b = repo.Books.FirstOrDefault(x => x.Title == title);

            basket.AddItem(b, 1);

            return RedirectToPage(new { ReturnUrl = returnUrl });
        }

        public IActionResult OnPostRemove (string title, string returnUrl)
        {
            basket.RemoveItem(basket.Items.First(x => x.Book.Title == title).Book);

            return RedirectToPage ( new {ReturnUrl = returnUrl});
        }
    }
}
