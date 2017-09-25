using System.Data;
using System.Text;
using MilitaryCommissariat.Domain;
using MilitaryCommissariat.Utils;
using MySql.Data.MySqlClient;

namespace MilitaryCommissariat.DAO
{
    public class EducationPlaceDao
    {
        public DataTable GetListByDraftee(long id)
        {
            try
            {
                StringBuilder sqlBuilder = new StringBuilder();
                sqlBuilder
                    .Append("SELECT ")
                    .Append("pl.id id, ")
                    .Append("pl.draftee_id draftee_id, ")
                    .Append("pl.name name, ")
                    .Append("pl.education education, ")
                    .Append("pl.institution_type institution_type, ")
                    .Append("pl.end_date end_date, ")
                    .Append("pl.faculty faculty, ")
                    .Append("pl.specialty specialty ")
                    .Append("FROM education_places pl ")
                    .Append("WHERE pl.draftee_id=")
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
                    .Append("DELETE FROM education_places ")
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

        public void Delete(EducationPlace educationPlace)
        {
            Delete(educationPlace.Id);
        }

        public void Update(EducationPlace educationPlace)
        {
            MySqlConnection connection = ConnectionUtils.GetConnection();
            try
            {
                StringBuilder sqlBuilder = new StringBuilder();
                sqlBuilder
                    .Append("UPDATE education_places SET ")
                    .Append("name='")
                    .Append(educationPlace.Name)
                    .Append("', ")
                    .Append("education='")
                    .Append(educationPlace.Education)
                    .Append("', ")
                    .Append("institution_type='")
                    .Append(educationPlace.InstitutionType)
                    .Append("', ")
                    .Append("end_date='")
                    .Append(educationPlace.EndDate.ToString("yyyy-MM-dd"))
                    .Append("', ")
                    .Append("faculty='")
                    .Append(educationPlace.Faculty)
                    .Append("', ")
                    .Append("specialty='")
                    .Append(educationPlace.Specialty)
                    .Append("' ")
                    .Append("WHERE id=")
                    .Append(educationPlace.Id)
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

        public void Insert(EducationPlace educationPlace)
        {
            MySqlConnection connection = ConnectionUtils.GetConnection();
            try
            {
                StringBuilder sqlBuilder = new StringBuilder();
                sqlBuilder
                    .Append("INSERT INTO education_places ")
                    .Append("(draftee_id, name, education, institution_type, end_date, faculty, specialty) ")
                    .Append("VALUES (")
                    .Append(educationPlace.DrafteeId)
                    .Append(", ")
                    .Append("'")
                    .Append(educationPlace.Name)
                    .Append("', ")
                    .Append("'")
                    .Append(educationPlace.Education)
                    .Append("', ")
                    .Append("'")
                    .Append(educationPlace.InstitutionType)
                    .Append("', ")
                    .Append("'")
                    .Append(educationPlace.EndDate.ToString("yyyy-MM-dd"))
                    .Append("', ")
                    .Append("'")
                    .Append(educationPlace.Faculty)
                    .Append("', ")
                    .Append("'")
                    .Append(educationPlace.Specialty)
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