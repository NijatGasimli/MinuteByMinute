using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entity.Entities
{
   public class Categories
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Shops> Shops { get; set; }
    }
}
