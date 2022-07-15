using Application.UseCases.GetTransactions.Model;
using GraphQL.Types;

namespace Application.UseCases.GetTransactions.Types
{
    public class TransactionInputType : InputObjectGraphType<Transaction>
    {
        public TransactionInputType()
        {
            Name = "TransactionInput";
            Field(x => x.Account, type: typeof(IdGraphType)).Description("user account");
            Field(x => x.Bank).Description("user bank");
            Field(x => x.Value).Description("transaction value");
            Field(x => x.Date, type: typeof(DateTimeGraphType)).Description("transaction date");
        }
    }
}
