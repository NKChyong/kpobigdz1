using System.Collections.Generic;
using FinancialAccounting.Domain;

namespace FinancialAccounting.ImportExport
{
    public class YamlDataImporter : DataImporterBase
    {
        protected override List<Operation> ParseData(string fileContent)
        {
            System.Console.WriteLine("Парсинг YAML");
            return new List<Operation>();
        }
    }
}