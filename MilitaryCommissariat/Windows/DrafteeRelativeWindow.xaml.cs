using System.Collections.Generic;
using System.Windows;
using MilitaryCommissariat.Controls;
using MilitaryCommissariat.Converters;
using MilitaryCommissariat.DAO;
using MilitaryCommissariat.Domain;

namespace MilitaryCommissariat.Windows
{
    /// <summary>
    /// Interaction logic for DrafteeRelativeWindow.xaml
    /// </summary>
    public partial class DrafteeRelativeWindow : Window
    {
        public long DrafteeId { get; set; }

        public DrafteeRelativeWindow()
        {
            InitializeComponent();
            Loaded += OnLoaded;
        }

        private void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {
            FillData(GetCurrentDraftee());
            FillData(GetCurrentRelatives());
        }

        private Draftee GetCurrentDraftee()
        {
            var dao = new DrafteeDao();
            var converter = new DrafteeConverter();
            return converter.Convert(dao.GetById(DrafteeId));
        }

        private List<Relative> GetCurrentRelatives()
        {
            var educationPlaceDao = new RelativeDao();
            var educationPlaceConverter = new RelativeListConverter();
            return educationPlaceConverter.Convert(educationPlaceDao.GetListByDraftee(DrafteeId));
        }

        private void FillData(Draftee draftee)
        {
            FirstNameValueLabel.Content = draftee.FirstName;
            LastNameValueLabel.Content = draftee.LastName;
            PatronymicValueLabel.Content = draftee.Patronymic;
            BirthDateValueLabel.Content = draftee.BirthDate.ToString("yyyy.MM.dd");
        }

        private void FillData(List<Relative> relatives)
        {
            RelativePanel.Children.Clear();
            foreach (var relative in relatives)
            {
                var view = new RelativeView();
                view.Margin = new Thickness(5);
                view.CollapseButtons = true;
                view.Relative = relative;
                RelativePanel.Children.Add(view);
            }
        }

        public void Refresh()
        {
            FillData(GetCurrentDraftee());
            FillData(GetCurrentRelatives());
        }
    }
}
