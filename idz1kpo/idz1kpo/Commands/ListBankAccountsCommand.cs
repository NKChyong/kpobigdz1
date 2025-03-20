using System;
using FinancialAccounting.Domain.Services;

namespace FinancialAccounting.Commands
{
    public class ListBankAccountsCommand : ICommand
    {
        private readonly BankAccountFacade _facade;

        public ListBankAccountsCommand(BankAccountFacade facade)
        {
            _facade = facade;
        }

        public string CommandName => "Список счетов";

        public void Execute()
        {
            var accounts = _facade.GetAllAccounts();
            Console.WriteLine("Счета:");
            foreach (var acc in accounts)
            {
                Console.WriteLine("Id=" + acc.Id + ", Name=" + acc.Name + ", Balance=" + acc.Balance);
            }
        }
    }
}