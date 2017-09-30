using System.Collections.Generic;
using System.Windows;
using MilitaryCommissariat.Controls;
using MilitaryCommissariat.Converters;
using MilitaryCommissariat.DAO;
using MilitaryCommissariat.Domain;

namespace MilitaryCommissariat.Windows
{
    /// <summary>
    /// Interaction logic for DrafteeEducationWindow.xaml
    /// </summary>
    public partial class DrafteeEducationWindow : Window
    {
        public long DrafteeId { get; set; }

        public DrafteeEducationWindow()
        {
            InitializeComponent();
            Loaded += OnLoaded;
        }

        private void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {
            FillData(GetCurrentDraftee());
            FillData(GetCurrentEducations());
        }

        private void ReturnButton_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void EditButton_OnClick(object sender, RoutedEventArgs e)
        {
            OpenEditDrafteeEducationWindow();
        }

        private void OpenEditDrafteeEducationWindow()
        {
            var window = new EditDrafteeEducationWindow();
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

        private Draftee GetCurrentDraftee()
        {
            var dao = new DrafteeDao();
            var converter = new DrafteeConverter();
            return converter.Convert(dao.GetById(DrafteeId));
        }

        private List<EducationPlace> GetCurrentEducations()
        {
            var educationPlaceDao = new EducationPlaceDao();
            var educationPlaceConverter = new EducationPlaceListConverter();
            return educationPlaceConverter.Convert(educationPlaceDao.GetListByDraftee(DrafteeId));
        }

        private void FillData(Draftee draftee)
        {
            FirstNameValueLabel.Content = draftee.FirstName;
            LastNameValueLabel.Content = draftee.LastName;
            PatronymicValueLabel.Content = draftee.Patronymic;
            BirthDateValueLabel.Content = draftee.BirthDate?.ToString("yyyy.MM.dd");
            ForeignLanguagesValueLabel.Text = draftee.ForeignLanguages;
        }

        private void FillData(List<EducationPlace> educations)
        {
            EducationPlacePanel.Children.Clear();
            foreach (var educationPlace in educations)
            {
                var view = new EducationPlaceView();
                view.Margin = new Thickness(5);
                view.CollapseButtons = true;
                view.EducationPlace = educationPlace;
                EducationPlacePanel.Children.Add(view);
            }
        }

        public void Refresh()
        {
            FillData(GetCurrentDraftee());
            FillData(GetCurrentEducations());
        }
    }
}