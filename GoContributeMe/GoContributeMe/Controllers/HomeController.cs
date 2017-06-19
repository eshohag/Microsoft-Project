using GoContributeMe.BLL;
using GoContributeMe.Gateway;
using GoContributeMe.Models.ViewModel;
using System;
using System.Web.Mvc;

namespace GoContributeMe.Controllers
{

    public class HomeController : Controller
    {
        UserManager aUserManager = new UserManager();
        UserGateway aUserGateway = new UserGateway();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        [HttpPost]
        public ActionResult About(ContactUsUserViewModel aSubscriber)
        {
            ViewBag.Message = "Your application description page.";
            if (ModelState.IsValid)
            {
                int result = aUserManager.aSubscriber(aSubscriber.Subscriber.Email);
                //return RedirectToAction("Index", "Home");
                ModelState.Clear();                                        //Clear model such as ContactUs            
                return View("ThanksSubscriberMe");
            }
            return View();
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpPost]
        public ActionResult Contact(ContactUsUserViewModel aContactUs)
        {
            ViewBag.Message = "Your contact page.";
            if (ModelState.IsValid)
            {
                var dateAndTime = DateTime.Now.Date;
                aContactUs.ContactUs.Date = dateAndTime;
                int result = aUserManager.ContactInfoCustomer(aContactUs.ContactUs);
                ModelState.Clear();                 //Clear model such as ContactUs                                                            //return RedirectToAction("Index", "Home");
                return View("ThanksContactUs");
            }
            return View();
        }






    }
}