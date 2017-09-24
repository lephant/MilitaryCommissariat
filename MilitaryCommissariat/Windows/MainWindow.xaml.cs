using System.Windows;
using MilitaryCommissariat.Converters;
using MilitaryCommissariat.DAO;
using MilitaryCommissariat.SearchCriterias;
using MilitaryCommissariat.SearchCriterias.Builders;

namespace MilitaryCommissariat.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            var drafteeDao = new DrafteeDao();
            var converter = new TableDrafteeConverter();
            var criteria = new TableDrafteeCriteriaBuilder().Build(FullNameTextBox.Text, BirthYearTextBox.Text);
            ResultsListView.ItemsSource = converter.Convert(drafteeDao.GetListByCriteria(criteria));
        }

        private void SelectButton_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}