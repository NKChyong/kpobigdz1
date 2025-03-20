using System.Collections.Generic;
using FinancialAccounting.Domain;

namespace FinancialAccounting.ImportExport
{
    public class CsvDataImporter : DataImporterBase
    {
        protected override List<Operation> ParseData(string fileContent)
        {
            var result = new List<Operation>();
            var lines = fileContent.Split('\n');
            foreach (var line in lines)
            {
                var parts = line.Split(';');
                if (parts.Length < 7) continue;
                if (int.TryParse(parts[0], out var id)
                    && decimal.TryParse(parts[3], out var amount)
                    && System.DateTime.TryParse(parts[4], out var date)
                    && int.TryParse(parts[2], out var bankAccId)
                    && int.TryParse(parts[6], out var catId))
                {
                    var op = new Operation(id, parts[1], bankAccId, amount, date, parts[5], catId);
                    result.Add(op);
                }
            }
            return result;
        }
    }
}