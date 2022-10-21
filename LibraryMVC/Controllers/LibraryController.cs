using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.Mvc;

namespace LibraryMVC.Controllers
{
    public class LibraryController : Controller
    {
        // GET: Library
       

         List<Book> books = new List<Book>();
        LibraryEntities context = null;

        public LibraryController()
        {
            //books.Add(new Book { Book_No = 12, Book_Name = "Ponniyin Selvan", Author = "kalki", Cost = 1500, Category = "Tamizh" });
            //books.Add(new Book { Book_No = 11, Book_Name = "Rich Dad Poor Dad", Author = "Robert Kiyosaki ", Cost = 1500, Category = "English" });
            //books.Add(new Book { Book_No = 13, Book_Name = "Wings Of fire", Author = "DR.\tA P J Abdul Kalam", Cost = 1500, Category = "Autobiography" });
            //books.Add(new Book { Book_No = 14, Book_Name = "War and Peace", Author = "Leo Tolstoy", Cost = 1500, Category = "English" });
            //books.Add(new Book { Book_No = 15, Book_Name = "Tholkappiyam", Author = "Unknown", Cost = 1500, Category = "Tamizh" });
            context = new LibraryEntities();
            //var ans = context.GetAllBook();
            //foreach (var item in ans)
            //{
            //    books.Add(new Book { Book_No = item.Book_No, Book_Name = item.Book_Name, Author = item.Author, Cost = item.Cost, Category = item.Category  });
            //}
        }

        public ActionResult Index()
        {
            // Console.WriteLine("hello from shyam);

            //books.Add(new Book { Book_No=12,Book_Name="Ponniyin Selvan",Author ="kalki", Cost=1500,Category="Tamizh"});
            //      books.Add(new Book { Book_No=11,Book_Name="Rich Dad Poor Dad",Author = "Robert Kiyosaki ", Cost=1500,Category="English"});
            //      books.Add(new Book { Book_No=13,Book_Name="Wings Of fire",Author = "DR.\tA P J Abdul Kalam", Cost=1500,Category= "Autobiography" });
            //      books.Add(new Book { Book_No=14,Book_Name= "War and Peace", Author = "Leo Tolstoy", Cost=1500,Category="English"});
            //      books.Add(new Book { Book_No=15,Book_Name= "Tholkappiyam", Author = "Unknown", Cost=1500,Category="Tamizh"});
            books = context.Books.ToList();
            return View(books);
        }
        public ActionResult CreateBook()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateBook(FormCollection collection)   
        {
            Book book = new Book();
            book.Book_No = Int32.Parse( Request["Book_No"]);
            book.Book_Name = Request["Book_Name"];
            book.Author = Request["Author"];
            book.Cost = decimal.Parse( Request["Cost"]);
            book.Category = Request["Category"];
           // book.Availability = Int32.Parse(Request["Availabity"]);
           // books.Add(book);
           context.Books.Add(book); 
            context.SaveChanges();  
           // ViewBag.allBooks = books;
            return RedirectToAction("Index");
        }

        //[HttpPost]
        //public ActionResult CreateBook(Book model)
        //{
        //    books.Add(model);
        //    return RedirectToAction("Index");
        //}
        public ActionResult ShowAllBooks()
        {
            ViewBag.allBooks = books;
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(FormCollection collection)
        {
          //  LoginDetail l = new LoginDetail();
            string uid = Request["UserId"];   
            string pwd = Request["Password"];
            
            var ans = context.LoginDetails.ToList().Find(temp => temp.UserId == uid);
            if(ans.UserId == uid && ans.Password == pwd)
            {
                
                return RedirectToAction("Index");

            }
            else
            {
                

                ViewBag.msg = "User Not Found";
                return View();
            }
          
        }
    }
}