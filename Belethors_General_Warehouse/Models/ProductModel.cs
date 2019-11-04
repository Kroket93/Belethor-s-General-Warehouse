using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DatabaseLib;

namespace Belethors_General_Warehouse.Models
{
    public class ProductModel
    {
        public int productID { get; set; }
        public String Brand { get; set; }
        public String Name { get; set; }
        public String Value { get; set; }
        public String Height { get; set; }
        public String Length { get; set; }
        public String Weight { get; set; }
        public ICollection<stock> Stocks { get; set; }

        public ProductModel(int productID, String Brand, String Name, String Value, String Height, String Length, String Weight, ICollection<stock> Stocks)
        {
            this.productID = productID;
            this.Brand = Brand;
            this.Name = Name;
            this.Value = Value;
            this.Height = Height;
            this.Length = Length;
            this.Weight = Weight;
            this.Stocks = Stocks;
        }

        public ProductModel()
        {

        }
    }
}