using System;
using System.Windows;
using System.Windows.Controls;
using MilitaryCommissariat.Domain;

namespace MilitaryCommissariat.Controls
{
    /// <summary>
    /// Interaction logic for EducationPlaceView.xaml
    /// </summary>
    public partial class EducationPlaceView : UserControl
    {
        public static DependencyProperty EducationPlaceProperty;
        public static DependencyProperty EducationProperty;
        public static DependencyProperty EducationNameProperty;
        public static DependencyProperty InstitutionTypeProperty;
        public static DependencyProperty EndDateProperty;
        public static DependencyProperty FacultyProperty;
        public static DependencyProperty SpecialtyProperty;

        public static DependencyProperty CollapseButtonsProperty;

        public static RoutedEvent DeleteButtonClickedEvent;
        public static RoutedEvent EditButtonClickedEvent;


        public EducationPlaceView()
        {
            InitializeComponent();
        }

        static EducationPlaceView()
        {
            EducationPlaceProperty = DependencyProperty.Register("EducationPlace", typeof(EducationPlace),
                typeof(EducationPlaceView), new FrameworkPropertyMetadata(OnEducationPlacePropertyChanged));
            EducationProperty = DependencyProperty.Register("Education", typeof(string),
                typeof(EducationPlaceView));
            EducationNameProperty = DependencyProperty.Register("EducationName", typeof(string),
                typeof(EducationPlaceView));
            InstitutionTypeProperty = DependencyProperty.Register("InstitutionType", typeof(string),
                typeof(EducationPlaceView));
            EndDateProperty = DependencyProperty.Register("EndDate", typeof(DateTime?),
                typeof(EducationPlaceView));
            FacultyProperty = DependencyProperty.Register("Faculty", typeof(string),
                typeof(EducationPlaceView));
            SpecialtyProperty = DependencyProperty.Register("Specialty", typeof(string),
                typeof(EducationPlaceView));

            CollapseButtonsProperty = DependencyProperty.Register("CollapseButtons", typeof(bool),
                typeof(EducationPlaceView), new FrameworkPropertyMetadata(OnCollapseButtonsChanged));

            DeleteButtonClickedEvent = EventManager.RegisterRoutedEvent("DeleteButtonClicked", RoutingStrategy.Bubble,
                typeof(RoutedEventHandler), typeof(EducationPlaceView));
            EditButtonClickedEvent = EventManager.RegisterRoutedEvent("EditButtonClicked", RoutingStrategy.Bubble,
                typeof(RoutedEventHandler), typeof(EducationPlaceView));
        }

        private static void OnCollapseButtonsChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            bool newValue = (bool) e.NewValue;
            EducationPlaceView view = (EducationPlaceView) sender;
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

        private static void OnEducationPlacePropertyChanged(DependencyObject sender,
            DependencyPropertyChangedEventArgs e)
        {
            EducationPlace newPlace = (EducationPlace) e.NewValue;
            EducationPlaceView view = (EducationPlaceView) sender;
            view.Education = newPlace.Education;
            view.EducationName = newPlace.Name;
            view.InstitutionType = newPlace.InstitutionType;
            if (newPlace.EndDate != null) view.EndDate = newPlace.EndDate.Value;
            view.Faculty = newPlace.Faculty;
            view.Specialty = newPlace.Specialty;
        }

        public EducationPlace EducationPlace
        {
            get { return (EducationPlace) GetValue(EducationPlaceProperty); }
            set { SetValue(EducationPlaceProperty, value); }
        }

        public string Education
        {
            get { return (string) GetValue(EducationProperty); }
            set { SetValue(EducationProperty, value); }
        }

        public string EducationName
        {
            get { return (string) GetValue(EducationNameProperty); }
            set { SetValue(EducationNameProperty, value); }
        }

        public string InstitutionType
        {
            get { return (string) GetValue(InstitutionTypeProperty); }
            set { SetValue(InstitutionTypeProperty, value); }
        }

        public DateTime? EndDate
        {
            get { return (DateTime?) GetValue(EndDateProperty); }
            set { SetValue(EndDateProperty, value); }
        }

        public string Faculty
        {
            get { return (string) GetValue(FacultyProperty); }
            set { SetValue(FacultyProperty, value); }
        }

        public string Specialty
        {
            get { return (string) GetValue(SpecialtyProperty); }
            set { SetValue(SpecialtyProperty, value); }
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
            RoutedEventArgs args = new RoutedEventArgs(EditButtonClickedEvent, EducationPlace);
            RaiseEvent(args);
        }

        private void DeleteButton_OnClick(object sender, RoutedEventArgs e)
        {
            RoutedEventArgs args = new RoutedEventArgs(DeleteButtonClickedEvent, EducationPlace);
            RaiseEvent(args);
        }
    }
}