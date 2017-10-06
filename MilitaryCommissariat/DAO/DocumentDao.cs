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
                    .Append("doc.certificate_issue_date certificate_issue_date, ")
                    .Append("doc.ticket_series ticket_series, ")
                    .Append("doc.ticket_number ticket_number, ")
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

        public void InsertUpdate(Document document)
        {
            MySqlConnection connection = ConnectionUtils.GetConnection();
            try
            {
                StringBuilder sqlBuilder = new StringBuilder();
                sqlBuilder
                    .Append("INSERT INTO documents (draftee_id, passport_series, ")
                    .Append("passport_number, passport_issue_date, passport_issued_by, ")
                    .Append("certificate_series, certificate_number, certificate_issue_date, ")
                    .Append("ticket_series, ticket_number, ticket_issue_date) ")
                    .Append("VALUES (")
                    .AppendFormat("{0}, ", document.DrafteeId)
                    .AppendFormat("'{0}', ", document.PassportSeries)
                    .AppendFormat("'{0}', ", document.PassportNumber)
                    .AppendFormat("{0}, ",
                        document.PassportIssueDate != null
                            ? "'" + document.PassportIssueDate?.ToString("yyyy-MM-dd") + "'"
                            : "NULL")
                    .AppendFormat("'{0}', ", document.PassportIssuedBy)
                    .AppendFormat("'{0}', ", document.CertificateSeries)
                    .AppendFormat("'{0}', ", document.CertificateNumber)
                    .AppendFormat("{0}, ",
                        document.CertificateIssueDate != null
                            ? "'" + document.CertificateIssueDate?.ToString("yyyy-MM-dd") + "'"
                            : "NULL")
                    .AppendFormat("'{0}', ", document.TicketSeries)
                    .AppendFormat("'{0}', ", document.TicketNumber)
                    .AppendFormat("{0}",
                        document.TicketIssueDate != null
                            ? "'" + document.TicketIssueDate?.ToString("yyyy-MM-dd") + "'"
                            : "NULL")
                    .Append(") ")
                    .Append("ON DUPLICATE KEY UPDATE ")
                    .AppendFormat("passport_series='{0}', ", document.PassportSeries)
                    .AppendFormat("passport_number='{0}', ", document.PassportNumber)
                    .AppendFormat("passport_issue_date={0}, ",
                        document.PassportIssueDate != null
                            ? "'" + document.PassportIssueDate?.ToString("yyyy-MM-dd") + "'"
                            : "NULL")
                    .AppendFormat("passport_issued_by='{0}', ", document.PassportIssuedBy)
                    .AppendFormat("certificate_series='{0}', ", document.CertificateSeries)
                    .AppendFormat("certificate_number='{0}', ", document.CertificateSeries)
                    .AppendFormat("certificate_issue_date={0}, ",
                        document.CertificateIssueDate != null
                            ? "'" + document.CertificateIssueDate?.ToString("yyyy-MM-dd") + "'"
                            : "NULL")
                    .AppendFormat("ticket_series='{0}', ", document.TicketSeries)
                    .AppendFormat("ticket_number='{0}', ", document.TicketNumber)
                    .AppendFormat("ticket_issue_date={0}",
                        document.TicketIssueDate != null
                            ? "'" + document.TicketIssueDate?.ToString("yyyy-MM-dd") + "'"
                            : "NULL")
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