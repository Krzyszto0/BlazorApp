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
                .AsNoTracking().ToListAsync();
        }

        public Task<Income> CreateIncomeAsync(Income objincome)
        {
            _context.Income .Add(objincome);
            _context.SaveChanges();
            return Task.FromResult(objincome);
        }
    }
}
