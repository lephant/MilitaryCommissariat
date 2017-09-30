using System;
using System.Windows;
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
                typeof(EditDrafteeCommonInfoWindow), new FrameworkPropertyMetadata(OnDrafteeChanged));
            LastNameProperty = DependencyProperty.Register("LastName", typeof(string),
                typeof(EditDrafteeCommonInfoWindow), new FrameworkPropertyMetadata(OnDrafteePropertyChanged));
            FirstNameProperty = DependencyProperty.Register("FirstName", typeof(string),
                typeof(EditDrafteeCommonInfoWindow), new FrameworkPropertyMetadata(OnDrafteePropertyChanged));
            PatronymicProperty = DependencyProperty.Register("Patronymic", typeof(string),
                typeof(EditDrafteeCommonInfoWindow), new FrameworkPropertyMetadata(OnDrafteePropertyChanged));
            BirthDateProperty = DependencyProperty.Register("BirthDate", typeof(DateTime?),
                typeof(EditDrafteeCommonInfoWindow), new FrameworkPropertyMetadata(OnDrafteePropertyChanged));
            BirthPlaceProperty = DependencyProperty.Register("BirthPlace", typeof(string),
                typeof(EditDrafteeCommonInfoWindow), new FrameworkPropertyMetadata(OnDrafteePropertyChanged));
            CategoryProperty = DependencyProperty.Register("Category", typeof(string),
                typeof(EditDrafteeCommonInfoWindow), new FrameworkPropertyMetadata(OnDrafteePropertyChanged));
            TroopTypeProperty = DependencyProperty.Register("TroopType", typeof(string),
                typeof(EditDrafteeCommonInfoWindow), new FrameworkPropertyMetadata(OnDrafteePropertyChanged));

            AddressProperty = DependencyProperty.Register("Address", typeof(Address),
                typeof(EditDrafteeCommonInfoWindow), new FrameworkPropertyMetadata(OnAddressChanged));
            MunicipalDistrictProperty = DependencyProperty.Register("MunicipalDistrict", typeof(string),
                typeof(EditDrafteeCommonInfoWindow), new FrameworkPropertyMetadata(OnAddressPropertyChanged));
            MailIndexProperty = DependencyProperty.Register("MailIndex", typeof(string),
                typeof(EditDrafteeCommonInfoWindow), new FrameworkPropertyMetadata(OnAddressPropertyChanged));
            StreetNameProperty = DependencyProperty.Register("StreetName", typeof(string),
                typeof(EditDrafteeCommonInfoWindow), new FrameworkPropertyMetadata(OnAddressPropertyChanged));
            HouseNumberProperty = DependencyProperty.Register("HouseNumber", typeof(string),
                typeof(EditDrafteeCommonInfoWindow), new FrameworkPropertyMetadata(OnAddressPropertyChanged));
            HousingNumberProperty = DependencyProperty.Register("HousingNumber", typeof(string),
                typeof(EditDrafteeCommonInfoWindow), new FrameworkPropertyMetadata(OnAddressPropertyChanged));
            ApartmentProperty = DependencyProperty.Register("Apartment", typeof(string),
                typeof(EditDrafteeCommonInfoWindow), new FrameworkPropertyMetadata(OnAddressPropertyChanged));
            HomePhoneProperty = DependencyProperty.Register("HomePhone", typeof(string),
                typeof(EditDrafteeCommonInfoWindow), new FrameworkPropertyMetadata(OnAddressPropertyChanged));
        }

        private static void OnDrafteeChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            Draftee newDraftee = (Draftee) e.NewValue;
            EditDrafteeCommonInfoWindow view = (EditDrafteeCommonInfoWindow) sender;
            view.LastName = newDraftee.LastName;
            view.FirstName = newDraftee.FirstName;
            view.Patronymic = newDraftee.Patronymic;
            if (newDraftee.BirthDate != null) view.BirthDate = newDraftee.BirthDate;
            view.BirthPlace = newDraftee.BirthPlace;
            view.Category = newDraftee.Category;
            view.TroopType = newDraftee.TroopType;
        }

        private static void OnDrafteePropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var view = (EditDrafteeCommonInfoWindow) sender;
            Draftee draftee = view.Draftee;
            if (e.Property == LastNameProperty)
                draftee.LastName = (string) e.NewValue;
            else if (e.Property == FirstNameProperty)
                draftee.FirstName = (string) e.NewValue;
            else if (e.Property == PatronymicProperty)
                draftee.Patronymic = (string) e.NewValue;
            else if (e.Property == BirthDateProperty)
                draftee.BirthDate = (DateTime) e.NewValue;
            else if (e.Property == BirthPlaceProperty)
                draftee.BirthPlace = (string) e.NewValue;
            else if (e.Property == CategoryProperty)
                draftee.Category = (string) e.NewValue;
            else if (e.Property == TroopTypeProperty)
                draftee.TroopType = (string) e.NewValue;
        }

        private static void OnAddressChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            Address newAddress = (Address) e.NewValue;
            EditDrafteeCommonInfoWindow view = (EditDrafteeCommonInfoWindow) sender;
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
            var view = (EditDrafteeCommonInfoWindow) sender;
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
            Draftee draftee = GetCurrentDraftee();
            if (draftee != null)
            {
                Draftee = draftee;
            }
            else
            {
                Draftee = new Draftee();
            }

            Address address = GetCurrentAddress();
            if (address != null)
            {
                Address = address;
            }
            else
            {
                Address = new Address();
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            var drafteeDao = new DrafteeDao();
            var addressDao = new AddressDao();
            if (Draftee.Id > 0)
            {
                drafteeDao.Update(Draftee);
                addressDao.Update(Address);
            }
            else
            {
                drafteeDao.Insert(Draftee, Address);
            }
            Close();
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

        public string BirthPlace
        {
            get { return (string) GetValue(BirthPlaceProperty); }
            set { SetValue(BirthPlaceProperty, value); }
        }

        public string Category
        {
            get { return (string) GetValue(CategoryProperty); }
            set { SetValue(CategoryProperty, value); }
        }

        public string TroopType
        {
            get { return (string) GetValue(TroopTypeProperty); }
            set { SetValue(TroopTypeProperty, value); }
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