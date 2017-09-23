using System.Windows;
using MilitaryCommissariat.Converters;
using MilitaryCommissariat.DAO;
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
            ResultsListView.ItemsSource =
                new TableDrafteeConverter().Convert(new DrafteeDao()
                    .GetListByCriteria(new TableDrafteeCriteriaBuilder()
                    .Build("text", "1997")));
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SelectButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}