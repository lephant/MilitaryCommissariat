using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using MilitaryCommissariat.Converters;
using MilitaryCommissariat.DAO;
using MilitaryCommissariat.Domain;
using MilitaryCommissariat.SearchCriterias.Builders;

namespace MilitaryCommissariat.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<TableDraftee> draftees;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            var drafteeDao = new DrafteeDao();
            var converter = new TableDrafteeListConverter();
            var criteria = new TableDrafteeCriteriaBuilder().Build(FullNameTextBox.Text, BirthYearTextBox.Text);
            draftees = new ObservableCollection<TableDraftee>(converter.Convert(drafteeDao.GetListByCriteria(criteria)));
            ResultsListView.ItemsSource = draftees;
        }

        private void SelectButton_Click(object sender, RoutedEventArgs e)
        {
            TableDraftee tableDraftee = ResultsListView.SelectedItem as TableDraftee;
            if (tableDraftee == null)
            {
                MessageBox.Show(this, "Не выбрана запись в таблице!", "Сообщение");
                return;
            }
            //TODO
        }

        private void SelectMenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            TableDraftee tableDraftee = ResultsListView.SelectedItem as TableDraftee;
            if (tableDraftee == null)
            {
                MessageBox.Show(this, "Не выбрана запись в таблице!", "Сообщение");
                return;
            }
            //TODO
        }

        private void UpdateMenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            TableDraftee tableDraftee = ResultsListView.SelectedItem as TableDraftee;
            if (tableDraftee == null)
            {
                MessageBox.Show(this, "Не выбрана запись в таблице!", "Сообщение");
                return;
            }
            //TODO
        }

        private void CreateMenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            //TODO
        }

        private void DeleteMenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            TableDraftee tableDraftee = ResultsListView.SelectedItem as TableDraftee;
            if (tableDraftee == null)
            {
                MessageBox.Show(this, "Не выбрана запись в таблице!", "Сообщение");
                return;
            }
            new DrafteeDao().Delete(tableDraftee);
            draftees.Remove(tableDraftee);
        }
    }
}