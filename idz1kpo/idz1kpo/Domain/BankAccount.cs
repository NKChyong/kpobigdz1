namespace FinancialAccounting.Domain
{
    public class BankAccount
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public decimal Balance { get; private set; }

        internal BankAccount(int id, string name, decimal balance)
        {
            Id = id;
            Name = name;
            Balance = balance;
        }

        public void UpdateBalance(decimal amount)
        {
            Balance += amount;
        }
    }
}