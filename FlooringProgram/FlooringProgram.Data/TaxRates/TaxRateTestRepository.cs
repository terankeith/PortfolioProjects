using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.Models;
using FlooringProgram.Models.Interfaces;

namespace FlooringProgram.Data.TaxRates
{
    public class TaxRateTestRepository : ITaxRateRepository
    {
        public List<TaxRate> GetTaxRates()
        {
            return new List<TaxRate>()
            {
                new TaxRate() {State = "OH", TaxPercent = 6.25M},
                new TaxRate() {State = "PA", TaxPercent = 6.75M},
                new TaxRate() {State = "MI", TaxPercent = 5.75M},
                new TaxRate() {State = "IN", TaxPercent = 6.00M}
            };
        }
    }
}
