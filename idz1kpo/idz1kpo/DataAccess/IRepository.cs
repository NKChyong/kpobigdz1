namespace FinancialAccounting.DataAccess
{
    public interface IRepository<T> where T : class
    {
        T GetById(int id);
        System.Collections.Generic.IEnumerable<T> GetAll();
        void Add(T item);
        void Update(T item);
        void Delete(int id);
    }
}