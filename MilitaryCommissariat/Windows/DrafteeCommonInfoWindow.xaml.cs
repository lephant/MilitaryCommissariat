using System.Windows;
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
            BirthPlaceValueLabel.Text = draftee.BirthPlace;
            CategoryValueLabel.Text = draftee.Category;
            TroopTypeValueLabel.Text = draftee.TroopType;
        }

        public void Refresh()
        {
            FillData(GetCurrentDraftee());
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
            var window = new EditDrafteeCommonInfoWindow();
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