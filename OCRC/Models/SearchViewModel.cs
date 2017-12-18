using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OCRC.Models
{
    public class SearchViewModel
    {
        
        public List<Search> searches { get; set; }
        public List<Sport> sports { get; set; }      
        public List<Search> allOfThem { get; set; }
        
        public List<Sport> getAllSports()
        {
            return null;
        }
        public List<Search> getAllSearchResults()
        {
            return null;
        }
    }
}