using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCases.GetTransactions.Ports
{
    public class TransactionRequest
    {
        public int Account { get; set; }
        public decimal Value { get; set; }
    }
}
