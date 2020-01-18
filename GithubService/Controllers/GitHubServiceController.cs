using GithubService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GithubService.Utils;

namespace GithubService.Controllers
{
    public class GitHubServiceController : Controller
    {
        // GET: GitHubService
        [HttpGet]
        public ActionResult Index()
        {
            return Json(new { Request = "GET" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetStoredGithub()
        {
            List<GithubCardModel> cardsList = null;
            if (Session["GihubCards"] == null)
            {
                cardsList = new List<GithubCardModel>();
            }
            else
            {
                cardsList = (List<GithubCardModel>)Session["GihubCards"];
            }
            ////reutrn custom json result to lowercase
            return new JsonNetResult(cardsList);
        }


        [HttpPost]
        [ActionName("SotreData")]
        public ActionResult SotreData(GithubCardModel card, string actionName)
        {
            if (card != null && card.Id > 0 && !string.IsNullOrEmpty(actionName))
                _AddRemoveItems(card, actionName);
            return Json("ok", JsonRequestBehavior.AllowGet);
        }

        private void _AddRemoveItems(GithubCardModel card, string actionName)
        {
            List<GithubCardModel> cardsList = null;
            if (Session["GihubCards"] == null)
            {
                cardsList = new List<GithubCardModel>();
            }
            else
            {
                cardsList = (List<GithubCardModel>)Session["GihubCards"];
            }

            switch (actionName.ToLower())
            {
                case "add":
                    cardsList.Add(card);
                    break;

                case "delete":
                    GithubCardModel item = cardsList.FirstOrDefault(x => x.Id == card.Id);
                    cardsList.Remove(item);
                    break;

                default:
                    break;
            }
            Session["GihubCards"] = cardsList;
            //return cardsList;
        }



    }
}