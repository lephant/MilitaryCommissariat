using System;
using System.Windows;
using MilitaryCommissariat.Converters;
using MilitaryCommissariat.DAO;
using MilitaryCommissariat.Domain;
using MilitaryCommissariat.Validators;

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
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            var validator = new CommonInfoValidator();
            if (validator.Validate(Draftee))
            {
                var drafteeDao = new DrafteeDao();
                if (Draftee.Id > 0)
                {
                    drafteeDao.Update(Draftee);
                }
                else
                {
                    drafteeDao.Insert(Draftee);
                }
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
    }
}