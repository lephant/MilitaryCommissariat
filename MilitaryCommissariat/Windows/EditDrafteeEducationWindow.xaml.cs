using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
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
