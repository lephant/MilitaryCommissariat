using System.Windows;
using System.Windows.Controls;
using MilitaryCommissariat.Domain;

namespace MilitaryCommissariat.Controls
{
    /// <summary>
    /// Interaction logic for RelativeView.xaml
    /// </summary>
    public partial class RelativeView : UserControl
    {
        public static DependencyProperty RelativeProperty;
        public static DependencyProperty RelationshipTypeProperty;
        public static DependencyProperty FullNameProperty;
        public static DependencyProperty BirthYearProperty;
        public static DependencyProperty BirthPlaceProperty;
        public static DependencyProperty WorkPlaceProperty;

        public static DependencyProperty CollapseButtonsProperty;

        public static RoutedEvent DeleteButtonClickedEvent;
        public static RoutedEvent EditButtonClickedEvent;

        public RelativeView()
        {
            InitializeComponent();
        }

        static RelativeView()
        {
            RelativeProperty = DependencyProperty.Register("Relative", typeof(Relative),
                typeof(RelativeView), new FrameworkPropertyMetadata(OnRelativeChanged));
            RelationshipTypeProperty = DependencyProperty.Register("RelationshipType", typeof(string),
                typeof(RelativeView), new FrameworkPropertyMetadata(OnRelativePropertyChanged));
            FullNameProperty = DependencyProperty.Register("FullName", typeof(string),
                typeof(RelativeView), new FrameworkPropertyMetadata(OnRelativePropertyChanged));
            BirthYearProperty = DependencyProperty.Register("BirthYear", typeof(int),
                typeof(RelativeView), new FrameworkPropertyMetadata(OnRelativePropertyChanged));
            BirthPlaceProperty = DependencyProperty.Register("BirthPlace", typeof(string),
                typeof(RelativeView), new FrameworkPropertyMetadata(OnRelativePropertyChanged));
            WorkPlaceProperty = DependencyProperty.Register("WorkPlace", typeof(string),
                typeof(RelativeView), new FrameworkPropertyMetadata(OnRelativePropertyChanged));

            CollapseButtonsProperty = DependencyProperty.Register("CollapseButtons", typeof(bool),
                typeof(RelativeView), new FrameworkPropertyMetadata(OnCollapseButtonsChanged));

            DeleteButtonClickedEvent = EventManager.RegisterRoutedEvent("DeleteButtonClicked", RoutingStrategy.Bubble,
                typeof(RoutedEventHandler), typeof(RelativeView));
            EditButtonClickedEvent = EventManager.RegisterRoutedEvent("EditButtonClicked", RoutingStrategy.Bubble,
                typeof(RoutedEventHandler), typeof(RelativeView));
        }

        private static void OnCollapseButtonsChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            bool newValue = (bool) e.NewValue;
            RelativeView view = (RelativeView) sender;
            if (newValue)
            {
                view.DeleteButton.Visibility = Visibility.Collapsed;
                view.EditButton.Visibility = Visibility.Collapsed;
            }
            else
            {
                view.DeleteButton.Visibility = Visibility.Visible;
                view.EditButton.Visibility = Visibility.Visible;
            }
        }

        private static void OnRelativeChanged(DependencyObject sender,
            DependencyPropertyChangedEventArgs e)
        {
            Relative newRelative = (Relative) e.NewValue;
            RelativeView view = (RelativeView) sender;
            view.RelationshipType = newRelative.RelationshipType;
            view.FullName = newRelative.FullName;
            view.BirthYear = newRelative.BirthYear;
            view.BirthPlace = newRelative.BirthPlace;
            view.WorkPlace = newRelative.WorkPlace;
        }

        private static void OnRelativePropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var view = (RelativeView) sender;
            Relative relative = view.Relative;
            if (e.Property == RelationshipTypeProperty)
                relative.RelationshipType = (string) e.NewValue;
            else if (e.Property == FullNameProperty)
                relative.FullName = (string) e.NewValue;
            else if (e.Property == BirthYearProperty)
                relative.BirthYear = (int) e.NewValue;
            else if (e.Property == BirthPlaceProperty)
                relative.BirthPlace = (string) e.NewValue;
            else if (e.Property == WorkPlaceProperty)
                relative.WorkPlace = (string) e.NewValue;
        }

        public Relative Relative
        {
            get { return (Relative) GetValue(RelativeProperty); }
            set { SetValue(RelativeProperty, value); }
        }

        public string RelationshipType
        {
            get { return (string) GetValue(RelationshipTypeProperty); }
            set { SetValue(RelationshipTypeProperty, value); }
        }

        public string FullName
        {
            get { return (string) GetValue(FullNameProperty); }
            set { SetValue(FullNameProperty, value); }
        }

        public int BirthYear
        {
            get { return (int) GetValue(BirthYearProperty); }
            set { SetValue(BirthYearProperty, value); }
        }

        public string BirthPlace
        {
            get { return (string) GetValue(BirthPlaceProperty); }
            set { SetValue(BirthPlaceProperty, value); }
        }

        public string WorkPlace
        {
            get { return (string) GetValue(WorkPlaceProperty); }
            set { SetValue(WorkPlaceProperty, value); }
        }

        public bool CollapseButtons
        {
            get { return (bool) GetValue(CollapseButtonsProperty); }
            set { SetValue(CollapseButtonsProperty, value); }
        }

        public event RoutedEventHandler DeleteButtonClicked
        {
            add { AddHandler(DeleteButtonClickedEvent, value); }
            remove { RemoveHandler(DeleteButtonClickedEvent, value); }
        }

        public event RoutedEventHandler EditButtonClicked
        {
            add { AddHandler(EditButtonClickedEvent, value); }
            remove { RemoveHandler(EditButtonClickedEvent, value); }
        }

        private void EditButton_OnClick(object sender, RoutedEventArgs e)
        {
            RoutedEventArgs args = new RoutedEventArgs(EditButtonClickedEvent, Relative);
            RaiseEvent(args);
        }

        private void DeleteButton_OnClick(object sender, RoutedEventArgs e)
        {
            RoutedEventArgs args = new RoutedEventArgs(DeleteButtonClickedEvent, Relative);
            RaiseEvent(args);
        }
    }
}