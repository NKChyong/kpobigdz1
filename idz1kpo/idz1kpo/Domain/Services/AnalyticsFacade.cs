using System.Linq;
using System.Collections.Generic;
using FinancialAccounting.DataAccess;

namespace FinancialAccounting.Domain.Services
{
    public class AnalyticsFacade
    {
        private readonly IRepository<Operation> _operations;
        private readonly IRepository<Category> _categories;

        public AnalyticsFacade(IRepository<Operation> operations, IRepository<Category> categories)
        {
            _operations = operations;
            _categories = categories;
        }

        public decimal GetIncomeMinusExpense(System.DateTime start, System.DateTime end)
        {
            var ops = _operations.GetAll().Where(o => o.Date >= start && o.Date <= end).ToList();
            decimal totalIncome = ops.Where(o => o.Type == "доход").Sum(o => o.Amount);
            decimal totalExpense = ops.Where(o => o.Type == "расход").Sum(o => o.Amount);
            return totalIncome - totalExpense;
        }

        public Dictionary<string, decimal> GetAmountByCategory(System.DateTime start, System.DateTime end, string operationType)
        {
            var ops = _operations.GetAll().Where(o => o.Date >= start && o.Date <= end && o.Type == operationType).ToList();
            var result = new Dictionary<string, decimal>();
            foreach (var op in ops)
            {
                var cat = _categories.GetById(op.CategoryId);
                if (cat == null) continue;
                if (!result.ContainsKey(cat.Name))
                {
                    result[cat.Name] = 0;
                }
                result[cat.Name] += op.Amount;
            }
            return result;
        }
    }
}