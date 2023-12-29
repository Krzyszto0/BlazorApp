using BlazorApp2.Data.Accounts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp2.Data
{
    public class AccountService : IAccountService
    {
        private readonly AccountDbContext _context;

        public AccountService(AccountDbContext context)
        {
            _context = context;
        }

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
    }
}