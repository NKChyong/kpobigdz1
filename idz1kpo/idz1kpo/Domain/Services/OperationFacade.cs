using System.Collections.Generic;
using FinancialAccounting.DataAccess;

namespace FinancialAccounting.Domain.Services
{
    public class OperationFacade
    {
        private readonly IRepository<Operation> _repository;
        private readonly IRepository<BankAccount> _accountRepository;

        public OperationFacade(IRepository<Operation> repository, IRepository<BankAccount> accountRepository)
        {
            _repository = repository;
            _accountRepository = accountRepository;
        }

        public Operation GetOperation(int id)
        {
            return _repository.GetById(id);
        }

        public IEnumerable<Operation> GetAllOperations()
        {
            return _repository.GetAll();
        }

        public void Create(Operation op)
        {
            var account = _accountRepository.GetById(op.BankAccountId);
            if (account == null)
            {
                throw new System.Exception();
            }
            var amount = op.Type == "расход" ? -op.Amount : op.Amount;
            account.UpdateBalance(amount);
            _repository.Add(op);
            _accountRepository.Update(account);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}