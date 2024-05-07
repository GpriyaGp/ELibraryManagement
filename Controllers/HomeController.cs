using ELibraryManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace ELibraryManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ApplicationDBContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDBContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index(LoginView login)
        {
            if(login.Name != null)
            {
                ViewBag.Name = login.Name;

                if (login.Password == "admin")
                {
                    return View();
                }

                return RedirectToAction("InvalidLogin");
            }
            return View();
        }

        public IActionResult InvalidLogin()
        {
            return View();
        }

        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddBook(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();

            // Redirect to a different action after successful submission
            return RedirectToAction("ViewBooks");

        }

        public IActionResult ViewBooks()
        {

            var books = _context.Books.ToList();
            return View(books);
        }
        public IActionResult Borrow(int ISDN)
        {
            // Find the book in the database with the given name
            var book = _context.Books.FirstOrDefault(b => b.ISDN == ISDN);

            if (book != null)
            {
                // Update the quantity of the book
                if (book.Quantity > 0)
                {
                    book.Quantity--;
                    _context.SaveChanges();
                    return RedirectToAction("ViewBooks");
                }
                else
                {
                    // Handle the case where the book is out of stock
                    TempData["Message"] = "Book is out of stock.";
                    return RedirectToAction("ViewBooks");
                }
            }
            else
            {
                // Handle the case where the book with the given name is not found
                TempData["Message"] = "Book not found.";
                return RedirectToAction("ViewBooks");
            }
        }

        public IActionResult Return(int ISDN)
        {
            // Find the book in the database with the given name
            var book = _context.Books.FirstOrDefault(b => b.ISDN == ISDN);

            if (book != null)
            {
                // Update the quantity of the book
                if (book.Quantity >= 0)
                {
                    book.Quantity++;
                    _context.SaveChanges();
                    return RedirectToAction("ViewBooks");
                }
                else
                {
                    // Handle the case where the book is out of stock
                    TempData["Message"] = "Book is out of stock.";
                    return RedirectToAction("ViewBooks");
                }
            }
            else
            {
                // Handle the case where the book with the given name is not found
                TempData["Message"] = "Book not found.";
                return RedirectToAction("ViewBooks");
            }
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
