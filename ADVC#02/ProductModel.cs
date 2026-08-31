using System;
using System.Collections.Generic;
using System.Text;

namespace ADVC_02
{
    internal class Product
    {
        public int Id {  get; set; }
        public string Name { get; set; }
        public string Category { get; set; } // "Electronics" , "Clothing" , "Food" , "Books"
        public double Price { get; set; }
        public int Stock { get; set; }

    }
}
