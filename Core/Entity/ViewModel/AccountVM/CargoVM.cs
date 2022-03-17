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
        [MaxLength(255)]
        [DataType(DataType.Url)]
        public string Link { get; set; }
        [Required]
        [MaxLength(20)]
        public int Count { get; set; }
        [Required]
        [MaxLength(20)]
        public int Size { get; set; }
        [Required]
        [MaxLength(255)]
        [DataType(DataType.Text)]
        public string About { get; set; }
        [Required]
        [MaxLength(50)]
      
        public double Price { get; set; }
    }
}
