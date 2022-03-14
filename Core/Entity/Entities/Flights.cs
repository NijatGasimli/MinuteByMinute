using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entity.AdminPanelEntityes
{
   public class Flights
    {
        public int Id { get; set; }
        public int Count { get; set; }
        public string FullName { get; set; }
        public double Price { get; set; }
        public int CargosID { get; set; }
    }
}
