using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Web;
using System.Web.Mvc;
using Mr.brand_store.Models;
using System.Data.Entity.Validation;
using System.Diagnostics;
namespace Mr.brand_store.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/

        IAmindepedency dep;
        
        public AdminController(IAmindepedency addproduct)
        {
            dep = addproduct;
            
        }

        DBcontextclasses cx = new DBcontextclasses();
        public ActionResult AddNewProduct()
        {

            return View();

        }
        [HttpPost]
        public ActionResult AddNewProduct(Product p)
        {
            if (SessionCheck.checkSession(Session["name"] as string))
            {

                HttpPostedFileBase file = Request.Files[0] as HttpPostedFileBase;
                dep.AddnewProduct(p, file);
                return RedirectToAction("AddNewProduct");

            }
            else {
                return Redirect("Home/index");

            }
           
            
        }

        public ActionResult UpdateProducts()
        {
            return View(cx.Products.ToList());
        }

        public ActionResult Update(int id)
        {

            return View(dep.Update(id));
        }

        [HttpPost]
        public ActionResult UpdateConfrim(Product p)
        {
            dep.updateProduct(p);
            return RedirectToAction("updateProducts");
        }
        public ActionResult Delete(int id)
        {
            cx.Database.Connection.Close();
            return View(dep.Delete(id));
        }
        [HttpPost]
        public ActionResult DeleteConf(int id)
        {
            cx.Database.Connection.Close();
            dep.DeleteProduct(id);
            return RedirectToAction("updateProducts");

        }
    }
}
