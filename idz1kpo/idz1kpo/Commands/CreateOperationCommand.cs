using System;
using FinancialAccounting.Domain.Factories;
using FinancialAccounting.Domain.Services;

namespace FinancialAccounting.Commands
{
    public class CreateOperationCommand : ICommand
    {
        private readonly OperationFacade _facade;
        private readonly IDomainFactory _factory;

        public CreateOperationCommand(OperationFacade facade, IDomainFactory factory)
        {
            _facade = facade;
            _factory = factory;
        }

        public string CommandName => "Создать операцию";

        public void Execute()
        {
            Console.Write("Тип операции (доход/расход): ");
            var type = Console.ReadLine();
            Console.Write("ID счёта: ");
            if (!int.TryParse(Console.ReadLine(), out var accId))
            {
                Console.WriteLine("Некорректный ID");
                return;
            }
            Console.Write("Сумма: ");
            if (!decimal.TryParse(Console.ReadLine(), out var amount))
            {
                Console.WriteLine("Некорректная сумма");
                return;
            }
            Console.Write("Описание: ");
            var desc = Console.ReadLine();
            Console.Write("ID категории: ");
            if (!int.TryParse(Console.ReadLine(), out var catId))
            {
                Console.WriteLine("Некорректный ID");
                return;
            }
            var op = _factory.CreateOperation(type, accId, amount, DateTime.Now, desc, catId);
            _facade.Create(op);
            Console.WriteLine("Операция создана. Id=" + op.Id);
        }
    }
}