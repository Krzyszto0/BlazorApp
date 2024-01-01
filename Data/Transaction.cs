using System.Data;
using BlazorApp2.Data;

namespace BlazorApp2.Data
{
    public class Transaction
    {
        public int Id { get; set; }
        public string AccountName { get; set; }
        public double? Amount { get; set; }
        public DateTime? Date { get; set; }

    }
}
