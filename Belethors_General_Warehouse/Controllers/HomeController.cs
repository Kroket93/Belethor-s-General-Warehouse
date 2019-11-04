using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DatabaseLib;
using DatabaseLib.Repositories;
using Belethors_General_Warehouse.Repositories;
using Belethors_General_Warehouse.Models;

namespace Belethors_General_Warehouse.Controllers
{
    public class HomeController : Controller
    {

        stockRepo stockRepo = new stockRepo();
        ProductRepo productRepo = new ProductRepo();

        StocksRepo stocksRepo = new StocksRepo();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Overview()
        {
            ViewBag.Message = "Overview page.";
            
            return View(stocksRepo.getStock());
        }

        public ActionResult AllProducts()
        {
            ViewBag.Message = "Showing all products.";

            return View(productRepo.GetProducts()) ;
        }

        public ActionResult ProductStocks(int productID)
        {
            return View(productID);
            //return (stocksRepo.getStockModel(productID));
        }




        public ActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddProduct(ProductModel model)
        {
            productRepo.AddNewProduct(model);
            return RedirectToAction("AllProducts");
        }

        public ActionResult UpdateProduct(int productID)
        {
            
            return View(productRepo.getProductModel(productID));
        }

        [HttpPost]
        public ActionResult UpdateProduct(ProductModel model)
        {
            productRepo.UpdateProduct(model);
            return RedirectToAction("AllProducts");
        }

        public ActionResult UpdateStock(String storeName, String productId, int stock_id)
        {
            
            var storeWithStock = stocksRepo.getStockByStoreNameProductID(storeName, productId, stock_id);
            return View(storeWithStock);
        }

        [HttpPost]
        public ActionResult UpdateStockBonus(storeNameWithStockModel storeNameWithStockModel)
        {
            stocksRepo.UpdateStock(storeNameWithStockModel);
            return RedirectToAction("AllProducts");
        }
    }
}