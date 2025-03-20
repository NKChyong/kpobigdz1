using System.Collections.Generic;
using FinancialAccounting.Domain;

namespace FinancialAccounting.ImportExport
{
    public class JsonExportVisitor : IExportVisitor
    {
        private readonly List<string> _lines = new List<string>();

        public void Visit(BankAccount account)
        {
            _lines.Add("{ \"Id\": " + account.Id + ", \"Name\": \"" + account.Name + "\", \"Balance\": " + account.Balance + " }");
        }

        public void Visit(Category category)
        {
            _lines.Add("{ \"Id\": " + category.Id + ", \"Type\": \"" + category.Type + "\", \"Name\": \"" + category.Name + "\" }");
        }

        public void Visit(Operation operation)
        {
            _lines.Add("{ \"Id\": " + operation.Id + ", \"Type\": \"" + operation.Type + "\", \"BankAccountId\": " + operation.BankAccountId + ", \"Amount\": " + operation.Amount + ", \"Date\": \"" + operation.Date.ToString("yyyy-MM-dd") + "\", \"Description\": \"" + operation.Description + "\", \"CategoryId\": " + operation.CategoryId + " }");
        }

        public string GetResult()
        {
            return "[\n" + string.Join(",\n", _lines) + "\n]";
        }
    }
}