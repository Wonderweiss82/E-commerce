using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Model
{
    public static class UserSession
    {
        public static int UserId { get; set; }
        public static string UserName { get; set; }

        public static bool IsAdmin { get; set; }

    }

}
