using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DatabaseLib;
using Belethors_General_Warehouse.Models;



namespace Belethors_General_Warehouse.Repositories
{
    public class ProductRepo
    {
        Belethor_general_goods_warehouseEntities context = new Belethor_general_goods_warehouseEntities();

        public List<ProductModel> GetProducts()
        {
            List<ProductModel> ProductList = new List<ProductModel>();
            foreach(product product in context.products)
            {
                ProductModel newProductModel = new ProductModel(product.ID, product.brand, product.name, product.value, product.height, product.length, product.weight, product.stocks);
                ProductList.Add(newProductModel);
            }
            Console.WriteLine(ProductList);
            return ProductList;
        }

        public String GetProductName(int productID)
        {
            String productName ="";
            foreach(product product in context.products)
            {
                if (product.ID == productID)
                {
                    productName = product.name;
                }
            }
            return productName;
        }

        public void AddNewProduct(ProductModel productModel)
        {
            context.products.Add(new product
            {
                brand = productModel.Brand,
                name = productModel.Name,
                value = productModel.Value,
                height = productModel.Height,
                length = productModel.Length,
                weight = productModel.Weight,
                stocks = productModel.Stocks
            });

            context.SaveChanges();
        }

        public void UpdateProduct(ProductModel productModel)
        {


            var product = context.products.Single(p => p.ID == productModel.productID);
            product.brand = productModel.Brand;
            product.name = productModel.Name;
            product.value = productModel.Value;
            product.height = productModel.Height;
            product.length = productModel.Length;
            product.weight = productModel.Weight;
            product.stocks = productModel.Stocks;

            context.SaveChanges();

        }

        public ProductModel getProductModel(int productID)
        {
            var product = context.products.Single(p => p.ID == productID);
            return new ProductModel(product.ID, product.brand, product.name, product.value, product.height, product.length, product.weight, product.stocks);
        }

    }
}
