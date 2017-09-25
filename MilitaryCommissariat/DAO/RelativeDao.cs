using System.Data;
using System.Text;
using MilitaryCommissariat.Domain;
using MilitaryCommissariat.Utils;

namespace MilitaryCommissariat.DAO
{
    public class RelativeDao
    {
        public DataTable GetListByDraftee(long id)
        {
            try
            {
                StringBuilder sqlBuilder = new StringBuilder();
                sqlBuilder
                    .Append("SELECT ")
                    .Append("rel.id id, ")
                    .Append("rel.draftee_id draftee_id, ")
                    .Append("rel.full_name full_name, ")
                    .Append("rel.birth_year birth_year, ")
                    .Append("rel.birth_place birth_place, ")
                    .Append("rel.work_place work_place ")
                    .Append("FROM relatives rel ")
                    .Append("WHERE rel.draftee_id=")
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

        public DataTable GetListByDraftee(Draftee draftee)
        {
            return GetListByDraftee(draftee.Id);
        }

        public DataTable GetListByDraftee(TableDraftee tableDraftee)
        {
            return GetListByDraftee(tableDraftee.Id);
        }

        public void Delete(long id)
        {
            MySqlConnection connection = ConnectionUtils.GetConnection();
            try
            {
                StringBuilder sqlBuilder = new StringBuilder();
                sqlBuilder
                    .Append("DELETE FROM relatives ")
                    .Append("WHERE id=")
                    .Append(id)
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

        public void Delete(Relative relative)
        {
            Delete(relative.Id);
        }

        public void Update(Relative relative)
        {
            MySqlConnection connection = ConnectionUtils.GetConnection();
            try
            {
                StringBuilder sqlBuilder = new StringBuilder();
                sqlBuilder
                    .Append("UPDATE relatives SET ")
                    .Append("full_name='")
                    .Append(relative.FullName)
                    .Append("', ")
                    .Append("birth_year=")
                    .Append(relative.BirthYear)
                    .Append(", ")
                    .Append("birth_place='")
                    .Append(relative.BirthPlace)
                    .Append("', ")
                    .Append("work_place='")
                    .Append(relative.WorkPlace)
                    .Append("' ")
                    .Append("WHERE id=")
                    .Append(relative.Id)
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

        public void Insert(Relative relative)
        {
            MySqlConnection connection = ConnectionUtils.GetConnection();
            try
            {
                StringBuilder sqlBuilder = new StringBuilder();
                sqlBuilder
                    .Append("INSERT INTO relatives ")
                    .Append("(draftee_id, full_name, birth_year, birth_place, work_place) ")
                    .Append("VALUES (")
                    .Append(relative.DrafteeId)
                    .Append(", ")
                    .Append("'")
                    .Append(relative.FullName)
                    .Append("', ")
                    .Append(relative.BirthYear)
                    .Append(", ")
                    .Append("'")
                    .Append(relative.BirthPlace)
                    .Append("', ")
                    .Append("'")
                    .Append(relative.WorkPlace)
                    .Append("');");
                connection.Open();
                MySqlCommand drafteeCommand = new MySqlCommand(sqlBuilder.ToString(), connection);
                drafteeCommand.ExecuteNonQuery();
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
