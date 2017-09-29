using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using MilitaryCommissariat.Converters;
using MilitaryCommissariat.DAO;
using MilitaryCommissariat.Domain;

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
            BirthDateValueLabel.Content = draftee.BirthDate.ToString("yyyy.MM.dd");
        }

        public void Refresh()
        {
            FillData(GetCurrentDraftee());
        }

        private void ReturnButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void SelectButton_Click(object sender, RoutedEventArgs e)
        {
            ListBoxItem selectedItem = SectionListBox.SelectedItem as ListBoxItem;
            if (selectedItem == null)
            {
                MessageBox.Show(this, "Не выбран раздел!", "Сообщение");
                return;
            }
            switch (selectedItem.Name)
            {
                case "CommonInfoItem":
                    OpenDrafteeCommonInfoWindow();
                    break;
                case "EducationItem":
                    OpenDrafteeEducationWindow();
                    break;
                case "RelativeItem":
                    OpenDrafteeRelativeWindow();
                    break;
                case "DocumentItem":
                    OpenDrafteeDocumentWindow();
                    break;
            }
        }

        private void CommonInfoItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            OpenDrafteeCommonInfoWindow();
        }

        private void EducationItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            OpenDrafteeEducationWindow();
        }

        private void RelativeItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            OpenDrafteeRelativeWindow();
        }

        private void DocumentItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            OpenDrafteeDocumentWindow();
        }

        private void OpenDrafteeCommonInfoWindow()
        {
            var window = new DrafteeCommonInfoWindow();
            window.Owner = this;
            window.DrafteeId = DrafteeId;
            Hide();
            window.Closed += (sender, args) => { Show(); };
            window.Show();
        }

        private void OpenDrafteeEducationWindow()
        {
            var window = new DrafteeEducationWindow();
            window.Owner = this;
            window.DrafteeId = DrafteeId;
            Hide();
            window.Closed += (sender, args) => { Show(); };
            window.Show();
        }

        private void OpenDrafteeRelativeWindow()
        {
            var window = new DrafteeRelativeWindow();
            window.Owner = this;
            window.DrafteeId = DrafteeId;
            Hide();
            window.Closed += (sender, args) => { Show(); };
            window.Show();
        }

        private void OpenDrafteeDocumentWindow()
        {
            var window = new DrafteeDocumentWindow();
            window.Owner = this;
            window.DrafteeId = DrafteeId;
            Hide();
            window.Closed += (sender, args) => { Show(); };
            window.Show();
        }
    }
}