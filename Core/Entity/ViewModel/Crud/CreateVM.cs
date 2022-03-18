using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Entity.ViewModel.Crud
{
   public class CreateVM
    {
        public string ImageLink { get; set; }
        [Required]
        public IFormFile Photo { get; set; }
    }
}
