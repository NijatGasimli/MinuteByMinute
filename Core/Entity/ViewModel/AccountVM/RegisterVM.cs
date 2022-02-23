using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Entity.ViewModel.AccountVM
{
    public class RegisterVM
    {
        [Required]
        [StringLength(100)]
        public string FullName { get; set; }
        [Required]
        [StringLength(7)]
        public string FIN { get; set; }
       [Required]
       [StringLength(2)]
        public string IdentityType { get; set; }
        [Required]
        [StringLength(7)]
        public string IdentityNumber { get; set; }

        [EmailAddress]
        [Required]
        public string Email { get; set; }


        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
       
        public string PhoneNumber { get; set; }
        [Required]
        public DateTime BirthdayTime { get; set; }
    }
}
