using FinancialAccounting.Domain;

namespace FinancialAccounting.Domain.Factories
{
    public interface IDomainFactory
    {
        BankAccount CreateBankAccount(string name, decimal initialBalance);
        Category CreateCategory(string type, string name);
        Operation CreateOperation(string type, int bankAccountId, decimal amount, System.DateTime date, string description, int categoryId);
    }
}