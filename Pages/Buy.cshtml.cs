using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Mission9steelea3.Models;

namespace Mission9steelea3.Pages
{
    public class BuyModel : PageModel
    {
        private IBookstoreRepository repo { get; set; }

        public BuyModel (IBookstoreRepository temp)
        {
            repo = temp;
        }

        public Basket basket { get; set; }

        public void OnGet(Basket b)
        {
            basket = b;
        }

        public IActionResult OnPost(string title)
        {
            Book b = repo.Books.FirstOrDefault(x => x.Title == title);

            basket = new Basket();
            basket.AddItem(b, 1);

            return RedirectToPage(basket);
        }
    }
}
