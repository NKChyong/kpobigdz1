using System.Collections.Generic;

namespace FinancialAccounting.DataAccess
{
    public class InMemoryRepository<T> : IRepository<T> where T : class
    {
        private readonly System.Func<T, int> _getIdFunc;
        private readonly Dictionary<int, T> _storage = new Dictionary<int, T>();

        public InMemoryRepository(System.Func<T, int> getIdFunc)
        {
            _getIdFunc = getIdFunc;
        }

        public T GetById(int id)
        {
            _storage.TryGetValue(id, out var value);
            return value;
        }

        public IEnumerable<T> GetAll()
        {
            return _storage.Values;
        }

        public void Add(T item)
        {
            var id = _getIdFunc(item);
            _storage[id] = item;
        }

        public void Update(T item)
        {
            var id = _getIdFunc(item);
            if (!_storage.ContainsKey(id))
            {
                throw new System.Exception();
            }
            _storage[id] = item;
        }

        public void Delete(int id)
        {
            _storage.Remove(id);
        }
    }
}