using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Belethors_General_Warehouse.Models
{
    public class StoresWithStockModel
    {
        public StoreModel Store { get; set; }
        public int Voorraad { get; set; }
    }
}