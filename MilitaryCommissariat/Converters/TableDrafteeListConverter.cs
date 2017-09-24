using System.Collections.Generic;
using System.Data;
using MilitaryCommissariat.Domain;

namespace MilitaryCommissariat.Converters
{
    public class TableDrafteeListConverter : IConverter<List<TableDraftee>, DataTable>
    {
        public List<TableDraftee> Convert(DataTable source)
        {
            List<TableDraftee> result = new List<TableDraftee>(source.Rows.Count);
            foreach (DataRow dataRow in source.Rows)
            {
                TableDraftee tableDraftee = new TableDraftee();
                tableDraftee.Id = (long) dataRow["id"];
                tableDraftee.FullName = (string) dataRow["full_name"];
                tableDraftee.Year = (long) dataRow["birth_year"];
                result.Add(tableDraftee);
            }
            return result;
        }
    }
}