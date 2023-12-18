using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kuna.Model
{
    public class UserModel
    {
        private string name;
        private string password;

        public String Name { get => name; set => name = value; }
        public String Password { get => password; set => password = value; }
    }
}
