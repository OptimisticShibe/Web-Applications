using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BirthdayCard2.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult CardInput()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult CardInput(Models.CardData cardData)
        {
            if (ModelState.IsValid)
            {
                return View("Confirmation", cardData);
            }
            else
            {
                return View();
            }
        }

        public ActionResult Confirmation()
        {
            return View();
        }
    }
}