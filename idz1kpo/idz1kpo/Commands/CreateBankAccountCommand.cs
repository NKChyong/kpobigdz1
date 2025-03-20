using System;
using FinancialAccounting.Domain.Factories;
using FinancialAccounting.Domain.Services;

namespace FinancialAccounting.Commands
{
    public class CreateBankAccountCommand : ICommand
    {
        private readonly BankAccountFacade _facade;
        private readonly IDomainFactory _factory;

        public CreateBankAccountCommand(BankAccountFacade facade, IDomainFactory factory)
        {
            _facade = facade;
            _factory = factory;
        }

        public string CommandName => "Создать счёт";

        public void Execute()
        {
            Console.Write("Введите название счёта: ");
            var name = Console.ReadLine();
            Console.Write("Введите начальный баланс: ");
            var balanceStr = Console.ReadLine();
            if (!decimal.TryParse(balanceStr, out var balance))
            {
                Console.WriteLine("Некорректное число");
                return;
            }
            var account = _factory.CreateBankAccount(name, balance);
            _facade.Create(account);
            Console.WriteLine("Счёт создан. Id=" + account.Id);
        }
    }
}