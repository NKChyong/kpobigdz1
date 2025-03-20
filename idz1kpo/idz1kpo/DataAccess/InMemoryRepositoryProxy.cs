using System.Collections.Generic;

namespace FinancialAccounting.DataAccess
{
    public class InMemoryRepositoryProxy<T> : IRepository<T> where T : class
    {
        private readonly IRepository<T> _innerRepository;
        private readonly Dictionary<int, T> _cache = new Dictionary<int, T>();
        private readonly System.Func<T, int> _getIdFunc;

        public InMemoryRepositoryProxy(IRepository<T> innerRepository, System.Func<T, int> getIdFunc)
        {
            _innerRepository = innerRepository;
            _getIdFunc = getIdFunc;
        }

        public T GetById(int id)
        {
            if (_cache.ContainsKey(id))
            {
                return _cache[id];
            }
            var item = _innerRepository.GetById(id);
            if (item != null)
            {
                _cache[id] = item;
            }
            return item;
        }

        public System.Collections.Generic.IEnumerable<T> GetAll()
        {
            var all = _innerRepository.GetAll();
            foreach (var item in all)
            {
                var id = _getIdFunc(item);
                _cache[id] = item;
            }
            return _cache.Values;
        }

        public void Add(T item)
        {
            _innerRepository.Add(item);
            var id = _getIdFunc(item);
            _cache[id] = item;
        }

        public void Update(T item)
        {
            _innerRepository.Update(item);
            var id = _getIdFunc(item);
            _cache[id] = item;
        }

        public void Delete(int id)
        {
            _innerRepository.Delete(id);
            if (_cache.ContainsKey(id))
            {
                _cache.Remove(id);
            }
        }
    }
}