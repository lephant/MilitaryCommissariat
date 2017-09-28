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
    /// Interaction logic for DrafteeCommonInfoWindow.xaml
    /// </summary>
    public partial class DrafteeCommonInfoWindow : Window
    {
        public long DrafteeId { get; set; }

        public DrafteeCommonInfoWindow()
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
            BirthDateValueLabel.Content = draftee.BirthDate.ToString("yyyy.MM.dd");
            BirthPlaceValueLabel.Text = draftee.BirthPlace;
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
    }
}
