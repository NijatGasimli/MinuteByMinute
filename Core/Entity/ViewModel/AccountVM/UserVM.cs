using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entity.ViewModel.AccountVM
{
   public class UserVM
    {
        public string Fullname { get; set; }
       
        public string FIN { get; set; }
        public string IdentityNumber { get; set; }
        public string IdentityType { get; set; }
        public string Location { get; set; }
        public DateTime BirthdayTime { get; set; }
        public string CustomerNumber { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }


    }
}
