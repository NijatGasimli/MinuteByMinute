using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entity.AdminPanelEntityes
{
   public class AzerbaijanStorage
    {
        public int Id { get; set; }
        public string Link { get; set; }
        public int Count { get; set; }
        public int Size { get; set; }
        public string About { get; set; }
        public double Price { get; set; }
        public DateTime ComingTime { get; set; }
        public bool IsInvoice { get; set; }
        public int DeclaredCargosId { get; set; }
        public DeclaredCargos Declared { get; set; }
    }
}
