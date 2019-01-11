using System;
using System.Collections;
using System.Collections.Generic;

namespace NetCoreExp.Models
{
    public class ProductViewModel
    {
        public ProductViewModel()
        {
        }

        public IEnumerable<Product> Products { get; set; }
        public int SelectedCategory { get; set; }
    }
}
