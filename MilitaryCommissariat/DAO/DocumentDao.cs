using System.Data;
using System.Text;
using MilitaryCommissariat.Domain;
using MilitaryCommissariat.Utils;
using MySql.Data.MySqlClient;

namespace MilitaryCommissariat.DAO
{
    public class DocumentDao
    {
        public DataTable GetByDraftee(long id)
        {
            try
            {
                StringBuilder sqlBuilder = new StringBuilder();
                sqlBuilder
                    .Append("SELECT ")
                    .Append("doc.draftee_id draftee_id, ")
                    .Append("doc.passport_series passport_series, ")
                    .Append("doc.passport_number passport_number, ")
                    .Append("doc.passport_issue_date passport_issue_date, ")
                    .Append("doc.passport_issued_by passport_issued_by, ")
                    .Append("doc.certificate_series certificate_series, ")
                    .Append("doc.certificate_number certificate_number, ")
                    .Append("doc.certificate_issue_date certificate_issue_date ")
                    .Append("doc.ticket_series ticket_series ")
                    .Append("doc.ticket_number ticket_number ")
                    .Append("doc.ticket_issue_date ticket_issue_date ")
                    .Append("FROM documents doc ")
                    .Append("WHERE doc.draftee_id=")
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

        public void Update(Document document)
        {
            MySqlConnection connection = ConnectionUtils.GetConnection();
            try
            {
                StringBuilder sqlBuilder = new StringBuilder();
                sqlBuilder
                    .Append("UPDATE addresses SET ")
                    .Append("passport_series='")
                    .Append(document.PassportSeries)
                    .Append("', ")
                    .Append("passport_number='")
                    .Append(document.PassportNumber)
                    .Append("', ")
                    .Append("passport_issue_date='")
                    .Append(document.PassportIssueDate.ToString("yyyy-MM-dd"))
                    .Append("', ")
                    .Append("passport_issued_by='")
                    .Append(document.PassportIssuedBy)
                    .Append("', ")
                    .Append("certificate_series='")
                    .Append(document.CertificateSeries)
                    .Append("', ")
                    .Append("certificate_number='")
                    .Append(document.CertificateNumber)
                    .Append("', ")
                    .Append("certificate_issue_date='")
                    .Append(document.CertificateIssueDate.ToString("yyyy-MM-dd"))
                    .Append("' ")
                    .Append("ticket_series='")
                    .Append(document.TicketSeries)
                    .Append("' ")
                    .Append("ticket_number='")
                    .Append(document.TicketNumber)
                    .Append("' ")
                    .Append("ticket_issue_date='")
                    .Append(document.TicketIssueDate.ToString("yyyy-MM-dd"))
                    .Append("' ")
                    .Append("WHERE draftee_id=")
                    .Append(document.DrafteeId)
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