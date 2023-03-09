using Microsoft.AspNetCore.Mvc;
using Mission9steelea3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Mission9steelea3.Components
    {
        public class BookCategoriesViewComponent : ViewComponent
        {
            private IBookstoreRepository repo { get; set; }

            public BookCategoriesViewComponent(IBookstoreRepository temp)
            {
                repo = temp;
            }

            public IViewComponentResult Invoke()
            {
                ViewBag.SelectedCategory = RouteData?.Values["bookCategories"];

                var categories = repo.Books
                    .Select(x => x.Category)
                    .Distinct()
                    .OrderBy(x => x);

                return View(categories);
            }
        }
    }

