using BlazorApp2.Data;
using Microsoft.AspNetCore.Components;

namespace BlazorApp2.Data
{
    public class Cashflow
    {
        public DateTime Month { get; set; }
        public double Income { get; set; }
        public double Outcome { get; set; }
        public double CashFlow { get; set; }
        
        public Cashflow(DateTime month, double income, double outcome, double cashflow) 
        {
            Month = month;
            Income = income;
            Outcome = outcome;
            CashFlow = cashflow;
        }

    }
}
