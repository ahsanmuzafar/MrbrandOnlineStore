using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Web;
using System.Web.Mvc;
using Mr.brand_store.Models;
using System.Data.Entity.Validation;
using System.Diagnostics;

namespace Mr.brand_store.Models
{
   public   interface IAmindepedency
    {
         void AddnewProduct(Product p, HttpPostedFileBase file);
         void updateProduct(Product p);
         void DeleteProduct(int id);
         Product Delete(int p);
         Product Update(int p);
    }
}
