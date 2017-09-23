using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using MilitaryCommissariat.Utils;
using MySql.Data.MySqlClient;

namespace MilitaryCommissariat
{
    public class DrafteeDao
    {
        public DataTable GetList()
        {
            MySqlConnection connection = ConnectionUtils.GetConnection();
            try
            {
                StringBuilder sqlBuilder = new StringBuilder();
                sqlBuilder
                    .Append("SELECT dr.id id, dr.last_name last_name, dr.first_name first_name, ")
                    .Append("dr.patronymic patronymic, dr.birth_date birth_date, dr.category category, ")
                    .Append("dr.troop_type troop_type ")
                    .Append("FROM draftees dr;");
                String sql = sqlBuilder.ToString();
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(sql, connection);
                DataTable dataTable = new DataTable();
                connection.Open();
                dataAdapter.Fill(dataTable);
                return dataTable;
            }
            catch
            {
                return null;
            }
            finally
            {
                connection?.Close();
            }
        }
    }
}