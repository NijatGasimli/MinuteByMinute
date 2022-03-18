using Core.Entity.AdminPanelEntityes;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entity.Entities
{
    public class Cargos
    {
        public int Id { get; set; }
       
        public string Link { get; set; }
        public int Count{ get; set; }
        public int Size { get; set; }
        public string About { get; set; }
        public double Price { get; set; }
        public bool Isdeleted { get; set; }
        public string Status { get; set; }
        public DateTime Time { get; set; }
        public AppUser? AppUser { get; set; }
        public string? AppUserId { get; set; }
        public DeclaredCargos? Declared { get; set; }
        public bool IsInvoice { get; set; }
        public  string Achieve { get; set; }

    }
}
