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
    /// Interaction logic for EditDrafteeCommonInfoWindow.xaml
    /// </summary>
    public partial class EditDrafteeCommonInfoWindow : Window
    {
        public static DependencyProperty DrafteeProperty;
        public static DependencyProperty LastNameProperty;
        public static DependencyProperty FirstNameProperty;
        public static DependencyProperty PatronymicProperty;
        public static DependencyProperty BirthDateProperty;
        public static DependencyProperty BirthPlaceProperty;
        public static DependencyProperty CategoryProperty;
        public static DependencyProperty TroopTypeProperty;

        public static DependencyProperty AddressProperty;
        public static DependencyProperty MunicipalDistrictProperty;
        public static DependencyProperty MailIndexProperty;
        public static DependencyProperty StreetNameProperty;
        public static DependencyProperty HouseNumberProperty;
        public static DependencyProperty HousingNumberProperty;
        public static DependencyProperty ApartmentProperty;
        public static DependencyProperty HomePhoneProperty;

        public long DrafteeId { get; set; }

        public EditDrafteeCommonInfoWindow()
        {
            InitializeComponent();
            Loaded += OnLoaded;
        }

        static EditDrafteeCommonInfoWindow()
        {
            DrafteeProperty = DependencyProperty.Register("Draftee", typeof(Draftee),
                typeof(EditDrafteeCommonInfoWindow), new FrameworkPropertyMetadata(OnDrafteePropertyChanged));
            LastNameProperty = DependencyProperty.Register("LastName", typeof(string),
                typeof(EditDrafteeCommonInfoWindow), new FrameworkPropertyMetadata(OnLastNamePropertyChanged));
            FirstNameProperty = DependencyProperty.Register("FirstName", typeof(string),
                typeof(EditDrafteeCommonInfoWindow), new FrameworkPropertyMetadata(OnFirstNamePropertyChanged));
            PatronymicProperty = DependencyProperty.Register("Patronymic", typeof(string),
                typeof(EditDrafteeCommonInfoWindow), new FrameworkPropertyMetadata(OnPatronymicPropertyChanged));
            BirthDateProperty = DependencyProperty.Register("BirthDate", typeof(string),
                typeof(EditDrafteeCommonInfoWindow), new FrameworkPropertyMetadata(OnBirthDatePropertyChanged));
            BirthPlaceProperty = DependencyProperty.Register("BirthPlace", typeof(string),
                typeof(EditDrafteeCommonInfoWindow), new FrameworkPropertyMetadata(OnBirthPlacePropertyChanged));
            CategoryProperty = DependencyProperty.Register("Category", typeof(string),
                typeof(EditDrafteeCommonInfoWindow), new FrameworkPropertyMetadata(OnCategoryPropertyChanged));
            TroopTypeProperty = DependencyProperty.Register("TroopType", typeof(string),
                typeof(EditDrafteeCommonInfoWindow), new FrameworkPropertyMetadata(OnTroopTypePropertyChanged));

            AddressProperty = DependencyProperty.Register("Address", typeof(Address),
                typeof(EditDrafteeCommonInfoWindow), new FrameworkPropertyMetadata(OnAddressPropertyChanged));
            MunicipalDistrictProperty = DependencyProperty.Register("MunicipalDistrict", typeof(string),
                typeof(EditDrafteeCommonInfoWindow), new FrameworkPropertyMetadata(OnMunicipalDistrictPropertyChanged));
            MailIndexProperty = DependencyProperty.Register("MailIndex", typeof(string),
                typeof(EditDrafteeCommonInfoWindow), new FrameworkPropertyMetadata(OnMailIndexPropertyChanged));
            StreetNameProperty = DependencyProperty.Register("StreetName", typeof(string),
                typeof(EditDrafteeCommonInfoWindow), new FrameworkPropertyMetadata(OnStreetNamePropertyChanged));
            HouseNumberProperty = DependencyProperty.Register("HouseNumber", typeof(string),
                typeof(EditDrafteeCommonInfoWindow), new FrameworkPropertyMetadata(OnHouseNumberPropertyChanged));
            HousingNumberProperty = DependencyProperty.Register("HousingNumber", typeof(string),
                typeof(EditDrafteeCommonInfoWindow), new FrameworkPropertyMetadata(OnHousingNumberPropertyChanged));
            ApartmentProperty = DependencyProperty.Register("Apartment", typeof(string),
                typeof(EditDrafteeCommonInfoWindow), new FrameworkPropertyMetadata(OnApartmentPropertyChanged));
            HomePhoneProperty = DependencyProperty.Register("HomePhone", typeof(string),
                typeof(EditDrafteeCommonInfoWindow), new FrameworkPropertyMetadata(OnHomePhonePropertyChanged));
        }

        private static void OnDrafteePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private static void OnLastNamePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private static void OnFirstNamePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private static void OnPatronymicPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private static void OnBirthDatePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private static void OnBirthPlacePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private static void OnCategoryPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private static void OnTroopTypePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private static void OnAddressPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private static void OnMunicipalDistrictPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private static void OnMailIndexPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private static void OnStreetNamePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private static void OnHouseNumberPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private static void OnHousingNumberPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private static void OnApartmentPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private static void OnHomePhonePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {
            //draftee = GetCurrentDraftee();
            //address = GetCurrentAddress();
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
    }
}