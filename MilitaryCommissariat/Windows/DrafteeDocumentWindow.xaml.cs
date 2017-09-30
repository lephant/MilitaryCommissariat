using System.Windows;
using MilitaryCommissariat.Converters;
using MilitaryCommissariat.DAO;
using MilitaryCommissariat.Domain;

namespace MilitaryCommissariat.Windows
{
    /// <summary>
    /// Interaction logic for DrafteeDocumentWindow.xaml
    /// </summary>
    public partial class DrafteeDocumentWindow : Window
    {
        public long DrafteeId { get; set; }

        public DrafteeDocumentWindow()
        {
            InitializeComponent();
            Loaded += OnLoaded;
        }

        private void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {
            FillData(GetCurrentDraftee());
            FillData(GetCurrentDocument());
        }

        private void SelectButton_OnClick(object sender, RoutedEventArgs e)
        {
            OpenEditDrafteeDocumentWindow();
        }

        private void ReturnButton_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void OpenEditDrafteeDocumentWindow()
        {
            var window = new EditDrafteeDocumentWindow();
            window.Owner = this;
            window.DrafteeId = DrafteeId;
            Hide();
            window.Closed += (sender, args) =>
            {
                Refresh();
                Show();
            };
            window.Show();
        }

        private Draftee GetCurrentDraftee()
        {
            var dao = new DrafteeDao();
            var converter = new DrafteeConverter();
            return converter.Convert(dao.GetById(DrafteeId));
        }

        private Document GetCurrentDocument()
        {
            var dao = new DocumentDao();
            var converter = new DocumentConverter();
            return converter.Convert(dao.GetByDraftee(DrafteeId));
        }

        private void FillData(Draftee draftee)
        {
            FirstNameValueLabel.Content = draftee.FirstName;
            LastNameValueLabel.Content = draftee.LastName;
            PatronymicValueLabel.Content = draftee.Patronymic;
            BirthDateValueLabel.Content = draftee.BirthDate?.ToString("yyyy.MM.dd");
        }

        private void FillData(Document document)
        {
            PassportSeriesLabel.Content = "Серия: " + document.PassportSeries;
            PassportNumberLabel.Content = "Номер: " + document.PassportNumber;
            PassportIssueDateLabel.Content = "Дата выдачи: " + document.PassportIssueDate?.ToString("yyyy.MM.dd");
            PassportIssuedByLabel.Content = "Кем выдан: " + document.PassportIssuedBy;

            CertificateSeriesLabel.Content = "Серия: " + document.CertificateSeries;
            CertificateNumberLabel.Content = "Номер: " + document.CertificateNumber;
            CertificateIssueDateLabel.Content = "Дата выдачи: " + document.CertificateIssueDate?.ToString("yyyy.MM.dd");

            TicketSeriesLabel.Content = "Серия: " + document.TicketSeries;
            TicketNumberLabel.Content = "Номер: " + document.TicketNumber;
            TicketIssueDateLabel.Content = "Дата выдачи: " + document.TicketIssueDate?.ToString("yyyy.MM.dd");
        }

        public void Refresh()
        {
            FillData(GetCurrentDraftee());
            FillData(GetCurrentDocument());
        }
    }
}