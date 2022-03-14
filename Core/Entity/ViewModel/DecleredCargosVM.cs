using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entity.ViewModel
{
   public class DecleredCargosVM
    {

        public IFormFile Photo { get; set; }
        public string ImageURL { get; set; }
        public string Price { get; set; }
        public string Count { get; set; }

    }
}
