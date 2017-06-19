using GoContributeMe.Gateway;
using GoContributeMe.Models;
using GoContributeMe.Models.Model;
using System.Web.Mvc;

namespace GoContributeMe.Controllers
{
    [Authorize]
    public class ContributeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        UserGateway aUserGateway = new UserGateway();
        // GET: Contribute     
        public ActionResult StartFundRising()
        {
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "Name");
            ViewBag.ContributionID = new SelectList(db.Contributions, "ContributionID", "Name");
            //if (TempData["aCampaign"]!=null)
            //{
            //    ViewBag.tempData = TempData["aCampaign"];
            //}
            return View();
        }
        [HttpPost]
        public ActionResult StartFundRising(Campaign aCampaign)
        {
            TempData.Clear();
            TempData["aCampaign"] = aCampaign;
            return RedirectToAction("FundRecipient");
        }

        public ActionResult FundRecipient()
        {
            return View();
        }
        [HttpPost]
        public ActionResult FundRecipient(Campaign aCampaigna)
        {
            Campaign aCampaignCreate = (Campaign)TempData["aCampaign"];
            if (!ModelState.IsValid)
            {
                Campaign campaign = new Campaign();
                campaign.Tittle = aCampaignCreate.Tittle;
                campaign.CategoryID = aCampaignCreate.CategoryID;
                campaign.Descriptions = aCampaignCreate.Descriptions;
                campaign.RecipientName = aCampaigna.RecipientName;
                campaign.RecipientNID = aCampaigna.RecipientNID;
                campaign.Email = aCampaigna.Email;
                campaign.MobileNo = aCampaigna.MobileNo;
                campaign.TargetAmount = aCampaigna.TargetAmount;
                campaign.CampaignClosingDate = aCampaigna.CampaignClosingDate;
                campaign.TermsConditions = aCampaigna.TermsConditions;

                db.Campaigns.Add(campaign);
                db.SaveChanges();
                ModelState.Clear();
                return RedirectToAction("ThanksToStartHere");
            }

            return HttpNotFound();
        }
        [AllowAnonymous]
        public ActionResult FundSomeOne()
        {
            //ViewBag.All = db.Campaigns.ToList();
            ViewBag.All = aUserGateway.GetAllCampaign();
            return View();
        }



        public ActionResult ThanksToStartHere()
        {
            return View();
        }



        [AllowAnonymous]
        public ActionResult Details()
        {
            return View();
        }
    }
}