using System.Collections.Generic;
using FinancialAccounting.Domain;

namespace FinancialAccounting.ImportExport
{
    public class CsvExportVisitor : IExportVisitor
    {
        private readonly List<string> _lines = new List<string>();

        public void Visit(BankAccount account)
        {
            _lines.Add(account.Id + ";" + account.Name + ";" + account.Balance);
        }

        public void Visit(Category category)
        {
            _lines.Add(category.Id + ";" + category.Type + ";" + category.Name);
        }

        public void Visit(Operation operation)
        {
            _lines.Add(operation.Id + ";" + operation.Type + ";" + operation.BankAccountId + ";" + operation.Amount + ";" + operation.Date + ";" + operation.Description + ";" + operation.CategoryId);
        }

        public string GetResult()
        {
            return string.Join("\n", _lines);
        }
    }
}