using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mr.brand_store.Models
{
    public class Productadd
    {
        public string name { get; set; }
        public string path { get; set; }
        public string type { get; set; }
        public double price { get; set; }
        public int rating { get; set; }
        
       public HttpPostedFileBase file{get;set;}
    }
}