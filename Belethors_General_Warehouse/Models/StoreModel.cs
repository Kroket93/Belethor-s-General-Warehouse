using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DatabaseLib;

namespace Belethors_General_Warehouse.Models
{
    public class StoreModel
    {
        public int StoreID { get; set; }
        public String Location { get; set; }
        public String Name { get; set; }
        public String Phone { get; set; }
        public String NumberOfEmployees { get; set; }
        public ICollection<stock> Stocks { get; set; }
    }
}