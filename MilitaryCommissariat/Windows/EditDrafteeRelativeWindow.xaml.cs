using System.Collections.Generic;
using System.Windows;
using MilitaryCommissariat.Controls;
using MilitaryCommissariat.Converters;
using MilitaryCommissariat.DAO;
using MilitaryCommissariat.Domain;

namespace MilitaryCommissariat.Windows
{
    /// <summary>
    /// Interaction logic for EditDrafteeRelativeWindow.xaml
    /// </summary>
    public partial class EditDrafteeRelativeWindow : Window
    {
        public long DrafteeId { get; set; }
        private Draftee draftee;
        private List<Relative> relatives = new List<Relative>();
        private List<long> idsForDelete = new List<long>();

        public EditDrafteeRelativeWindow()
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
            foreach (var relative in GetCurrentRelatives())
            {
                AddRelative(relative);
            }
        }

        private void SaveButton_OnClick(object sender, RoutedEventArgs e)
        {
            var relativeDao = new RelativeDao();
            foreach (long id in idsForDelete)
            {
                relativeDao.Delete(id);
            }
            foreach (var relative in relatives)
            {
                if (relative.Id > 0)
                {
                    relativeDao.Update(relative);
                }
                else
                {
                    relativeDao.Insert(relative);
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

        private List<Relative> GetCurrentRelatives()
        {
            var dao = new RelativeDao();
            var converter = new RelativeListConverter();
            return converter.Convert(dao.GetListByDraftee(DrafteeId));
        }

        private void AddRelative(Relative relative)
        {
            relatives.Add(relative);
            var view = new RelativeView();
            view.Margin = new Thickness(5);
            view.CollapseButtons = false;
            view.Relative = relative;
            view.DeleteButtonClicked += (sender, args) =>
            {
                if (view.Relative.Id > 0)
                {
                    idsForDelete.Add(view.Relative.Id);
                }
                RelativePanel.Children.Remove(view);
                relatives.Remove(view.Relative);
            };
            view.EditButtonClicked += (sender, args) =>
            {
                var window = new EditRelativeWindow();
                window.Owner = this;
                window.RelativeView = view;
                window.ShowDialog();
            };
            RelativePanel.Children.Add(view);
        }

        private void AddRelativeButton_OnClick(object sender, RoutedEventArgs e)
        {
            Relative relative = new Relative();
            relative.DrafteeId = DrafteeId;

            RelativeView view = new RelativeView();
            view.Relative = relative;

            var window = new EditRelativeWindow();
            window.RelativeView = view;
            window.Owner = this;
            window.ShowDialog();
            if (window.ApplyClicked)
            {
                AddRelative(relative);
            }
        }
    }
}
