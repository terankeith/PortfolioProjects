using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.Models;
using FlooringProgram.Models.Interfaces;

namespace FlooringProgram.Data.OrderRepos
{
    public class OrderTestRepo : IOrderRepo
    {
        public List<Order> GetOrders()
        {
            return new List<Order>()
            {
                new Order()
                {
                    OrderNumber = 1,
                    CustomerName = "Wise",
                    State = "OH",
                    TaxRate = 6.25M,
                    ProductType = "Wood",
                    Area = 100.00M,
                    CostPerSquareFoot = 5.15M,
                    LaborCostPerSquareFoot = 4.75M,
                    MaterialCost = 515.00M,
                    LaborCost = 475.00M,
                    Tax = 61.88M,
                    Total = 1051.88M
                }
            };
        }
    }
}
