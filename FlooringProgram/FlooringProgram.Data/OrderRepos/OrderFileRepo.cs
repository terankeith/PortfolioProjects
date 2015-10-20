using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.Models.Interfaces;
using FlooringProgram.Models;

namespace FlooringProgram.Data.OrderRepos
{
    public class OrderFileRepo : IOrderRepo
    {
        public List<Order> GetOrders()
        {
            // get orders from file
            return new List<Order>();
        }
    }
}
