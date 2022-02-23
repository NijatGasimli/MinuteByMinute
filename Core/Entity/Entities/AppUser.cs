using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entity.Entities
{
    public class AppUser:IdentityUser
    {
        public string Fullname { get; set; }
        public ICollection<Cargos> Cargos { get; set; }
        public string FIN { get; set; }
        public string IdentityNumber { get; set; }
        public string IdentityType { get; set; }
        public string Location { get; set; }
        public DateTime BirthdayTime { get; set; }
        public int CustomerNumber { get; set; }


    }
}
