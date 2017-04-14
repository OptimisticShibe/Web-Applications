using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BirthdayCard.Models;

namespace BirthdayCard.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Confirmation()
        {
            return View();
        }

        [HttpPost] //Ask about
        public ActionResult Index(BirthdayInfo BirthdayInfo)
        {
            if (ModelState.IsValid) // check on validation
            {
                return View("Confirmation", BirthdayInfo);
            }
            else // if false, stay on the same page
            {
                return View();
            }
        }
    }
}