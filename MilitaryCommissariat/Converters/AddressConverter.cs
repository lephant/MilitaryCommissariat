using System;
using System.Data;
using MilitaryCommissariat.Domain;

namespace MilitaryCommissariat.Converters
{
    public class AddressConverter : IConverter<Address, DataTable>
    {
        public Address Convert(DataTable source)
        {
            if (source.Rows.Count != 1)
            {
                throw new Exception("Число строк в переданной таблице отличается от 1");
            }
            DataRow dataRow = source.Rows[0];
            Address result = new Address();
            result.DrafteeId = (long) dataRow["draftee_id"];
            result.MunicipalDistrict = Convert(dataRow["municipal_district"]);
            result.MailIndex = Convert(dataRow["mail_index"]);
            result.StreetName = Convert(dataRow["street_name"]);
            result.HouseNumber = Convert(dataRow["house_number"]);
            result.HousingNumber = Convert(dataRow["housing_number"]);
            result.Apartment = Convert(dataRow["apartment"]);
            result.HomePhone = Convert(dataRow["home_phone"]);
            return result;
        }

        private string Convert(object source)
        {
            if (System.Convert.IsDBNull(source))
            {
                return "";
            }
            return (string) source;
        }
    }
}