using Application.Repositories;
using Application.UseCases.GetTransactions.Ports;
using Application.UseCases.GetTransactions.Types;
using GraphQL;
using GraphQL.Types;

namespace Application.UseCases.GetTransactions.Queries
{
    public class TransactionQuery : ObjectGraphType<object>
    {
        public TransactionQuery()
        {
            Field<ListGraphType<TransactionType>>("transaction",
                arguments: new QueryArguments(new QueryArgument[]
                {   
                    new QueryArgument<IdGraphType>{Name="account"},
                    new QueryArgument<StringGraphType>{Name="value"}
                }),
                resolve: context =>
                {
                    var filter = new TransactionRequest()
                    {
                        Account = context.GetArgument<int>("account"),
                        Value = context.GetArgument<decimal>("value"),
                    };
                    return TransactionsMock.GetSelectedTransaction(filter);
                }
                );
        }

    }
}
