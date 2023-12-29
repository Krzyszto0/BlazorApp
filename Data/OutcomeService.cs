using BlazorApp2.Data.Outcomes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp2.Data
{
    public class OutcomeService
    {
        private readonly OutcomeDbContext _context;

        public OutcomeService(OutcomeDbContext context)
        {
            _context = context;
        }

        public async Task<List<Outcome>> GetOutcomesAsync(string strCurrentUser)
        {
            return await _context.Outcome
                .Where(Half => Half.UserName == strCurrentUser)
                .Include(h => h.AccountName)
                .OrderByDescending(Half => Half.Data)
                .AsNoTracking().ToListAsync();
        }

        public Task<Outcome> CreateOutcomeAsync(Outcome objoutcome)
        {
            _context.Outcome.Add(objoutcome);
            _context.SaveChanges();
            return Task.FromResult(objoutcome);
        }

        public Task<bool> UpdateOutcomeAsync(Outcome objoutcome)
        {
            var ExistingOutcome = _context.Outcome.Where(h => h.Id == objoutcome.Id)
                .FirstOrDefault();
            if (ExistingOutcome != null)
            {
                ExistingOutcome.Data = objoutcome.Data;
                ExistingOutcome.AccountName = objoutcome.AccountName;
                ExistingOutcome.Amount = objoutcome.Amount;
                ExistingOutcome.UserName = objoutcome.UserName;
                _context.SaveChanges();
            }
            else
            {
                return Task.FromResult(false);
            }
            return Task.FromResult(true);
        }

        public Task<bool> DeleteOutcomeAsync(Outcome objoutcome)
        {
            var ExistingOutcome = _context.Outcome.Where(h => h.Id == objoutcome.Id)
                .FirstOrDefault();
            if (ExistingOutcome != null)
            {
                _context.Outcome.Remove(ExistingOutcome);
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
