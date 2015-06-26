using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mr.brand_store.Models;

namespace Mr.brand_store.Models
{
    public class Userdependency : IUserDependency
    {
        DBcontextclasses cx = new DBcontextclasses();
        public List<Product> indexpage() {
            var x = cx.Products.Take(5).ToList();
            
            return x;
        
        }
        public void adduser(user s)
        {
            using (DBcontextclasses cx = new DBcontextclasses())
            {

                s.type = "Customer";
                cx.users.Add(s);
                cx.SaveChanges();

            }
        }
        public List<Cart> viewcart(int uid) { 
        
            
                return cx.Carts.ToList();
    
           
        
        }
        public user login(user u)
        {
            using (DBcontextclasses cx = new DBcontextclasses())
            {
                string em = u.email;
                cx.Database.Connection.Open();
                var usr = cx.users.First(x=>x.email==u.email );//
                if (usr == null)
                {
                    return null;
                }
                else
                {
                    if (usr.passwd != u.passwd)
                    {
                        return null;
                    }
                    return usr;
                }
            }

        }
        public bool checkValidEmail(String email){
            using (DBcontextclasses cx = new DBcontextclasses())
            {
                bool flag = false;
                var z = cx.users.Where(x => x.email == email);
                if (z != null)
                {
                    flag = false;
                }
                else
                {
                    flag = true;
                }


                return flag;
            }


        }   
}
}