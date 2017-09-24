using System.Data;
using System.Text;
using MilitaryCommissariat.Domain;
using MilitaryCommissariat.Utils;
using MySql.Data.MySqlClient;

namespace MilitaryCommissariat.DAO
{
    public class AddressDao
    {
        public DataTable GetByDraftee(long id)
        {
            try
            {
                StringBuilder sqlBuilder = new StringBuilder();
                sqlBuilder
                    .Append("SELECT ")
                    .Append("addr.draftee_id draftee_id, ")
                    .Append("addr.municipal_district municipal_district, ")
                    .Append("addr.mail_index mail_index, ")
                    .Append("addr.street_name street_name, ")
                    .Append("addr.house_number house_number, ")
                    .Append("addr.housing_number housing_number, ")
                    .Append("addr.apartment apartment, ")
                    .Append("addr.home_phone home_phone ")
                    .Append("FROM addresses addr ")
                    .Append("WHERE draftee_id=")
                    .Append(id)
                    .Append(";");
                var dataAdapter = new MySqlDataAdapter(sqlBuilder.ToString(), ConnectionUtils.GetConnection());
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                return dataTable;
            }
            catch
            {
                return null;
            }
        }

        public DataTable GetByDraftee(Draftee draftee)
        {
            return GetByDraftee(draftee.Id);
        }

        public DataTable GetByDraftee(TableDraftee tableDraftee)
        {
            return GetByDraftee(tableDraftee.Id);
        }

        public void Update(Address address)
        {
            MySqlConnection connection = ConnectionUtils.GetConnection();
            try
            {
                StringBuilder sqlBuilder = new StringBuilder();
                sqlBuilder
                    .Append("UPDATE addresses SET ")
                    .Append("municipal_district='")
                    .Append(address.MunicipalDistrict)
                    .Append("', ")
                    .Append("mail_index='")
                    .Append(address.MailIndex)
                    .Append("', ")
                    .Append("street_name='")
                    .Append(address.StreetName)
                    .Append("', ")
                    .Append("house_number='")
                    .Append(address.HouseNumber)
                    .Append("', ")
                    .Append("housing_number='")
                    .Append(address.HousingNumber)
                    .Append("', ")
                    .Append("apartment='")
                    .Append(address.Apartment)
                    .Append("', ")
                    .Append("home_phone='")
                    .Append(address.HomePhone)
                    .Append("' ")
                    .Append("WHERE draftee_id=")
                    .Append(address.DrafteeId)
                    .Append(";");
                MySqlCommand command = new MySqlCommand(sqlBuilder.ToString(), connection);
                connection.Open();
                command.ExecuteNonQuery();
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
