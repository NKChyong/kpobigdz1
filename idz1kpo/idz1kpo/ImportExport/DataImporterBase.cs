using System.Collections.Generic;
using FinancialAccounting.Domain;

namespace FinancialAccounting.ImportExport
{
    public abstract class DataImporterBase
    {
        public void ImportData(string filePath)
        {
            var fileContent = System.IO.File.ReadAllText(filePath);
            var data = ParseData(fileContent);
            SaveData(data);
        }

        protected abstract List<Operation> ParseData(string fileContent);

        protected virtual void SaveData(List<Operation> operations)
        {
            System.Console.WriteLine("Импортировано операций: " + operations.Count);
        }
    }
}