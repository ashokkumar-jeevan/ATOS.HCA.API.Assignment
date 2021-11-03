using System;
using System.Collections.Generic;
using System.Text;

namespace HCA.Users.BO
{
    public class UsersBO
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
        public string Salt { get; set; }
        public string Token { get; set; }
        public bool IsValidUser { get; set; }
        public bool IsUserExist { get; set; }
        

    }
}
