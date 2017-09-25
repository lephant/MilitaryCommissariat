using System.Collections.Generic;
using System.Data;
using MilitaryCommissariat.Domain;
using MilitaryCommissariat.Utils;

namespace MilitaryCommissariat.Converters
{
    public class RelativeListConverter : IConverter<List<Relative>, DataTable>
    {
        public List<Relative> Convert(DataTable source)
        {
            List<Relative> result = new List<Relative>(source.Rows.Count);
            foreach (DataRow dataRow in source.Rows)
            {
                Relative relative = new Relative();
                relative.Id = (long) dataRow["id"];
                relative.DrafteeId = (long) dataRow["draftee_id"];
                relative.FullName = DbConverterUtils.ConvertString(dataRow["full_name"]);
                relative.BirthYear = DbConverterUtils.ConvertInt(dataRow["birth_year"]);
                relative.BirthPlace = DbConverterUtils.ConvertString(dataRow["birth_place"]);
                relative.WorkPlace = DbConverterUtils.ConvertString(dataRow["work_place"]);
                result.Add(relative);
            }
            return result;
        }
    }
}