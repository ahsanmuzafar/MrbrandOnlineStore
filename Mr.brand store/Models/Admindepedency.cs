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
    public class Admindepedency : IAmindepedency
    {

        public void AddnewProduct(Product p, HttpPostedFileBase file)
        {

            using (DBcontextclasses cx = new DBcontextclasses())
            {
                
                string filename = null;
                string[] str = file.FileName.Split('\\');

                filename = str[str.Length - 1];
                filename.Remove(0, 1);

                var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "Content\\images\\", (filename));

                p.path = "~/Content/images/" + filename;

                p.rating = 0;

                file.SaveAs(path);
                cx.Products.Add(p);

                try
                {
                    // Your code...
                    // Could also be before try if you know the exception occurs in SaveChanges

                    cx.SaveChanges();
                }
                catch (DbEntityValidationException e)
                {
                    foreach (var eve in e.EntityValidationErrors)
                    {
                        Debug.Print("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                            eve.Entry.Entity.GetType().Name, eve.Entry.State);
                        foreach (var ve in eve.ValidationErrors)
                        {
                            Debug.Print("- Property: \"{0}\", Error: \"{1}\"",
                                ve.PropertyName, ve.ErrorMessage);
                        }
                    }
                    throw;
                }
            }
        }
        public void updateProduct(Product p)
        {
            using (DBcontextclasses cx = new DBcontextclasses())
            {
                var x = cx.Products.Find(p.Id);
                x.name = p.name;
                x.type = p.type;
                x.price = p.price;
                try
                {
                    // Your code...
                    // Could also be before try if you know the exception occurs in SaveChanges

                    cx.SaveChanges();
                }
                catch (DbEntityValidationException e)
                {
                    foreach (var eve in e.EntityValidationErrors)
                    {
                        Debug.Print("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                            eve.Entry.Entity.GetType().Name, eve.Entry.State);
                        foreach (var ve in eve.ValidationErrors)
                        {
                            Debug.Print("- Property: \"{0}\", Error: \"{1}\"",
                                ve.PropertyName, ve.ErrorMessage);
                        }
                    }
                    throw;
                }

            }

        }
        public void DeleteProduct(int p) {
            using (DBcontextclasses cx=new DBcontextclasses()){

               var x = cx.Products.Find(p);

             cx.Products.Remove(x);

             try
             {
                 // Your code...
                 // Could also be before try if you know the exception occurs in SaveChanges

                 cx.SaveChanges();
             }
             catch (Exception e)
             {
                 
             }

            }
        }
            public Product Delete(int p) {
                using (DBcontextclasses cx = new DBcontextclasses())
                {

                    var x = cx.Products.Find(p);
                    return x;

                }
             
        }
                public Product Update(int p) {
            using (DBcontextclasses cx=new DBcontextclasses()){

               var x = cx.Products.Find(p);

               return x;
        }

         
        
        
        }

    }
}
