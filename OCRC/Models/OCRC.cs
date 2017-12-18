using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using static OCRC.Models.Repo;
using static OCRC.Controllers.AccountController;

namespace OCRC.Models
{
    /// <summary>
    /// Contains all the CRUD methods for OCRC models
    /// </summary>
    public class OCRC
    {
        /// <summary>
        /// Returns the notes by it's id
        /// </summary>
        /// <param name="id">the id that's being searched on</param>
        /// <returns>The note being searched for</returns>
        public static Notes findNoteById(int? id)
        {
            using (OCRCDbContext db = new OCRCDbContext())
            {
                Notes note = db.Notes.Find(id);
                return note;
            }
        }

        /// <summary>
        /// Returns a list of all the notes
        /// </summary>
        /// <returns>list of notes</returns>
        public static List<Notes> getAllNotes()
        {
            using (OCRCDbContext db = new OCRCDbContext())
            {
                List<Notes> notes = db.Notes.ToList();
                return notes;
            }
        }

        public static ReturnResult AddUser(User user)
        {
            try
            {
                using(OCRCDbContext db = new OCRCDbContext())
                {
                    ReturnResult rr = new ReturnResult();
                    rr.data = db.Users.Add(user); //we could check this line to see if the command was successful
                    rr.returnCode = 0;
                    db.SaveChanges();
                    return rr;
                }
            }
            catch (Exception e)
            {
                return new ReturnResult(ReturnCode.FAILURE, e.Message);
            }
        }

        public static ReturnResult UpdateUser(User user)
        {
            try
            {
                using (OCRCDbContext db = new OCRCDbContext())
                {
                    ReturnResult rr = new ReturnResult();
                    db.Entry(user).State = EntityState.Modified;
                    rr.data = db.Entry(user); //we could check this line to see if the command was successful
                    rr.returnCode = 0;
                    db.SaveChanges();
                    return rr;
                }
            }
            catch (Exception e)
            {
                return new ReturnResult(ReturnCode.FAILURE, e.Message);
            }
        }

        public static void addStatus(Status status)
        {
            try
            {
                using(OCRCDbContext db = new OCRCDbContext())
                {
                    db.Statuses.Add(status);
                    db.SaveChanges();
                }
            }
            catch (Exception e)
            {

                throw;
            }
        }

        /// <summary>
        /// Adds a note to the database
        /// </summary>
        /// <param name="note">The note being added</param>
        public static void addNote(Notes note)
        {
            using (OCRCDbContext db = new OCRCDbContext())
            {
                db.Notes.Add(note);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Sets a notes date modified field
        /// </summary>
        /// <param name="dateModified">The date that it was modified</param>
        public static void setNotesDateModified(DateTime dateModified)
        {
            using (OCRCDbContext db = new OCRCDbContext())
            {
                db.Entry(dateModified.ToString()).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Sets a notes date created field
        /// </summary>
        /// <param name="dateCreated">The date that it was created</param>
        public static void setNotesDateCreated(DateTime dateCreated)
        {
            using (OCRCDbContext db = new OCRCDbContext())
            {
                db.Entry(dateCreated.ToString()).State = EntityState.Modified;
                db.SaveChanges();
            }
        }


        /// <summary>
        /// Returns the ranking by it's id
        /// </summary>
        /// <param name="id">the id that's being searched on</param>
        /// <returns>The ranking being searched for</returns>
        public static Ranking findRankingById(int? id)
        {
            using (OCRCDbContext db = new OCRCDbContext())
            {
                Ranking ranking = db.Rankings.Find(id);
                return ranking;
            }
        }

        /// <summary>
        /// Returns a list of all the rankings
        /// </summary>
        /// <returns>list of rankings</returns>
        public static List<Ranking> getAllRankings()
        {
            using (OCRCDbContext db = new OCRCDbContext())
            {
                List<Ranking> rankings = db.Rankings.ToList();
                return rankings;
            }
        }

        /// <summary>
        /// Adds a ranking to the database
        /// </summary>
        /// <param name="ranking">The ranking being added</param>
        public static void addRanking(Ranking ranking)
        {
            using (OCRCDbContext db = new OCRCDbContext())
            {
                db.Rankings.Add(ranking);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Sets the ranking date created field
        /// </summary>
        /// <param name="dateCreated">The date that it was created</param>
        public static void setRankingDateCreated(DateTime dateCreated)
        {
            using (OCRCDbContext db = new OCRCDbContext())
            {
                db.Entry(dateCreated.ToString()).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Sets the ranking sport type field
        /// </summary>
        /// <param name="sportType">The sport type</param>
        public static void setRankingSportType(string sportType)
        {
            using (OCRCDbContext db = new OCRCDbContext())
            {
                db.Entry(sportType).State = EntityState.Modified;
                db.SaveChanges();
            }
        }


        /// <summary>
        /// Returns the status by it's id
        /// </summary>
        /// <param name="id">the id that's being searched on</param>
        /// <returns>The status being searched for</returns>
        public static Status findStatusById(int? id)
        {
            using (OCRCDbContext db = new OCRCDbContext())
            {
                Status status = db.Statuses.Find(id);
                return status;
            }
        }

        /// <summary>
        /// Returns a list of all the statuses
        /// </summary>
        /// <returns>list of statuses</returns>
        public static List<Status> getAllStatuses()
        {
            using (OCRCDbContext db = new OCRCDbContext())
            {
                List<Status> statuses = db.Statuses.ToList();
                return statuses;
            }
        }

        /// <summary>
        /// Sets the status kidIdentifier field
        /// </summary>
        /// <param name="kidIdentifier">The kidIdentifier being set</param>
        public static void setStatusKidIdentifier(string kidIdentifier)
        {
            using (OCRCDbContext db = new OCRCDbContext())
            {
                db.Entry(kidIdentifier).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Sets the status active field
        /// </summary>
        /// <param name="active">The active being set</param>
        public static void setStatusActive(string active)
        {
            using (OCRCDbContext db = new OCRCDbContext())
            {
                db.Entry(active).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Sets the status activity modified field
        /// </summary>
        /// <param name="activityModified">The activity modified being set</param>
        public static void setStatusActivityModified(DateTime activityModified)
        {
            using (OCRCDbContext db = new OCRCDbContext())
            {
                db.Entry(activityModified.ToString()).State = EntityState.Modified;
                db.SaveChanges();
            }
        }


        /// <summary>
        /// Returns the user by it's id
        /// </summary>
        /// <param name="id">the id that's being searched on</param>
        /// <returns>The user being searched for</returns>
        public static User findUserById(int? id)
        {
            using (OCRCDbContext db = new OCRCDbContext())
            {
                User user = db.Users.Find(id);
                return user;
            }
        }

        public static User findUserByEmail(String userEmail)
        {
            try
            {
                using(OCRCDbContext db = new OCRCDbContext())
                {
                    var user = db.Users.Where(it => it.email == userEmail).FirstOrDefault();
                    return user;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static PasswordReset findTokenByEmail(String userEmail)
        {
            try
            {
                using (OCRCDbContext db = new OCRCDbContext())
                {
                    var token = db.PasswordResets.Where(it => it.email == userEmail).FirstOrDefault();
                    return token;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Returns a list of all the users
        /// </summary>
        /// <returns>list of users</returns>
        public static List<User> getAllUsers()
        {
            using (OCRCDbContext db = new OCRCDbContext())
            {
                List<User> users = db.Users.ToList();
                return users;
            }
        }

        /// <summary>
        /// Sets the user first name
        /// </summary>
        /// <param name="fname">The first name being set</param>
        public static void setUserFName(string fname)
        {
            using (OCRCDbContext db = new OCRCDbContext())
            {
                db.Entry(fname).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Sets the user last name
        /// </summary>
        /// <param name="lname">The last name being set</param>
        public static void setUserLName(string lname)
        {
            using (OCRCDbContext db = new OCRCDbContext())
            {
                db.Entry(lname).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Sets the user email
        /// </summary>
        /// <param name="email">The email being set</param>
        public static void setUserEmail(string email)
        {
            using (OCRCDbContext db = new OCRCDbContext())
            {
                db.Entry(email).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Sets the user password
        /// </summary>
        /// <param name="password">The password being set</param>
        public static void setUserPassword(string password)
        {
            using (OCRCDbContext db = new OCRCDbContext())
            {
                db.Entry(password).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Sets the user access level
        /// </summary>
        /// <param name="accesslvl">The accesslvl being set</param>
        public static void setUserAccesslvl(string accesslvl)
        {
            using (OCRCDbContext db = new OCRCDbContext())
            {
                db.Entry(accesslvl).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public static void setToken(string token)
        {
            using (OCRCDbContext db = new OCRCDbContext())
            {
                db.Entry(token).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Sets the user team identifier
        /// </summary>
        /// <param name="teamIdentifier">The teamIdentifier being set</param>
        public static void setUserTeamIdentifier(string teamIdentifier)
        {
            using (OCRCDbContext db = new OCRCDbContext())
            {
                db.Entry(teamIdentifier).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
    }


    /// <summary>
    /// Classes for the corresponding tables in the OCRC Database
    /// </summary>
    [Table("Notes")]
    public class Notes
    {
        [Key]
        public int notesID { get; set; }
        [DisplayName("Created Date"), DataType(DataType.DateTime)]
        public DateTime dateCreated { get; set; }
        [DisplayName("Modified Date"), DataType(DataType.DateTime)]
        public DateTime dateModified { get; set; }
        public int statusID { get; set; }
        public int userID { get; set; }
        [DisplayName("Notes")]
        public String notes { get; set; }

    }

    [Table("Ranking")]
    public class Ranking
    {
        [Key]
        public int rankingID { get; set; }
        public int statusID { get; set; }
        public int userID { get; set; }
        [DisplayName("Date Created"),DataType(DataType.DateTime)]
        public DateTime dateCreated { get; set; }
        [DisplayName("Rank")]
        public int rank { get; set; }
        [DisplayName("Sport")]
        public String sportType { get; set; }

    }

    /// <summary>
    /// TODO: better comment
    /// </summary>
    [Table("School")]
    public class School
    {
        [Key]
        public int schoolID { get; set; }
        [DisplayName("School Name")]
        public String schoolName { get; set; }
        [DisplayName("School Coach")]
        public String schoolCoach { get; set; }
    }
    
    /// <summary>
    /// TODO: better comment
    /// </summary>

    [Table("Status")]
    public class Status
    {
        [Key]
        public int statusID { get; set; }
        [DisplayName("Kid")]
        public String kidIdentifier { get; set; }
        [DisplayName("Kid Status")]
        public String active { get; set; }
        [DisplayName("Modified Date")]
        public DateTime activityModified { get; set; }
    }

    [Table("User")]
    public class User
    {
        [Key]
        public int userID { get; set; }
        [DisplayName("First Name")]
        public String fname { get; set; }
        [DisplayName("Last Name")]
        public String lname { get; set; }
        [DisplayName("Email"), EmailAddress, Required]
        public String email { get; set; }
        [DisplayName("Password"), PasswordPropertyText, Required]
        public String password { get; set; }
        public int accesslvl { get; set; }

        public String teamIdentifier { get; set; }
        public String schoolIdentifier { get; set; }
        [NotMapped]
        public bool[] role { get; set; } //used on the view for checkboxes
    }

    [Table("PasswordReset")]
    public class PasswordReset
    {
        [Key]
        public int passwordresetID { get; set; }
        [DisplayName("Token")]
        public String token { get; set; }
        [DisplayName("Email")]
        public String email { get; set; }
    }

    /// <summary>
    /// DataSets connecting to database tables
    /// </summary>
    public class OCRCDbContext : DbContext
    {
       public DbSet<Notes> Notes { get; set; }
       public DbSet<Ranking> Rankings { get; set; }
       public DbSet<Registration> Registrations { get; set; }
       public DbSet<School> Schools { get; set; }
       public DbSet<Sport> Sports { get; set; }
       public DbSet<Status> Statuses { get; set; }
       public DbSet<User> Users { get; set; }
        public DbSet<PasswordReset> PasswordResets { get; set; }
    }

}