using System.Collections.Generic;
using FinancialAccounting.DataAccess;

namespace FinancialAccounting.Domain.Services
{
    public class BankAccountFacade
    {
        private readonly IRepository<BankAccount> _repository;

        public BankAccountFacade(IRepository<BankAccount> repository)
        {
            _repository = repository;
        }

        public BankAccount GetAccount(int id)
        {
            return _repository.GetById(id);
        }

        public IEnumerable<BankAccount> GetAllAccounts()
        {
            return _repository.GetAll();
        }

        public void Create(BankAccount account)
        {
            _repository.Add(account);
        }

        public void Update(BankAccount account)
        {
            _repository.Update(account);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}