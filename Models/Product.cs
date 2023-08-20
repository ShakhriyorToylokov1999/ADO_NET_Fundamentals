using System;
using System.Collections.Generic;
using System.Text;

namespace ADO_NET_Fundamentals.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
