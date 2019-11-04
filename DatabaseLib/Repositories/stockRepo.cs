using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLib.Repositories
{
    public class stockRepo
    {
        Belethor_general_goods_warehouseEntities context = new Belethor_general_goods_warehouseEntities();
        public List<List<String>> getStock()
        {
            List<List<String>> stockInfoInfo = new List<List<String>>();
            foreach (var stock in context.stocks)
            {
                List<String> stockInfo = new List<String>();
                stockInfo.Add(Convert.ToString(stock.product.name));
                stockInfo.Add(Convert.ToString(stock.store.name));
                stockInfo.Add(Convert.ToString(stock.amount));
                stockInfoInfo.Add(stockInfo);

            }

            return stockInfoInfo;
        }
    }
}
