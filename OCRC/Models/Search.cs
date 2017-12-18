using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OCRC.Models
{

    public class Search
    {
        public int id { get; set; }
        public String fname { get; set; }
        public String lname { get; set; }
        public int year { get; set; }
        public List<Ranking> rank { get; set; }
        public String school { get; set; }
        public int age { get; set; }
        public int grade { get; set; }
        public String sport { get; set; }

        /// <summary>
        /// returns a list of search model for kids who are active
        /// </summary>
        /// <returns></returns>
        public static List<Search> getSearchResultsForActive()
        {
            
            List<Search> searchResults = new List<Search>();
            List<Kid> kids = OCRC_API.getAllKids();
            List<Registration> reg = OCRC_API.getAllRegistrations();
            List<Ranking> allrankings = Repo.getAllRankings();
            

            foreach (var kid in kids)
            {
                Search s = new Search();
                s.rank = new List<Ranking>();
                Ranking r = new Ranking();
                

                Status status = Repo.findStatusById(kid.kidID);
                if (status == null)
                {
                    status = new Status();
                    status.kidIdentifier = kid.kidID.ToString();
                    status.active = "active";
                    status.activityModified = DateTime.Now;
                    Repo.addStatus(status);
                    s.id = kid.kidID;
                    s.fname = kid.fname;
                    s.lname = kid.lname;
                    s.age = kid.age;
                    s.grade = kid.grade;
                    s.school = kid.school;
                    
                    //s.sport = Repo.getRankingByStatusId(status.statusID).sportType;
                    
                }
                if (status.active.Equals("active"))
                {
                    s.id = kid.kidID;
                    s.age = kid.age;
                    s.grade = kid.grade;
                    s.fname = kid.fname;
                    s.lname = kid.lname;
                    s.school = kid.school;
                    s.year = OCRC_API.registrationYear(kid.kidID);

                    //s.sport = Repo.getRankingByStatusId(status.statusID).sportType;

                    foreach (var Ranking in allrankings)
                    {
                        if(status.statusID == Ranking.statusID)
                        {
                            s.rank.Add(Ranking);
                        }
                    }

                }

               
                searchResults.Add(s);

            }

            return searchResults;
        }




    }
}