using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BootcampHW.Data;
using Microsoft.AspNetCore.Mvc;

namespace BootcampHW.ViewComponents
{
    public class CategoriesViewComponent : ViewComponent
    {
        private readonly BookContext _context;
        public CategoriesViewComponent(BookContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData.Values["id"];
            return View(_context.Categories.ToList());
        }
    }
}
