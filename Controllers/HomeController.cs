using Microsoft.AspNetCore.Mvc;
using Mission9.Models;
using Mission9.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission9.Controllers
{
    public class HomeController : Controller
    {
        private IBookstoreRepository repo;

        public HomeController (IBookstoreRepository temp)
        {
            repo = temp;
        }

        public IActionResult Index(string bookCategory, int PageNum = 1)
        {
            int numBooks = 10;

            var x = new BooksViewModel
            {
                Books = repo.Books
                .Where(b =>b.Category == bookCategory || bookCategory == null)
                .OrderBy(b => b.Title)
                .Skip((PageNum - 1) * numBooks)
                .Take(numBooks),

                PageInfo = new PageInfo
                {
                    TotalNumBooks = (bookCategory == null 
                                        ? repo.Books.Count() 
                                        : repo.Books.Where(x => x.Category == bookCategory).Count()),
                    BPerPage = numBooks,
                    CurrentPage = PageNum
                }
            };

            return View(x);
        }
    }
}
