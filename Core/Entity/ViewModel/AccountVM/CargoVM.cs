using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Entity.ViewModel.AccountVM
{
    public class CargoVM
    {
        public string UserId { get; set; }
        [Required]
        public string Link { get; set; }
  
        public int Count { get; set; }
       
     [Required]
        public int Size { get; set; }
       
       [Required]
        public string About { get; set; }
    
      
        public double Price { get; set; }
    }
}
