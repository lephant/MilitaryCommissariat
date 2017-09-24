using System;
using System.Data;
using MilitaryCommissariat.Domain;

namespace MilitaryCommissariat.Converters
{
    public class DrafteeConverter : IConverter<Draftee, DataTable>
    {
        public Draftee Convert(DataTable source)
        {
            if (source.Rows.Count != 1)
            {
                throw new Exception("Число строк в переданной таблице отличается от 1");
            }
            DataRow dataRow = source.Rows[0];
            Draftee draftee = new Draftee();
            draftee.Id = (long)dataRow["id"];
            draftee.LastName = (string)dataRow["last_name"];
            draftee.FirstName = (string)dataRow["first_name"];
            draftee.Patronymic = (string)dataRow["patronymic"];
            draftee.BirthDate = (DateTime)dataRow["birth_date"];
            draftee.Category = (string)dataRow["category"];
            draftee.TroopType = (string)dataRow["troop_type"];
            return draftee;
        }
    }
}