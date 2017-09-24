using System.Data;
using System.Text;
using MilitaryCommissariat.Domain;
using MilitaryCommissariat.SearchCriterias;
using MilitaryCommissariat.Utils;
using MySql.Data.MySqlClient;

namespace MilitaryCommissariat.DAO
{
    public class DrafteeDao
    {
        public DataTable GetList()
        {
            try
            {
                StringBuilder sqlBuilder = new StringBuilder();
                sqlBuilder
                    .Append("SELECT dr.id id, dr.last_name last_name, dr.first_name first_name, ")
                    .Append("dr.patronymic patronymic, dr.birth_date birth_date, dr.category category, ")
                    .Append("dr.troop_type troop_type ")
                    .Append("FROM draftees dr;");
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

        public DataTable GetListByCriteria(TableDrafteeCriteria criteria)
        {
            try
            {
                StringBuilder sqlBuilder = new StringBuilder();
                sqlBuilder
                    .Append("SELECT dr.id id, ")
                    .Append("CONCAT(dr.last_name, ' ', dr.first_name, ' ', dr.patronymic) full_name, ")
                    .Append("YEAR(dr.birth_date) birth_year ")
                    .Append("FROM draftees dr ");

                bool havingExists = false;
                bool needAnd = false;
                if (!string.IsNullOrEmpty(criteria.FullName))
                {
                    sqlBuilder.Append("HAVING full_name LIKE '%")
                        .Append(criteria.FullName)
                        .Append("%' ");
                    havingExists = true;
                    needAnd = true;
                }
                if (criteria.BirthYear != null)
                {
                    if (!havingExists)
                    {
                        sqlBuilder.Append("HAVING ");
                    }
                    if (needAnd)
                    {
                        sqlBuilder.Append("AND ");
                    }
                    sqlBuilder.Append("birth_year=")
                        .Append(criteria.BirthYear.Value)
                        .Append(" ");
                }

                sqlBuilder.Append(";");
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

        public DataTable GetById(long id)
        {
            try
            {
                StringBuilder sqlBuilder = new StringBuilder();
                sqlBuilder
                    .Append("SELECT dr.id id, dr.last_name last_name, dr.first_name first_name, ")
                    .Append("dr.patronymic patronymic, dr.birth_date birth_date, dr.category category, ")
                    .Append("dr.troop_type troop_type ")
                    .Append("FROM draftees dr ")
                    .Append("WHERE id=")
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

        public void Delete(long id)
        {
            MySqlConnection connection = ConnectionUtils.GetConnection();
            try
            {
                StringBuilder sqlBuilder = new StringBuilder();
                sqlBuilder
                    .Append("DELETE FROM draftees ")
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

        public void Delete(Draftee draftee)
        {
            Delete(draftee.Id);
        }

        public void Delete(TableDraftee tableDraftee)
        {
            Delete(tableDraftee.Id);
        }

        public void Update(Draftee draftee)
        {
            MySqlConnection connection = ConnectionUtils.GetConnection();
            try
            {
                StringBuilder sqlBuilder = new StringBuilder();
                sqlBuilder
                    .Append("UPDATE draftees SET ")
                    .Append("last_name='")
                    .Append(draftee.LastName)
                    .Append("', ")
                    .Append("first_name='")
                    .Append(draftee.FirstName)
                    .Append("', ")
                    .Append("patronymic='")
                    .Append(draftee.Patronymic)
                    .Append("', ")
                    .Append("birth_date='")
                    .Append(draftee.BirthDate.ToString("yyyy-MM-dd"))
                    .Append("', ")
                    .Append("category='")
                    .Append(draftee.Category)
                    .Append("', ")
                    .Append("troop_type='")
                    .Append(draftee.TroopType)
                    .Append("' ")
                    .Append("WHERE id=")
                    .Append(draftee.Id)
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