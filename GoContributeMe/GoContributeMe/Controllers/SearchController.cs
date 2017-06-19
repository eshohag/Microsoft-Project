using GoContributeMe.BLL;
using GoContributeMe.Models.ViewModel;
using System.Collections.Generic;
using System.Web.Mvc;

namespace GoContributeMe.Controllers
{
    public class SearchController : Controller
    {
        UserManager aUserManager = new UserManager();
        // GET: Search
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Index(ContactUsUserViewModel searchKey)
        {
            List<ViewAllDataInfo> campaign = aUserManager.SearchKey(searchKey.Campaign.Tittle);
            ViewBag.Campaign = campaign;
            return View();
        }
    }
}