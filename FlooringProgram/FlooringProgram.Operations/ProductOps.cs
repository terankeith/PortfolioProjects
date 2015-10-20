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
                if (prod.ProductName.ToUpper() == NameOfProduct.ToUpper())
                {
                    p1.ProductName = prod.ProductName;
                    p1.CostPerSquareFoot = prod.CostPerSquareFoot;
                    p1.LaborCostPerSquareFoot = prod.LaborCostPerSquareFoot;
                }
            }
            return p1;
        }
       

        public static bool isValidProductType(string userInput)
        {
            IProductRepo repo = ProductRepoFactory.GetProductRepository();
            var AllProducts = repo.GetProducts();

            bool success = false;

            foreach (var product in AllProducts)
            {
                if (userInput.ToUpper() == product.ProductName.ToUpper())
                {
                    success = true;
                }
            }
            return success;
        }

        // public Product GetProductCostsFor(string NameOfProduct)
        // {


        // }


        



    }
}
