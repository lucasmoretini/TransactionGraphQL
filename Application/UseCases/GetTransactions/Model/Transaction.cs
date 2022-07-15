using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCases.GetTransactions.Model
{
    public class Transaction
    {
        public int Account { get; set; }
        public decimal Value { get; set; }
        public string Bank { get; set; }
        public DateTime Date { get; set; }
    }
}
