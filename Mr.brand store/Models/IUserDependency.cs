using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mr.brand_store.Models
{
    public interface IUserDependency
    {
        void adduser(user s);
        List<Cart> viewcart(int uid);
        user login(user u);
        bool checkValidEmail(String email);
        List<Product> indexpage();
    }
}
