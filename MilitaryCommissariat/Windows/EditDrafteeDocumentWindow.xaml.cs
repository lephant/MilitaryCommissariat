using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MilitaryCommissariat.Converters;
using MilitaryCommissariat.DAO;
using MilitaryCommissariat.Domain;

namespace MilitaryCommissariat.Windows
{
    /// <summary>
    /// Interaction logic for EditDrafteeDocumentWindow.xaml
    /// </summary>
    public partial class EditDrafteeDocumentWindow : Window
    {
        public long DrafteeId { get; set; }

        public static DependencyProperty DocumentProperty;
        public static DependencyProperty PassportSeriesProperty;
        public static DependencyProperty PassportNumberProperty;
        public static DependencyProperty PassportIssueDateProperty;
        public static DependencyProperty PassportIssuedByProperty;
        public static DependencyProperty CertificateSeriesProperty;
        public static DependencyProperty CertificateNumberProperty;
        public static DependencyProperty CertificateIssueDateProperty;
        public static DependencyProperty TicketSeriesProperty;
        public static DependencyProperty TicketNumberProperty;
        public static DependencyProperty TicketIssueDateProperty;

        static EditDrafteeDocumentWindow()
        {
            DocumentProperty = DependencyProperty.Register("Document", typeof(Document),
                typeof(EditDrafteeDocumentWindow), new FrameworkPropertyMetadata(OnDocumentChanged));

            PassportSeriesProperty = DependencyProperty.Register("PassportSeries", typeof(string),
                typeof(EditDrafteeDocumentWindow), new FrameworkPropertyMetadata(OnDocumentPropertyChanged));
            PassportNumberProperty = DependencyProperty.Register("PassportNumber", typeof(string),
                typeof(EditDrafteeDocumentWindow), new FrameworkPropertyMetadata(OnDocumentPropertyChanged));
            PassportIssueDateProperty = DependencyProperty.Register("PassportIssueDate", typeof(DateTime?),
                typeof(EditDrafteeDocumentWindow), new FrameworkPropertyMetadata(OnDocumentPropertyChanged));
            PassportIssuedByProperty = DependencyProperty.Register("PassportIssuedBy", typeof(string),
                typeof(EditDrafteeDocumentWindow), new FrameworkPropertyMetadata(OnDocumentPropertyChanged));

            CertificateSeriesProperty = DependencyProperty.Register("CertificateSeries", typeof(string),
                typeof(EditDrafteeDocumentWindow), new FrameworkPropertyMetadata(OnDocumentPropertyChanged));
            CertificateNumberProperty = DependencyProperty.Register("CertificateNumber", typeof(string),
                typeof(EditDrafteeDocumentWindow), new FrameworkPropertyMetadata(OnDocumentPropertyChanged));
            CertificateIssueDateProperty = DependencyProperty.Register("CertificateIssueDate", typeof(DateTime?),
                typeof(EditDrafteeDocumentWindow), new FrameworkPropertyMetadata(OnDocumentPropertyChanged));

            TicketSeriesProperty = DependencyProperty.Register("TicketSeries", typeof(string),
                typeof(EditDrafteeDocumentWindow), new FrameworkPropertyMetadata(OnDocumentPropertyChanged));
            TicketNumberProperty = DependencyProperty.Register("TicketNumber", typeof(string),
                typeof(EditDrafteeDocumentWindow), new FrameworkPropertyMetadata(OnDocumentPropertyChanged));
            TicketIssueDateProperty = DependencyProperty.Register("TicketIssueDate", typeof(DateTime?),
                typeof(EditDrafteeDocumentWindow), new FrameworkPropertyMetadata(OnDocumentPropertyChanged));
        }

        public EditDrafteeDocumentWindow()
        {
            InitializeComponent();
            Loaded += OnLoaded;
        }

        private void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {
            FillData(GetCurrentDraftee());
            var dao = new DocumentDao();
            var converter = new DocumentConverter();
            var document = converter.Convert(dao.GetByDraftee(DrafteeId));
            if (document != null)
            {
                Document = document;
            }
            else
            {
                Document = new Document();
            }
        }

        private Draftee GetCurrentDraftee()
        {
            var dao = new DrafteeDao();
            var converter = new DrafteeConverter();
            return converter.Convert(dao.GetById(DrafteeId));
        }

        private void FillData(Draftee draftee)
        {
            FirstNameValueLabel.Content = draftee.FirstName;
            LastNameValueLabel.Content = draftee.LastName;
            PatronymicValueLabel.Content = draftee.Patronymic;
            BirthDateValueLabel.Content = draftee.BirthDate?.ToString("yyyy.MM.dd");
        }

        private void ReturnButton_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void EditButton_OnClick(object sender, RoutedEventArgs e)
        {
            var dao = new DocumentDao();
            dao.Update(Document);
            Close();
        }

        private static void OnDocumentChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            Document newDocument = (Document) e.NewValue;
            var view = (EditDrafteeDocumentWindow) sender;

            view.PassportSeries = newDocument.PassportSeries;
            view.PassportNumber = newDocument.PassportNumber;
            if (newDocument.PassportIssueDate != null) view.PassportIssueDate = newDocument.PassportIssueDate;
            view.PassportIssuedBy = newDocument.PassportIssuedBy;

            view.CertificateSeries = newDocument.CertificateSeries;
            view.CertificateNumber = newDocument.CertificateNumber;
            if (newDocument.CertificateIssueDate != null) view.CertificateIssueDate = newDocument.CertificateIssueDate;

            view.TicketSeries = newDocument.TicketSeries;
            view.TicketNumber = newDocument.TicketNumber;
            if (newDocument.TicketIssueDate != null) view.TicketIssueDate = newDocument.TicketIssueDate;
        }

        private static void OnDocumentPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var view = (EditDrafteeDocumentWindow) sender;
            Document document = view.Document;
            if (e.Property == PassportSeriesProperty)
                document.PassportSeries = (string) e.NewValue;
            else if (e.Property == PassportNumberProperty)
                document.PassportNumber = (string) e.NewValue;
            else if (e.Property == PassportIssueDateProperty)
                document.PassportIssueDate = (DateTime?) e.NewValue;
            else if (e.Property == PassportIssuedByProperty)
                document.PassportIssuedBy = (string) e.NewValue;
            else if (e.Property == CertificateSeriesProperty)
                document.CertificateSeries = (string) e.NewValue;
            else if (e.Property == CertificateNumberProperty)
                document.CertificateNumber = (string) e.NewValue;
            else if (e.Property == CertificateIssueDateProperty)
                document.CertificateIssueDate = (DateTime?) e.NewValue;
            else if (e.Property == TicketSeriesProperty)
                document.TicketSeries = (string) e.NewValue;
            else if (e.Property == TicketNumberProperty)
                document.TicketNumber = (string) e.NewValue;
            else if (e.Property == TicketIssueDateProperty)
                document.TicketIssueDate = (DateTime?) e.NewValue;
        }

        public Document Document
        {
            get { return (Document) GetValue(DocumentProperty); }
            set { SetValue(DocumentProperty, value); }
        }

        public string PassportSeries
        {
            get { return (string) GetValue(PassportSeriesProperty); }
            set { SetValue(PassportSeriesProperty, value); }
        }

        public string PassportNumber
        {
            get { return (string) GetValue(PassportNumberProperty); }
            set { SetValue(PassportNumberProperty, value); }
        }

        public DateTime? PassportIssueDate
        {
            get { return (DateTime?) GetValue(PassportIssueDateProperty); }
            set { SetValue(PassportIssueDateProperty, value); }
        }

        public string PassportIssuedBy
        {
            get { return (string) GetValue(PassportIssuedByProperty); }
            set { SetValue(PassportIssuedByProperty, value); }
        }

        public string CertificateSeries
        {
            get { return (string) GetValue(CertificateSeriesProperty); }
            set { SetValue(CertificateSeriesProperty, value); }
        }

        public string CertificateNumber
        {
            get { return (string) GetValue(CertificateNumberProperty); }
            set { SetValue(CertificateNumberProperty, value); }
        }

        public DateTime? CertificateIssueDate
        {
            get { return (DateTime?) GetValue(CertificateIssueDateProperty); }
            set { SetValue(CertificateIssueDateProperty, value); }
        }

        public string TicketSeries
        {
            get { return (string) GetValue(TicketSeriesProperty); }
            set { SetValue(TicketSeriesProperty, value); }
        }

        public string TicketNumber
        {
            get { return (string) GetValue(TicketNumberProperty); }
            set { SetValue(TicketNumberProperty, value); }
        }

        public DateTime? TicketIssueDate
        {
            get { return (DateTime?) GetValue(TicketIssueDateProperty); }
            set { SetValue(TicketIssueDateProperty, value); }
        }
    }
}