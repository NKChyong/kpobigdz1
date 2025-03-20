using System.Collections.Generic;
using FinancialAccounting.Domain;

namespace FinancialAccounting.ImportExport
{
    public class YamlExportVisitor : IExportVisitor
    {
        private readonly List<string> _lines = new List<string>();

        public void Visit(BankAccount account)
        {
            _lines.Add("- Id: " + account.Id + "\n  Name: " + account.Name + "\n  Balance: " + account.Balance);
        }

        public void Visit(Category category)
        {
            _lines.Add("- Id: " + category.Id + "\n  Type: " + category.Type + "\n  Name: " + category.Name);
        }

        public void Visit(Operation operation)
        {
            _lines.Add("- Id: " + operation.Id + "\n  Type: " + operation.Type + "\n  BankAccountId: " + operation.BankAccountId + "\n  Amount: " + operation.Amount + "\n  Date: " + operation.Date.ToString("yyyy-MM-dd") + "\n  Description: " + operation.Description + "\n  CategoryId: " + operation.CategoryId);
        }

        public string GetResult()
        {
            return string.Join("\n", _lines);
        }
    }
}