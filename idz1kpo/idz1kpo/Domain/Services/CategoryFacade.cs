using System.Collections.Generic;
using FinancialAccounting.DataAccess;

namespace FinancialAccounting.Domain.Services
{
    public class CategoryFacade
    {
        private readonly IRepository<Category> _repository;

        public CategoryFacade(IRepository<Category> repository)
        {
            _repository = repository;
        }

        public Category GetCategory(int id)
        {
            return _repository.GetById(id);
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return _repository.GetAll();
        }

        public void Create(Category cat)
        {
            _repository.Add(cat);
        }

        public void Update(Category cat)
        {
            _repository.Update(cat);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}