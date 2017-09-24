using System;
using System.Collections.Generic;
using System.Data;
using MilitaryCommissariat.Domain;

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
                draftee.LastName = (string) dataRow["last_name"];
                draftee.FirstName = (string) dataRow["first_name"];
                draftee.Patronymic = (string) dataRow["patronymic"];
                draftee.BirthDate = (DateTime) dataRow["birth_date"];
                draftee.Category = (string) dataRow["category"];
                draftee.TroopType = (string) dataRow["troop_type"];
                result.Add(draftee);
            }
            return result;
        }
    }
}