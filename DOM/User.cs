using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOM
{
    class User
    {
        private string username { get; set; }
        private string email { get; set; }
        private string password { get; set; }
        private int rol { get; set; }


        public User(string username, string email, string password, int rol) 
        {
            this.username = username;
            this.email = email;
            this.password = password;
            this.rol = rol;
        }
    }
}
