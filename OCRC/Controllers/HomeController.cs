using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OCRC.Models;

namespace OCRC.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        

        //Nas
        public PartialViewResult _KidDetails()
        {
            Kid kid = new Kid();
            kid.fname = "some";
            kid.lname = "lsome";
            kid.grade = 3;
            kid.school = "MIT";

            return PartialView(kid);
        }

 

        public JsonResult filterSearch(String[] sport, int age,int grade,String year,String school,String name)
        {
            //check if Json requested or return null;

            List<Search> result = Repo.filterSearches(sport,age, grade,year,school,name);

            return new JsonResult { Data = new { result = result} };
        }


        public JsonResult getKidDataForModal(int kidId)
        {
            Search search = Search.getSearchResultsForActive().Where(s=>
                kidId == s.id).FirstOrDefault();
            

            return new JsonResult { Data = new { result = search } };
        }


        //Yi Lao (Ming)-------------------------
        public ActionResult Result(ResetPasswordModel model)
        {
            SearchViewModel svm = new SearchViewModel();
            svm.sports = OCRC_API.getAllSports();
            svm.searches = Search.getSearchResultsForActive();
            svm.allOfThem = Repo.getSeachesPerRank(svm.searches);

            return View(svm);

            //List<object> passData = new List<object>();
            //var allSports = OCRC_API.getAllSports();
            //var allKids = OCRC_API.getAllKids();
            //passData.Add(allSports);
            //passData.Add(allKids);
            //return View(passData);
        }
    }
}