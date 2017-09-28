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
            var drafteeDao = new DrafteeDao();
            var drafteeConverter = new DrafteeConverter();
            var draftee = drafteeConverter.Convert(drafteeDao.GetById(DrafteeId));
            FirstNameValueLabel.Content = draftee.FirstName;
            LastNameValueLabel.Content = draftee.LastName;
            PatronymicValueLabel.Content = draftee.Patronymic;
            BirthDateValueLabel.Content = draftee.BirthDate.ToString("yyyy.MM.dd");

            var relativeDao = new RelativeDao();
            var relativeConverter = new RelativeListConverter();
            var educations = relativeConverter.Convert(relativeDao.GetListByDraftee(draftee.Id));
            foreach (var relative in educations)
            {
                var view = new RelativeView();
                view.Margin = new Thickness(5);
                view.CollapseButtons = true;
                view.Relative = relative;
                RelativePanel.Children.Add(view);
            }
        }
    }
}
