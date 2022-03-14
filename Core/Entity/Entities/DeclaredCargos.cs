using Core.Entity.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Entity.AdminPanelEntityes
{
   public class DeclaredCargos
    {
        public int Id { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }
        public string ImageURL { get; set; }
        public string Price { get; set; }
        public string Count { get; set; }
        public Cargos Cargos{ get; set; }
        public int? CargosId { get; set; }

    }
}
