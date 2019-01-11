using System;
using System.Collections.Generic;

namespace NetCoreExp.Models
{
    public class CategoryViewModel
    {
        public string SelectedCategory { get; set; }
        public List<Category> Categories { get; set; }
    }
}
