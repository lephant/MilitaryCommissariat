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

        public void InsertUpdate(Address address)
        {
            MySqlConnection connection = ConnectionUtils.GetConnection();
            try
            {
                StringBuilder sqlBuilder = new StringBuilder();
                sqlBuilder
                    .Append("INSERT INTO addresses (draftee_id, municipal_district, mail_index, ")
                    .Append("street_name, house_number, housing_number, apartment, home_phone) ")
                    .Append("VALUES (")
                    .AppendFormat("{0}, ", address.DrafteeId)
                    .AppendFormat("'{0}', ", address.MunicipalDistrict)
                    .AppendFormat("'{0}', ", address.MailIndex)
                    .AppendFormat("'{0}', ", address.StreetName)
                    .AppendFormat("'{0}', ", address.HouseNumber)
                    .AppendFormat("'{0}', ", address.HousingNumber)
                    .AppendFormat("'{0}', ", address.Apartment)
                    .AppendFormat("'{0}'", address.HomePhone)
                    .Append(") ")
                    .Append("ON DUPLICATE KEY UPDATE ")
                    .AppendFormat("municipal_district='{0}', ", address.MunicipalDistrict)
                    .AppendFormat("mail_index='{0}', ", address.MailIndex)
                    .AppendFormat("street_name='{0}', ", address.StreetName)
                    .AppendFormat("house_number='{0}', ", address.HouseNumber)
                    .AppendFormat("housing_number='{0}', ", address.HousingNumber)
                    .AppendFormat("apartment='{0}', ", address.Apartment)
                    .AppendFormat("home_phone='{0}'", address.HomePhone)
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