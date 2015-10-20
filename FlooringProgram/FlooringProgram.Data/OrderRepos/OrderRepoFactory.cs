using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.Models.Interfaces;

namespace FlooringProgram.Data.OrderRepos
{
    public class OrderRepoFactory
    {
        public static IOrderRepo GetOrderRepository()
        {
            switch (ConfigurationSettings.GetMode())
            {
                case "Prod":
                    return new OrderTestRepo();
                case "Test":
                    return new OrderTestRepo();
            }

            return null;
        }
    }
}
