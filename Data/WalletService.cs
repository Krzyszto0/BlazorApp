﻿using BlazorApp2.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Globalization;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace BlazorApp2.Data
{
    public class WalletService
    {
        private readonly WalletDBContext _context;
        public WalletService(WalletDBContext context)
        {
            _context = context;
        }

        //Account Context
        public async Task<List<Account>> GetAccountsAsync(string strCurrentUser)
        {
            return await _context.Account
                .Where(Half => Half.UserName == strCurrentUser)
                .AsNoTracking().ToListAsync();
        }

        public Task<Account> CreateAccountAsync(Account objAccount)
        {
            _context.Account.Add(objAccount);
            _context.SaveChanges();
            return Task.FromResult(objAccount);
        }

        public Task<bool> UpdateAccountAsync(Account objAccount)
        {
            var ExistingAccount = _context.Account.Where(h => h.Id == objAccount.Id)
                .FirstOrDefault();
            if (ExistingAccount != null)
            {
                ExistingAccount.AccountName = objAccount.AccountName;
                ExistingAccount.UserName = objAccount.UserName;
                _context.SaveChanges();
            }
            else
            {
                return Task.FromResult(false);
            }
            return Task.FromResult(true);
        }

        public Task<bool> DeleteAccountAsync(Account objAccount)
        {
            var ExistingAccount = _context.Account.Where(h => h.Id == objAccount.Id)
                .FirstOrDefault();
            if (ExistingAccount != null)
            {
                _context.Account.Remove(ExistingAccount);
                _context.SaveChanges();
            }
            else
            {
                return Task.FromResult(false);
            }
            return Task.FromResult(true);
        }

        //Income Context
        public async Task<List<Income>> GetIncomesAsync(string strCurrentUser)
        {
            return await _context.Income
                .Where(Half => Half.UserName == strCurrentUser)
                .Include(h => h.AccountName)
                .OrderByDescending(Half => Half.Data)
                .AsNoTracking().ToListAsync();
        }

        public Task<Income> CreateIncomeAsync(Income objincome)
        {
            _context.Income.Add(objincome);
            _context.SaveChanges();
            return Task.FromResult(objincome);
        }

        public Task<bool> UpdateIncomeAsync(Income objincome)
        {
            var ExistingIncome = _context.Income.Where(h => h.Id == objincome.Id)
                .FirstOrDefault();
            if (ExistingIncome != null)
            {
                ExistingIncome.Data = objincome.Data;
                ExistingIncome.AccountId = objincome.AccountId;
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


        //Outcome Context
        public async Task<List<Outcome>> GetOutcomesAsync(string strCurrentUser)
        {
            return await _context.Outcome
                .Where(h => h.UserName == strCurrentUser)
                .Include(h => h.AccountName)
                .OrderByDescending(h => h.Data)
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
                ExistingOutcome.AccountId = objoutcome.AccountId;
                if (objoutcome.Amount > 0)
                {
                    ExistingOutcome.Amount = -objoutcome.Amount;
                }
                else
                {
                    ExistingOutcome.Amount = objoutcome.Amount;
                }
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

        //Cashflow Chart
        public List<Cashflow> GetCashflows(string strCurrentUser)
        {
            var cashflows = new List<Cashflow>();

            var incomes = _context.Income
                .Where(i => i.UserName == strCurrentUser)
                .ToList();
            var outcomes = _context.Outcome
                .Where(o => o.UserName == strCurrentUser)
                .ToList();

            var IncomesByMonth = incomes.GroupBy(i => new { i.Data.Year, i.Data.Month })
                .Select(grp => new
                {
                    Year = grp.Key.Year,
                    Month = grp.Key.Month,
                    allIncome = grp.Sum(i => i.Amount ?? 0)
                })
                .ToList();

            var OutcomesByMonth = outcomes.GroupBy(o => new { o.Data.Year, o.Data.Month })
                .Select(grp => new
                {
                    Year = grp.Key.Year,
                    Month = grp.Key.Month,
                    allOutcome = grp.Sum(i => i.Amount ?? 0)
                })
                .ToList();

            foreach (var income in IncomesByMonth)
            {
                var OutcomeToIncome = OutcomesByMonth.FirstOrDefault(o => o.Year == income.Year && o.Month == income.Month);
                var OutcomeSum = OutcomeToIncome?.allOutcome ?? 0;
                var SumToCashflow = income.allIncome + OutcomeSum;

                var addcashflow = new Cashflow(new DateTime(income.Year, income.Month, 1), income.allIncome, OutcomeSum, SumToCashflow);
                cashflows.Add(addcashflow);
            }
            return cashflows;
        }
    }
}
