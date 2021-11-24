﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class Product
    {
        public string Product_id { get; set; }
        public string Product_title { get; set; }
        public string Category_id { get; set; }
        public string Publisher_id { get; set; }
        public string Author { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }
        public string Image_url { get; set; }
        public string Big_image_url { get; set; }
        public string Description { get; set; }
        public int Active_flag { get; set; }
    }
}