using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace kuna.Models
{
    public class UserAccountModel
    {
        private string name;
        private string aboutMe;
        private string profilePicture;

        public string Name { get => name; set => name = value; }
        public string AboutMe { get => aboutMe; set => aboutMe = value; }
        public string ProfilePicture { get => profilePicture; set => profilePicture = value; }

  
    }
}
