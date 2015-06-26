using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mr.brand_store.Models
{
    public static class SessionCheck
    {
        public static bool checkSession(String s) {
            if (s == null)
                return false;
            else
                return true;
        }
    }
}