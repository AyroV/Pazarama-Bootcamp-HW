using BootcampHW.Data;
using BootcampHW.Entity;
using BootcampHW.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BootcampHW.Controllers
{
    public class BookController : Controller
    {
        private readonly BookContext _context;
        public BookController(BookContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult List(int? id, string query)
        {
            var books = _context.Books.AsQueryable();

            if (id != null)
            {
                books = books
                    .Include(book => book.Categories)
                    .Where(book => book.Categories.Any(category => category.CategoryId == id));
            }

            if (!string.IsNullOrEmpty(query))
            {
                books = books.Where(book =>
                    book.Title.ToLower().Contains(query.ToLower()) ||
                    book.Author.ToLower().Contains(query.ToLower()) ||
                    book.Description.ToLower().Contains(query.ToLower())
                );
            }

            var model = new BooksViewModel()
            {
                Books = books.ToList()
            };

            return View("Books", model);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            return View(_context.Books.Find(id));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {

            return View(_context.Books.Find(id));
        }

        [HttpPost]
        public IActionResult Edit(Book book)
        {
            _context.Books.Update(book);
            _context.SaveChanges();
            Console.WriteLine(book.BookId);
            return RedirectToAction("List");
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
            TempData["Message"] = $"{book.Title} isimli kitap eklendi";
            return RedirectToAction("List");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            ModelState.Remove("BookId");
            var book = _context.Books.Find(id);
            if(book == null)
            {
                Console.WriteLine("null");
                TempData["Message"] = $"Kitap bulunamadı";
                return RedirectToAction("List");
            }
            var title = book.Title;
            _context.Books.Remove(book);
            _context.SaveChanges();
            TempData["Message"] = $"{title} isimli kitap silindi";
            return RedirectToAction("List");
        }
    }
}
