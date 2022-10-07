using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryMVC.Controllers
{
    public class LibraryController : Controller
    {
        // GET: Library
       

        static List<Book> books = new List<Book>();


        static LibraryController()
        {
            books.Add(new Book { Book_No = 12, Book_Name = "Ponniyin Selvan", Author = "kalki", Cost = 1500, Category = "Tamizh" });
            books.Add(new Book { Book_No = 11, Book_Name = "Rich Dad Poor Dad", Author = "Robert Kiyosaki ", Cost = 1500, Category = "English" });
            books.Add(new Book { Book_No = 13, Book_Name = "Wings Of fire", Author = "DR.\tA P J Abdul Kalam", Cost = 1500, Category = "Autobiography" });
            books.Add(new Book { Book_No = 14, Book_Name = "War and Peace", Author = "Leo Tolstoy", Cost = 1500, Category = "English" });
            books.Add(new Book { Book_No = 15, Book_Name = "Tholkappiyam", Author = "Unknown", Cost = 1500, Category = "Tamizh" });

        }

        public ActionResult Index()
        {
             //books.Add(new Book { Book_No=12,Book_Name="Ponniyin Selvan",Author ="kalki", Cost=1500,Category="Tamizh"});
      //      books.Add(new Book { Book_No=11,Book_Name="Rich Dad Poor Dad",Author = "Robert Kiyosaki ", Cost=1500,Category="English"});
      //      books.Add(new Book { Book_No=13,Book_Name="Wings Of fire",Author = "DR.\tA P J Abdul Kalam", Cost=1500,Category= "Autobiography" });
      //      books.Add(new Book { Book_No=14,Book_Name= "War and Peace", Author = "Leo Tolstoy", Cost=1500,Category="English"});
      //      books.Add(new Book { Book_No=15,Book_Name= "Tholkappiyam", Author = "Unknown", Cost=1500,Category="Tamizh"});
      
            return View(books);
        }
        public ActionResult CreateBook()
        {
           // ViewBag.allBooks = books;
            return View();
        }

        [HttpPost]
        public ActionResult CreateBook(Book model)
        {
            books.Add(model);
            return RedirectToAction("Index");
        }
        public ActionResult ShowAllBooks()
        {
            //List<Book> bookList = books.ToList();
            ViewBag.allBooks = books;
            return View();
        }
    }
}