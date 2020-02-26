using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardsAgainstHumanityClone.Models
{
    public class Profile
    {
        string userName = "";
        string password = "";
        string email = "";
        byte[] profileImage = null;

        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public byte[] ProfileImage
        {
            get { return profileImage; }
            set { profileImage = value; }
        }
    }
}
