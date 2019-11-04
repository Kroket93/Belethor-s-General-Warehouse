using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Belethors_General_Warehouse.Models
{
    public class AddProductModel
    {
        public ProductModel product { get; set; }
        public List<StoresWithStockModel> stores { get; set; }
    }
}