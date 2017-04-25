using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HelloWorld.Models;
using System.Web.UI; //For Caching

namespace HelloWorld.Controllers
{
    [Logging]
    [AuthorizeIPAddress]
    public class HomeController : Controller
    {
        //public ActionResult Products()
        //{
        //    var products = new Product[]
        //    {
        //new Product{ ProductId = 1, Name = "First One", Price = 1.11m, Count = 2},
        //new Product{ ProductId = 2, Name="Second One", Price = 2.22m, Count = 1},
        //new Product{ ProductId = 3, Name="Third One", Price = 3.33m, Count = 0},
        //new Product{ ProductId = 4, Name="Fourth One", Price = 4.44m, Count = 5},
        //    };

        //    return View(products);
        //}

        //public ActionResult Product()
        //{
        //    var myProduct = new Product
        //    {
        //        ProductId = 1,
        //        Name = "Kayak",
        //        Description = "A boat for one person",
        //        Category = "water-sports",
        //        Price = 200m,
        //    };

        //    return View(myProduct);
        //}


        private IProductRepository productRepository;

        public HomeController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public ActionResult Product()
        {
            return View(productRepository.Products.First());
        }

        //Only want one cache at a time if possible -- other in ProductRepository
        //[OutputCache(Duration = 15, Location = OutputCacheLocation.Any, VaryByParam = "none")]
        public ActionResult Products()
        {
            return View(productRepository.Products);

        }

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet] //Ask about
        public ActionResult RsvpForm()
        {
            return View();
        }

        [HttpPost] //Ask about
        public ActionResult RsvpForm(Models.GuestResponse guestResponse)
        {
            if (ModelState.IsValid) // check on validation
            {
                return View("Thanks", guestResponse);
            }
            else // if false, stay on the same page
            {
                return View();
            }
        }

        public PartialViewResult IncrementCount()
        {
            int count = 0;

            // Check if MyCount exists
            if (Session["MyCount"] != null)
            {
                count = (int)Session["MyCount"];
                count++;
            }

            // Create the MyCount session variable
            Session["MyCount"] = count;

            return new PartialViewResult();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel logIn)
        {
            Session["UserName"] = logIn.UserName;
            return RedirectToAction("index"); //This is what I was missing. Both lines.
        }

        public ActionResult Logoff()
        {
            Session["UserName"] = null;
            return RedirectToAction("Index");
        }

        public PartialViewResult DisplayLoginName()
        {
            string User = null;
            if (Session["UserName"] != null)
            {
                User = (string)Session["UserName"];
            }
            return new PartialViewResult();
        }
    }
}