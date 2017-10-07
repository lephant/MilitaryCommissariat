using System;
using System.Windows;
using MilitaryCommissariat.Converters;
using MilitaryCommissariat.DAO;
using MilitaryCommissariat.Domain;
using MilitaryCommissariat.Validators;

namespace MilitaryCommissariat.Windows
{
    /// <summary>
    /// Interaction logic for EditDrafteeAddressWindow.xaml
    /// </summary>
    public partial class EditDrafteeAddressWindow : Window
    {
        public static DependencyProperty DrafteeProperty;
        public static DependencyProperty LastNameProperty;
        public static DependencyProperty FirstNameProperty;
        public static DependencyProperty PatronymicProperty;
        public static DependencyProperty BirthDateProperty;

        public static DependencyProperty AddressProperty;
        public static DependencyProperty MunicipalDistrictProperty;
        public static DependencyProperty MailIndexProperty;
        public static DependencyProperty StreetNameProperty;
        public static DependencyProperty HouseNumberProperty;
        public static DependencyProperty HousingNumberProperty;
        public static DependencyProperty ApartmentProperty;
        public static DependencyProperty HomePhoneProperty;

        public long DrafteeId { get; set; }

        public EditDrafteeAddressWindow()
        {
            InitializeComponent();
            Loaded += OnLoaded;
        }

        static EditDrafteeAddressWindow()
        {
            DrafteeProperty = DependencyProperty.Register("Draftee", typeof(Draftee),
                typeof(EditDrafteeAddressWindow), new FrameworkPropertyMetadata(OnDrafteeChanged));
            LastNameProperty = DependencyProperty.Register("LastName", typeof(string),
                typeof(EditDrafteeAddressWindow));
            FirstNameProperty = DependencyProperty.Register("FirstName", typeof(string),
                typeof(EditDrafteeAddressWindow));
            PatronymicProperty = DependencyProperty.Register("Patronymic", typeof(string),
                typeof(EditDrafteeAddressWindow));
            BirthDateProperty = DependencyProperty.Register("BirthDate", typeof(DateTime?),
                typeof(EditDrafteeAddressWindow));

            AddressProperty = DependencyProperty.Register("Address", typeof(Address),
                typeof(EditDrafteeAddressWindow), new FrameworkPropertyMetadata(OnAddressChanged));
            MunicipalDistrictProperty = DependencyProperty.Register("MunicipalDistrict", typeof(string),
                typeof(EditDrafteeAddressWindow), new FrameworkPropertyMetadata(OnAddressPropertyChanged));
            MailIndexProperty = DependencyProperty.Register("MailIndex", typeof(string),
                typeof(EditDrafteeAddressWindow), new FrameworkPropertyMetadata(OnAddressPropertyChanged));
            StreetNameProperty = DependencyProperty.Register("StreetName", typeof(string),
                typeof(EditDrafteeAddressWindow), new FrameworkPropertyMetadata(OnAddressPropertyChanged));
            HouseNumberProperty = DependencyProperty.Register("HouseNumber", typeof(string),
                typeof(EditDrafteeAddressWindow), new FrameworkPropertyMetadata(OnAddressPropertyChanged));
            HousingNumberProperty = DependencyProperty.Register("HousingNumber", typeof(string),
                typeof(EditDrafteeAddressWindow), new FrameworkPropertyMetadata(OnAddressPropertyChanged));
            ApartmentProperty = DependencyProperty.Register("Apartment", typeof(string),
                typeof(EditDrafteeAddressWindow), new FrameworkPropertyMetadata(OnAddressPropertyChanged));
            HomePhoneProperty = DependencyProperty.Register("HomePhone", typeof(string),
                typeof(EditDrafteeAddressWindow), new FrameworkPropertyMetadata(OnAddressPropertyChanged));
        }

        private static void OnDrafteeChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            Draftee newDraftee = (Draftee) e.NewValue;
            EditDrafteeAddressWindow view = (EditDrafteeAddressWindow) sender;
            view.LastName = newDraftee.LastName;
            view.FirstName = newDraftee.FirstName;
            view.Patronymic = newDraftee.Patronymic;
            if (newDraftee.BirthDate != null) view.BirthDate = newDraftee.BirthDate;
        }


        private static void OnAddressChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            Address newAddress = (Address) e.NewValue;
            EditDrafteeAddressWindow view = (EditDrafteeAddressWindow) sender;
            view.MunicipalDistrict = newAddress.MunicipalDistrict;
            view.MailIndex = newAddress.MailIndex;
            view.StreetName = newAddress.StreetName;
            view.HouseNumber = newAddress.HouseNumber;
            view.HousingNumber = newAddress.HousingNumber;
            view.Apartment = newAddress.Apartment;
            view.HomePhone = newAddress.HomePhone;
        }

        private static void OnAddressPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var view = (EditDrafteeAddressWindow) sender;
            Address address = view.Address;
            if (e.Property == MunicipalDistrictProperty)
                address.MunicipalDistrict = (string) e.NewValue;
            else if (e.Property == MailIndexProperty)
                address.MailIndex = (string) e.NewValue;
            else if (e.Property == StreetNameProperty)
                address.StreetName = (string) e.NewValue;
            else if (e.Property == HouseNumberProperty)
                address.HouseNumber = (string) e.NewValue;
            else if (e.Property == HousingNumberProperty)
                address.HousingNumber = (string) e.NewValue;
            else if (e.Property == ApartmentProperty)
                address.Apartment = (string) e.NewValue;
            else if (e.Property == HomePhoneProperty)
                address.HomePhone = (string) e.NewValue;
        }

        private void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {
            Draftee = GetCurrentDraftee();

            Address address = GetCurrentAddress();
            if (address != null)
            {
                Address = address;
            }
            else
            {
                Address = new Address();
                Address.DrafteeId = DrafteeId;
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            var validator = new AddressValidator();
            if (validator.Validate(Address))
            {
                var addressDao = new AddressDao();
                addressDao.InsertUpdate(Address);
                Close();
            }
            else
            {
                MessageBox.Show(
                    this,
                    string.Format("Данные не прошли проверку.\nСообщение об ошибке: \"{0}\"", validator.Message),
                    "Сообщение");
            }
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
            var address = converter.Convert(dao.GetByDraftee(DrafteeId));
            if (address == null)
            {
                address = new Address();
                address.DrafteeId = DrafteeId;
            }
            return address;
        }

        public Draftee Draftee
        {
            get { return (Draftee) GetValue(DrafteeProperty); }
            set { SetValue(DrafteeProperty, value); }
        }

        public string LastName
        {
            get { return (string) GetValue(LastNameProperty); }
            set { SetValue(LastNameProperty, value); }
        }

        public string FirstName
        {
            get { return (string) GetValue(FirstNameProperty); }
            set { SetValue(FirstNameProperty, value); }
        }

        public string Patronymic
        {
            get { return (string) GetValue(PatronymicProperty); }
            set { SetValue(PatronymicProperty, value); }
        }

        public DateTime? BirthDate
        {
            get { return (DateTime?) GetValue(BirthDateProperty); }
            set { SetValue(BirthDateProperty, value); }
        }

        public Address Address
        {
            get { return (Address) GetValue(AddressProperty); }
            set { SetValue(AddressProperty, value); }
        }

        public string MunicipalDistrict
        {
            get { return (string) GetValue(MunicipalDistrictProperty); }
            set { SetValue(MunicipalDistrictProperty, value); }
        }

        public string MailIndex
        {
            get { return (string) GetValue(MailIndexProperty); }
            set { SetValue(MailIndexProperty, value); }
        }

        public string StreetName
        {
            get { return (string) GetValue(StreetNameProperty); }
            set { SetValue(StreetNameProperty, value); }
        }

        public string HouseNumber
        {
            get { return (string) GetValue(HouseNumberProperty); }
            set { SetValue(HouseNumberProperty, value); }
        }

        public string HousingNumber
        {
            get { return (string) GetValue(HousingNumberProperty); }
            set { SetValue(HousingNumberProperty, value); }
        }

        public string Apartment
        {
            get { return (string) GetValue(ApartmentProperty); }
            set { SetValue(ApartmentProperty, value); }
        }

        public string HomePhone
        {
            get { return (string) GetValue(HomePhoneProperty); }
            set { SetValue(HomePhoneProperty, value); }
        }
    }
}