using System;
using System.Windows;
using MilitaryCommissariat.Domain;

namespace MilitaryCommissariat.Windows
{
    /// <summary>
    /// Interaction logic for EditEducationWindow.xaml
    /// </summary>
    public partial class EditEducationWindow : Window
    {
        public EducationPlace EducationPlace { get; set; }

        public EditEducationWindow()
        {
            InitializeComponent();
            Loaded += OnLoaded;
        }

        private void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {
            FillData(EducationPlace);
        }

        private void ApplyButton_OnClick(object sender, RoutedEventArgs e)
        {
            EducationPlace.Education = EducationText.Text;
            EducationPlace.Name = EducationPlaceNameText.Text;
            EducationPlace.InstitutionType = InstitutionTypeText.Text;
            EducationPlace.EndDate = Convert.ToDateTime(EndDateText.Text);
            EducationPlace.Faculty = FacultyText.Text;
            EducationPlace.Specialty = SpecialtyText.Text;
            Close();
        }

        private void CancelButton_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void FillData(EducationPlace place)
        {
            EducationText.Text = place.Education;
            EducationPlaceNameText.Text = place.Name;
            InstitutionTypeText.Text = place.InstitutionType;
            if (place.EndDate != null) EndDateText.Text = place.EndDate.Value.ToString("yyyy.MM.dd");
            FacultyText.Text = place.Faculty;
            SpecialtyText.Text = place.Specialty;
        }
    }
}