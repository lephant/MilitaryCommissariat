using System.Collections.Generic;
using System.Windows;
using MilitaryCommissariat.Controls;
using MilitaryCommissariat.Converters;
using MilitaryCommissariat.DAO;
using MilitaryCommissariat.Domain;

namespace MilitaryCommissariat.Windows
{
    /// <summary>
    /// Interaction logic for EditDrafteeEducationWindow.xaml
    /// </summary>
    public partial class EditDrafteeEducationWindow : Window
    {
        public long DrafteeId { get; set; }
        private Draftee draftee;
        private List<EducationPlace> educationPlaces = new List<EducationPlace>();
        private List<long> idsForDelete = new List<long>();

        public EditDrafteeEducationWindow()
        {
            InitializeComponent();
            Loaded += OnLoaded;
        }

        private void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {
            draftee = GetCurrentDraftee();
            LastNameValueLabel.Content = draftee.LastName;
            FirstNameValueLabel.Content = draftee.FirstName;
            PatronymicValueLabel.Content = draftee.Patronymic;
            BirthDateValueLabel.Content = draftee.BirthDate?.ToString("yyyy.MM.dd");
            ForeignLanguagesText.Text = draftee.ForeignLanguages;
            foreach (var place in GetCurrentEducationPlaces())
            {
                AddEducationPlace(place);
            }
        }

        private void SaveButton_OnClick(object sender, RoutedEventArgs e)
        {
            draftee.ForeignLanguages = ForeignLanguagesText.Text;
            var drafteeDao = new DrafteeDao();
            var educationDao = new EducationPlaceDao();
            drafteeDao.Update(draftee);
            foreach (long id in idsForDelete)
            {
                educationDao.Delete(id);
            }
            foreach (var place in educationPlaces)
            {
                if (place.Id > 0)
                {
                    educationDao.Update(place);
                }
                else
                {
                    educationDao.Insert(place);
                }
            }
            Close();
        }

        private void CancelButton_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private Draftee GetCurrentDraftee()
        {
            var dao = new DrafteeDao();
            var converter = new DrafteeConverter();
            return converter.Convert(dao.GetById(DrafteeId));
        }

        private List<EducationPlace> GetCurrentEducationPlaces()
        {
            var dao = new EducationPlaceDao();
            var converter = new EducationPlaceListConverter();
            return converter.Convert(dao.GetListByDraftee(DrafteeId));
        }

        private void AddEducationPlace(EducationPlace place)
        {
            educationPlaces.Add(place);
            var view = new EducationPlaceView();
            view.Margin = new Thickness(5);
            view.CollapseButtons = false;
            view.EducationPlace = place;
            view.DeleteButtonClicked += (sender, args) =>
            {
                if (view.EducationPlace.Id > 0)
                {
                    idsForDelete.Add(view.EducationPlace.Id);
                }
                EducationPlacePanel.Children.Remove(view);
                educationPlaces.Remove(view.EducationPlace);
            };
            view.EditButtonClicked += (sender, args) =>
            {
                var window = new EditEducationWindow();
                window.Owner = this;
                window.EducationPlaceView = view;
                window.ShowDialog();
            };
            EducationPlacePanel.Children.Add(view);
        }

        private void AddEducationPlaceButton_OnClick(object sender, RoutedEventArgs e)
        {
            EducationPlace place = new EducationPlace();
            place.DrafteeId = DrafteeId;

            EducationPlaceView view = new EducationPlaceView();
            view.EducationPlace = place;

            var window = new EditEducationWindow();
            window.EducationPlaceView = view;
            window.Owner = this;
            window.ShowDialog();
            if (window.ApplyClicked)
            {
                AddEducationPlace(place);
            }
        }
    }
}
