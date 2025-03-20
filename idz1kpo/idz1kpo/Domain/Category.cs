namespace FinancialAccounting.Domain
{
    public class Category
    {
        public int Id { get; private set; }
        public string Type { get; private set; }
        public string Name { get; private set; }

        internal Category(int id, string type, string name)
        {
            if (type != "доход" && type != "расход")
            {
                throw new System.ArgumentException();
            }
            Id = id;
            Type = type;
            Name = name;
        }
    }
}