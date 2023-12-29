using System.ComponentModel.DataAnnotations;

namespace BlazorApp2.Data.Accounts
{
    public interface IAccount
    {
        public int Id { get; set; }
        [StringLength(100)]
        public string AccountName { get; set; }
        [StringLength(100)]
        public string UserName { get; set; }
    }
}
