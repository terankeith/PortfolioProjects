using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.Models.Interfaces;

namespace FlooringProgram.Data.ProductRepos
{
    public class ProductRepoFactory
    {
        public static IProductRepo GetProductRepository()
        {
            switch (ConfigurationSettings.GetMode())
            {
                case "Prod":
                    return new ProductTestRepo();
                case "Test":
                    return new ProductTestRepo();
            }

            return null;
        }
    }
}
