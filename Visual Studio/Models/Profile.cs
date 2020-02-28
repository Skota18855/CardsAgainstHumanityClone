using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        public int Id { get; set; }

        public static int count = 0;

        public Profile()
        {
            Id = count++;
        }

        [Required]
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }
        [MinLength(8), Required]//, RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*/d)(?=.*[^/da-zA-Z]).{8,15}$", ErrorMessage = "Password must have a number, a symbol, and be at least 8 characters long.")]
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        [EmailAddress(ErrorMessage ="Must be a valid email address")]
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
