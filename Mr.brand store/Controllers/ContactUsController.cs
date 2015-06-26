using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mr.brand_store.Controllers
{
    public class ContactUsController : Controller
    {
        //
        // GET: /ContactUs/
        [HttpPost]
        public ActionResult SendMail()
        {
            return RedirectToAction("index");
        }

    }
}
