using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.Models;
using FlooringProgram.Data.ProductRepos;
using FlooringProgram.Models.Interfaces;

namespace FlooringProgram.Operations
{
    class ProductOps
    {
         public Product GetProduct(string NameOfProduct)
        {
            Product p1 = new Product();
            //find product in product file, set Product properties using elements of the file
            IProductRepo repo = ProductRepoFactory.GetProductRepository();
            var AllProducts = repo.GetProducts();
            foreach (var prod in AllProducts)
            {
                if (prod.ProductName == NameOfProduct)
                {
                    p1.ProductName = prod.ProductName;
                    p1.CostPerSquareFoot = prod.CostPerSquareFoot;
                    p1.LaborCostPerSquareFoot = prod.LaborCostPerSquareFoot;
                }
            }
            return p1;
        }

        private static List<Product> getList()
        {
            List<Product> newList = new List<Product>();

            Product Carpet = new Product
            {
                ProductName = "Carpet",
                CostPerSquareFoot = 2.25M,
                LaborCostPerSquareFoot = 2.10M
            };

            Product Laminate = new Product
            {
                ProductName = "Laminate",
                CostPerSquareFoot = 1.75M,
                LaborCostPerSquareFoot = 2.10M
            };

            Product Tile = new Product
            {
                ProductName = "Tile",
                CostPerSquareFoot = 3.50M,
                LaborCostPerSquareFoot = 4.15M
            };

            Product Wood = new Product
            {
                ProductName = "Wood",
                CostPerSquareFoot = 5.15M,
                LaborCostPerSquareFoot = 4.75M
            };

            newList.Add(Carpet);
            newList.Add(Laminate);
            newList.Add(Tile);
            newList.Add(Wood);

            return newList;

        }

        public static bool isValidProductType(string userInput)
        {
            List<Product> newList = getList();
            bool success = false;

            for (int i = 0; i < newList.Count; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (userInput.ToUpper() == newList[i].ProductName.ToUpper())
                    {
                        success = true;
                    }
                }
            }
            return success;
        }

        // public Product GetProductCostsFor(string NameOfProduct)
        // {


        // }






    }
}
