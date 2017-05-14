using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LearningWebsite.Business;
using LearningWebsite.Models;

namespace LearningWebsite.Controllers
{
    public class HomeController : Controller
    {
        private readonly IClassOfferingsManager classOfferingsManager;
        private readonly IUserManager userManager;
        private readonly IClassScheduleManager classScheduleManager;

        public HomeController(IClassOfferingsManager classOfferingsManager, IUserManager userManager,
            IClassScheduleManager classScheduleManager)
        {
            this.classOfferingsManager = classOfferingsManager;
            this.userManager = userManager;
            this.classScheduleManager = classScheduleManager;
        }

        // Unfinished--will be class register action result
        public ActionResult ClassRegister(int userId, int classId)
        {
            var user = userManager.GetUser(userId);
            var classToAdd = classOfferingsManager.ClassOffering(classId); // AKA "Get Class"

            

            //var user = (Models.UserModel)Session["User"];
            ////var item = shoppingCartManager.Add(user.Id, id, 1);
            //var classes = classOfferingsManager.ClassOffering(classId)
            //    .Select(t => new Models.ClassScheduleModel
            //    {
            //        Id = t.Id,
            //        Name = t.Name
            //    })
            //    .ToArray();
            //return View(classId);
        }

        public ActionResult ClassOfferingsPage()
        {
            var classOfferings = classOfferingsManager.Classes
                .Select(x => new LearningWebsite.Models.ClassOfferingsModel(x.Id, x.Name))
                .ToArray();
            var model = new ClassOfferingsPageModel { Classes = classOfferings };
            return View(model);
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(LoginModel loginModel, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var user = userManager.LogIn(loginModel.UserName, loginModel.Password);

                if (user == null)
                {
                    ModelState.AddModelError("", "User name and password do not match.");
                }
                else
                {
                    Session["User"] = new Models.UserModel { Id = user.Id, Name = user.Name };

                    System.Web.Security.FormsAuthentication.SetAuthCookie(loginModel.UserName, false);

                    return Redirect(returnUrl ?? "~/");
                }
            }

            return View(loginModel);
        }

        public ActionResult LogOff()
        {
            Session["User"] = null;
            System.Web.Security.FormsAuthentication.SignOut();

            return Redirect("~/");
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel registerViewModel, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var user = userManager.Register(registerViewModel.Email, registerViewModel.Password);

                if (user == null)
                {
                    ModelState.AddModelError("", "Please fill both fields");
                }
                else
                {
                    Session["User"] = new LearningWebsite.Models.UserModel { Id = user.Id, Name = user.Name };

                    System.Web.Security.FormsAuthentication.SetAuthCookie(registerViewModel.Email, false);

                    return Redirect(returnUrl ?? "~/");
                }
            }

            return View(registerViewModel);
        }
    }
}