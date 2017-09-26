using System;
using System.Data;
using MilitaryCommissariat.Domain;
using MilitaryCommissariat.Utils;

namespace MilitaryCommissariat.Converters
{
    public class DocumentConverter : IConverter<Document, DataTable>
    {
        public Document Convert(DataTable source)
        {
            if (source.Rows.Count != 1)
            {
                throw new Exception("Число строк в переданной таблице отличается от 1");
            }
            DataRow dataRow = source.Rows[0];
            Document result = new Document();
            result.DrafteeId = (long) dataRow["draftee_id"];
            result.PassportSeries = DbConverterUtils.ConvertString(dataRow["passport_series"]);
            result.PassportNumber = DbConverterUtils.ConvertString(dataRow["passport_number"]);
            result.PassportIssueDate = DbConverterUtils.ConvertDateTime(dataRow["passport_issue_date"]);
            result.PassportIssuedBy = DbConverterUtils.ConvertString(dataRow["passport_issued_by"]);
            result.CertificateSeries = DbConverterUtils.ConvertString(dataRow["certificate_series"]);
            result.CertificateNumber = DbConverterUtils.ConvertString(dataRow["certificate_number"]);
            result.CertificateIssueDate = DbConverterUtils.ConvertDateTime(dataRow["certificate_issue_date"]);
            result.TicketSeries = DbConverterUtils.ConvertString(dataRow["ticket_series"]);
            result.TicketNumber = DbConverterUtils.ConvertString(dataRow["ticket_number"]);
            result.TicketIssueDate = DbConverterUtils.ConvertDateTime(dataRow["ticket_issue_date"]);
            return result;
        }
    }
}