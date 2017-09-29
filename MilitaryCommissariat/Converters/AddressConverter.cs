using System;
using System.Data;
using MilitaryCommissariat.Domain;
using MilitaryCommissariat.Utils;

namespace MilitaryCommissariat.Converters
{
    public class AddressConverter : IConverter<Address, DataTable>
    {
        public Address Convert(DataTable source)
        {
            if (source == null || source.Rows.Count < 1)
            {
                return null;
            }
            DataRow dataRow = source.Rows[0];
            Address result = new Address();
            result.DrafteeId = (long) dataRow["draftee_id"];
            result.MunicipalDistrict = DbConverterUtils.ConvertString(dataRow["municipal_district"]);
            result.MailIndex = DbConverterUtils.ConvertString(dataRow["mail_index"]);
            result.StreetName = DbConverterUtils.ConvertString(dataRow["street_name"]);
            result.HouseNumber = DbConverterUtils.ConvertString(dataRow["house_number"]);
            result.HousingNumber = DbConverterUtils.ConvertString(dataRow["housing_number"]);
            result.Apartment = DbConverterUtils.ConvertString(dataRow["apartment"]);
            result.HomePhone = DbConverterUtils.ConvertString(dataRow["home_phone"]);
            return result;
        }
    }
}