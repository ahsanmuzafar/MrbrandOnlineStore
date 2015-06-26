using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mr.brand_store.Models;
namespace Mr.brand_store.Controllers
{
    public class CartController : Controller
    {
        //
        DBcontextclasses cx = new DBcontextclasses();
        // GET: /Cart/
        [HttpPost]
        public ActionResult AddtoCart(string uid,string pid)
        {
            int ui = -1;
            try
            {
                 ui = Int32.Parse(uid);
            }
            catch (Exception e) {
                return RedirectToAction("/Home/index");
            }

            int pi = Int32.Parse(pid);

            Cart c = new Cart();
            c.Uid = ui;
            c.Pid = pi;
            c.quantity = Request["quantity"];
           // c.Product = cx.Products.Find(pi);
           // c.user = cx.users.Find(ui);
            
            cx.Carts.Add(c);
            cx.SaveChanges();
            return Redirect("/Home/index");
        }
        public ActionResult checkout()
        {
            var x = cx.Carts.ToList();
            foreach (var y in x) {
                Order o = new Order();
                o.Pid = y.Pid;
                o.quantity =Int32.Parse( y.quantity);
                o.Uid = y.Uid;
                o.date = DateTime.Now;
                cx.Orders.Add(o);
                cx.Carts.Remove(y);
            }
            cx.SaveChanges();
           
            return Redirect("/Home/index");
        }

    }
}
