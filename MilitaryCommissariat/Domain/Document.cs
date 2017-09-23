using System;

namespace MilitaryCommissariat.Domain
{
    public class Document
    {
        public long DrafteeId { get; set; }
        public string PassportSeries { get; set; }
        public string PassportNumber { get; set; }
        public DateTime PassportIssueDate { get; set; }
        public string PassportIssuedBy { get; set; }
        public string CertificateSeries { get; set; }
        public string CertificateNumber { get; set; }
        public DateTime CertificateIssueDate { get; set; }
        public string TicketSeries { get; set; }
        public string TicketNumber { get; set; }
        public DateTime TicketIssueDate { get; set; }
    }
}
