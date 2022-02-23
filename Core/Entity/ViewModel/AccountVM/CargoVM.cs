using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entity.ViewModel.AccountVM
{
    public class CargoVM
    {
        public string UserId { get; set; }
        public string Link { get; set; }
        public int Count { get; set; }
        public int Size { get; set; }
        public string About { get; set; }
        public double Price { get; set; }
    }
}
