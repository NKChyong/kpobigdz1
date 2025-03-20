using System.Collections.Generic;
using FinancialAccounting.Domain;

namespace FinancialAccounting.ImportExport
{
    public class JsonDataImporter : DataImporterBase
    {
        protected override List<Operation> ParseData(string fileContent)
        {
            System.Console.WriteLine("Парсинг JSON");
            return new List<Operation>();
        }
    }
}