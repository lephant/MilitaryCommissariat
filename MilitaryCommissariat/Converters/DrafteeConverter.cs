using System;
using System.Data;
using MilitaryCommissariat.Domain;
using MilitaryCommissariat.Utils;

namespace MilitaryCommissariat.Converters
{
    public class DrafteeConverter : IConverter<Draftee, DataTable>
    {
        public Draftee Convert(DataTable source)
        {
            if (source == null || source.Rows.Count < 1)
            {
                return null;
            }
            DataRow dataRow = source.Rows[0];
            Draftee draftee = new Draftee();
            draftee.Id = (long)dataRow["id"];
            draftee.LastName = DbConverterUtils.ConvertString(dataRow["last_name"]);
            draftee.FirstName = DbConverterUtils.ConvertString(dataRow["first_name"]);
            draftee.Patronymic = DbConverterUtils.ConvertString(dataRow["patronymic"]);
            draftee.BirthDate = (DateTime) DbConverterUtils.ConvertDateTime(dataRow["birth_date"]);
            draftee.BirthPlace = DbConverterUtils.ConvertString(dataRow["birth_place"]);
            draftee.Category = DbConverterUtils.ConvertString(dataRow["category"]);
            draftee.TroopType = DbConverterUtils.ConvertString(dataRow["troop_type"]);
            return draftee;
        }
    }
}