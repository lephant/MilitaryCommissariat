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

        public static readonly RoutedEvent DeleteButtonClickedEvent;
        public static readonly RoutedEvent EditButtonClickedEvent;


        public EducationPlaceView()
        {
            InitializeComponent();
        }

        static EducationPlaceView()
        {
            EducationPlaceProperty = DependencyProperty.Register("EducationPlace", typeof(EducationPlace),
                typeof(EducationPlaceView), new FrameworkPropertyMetadata(EducationPlacePropertyChanged));
            EducationPlaceProperty = DependencyProperty.Register("Education", typeof(string),
                typeof(EducationPlaceView));
            EducationPlaceProperty = DependencyProperty.Register("EducationName", typeof(string),
                typeof(EducationPlaceView));
            EducationPlaceProperty = DependencyProperty.Register("InstitutionType", typeof(string),
                typeof(EducationPlaceView));
            EducationPlaceProperty = DependencyProperty.Register("EndDate", typeof(DateTime),
                typeof(EducationPlaceView));
            EducationPlaceProperty = DependencyProperty.Register("Faculty", typeof(string),
                typeof(EducationPlaceView));
            EducationPlaceProperty = DependencyProperty.Register("Specialty", typeof(string),
                typeof(EducationPlaceView));
            DeleteButtonClickedEvent = EventManager.RegisterRoutedEvent("DeleteButtonClicked", RoutingStrategy.Bubble,
                typeof(RoutedPropertyChangedEventHandler<EducationPlace>), typeof(EducationPlaceView));
            EditButtonClickedEvent = EventManager.RegisterRoutedEvent("EditButtonClicked", RoutingStrategy.Bubble,
                typeof(RoutedPropertyChangedEventHandler<EducationPlace>), typeof(EducationPlaceView));
        }

        private static void EducationPlacePropertyChanged(DependencyObject sender,
            DependencyPropertyChangedEventArgs e)
        {
            EducationPlace newPlace = (EducationPlace) e.NewValue;
            EducationPlaceView educationPlaceView = (EducationPlaceView)sender;
            educationPlaceView.Education = newPlace.Education;
            educationPlaceView.EducationName = newPlace.Name;
            educationPlaceView.InstitutionType = newPlace.InstitutionType;
            educationPlaceView.EndDate = newPlace.EndDate;
            educationPlaceView.Faculty = newPlace.Faculty;
            educationPlaceView.Specialty = newPlace.Specialty;
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

        public DateTime EndDate
        {
            get { return (DateTime) GetValue(EndDateProperty); }
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

        public event RoutedPropertyChangedEventHandler<EducationPlace> DeleteButtonClicked
        {
            add { AddHandler(DeleteButtonClickedEvent, value); }
            remove { RemoveHandler(DeleteButtonClickedEvent, value); }
        }

        public event RoutedPropertyChangedEventHandler<EducationPlace> EditButtonClicked
        {
            add { AddHandler(EditButtonClickedEvent, value); }
            remove { RemoveHandler(EditButtonClickedEvent, value); }
        }
    }
}