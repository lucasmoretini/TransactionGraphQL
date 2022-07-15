using Application.UseCases.GetTransactions.Model;
using Application.UseCases.GetTransactions.Ports;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public class TransactionsMock
    {
        public static List<Transaction> GetSelectedTransaction(TransactionRequest filter)
        {
            var listTransactions = GetTransactions();

            if(filter.Account == 0 && filter.Value == 0)
                return listTransactions;


            var selectedTransactions = listTransactions.FindAll(x => x.Account == filter.Account || x.Value == filter.Value);
            return selectedTransactions;
        }

        private static List<Transaction> GetTransactions() =>
            new List<Transaction>()
            {
                new Transaction()
                {
                    Account = 1,
                    Bank = "Nubank",
                    Date = new DateTime(),
                    Value = 100m
                },
                new Transaction()
                {
                    Account = 1,
                    Bank = "Nubank",
                    Date = new DateTime(),
                    Value = 500m
                },
                new Transaction()
                {
                    Account = 2,
                    Bank = "XP",
                    Date = new DateTime(),
                    Value = 500m
                },
                new Transaction()
                {
                    Account = 3,
                    Bank = "Bradesco",
                    Date = new DateTime(),
                    Value = 1500m
                },
                new Transaction()
                {
                    Account = 4,
                    Bank = "Banco do Brasil",
                    Date = new DateTime(),
                    Value = 2000m
                },
                new Transaction()
                {
                    Account = 4,
                    Bank = "Bradesco",
                    Date = new DateTime(),
                    Value = 2000m
                },
                new Transaction()
                {
                    Account = 5,
                    Bank = "Digio",
                    Date = new DateTime(),
                    Value = 3500m
                },
            };
    }
}
