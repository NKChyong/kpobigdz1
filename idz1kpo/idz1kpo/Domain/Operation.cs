namespace FinancialAccounting.Domain
{
    public class Operation
    {
        public int Id { get; private set; }
        public string Type { get; private set; }
        public int BankAccountId { get; private set; }
        public decimal Amount { get; private set; }
        public System.DateTime Date { get; private set; }
        public string Description { get; private set; }
        public int CategoryId { get; private set; }

        internal Operation(int id, string type, int bankAccountId, decimal amount, System.DateTime date, string description, int categoryId)
        {
            if (amount < 0)
            {
                throw new System.ArgumentException();
            }
            if (type != "доход" && type != "расход")
            {
                throw new System.ArgumentException();
            }
            Id = id;
            Type = type;
            BankAccountId = bankAccountId;
            Amount = amount;
            Date = date;
            Description = description;
            CategoryId = categoryId;
        }
    }
}