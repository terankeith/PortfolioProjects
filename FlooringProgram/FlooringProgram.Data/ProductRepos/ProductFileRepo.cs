using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.Models.Interfaces;
using FlooringProgram.Models;
using System.IO;

namespace FlooringProgram.Data.ProductRepos
{
    public class ProductFileRepo : IProductRepo
    {
        public List<Product> GetProducts()
        {
            List<Product> products = new List<Product>();
            string[] data = File.ReadAllLines(@"Data\Products.txt");
            for (int i = 1; i < data.Length; i++)
            {
                string[] elements = data[i].Split(',');

                Product toAdd = new Product();
                toAdd.ProductName = elements[0];
                toAdd.CostPerSquareFoot = decimal.Parse(elements[1]);
                toAdd.LaborCostPerSquareFoot = decimal.Parse(elements[2]);
                products.Add(toAdd);
            }
            return products;
        }
    }
}
