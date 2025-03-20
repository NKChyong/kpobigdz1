using FinancialAccounting.Domain;
using FinancialAccounting.ImportExport;

namespace FinancialAccounting.Extensions
{
    public static class VisitorExtensions
    {
        public static void Accept(this BankAccount ba, params IExportVisitor[] visitors)
        {
            foreach (var v in visitors)
            {
                v.Visit(ba);
            }
        }

        public static void Accept(this Category cat, params IExportVisitor[] visitors)
        {
            foreach (var v in visitors)
            {
                v.Visit(cat);
            }
        }

        public static void Accept(this Operation op, params IExportVisitor[] visitors)
        {
            foreach (var v in visitors)
            {
                v.Visit(op);
            }
        }
    }
}