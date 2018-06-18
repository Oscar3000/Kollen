using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProductApp.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string ProductType { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string Category { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        public double Price { get; set; }
        [Required]
        public int Size { get; set; }
        [Required]
        public int Stocks { get; set; }
        public byte[] Picture { get; set; }
    }

    public enum ProType
    {
        Man,
        Woman,
        Children,
        Babies
    }

    public enum Category
    {
        Shoes,
        Shirts,
        Trousers,
        Dress,
        Bag
    }

    public enum Range
    {
       LessThan100,
       GreaterThan100
    }

}