using System;
using System.Collections.Generic;
using System.Text;

namespace ADO_NET_Fundamentals.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        public string Status { get; set; }
    }
}
