using Application.UseCases.GetTransactions.Model;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCases.GetTransactions.Types
{
    public class TransactionType : ObjectGraphType<Transaction>
    {
        public TransactionType()
        {
            Name = "Transaction";
            Field(x => x.Account, type: typeof(IdGraphType)).Description("user account");
            Field(x => x.Bank).Description("user bank");
            Field(x => x.Value).Description("transaction value");
            Field(x => x.Date, type: typeof(DateTimeGraphType)).Description("transaction date");
        }
    }
}
