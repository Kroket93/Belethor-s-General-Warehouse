using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DatabaseLib;
using Belethors_General_Warehouse.Models;

namespace Belethors_General_Warehouse.Repositories
{
    public class StocksRepo
    {

        Belethor_general_goods_warehouseEntities context = new Belethor_general_goods_warehouseEntities();

        public List<List<String>> getStockInfo(int ProductID)
        {
            
            List<List<String>> stockInfoInfo = new List<List<String>>();

            foreach(stock stock in context.stocks)
            {
                if(stock.product_id == ProductID)
                {

                    foreach(store store in context.stores)
                    {
                        
                        if (store.ID == stock.store_id)
                        {
                            List<String> stockInfo = new List<String>();
                            stockInfo.Add(store.name);
                            stockInfo.Add(Convert.ToString(stock.amount));

                            stockInfoInfo.Add(stockInfo);
                        }
                    }
                }
            }
            return stockInfoInfo;
        }

        public void UpdateStock(storeNameWithStockModel storeWithStock)
        {
            var stock = context.stocks.Single(p => p.ID == storeWithStock.stockID);

            stock.amount = Convert.ToInt32(storeWithStock.stockAmount);

            context.SaveChanges();
        }

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

        public storeNameWithStockModel getStockByStoreNameProductID(String storeName, String productID, int stock_id)
        {
            int productIDasInt = Convert.ToInt32(productID);
            var store = context.stores.Single(p => p.name == storeName);
            var stock = context.stocks.Single(c => c.store_id == store.ID && c.product_id == productIDasInt);



            return( new storeNameWithStockModel { storeName = store.name, stockAmount = stock.amount, stockID = stock_id });
        }

        public stock getStock(String storeName, int productID)
        {
            var store = context.stores.Single(p => p.name == storeName);
            return context.stocks.Single(c => c.store_id == store.ID && c.product_id == productID);
        }

    }
}