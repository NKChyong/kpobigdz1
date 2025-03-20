using System;
using FinancialAccounting.Domain.Services;

namespace FinancialAccounting.Commands
{
    public class ListOperationsCommand : ICommand
    {
        private readonly OperationFacade _facade;

        public ListOperationsCommand(OperationFacade facade)
        {
            _facade = facade;
        }

        public string CommandName => "Список операций";

        public void Execute()
        {
            var operations = _facade.GetAllOperations();
            Console.WriteLine("Операции:");
            foreach (var op in operations)
            {
                Console.WriteLine("Id=" + op.Id + ", Type=" + op.Type + ", Amount=" + op.Amount + ", Date=" + op.Date + ", AccountId=" + op.BankAccountId + ", CategoryId=" + op.CategoryId + ", Desc=" + op.Description);
            }
        }
    }
}