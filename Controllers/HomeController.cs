using Microsoft.AspNetCore.Mvc;
using Mission9steelea3.Models;
using Mission9steelea3.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission9steelea3.Controllers
{
    public class HomeController : Controller
    {

        private IBookstoreRepository repo;

        public HomeController (IBookstoreRepository temp)
        {
            repo = temp;
        }
        public IActionResult Index(string bookCategories, int pageNum = 1)
        {
            int pageSize = 10;

            var x = new BooksViewModel
            {
                Books = repo.Books
                .Where(b => b.Category == bookCategories || bookCategories == null)
                .OrderBy(b => b.Title)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),

                PageInfo = new PageInfo
                {
                    TotalNumBooks = (bookCategories == null ? repo.Books.Count() : repo.Books.Where(x => x.Category == bookCategories).Count()),
                    BooksPerPage = pageSize,
                    CurrentPage = pageNum
                }
            };

            
            return View(x);
        }

    }
}
