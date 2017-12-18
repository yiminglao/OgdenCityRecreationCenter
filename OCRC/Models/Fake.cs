using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OCRC.Models
{
    public class Fake
    {
    }


    public class Kid
    {
        public Kid(String f,String l, String s, String g, String sp)
        {
            fname = f;
            lname = l;
            school = s;
            grade = g;
            sport = sp;
            active = true;
            age = 16;
            rank = 5;
            year = 2017;
        }
        public String fname { get; set; }
        public String lname { get; set; }
        public String school { get; set; }
        public String grade { get; set; }
        public String sport { get; set; }

        public int age, rank, year;
        public bool active;
    }
}