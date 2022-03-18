using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Entity.Entities
{
   public class Slider
    {
        public int Id { get; set; }
        public string ImageLink { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }
    }
}
