using System.Windows;
using MilitaryCommissariat.Converters;
using MilitaryCommissariat.DAO;
using MilitaryCommissariat.Domain;

namespace MilitaryCommissariat.Windows
{
    /// <summary>
    /// Interaction logic for DrafteeAddressWindow.xaml
    /// </summary>
    public partial class DrafteeAddressWindow : Window
    {
        public long DrafteeId { get; set; }

        public DrafteeAddressWindow()
        {
            InitializeComponent();
            Loaded += OnLoaded;
        }

        private void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {
            FillData(GetCurrentDraftee());
            FillData(GetCurrentAddress());
        }

        private Draftee GetCurrentDraftee()
        {
            var dao = new DrafteeDao();
            var converter = new DrafteeConverter();
            return converter.Convert(dao.GetById(DrafteeId));
        }

        private Address GetCurrentAddress()
        {
            var dao = new AddressDao();
            var converter = new AddressConverter();
            return converter.Convert(dao.GetByDraftee(DrafteeId));
        }

        private void FillData(Draftee draftee)
        {
            FirstNameValueLabel.Content = draftee.FirstName;
            LastNameValueLabel.Content = draftee.LastName;
            PatronymicValueLabel.Content = draftee.Patronymic;
            BirthDateValueLabel.Content = draftee.BirthDate?.ToString("yyyy.MM.dd");
        }

        private void FillData(Address address)
        {
            MunicipalDistrictValueLabel.Text = address.MunicipalDistrict;
            MailIndexValueLabel.Text = address.MailIndex;
            StreetNameValueLabel.Text = address.StreetName;
            HouseNumberValueLabel.Text = address.HouseNumber;
            HousingNumberValueLabel.Text = address.HousingNumber;
            ApartmentValueLabel.Text = address.Apartment;
            HomePhoneValueLabel.Text = address.HomePhone;
        }

        public void Refresh()
        {
            FillData(GetCurrentDraftee());
            FillData(GetCurrentAddress());
        }

        private void ReturnButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            OpenEditDrafteeCommonInfoWindow();
        }

        private void OpenEditDrafteeCommonInfoWindow()
        {
            var window = new EditDrafteeAddressWindow();
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
    }
}
