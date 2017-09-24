using System.Data;
using System.Text;
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
                if (!string.IsNullOrEmpty(criteria.FullName))
                {
                    sqlBuilder.Append("HAVING full_name LIKE '%")
                        .Append(criteria.FullName)
                        .Append("%' ");
                    havingExists = true;
                }
                if (criteria.BirthYear != null)
                {
                    if (!havingExists)
                    {
                        sqlBuilder.Append("HAVING ");
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
    }
}