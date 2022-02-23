using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Entity.ViewModel
{
    public class CargoCreateVM
    
    {
        [Required]
        public string Link { get; set; }
        [Required]
        public int Count { get; set; }
        [Required]
        public int Size { get; set; }
        [Required]
        public string About { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public bool Isdeleted { get; set; }
        public string IdentityUserId { get; set; }
    }
}
