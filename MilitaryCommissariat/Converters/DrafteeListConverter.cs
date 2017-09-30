using System;
using System.Collections.Generic;
using System.Data;
using MilitaryCommissariat.Domain;
using MilitaryCommissariat.Utils;

namespace MilitaryCommissariat.Converters
{
    public class DrafteeListConverter : IConverter<List<Draftee>, DataTable>
    {
        public List<Draftee> Convert(DataTable source)
        {
            List<Draftee> result = new List<Draftee>(source.Rows.Count);
            foreach (DataRow dataRow in source.Rows)
            {
                Draftee draftee = new Draftee();
                draftee.Id = (long) dataRow["id"];
                draftee.LastName = DbConverterUtils.ConvertString(dataRow["last_name"]);
                draftee.FirstName = DbConverterUtils.ConvertString(dataRow["first_name"]);
                draftee.Patronymic = DbConverterUtils.ConvertString(dataRow["patronymic"]);
                draftee.BirthDate = (DateTime) DbConverterUtils.ConvertDateTime(dataRow["birth_date"]);
                draftee.BirthPlace = DbConverterUtils.ConvertString(dataRow["birth_place"]);
                draftee.Category = DbConverterUtils.ConvertString(dataRow["category"]);
                draftee.TroopType = DbConverterUtils.ConvertString(dataRow["troop_type"]);
                draftee.ForeignLanguages = DbConverterUtils.ConvertString(dataRow["foreign_languages"]);
                result.Add(draftee);
            }
            return result;
        }
    }
}