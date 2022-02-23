using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Entity.ViewModel.AccountVM
{
   public class LoginVM
    {
        [Required]
        [MaxLength(255)]
        public string Email { get; set; }
        [Required]
        [MaxLength(255)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool RememberMe { get; set; }

    }
}
