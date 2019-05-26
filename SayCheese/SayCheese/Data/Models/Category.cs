﻿using System.Collections.Generic;

namespace SayCheese.Data.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public List<Product> products { get; set; }
    }
}
