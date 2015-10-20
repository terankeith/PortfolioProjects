using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.Models.Interfaces;
using FlooringProgram.Models;
using System.IO;

namespace FlooringProgram.Data.OrderRepos
{
    public class OrderFileRepo : IOrderRepo
    {


        public List<Order> GetOrders(string date)
        {
            //get orders from files
            List<Order> orders = new List<Order>();
            if (File.Exists(@".\Data\Orders_" + date + ".txt"))
            {
                string[] data = File.ReadAllLines(@".\Data\Orders_" + date + ".txt");
                for (int i = 0; i < data.Length; i++)
                {
                    string[] row = data[i].Split(',');
                    Order toAdd = new Order();
                    toAdd.OrderNumber = int.Parse(row[0]);
                    toAdd.CustomerName = row[1];
                    toAdd.State = row[2];
                    toAdd.TaxRate = decimal.Parse(row[3]);
                    toAdd.ProductType = row[4];
                    toAdd.Area = decimal.Parse(row[5]);
                    toAdd.CostPerSquareFoot = decimal.Parse(row[6]);
                    toAdd.LaborCostPerSquareFoot = decimal.Parse(row[7]);
                    toAdd.MaterialCost = decimal.Parse(row[8]);
                    toAdd.LaborCost = decimal.Parse(row[9]);
                    toAdd.Tax = decimal.Parse(row[10]);
                    toAdd.Total = decimal.Parse(row[11]);
                    orders.Add(toAdd);
                }
                return orders;
            }
            else
            {
                Console.WriteLine("That order does not exist.");
                return orders;
            }
            
        }
    }
}
