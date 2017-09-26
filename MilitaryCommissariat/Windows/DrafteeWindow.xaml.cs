using System.Windows;
using System.Windows.Input;
using MilitaryCommissariat.Converters;
using MilitaryCommissariat.DAO;

namespace MilitaryCommissariat.Windows
{
    /// <summary>
    /// Interaction logic for DrafteeWindow.xaml
    /// </summary>
    public partial class DrafteeWindow : Window
    {
        public long DrafteeId { get; set; }

        public DrafteeWindow()
        {
            InitializeComponent();
            Loaded += OnLoaded;
        }

        private void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {
            var dao = new DrafteeDao();
            var converter = new DrafteeConverter();
            var draftee = converter.Convert(dao.GetById(DrafteeId));
            FirstNameValueLabel.Content = draftee.FirstName;
            LastNameValueLabel.Content = draftee.LastName;
            PatronymicValueLabel.Content = draftee.Patronymic;
            BirthDateValueLabel.Content = draftee.BirthDate.ToString("yyyy.MM.dd");
        }

        private void ReturnButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void SelectButton_Click(object sender, RoutedEventArgs e)
        {
        }

        private void CommonInfoItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
        }

        private void EducationItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
        }

        private void RelativeItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
        }

        private void DocumentItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
        }
    }
}