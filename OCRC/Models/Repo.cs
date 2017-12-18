using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OCRC.Models
{
    public class Repo
    {
        // Tim
        public static ReturnResult UpdateUser(User user)
        {
            try
            {
                ReturnResult rr = new ReturnResult();

                if (user.password != null) {
                    user.password = SHA1.Encode(user.password);
                } else {
                    User thisUser = Repo.findUserById(user.userID);
                    user.password = thisUser.password;
                }


                rr.data = OCRC.UpdateUser(user);
                rr.returnCode = 0;
                return rr;
            }
            catch (Exception e)
            {
                return new ReturnResult(ReturnCode.FAILURE, e.Message);
            }
        }

        // Nas


        // yi


        // Heather
        public static Notes findNoteById(int? id)
        {
            return OCRC.findNoteById(id);
        }

        public static List<Notes> getAllNotes()
        {
            List<Notes> notes = OCRC.getAllNotes();
            return notes;
        }

        public static void addNote(Notes note)
        {
            OCRC.addNote(note);
        }

        public static ReturnResult UserExists(User user)
        {
            try
            {//TODO:create the actual ifExists method
                return new ReturnResult(0, false);
            }
            catch (Exception e)
            {
                return new ReturnResult(ReturnCode.FAILURE, e.Message);
            }
        }

        public static ReturnResult AddUser(User user)
        {
            try
            {
                ReturnResult rr = new ReturnResult();
                user.password = SHA1.Encode(user.password);

                rr.data = OCRC.AddUser(user);
                rr.returnCode = 0;
                return rr;
            }
            catch (Exception e)
            {
                return new ReturnResult(ReturnCode.FAILURE, e.Message);
            }
        }

        public static Ranking getRankingByStatusId(int statusID)
        {
            try
            {
                Ranking ranking = OCRC.getAllRankings().Where(item => item.statusID == statusID).FirstOrDefault();
                return ranking;
            }
            catch (Exception e)
            {

                throw;
            }
        }

        //by age, grade and sports
        public static List<Search> filterSearches(String[] sport,int age, int grade,String year,String school,String name)
        {
            try
            {

                List<Search> l1 = Search.getSearchResultsForActive();
                List<Search> result = getSeachesPerRank(l1);

                //filtering
                if (age!=0)
                    result = result.Where(search => search.age == age).ToList();
                if (grade != 0)
                    result = result.Where(search => search.grade == grade).ToList();
                if (sport != null)
                    result = result.Where(search => sport.Contains(search.sport)).ToList();
                if(year != "")
                    result = result.Where(search => search.year.ToString() == year).ToList();
                if(school != "")
                    result = result.Where(search => search.school.ToLower().Contains(school.ToLower())).ToList();
                if (name != "") 
                    result = result.Where( search =>
                    (search.fname+" "+search.lname).ToLower()
                    .Contains(name.ToLower()))
                    .ToList();


                return result;

            }
            catch (Exception e)
            {

                throw;
            }
        }

        public static List<Search> getSeachesPerRank(List<Search> searches)
        {
            try
            {
                List<Search> result = new List<Search>();
                foreach (var aSearch in searches)
                {
                    int z = 0;
                    foreach (var x in aSearch.rank)
                    {
                        Search s = new Search();
                        s.fname = aSearch.fname;
                        s.lname = aSearch.lname;
                        s.age = aSearch.age;
                        s.grade = aSearch.grade;
                        s.school = aSearch.school;
                        s.rank = new List<Ranking>();
                        s.rank.Add(aSearch.rank[z]);
                        s.year = aSearch.year;
                        s.sport = aSearch.sport;
                        s.id = aSearch.id;
                        z++;
                        result.Add(s);
                    }
                }

                return result;

            }
            catch (Exception e)
            {

                throw;
            }
        }

        public static void addStatus(Status status)
        {
            try
            {
                OCRC.addStatus(status);
            }
            catch (Exception e)
            {

                return;
            }
        }

        public static void setNotesDateModified(DateTime dateModified)
        {
            OCRC.setNotesDateModified(dateModified);
        }

        public static void setNotesDateCreated(DateTime dateCreated)
        {
            OCRC.setNotesDateCreated(dateCreated);
        }

        public static Ranking findRankingById(int? id)
        {
            return OCRC.findRankingById(id);
        }

        public static List<Ranking> getAllRankings()
        {
            return OCRC.getAllRankings();
        }

        public static void addRanking(Ranking ranking)
        {
            OCRC.addRanking(ranking);
        }

        public static void setRankingDateCreated(DateTime dateCreated)
        {
            OCRC.setRankingDateCreated(dateCreated);
        }

        public static void setRankingSportType(string sportType)
        {
            OCRC.setRankingSportType(sportType);
        }

        public static Status findStatusById(int? id)
        {
            return OCRC.findStatusById(id);
        }

        public static List<Status> getAllStatuses()
        {
            return OCRC.getAllStatuses();
        }

        public static void setStatusKidIdentifier(string kidIdentifier)
        {
            OCRC.setStatusKidIdentifier(kidIdentifier);
        }

        public static void setStatusActive(string active)
        {
            OCRC.setStatusActive(active);
        }

        public static void setStatusActivityModified(DateTime activityModified)
        {
            OCRC.setStatusActivityModified(activityModified);
        }

        public static User findUserById(int? id)
        {
            User user = OCRC.findUserById(id);
            user.role = new bool[4];
            if(user.accesslvl == 1)
            {
                user.role[0] = true;
            }
            if(user.accesslvl == 2)
            {
                user.role[1] = true;
            }
            if(user.teamIdentifier != null)
            {
                user.role[2] = true;
            }
            if (user.schoolIdentifier != null)
            {
                user.role[3] = true;
            }

            return user;
        }

        public static List<User> getAllUsers()
        {
            return OCRC.getAllUsers();
        }

        public static void setUserFName(string fname)
        {
            OCRC.setUserFName(fname);
        }

        public static void setUserLName(string lname)
        {
            OCRC.setUserLName(lname);
        }

        public static void setUserEmail(string email)
        {
            OCRC.setUserEmail(email);
        }

        public static void setUserPassword(string password)
        {
            OCRC.setUserPassword(password);
        }

        public static void setUserAccesslvl(string accesslvl)
        {
            OCRC.setUserAccesslvl(accesslvl);
        }

        public static void setToken(string token)
        {
            OCRC.setToken(token);
        }

        public static void setUserTeamIdentifier(string teamIdentifier)
        {
            OCRC.setUserTeamIdentifier(teamIdentifier);
        }

        public static User findUserByEmail(String userEmail)
        {
            try
            {
                var user = OCRC.findUserByEmail(userEmail);
                return user;
            }
            catch (Exception e)
            {

                throw;
            }
        }


        public static PasswordReset findTokenByEmail(String userEmail)
        {
            try
            {
                var token = OCRC.findTokenByEmail(userEmail);
                return token;
            }
            catch (Exception e)
            {

                throw;
            }
        }
        // Eric


        // Mohammed


        // Hoang


        //Nelson


    }
}