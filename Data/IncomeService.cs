using BlazorApp2.Data.Incomes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp2.Data
{
    public class IncomeService
    {
        private readonly IncomeDbContext _context;

        public IncomeService(IncomeDbContext context)
        {
            _context = context;
        }

        public async Task<List<Income>> GetIncomesAsync(string strCurrentUser)
        {
            return await _context.Income
                .Where(Half => Half.UserName == strCurrentUser)
                .OrderByDescending(Half => Half.Data)
                .AsNoTracking().ToListAsync();
        }

        public Task<Income> CreateIncomeAsync(Income objincome)
        {
            _context.Income .Add(objincome);
            _context.SaveChanges();
            return Task.FromResult(objincome);
        }

        public Task<bool> UpdateIncomeAsync(Income objincome)
        {
            var ExistingIncome = _context.Income.Where(h => h.Id == objincome.Id)
                .FirstOrDefault();
            if (ExistingIncome != null) { 
                ExistingIncome.Data = objincome.Data;
                ExistingIncome.Account = objincome.Account;
                ExistingIncome.Amount = objincome.Amount;
                ExistingIncome.UserName = objincome.UserName;
                _context.SaveChanges();
            }
            else
            {
                return Task.FromResult(false);
            }
            return Task.FromResult(true);
        }

        public Task<bool> DeleteIncomeAsync(Income objincome)
        {
            var ExistingIncome = _context.Income.Where(h => h.Id == objincome.Id)
                .FirstOrDefault();
            if (ExistingIncome != null)
            {
                _context.Income.Remove(ExistingIncome);
                _context.SaveChanges();
            }
            else
            {
                return Task.FromResult(false);
            }
            return Task.FromResult(true);
        }
    }
}
