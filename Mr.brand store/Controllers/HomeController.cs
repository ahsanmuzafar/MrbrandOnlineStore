using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mr.brand_store.Models;
namespace Mr.brand_store.Controllers
{
    public class HomeController : Controller
    {
        
        // GET: /Home/
        IUserDependency deu;
        public HomeController(IUserDependency us) {
            deu = us;
        }
        DBcontextclasses cy = new DBcontextclasses();
        public ActionResult Index()
        {
            
            return View(deu.indexpage());
        }
        public ActionResult About()
        {
            return View();
        }
        public ActionResult Contact_us()
        {
            return View();
        }
        public ActionResult AdminPage()
        {
            if (checkSession())
            {

                return View();
            }
            else {
                return RedirectToAction("index");
            }
        }
        public ActionResult signin()
        {

            return View();
        }
        public ActionResult logout() {
            Session["name"] =null;
            Session["Id"] = null;
           return RedirectToAction("index");
        
        }

        [HttpPost]
        public ActionResult login(user u)
        {

            ValidateModel(u);
            
                if (u.email == null && u.passwd == null)
                {
                    return RedirectToAction("Error");
                }
                var x = deu.login(u);
                if (x == null)
                {
                    return RedirectToAction("Error");
                }
                else
                {
                    if (x.type.ToString().Contains("Customer"))
                    {
                        Session["name"] = x.name;
                        Session["Id"] = x.Id.ToString();
                        return RedirectToAction("index");
                    }
                    else if (x.type.ToString().Contains("Admin"))
                    {
                        Session["Admin"] = x.type;
                        Session["name"] = x.name;
                        Session["Id"] = x.Id.ToString();
                        return RedirectToAction("AdminPage");

                    }
                    else
                    {
                        return RedirectToAction("index");
                    }
                
            }
        }
        public ActionResult Register() {
            return View();

        }
        [HttpPost]
        public ActionResult RegisterUser(user s)
        {
            
            deu.adduser(s);
            return RedirectToAction("index");
        }
        public ActionResult ViewCart(string uid) {
            int id = Int32.Parse(uid);
            if (id > 0)
            {
                return View(deu.viewcart(id));
            }
            else {
                return   RedirectToAction("index");
            }
        }
       
        public JsonResult validEmail(string email) {

          bool flag= deu.checkValidEmail(email);

          return this.Json(flag,JsonRequestBehavior.AllowGet); 

        }
        public bool checkSession(){
            if (Session["name"] == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        
    }
    
    
    
}
