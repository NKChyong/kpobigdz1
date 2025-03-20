using FinancialAccounting.Domain;

namespace FinancialAccounting.Domain.Factories
{
    public class DomainFactory : IDomainFactory
    {
        private int _bankAccountIdSequence;
        private int _categoryIdSequence;
        private int _operationIdSequence;

        public BankAccount CreateBankAccount(string name, decimal initialBalance)
        {
            _bankAccountIdSequence++;
            return new BankAccount(_bankAccountIdSequence, name, initialBalance);
        }

        public Category CreateCategory(string type, string name)
        {
            _categoryIdSequence++;
            return new Category(_categoryIdSequence, type, name);
        }

        public Operation CreateOperation(string type, int bankAccountId, decimal amount, System.DateTime date, string description, int categoryId)
        {
            _operationIdSequence++;
            return new Operation(_operationIdSequence, type, bankAccountId, amount, date, description, categoryId);
        }
    }
}