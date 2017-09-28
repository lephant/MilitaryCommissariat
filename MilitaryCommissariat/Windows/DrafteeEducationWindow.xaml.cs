using System;
using System.Collections.Generic;
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
            var drafteeDao = new DrafteeDao();
            var drafteeConverter = new DrafteeConverter();
            var draftee = drafteeConverter.Convert(drafteeDao.GetById(DrafteeId));
            FirstNameValueLabel.Content = draftee.FirstName;
            LastNameValueLabel.Content = draftee.LastName;
            PatronymicValueLabel.Content = draftee.Patronymic;
            BirthDateValueLabel.Content = draftee.BirthDate.ToString("yyyy.MM.dd");

            var educationPlaceDao = new EducationPlaceDao();
            var educationPlaceConverter = new EducationPlaceListConverter();
            var educations = educationPlaceConverter.Convert(educationPlaceDao.GetListByDraftee(draftee.Id));
            foreach (var educationPlace in educations)
            {
                var view = new EducationPlaceView();
                view.Margin = new Thickness(5);
                view.CollapseButtons = false;
                view.EducationPlace = educationPlace;
                EducationPlacePanel.Children.Add(view);
            }
        }
    }
}
