using BlazorApp2.Data.Accounts;

namespace BlazorApp2.Data
{
    public interface IAccountService
    {
        Task<Account> CreateAccountAsync(Account objAccount);
        Task<bool> DeleteAccountAsync(Account objAccount);
        Task<List<Account>> GetAccountsAsync(string strCurrentUser);
        Task<bool> UpdateAccountAsync(Account objAccount);
    }
}