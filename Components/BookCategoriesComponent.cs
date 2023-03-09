using Microsoft.AspNetCore.Mvc;
using Mission9steelea3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission9steelea3.Components
{
    public class BookCategoriesComponent : ViewComponent
    {
        private IBookstoreRepository repo { get; set; }

        public BookCategoriesComponent (IBookstoreRepository temp)
        {
            repo = temp;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["bookCategory"];

            var categories = repo.Books
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x);

            return View(categories);
        }
    }
}
