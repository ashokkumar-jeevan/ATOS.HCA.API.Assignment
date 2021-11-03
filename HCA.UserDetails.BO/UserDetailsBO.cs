using System;
using System.Collections.Generic;
using System.Text;

namespace HCA.UserDetails.BO
{
    public class UserDetailsBO
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
        public string ContactNo { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfrimPassword { get; set; }
        public string SaltPassword { get; set; }
    }
}
