using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.Models;
using FlooringProgram.Models.Interfaces;

namespace FlooringProgram.Data.ProductRepos
{
    class ProductTestRepo : IProductRepo
    {
        public List<Product> GetProducts()
        {
            return new List<Product>()
            {
                new Product
                {
                    ProductName = "Wood",
                    CostPerSquareFoot = 5.15M,
                    LaborCostPerSquareFoot = 4.75M
                },

                new Product
                {
                    ProductName = "Carpet",
                    CostPerSquareFoot = 2.25M,
                    LaborCostPerSquareFoot = 2.1M
                },

                new Product
                {
                    ProductName = "Laminate",
                    CostPerSquareFoot = 5.15M,
                    LaborCostPerSquareFoot = 4.75M
                },

                new Product
                {
                    ProductName = "Tile",
                    CostPerSquareFoot = 5.15M,
                    LaborCostPerSquareFoot = 4.75M
                }

            };

        }
    }
}
