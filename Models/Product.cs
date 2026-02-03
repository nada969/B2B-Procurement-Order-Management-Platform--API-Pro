using System;

namespace B2B_Procurement___Order_Management_Platform.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Supplier { get; set; }
//- Current status(Active, Inactive, Discontinued)
    }
}
