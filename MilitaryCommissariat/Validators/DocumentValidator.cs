using MilitaryCommissariat.Domain;

namespace MilitaryCommissariat.Validators
{
    public class DocumentValidator
    {
        public bool Validate(Document document)
        {
            if (document.PassportSeries.Length > 64)
            {
                Message = "Серия паспорта не должна быть больше 64 символов!";
                return false;
            }
            if (document.PassportNumber.Length > 64)
            {
                Message = "Номер паспорта не должен быть больше 64 символов!";
                return false;
            }
            if (document.PassportIssuedBy.Length > 512)
            {
                Message = "Название организация, выдавшей паспорт не должно быть больше 512 символов!";
                return false;
            }
            if (document.CertificateSeries.Length > 64)
            {
                Message = "Серия УГППнВС не должна быть больше 64 символов!";
                return false;
            }
            if (document.CertificateNumber.Length > 64)
            {
                Message = "Номер УГППнВС не должен быть больше 64 символов!";
                return false;
            }
            if (document.TicketSeries.Length > 64)
            {
                Message = "Серия военного билета не должна быть больше 64 символов!";
                return false;
            }
            if (document.TicketNumber.Length > 64)
            {
                Message = "Номер военного билета не должен быть больше 64 символов!";
                return false;
            }
            Message = "OK";
            return true;
        }

        public string Message { get; private set; }
    }
}