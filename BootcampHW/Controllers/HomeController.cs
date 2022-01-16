using BootcampHW.Data;
using BootcampHW.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BootcampHW.Controllers
{
    public class HomeController : Controller
    {
        private readonly BookContext _context;

        public HomeController(BookContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var model = new HomePageViewModel()
            {
                PopularBooks = _context.Books.ToList()
            };
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
