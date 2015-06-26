using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mr.brand_store.Models;
namespace Mr.brand_store.Controllers
{
    public class CategoryController : Controller
    {
        //
        // GET: /Category/
        
        DBcontextclasses cx = new DBcontextclasses();
        
        public ActionResult Jeans()
        {
 
              var y=cx.Products.Where(s => s.type == "Jeans");
              var z=y.ToList();
            return View(z);

        }
        public ActionResult PoductDescription(int pid) {
            
            return View(cx.Products.Find(pid));
        
        }
        public ActionResult Baby()
        {

            var y = cx.Products.Where(s => s.type == "Baby");
            var z = y.ToList();
            return View(z);

        }
        public ActionResult tshirt()
        {

            var y = cx.Products.Where(s => s.type == "TShirt");
            var z = y.ToList();
            return View(z);

        }
        public ActionResult Dressshirt()
        {

            var y = cx.Products.Where(s => s.type == "Dress Shirt");
            var z = y.ToList();
            return View(z);

        }
        public ActionResult DressPant()
        {

            var y = cx.Products.Where(s => s.type == "Dress Pant");
            var z = y.ToList();
            return View(z);

        }

        public ActionResult Productdescription(int id) {
            var x = cx.Products.Find(id);
            return View(x);
        }
        

    }
}
