using Application.UseCases.GetTransactions.Queries;
using GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Application.UseCases
{
    public class GraphQlSchema : Schema
    {
        public GraphQlSchema(IServiceProvider serviceProvider)
           : base(serviceProvider)
        {
            Query = serviceProvider.GetRequiredService<TransactionQuery>();
        }
    }
}
