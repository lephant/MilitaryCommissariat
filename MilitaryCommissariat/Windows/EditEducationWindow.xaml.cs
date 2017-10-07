using System;
using System.Windows;
using MilitaryCommissariat.Controls;
using MilitaryCommissariat.Domain;

namespace MilitaryCommissariat.Windows
{
    /// <summary>
    /// Interaction logic for EditEducationWindow.xaml
    /// </summary>
    public partial class EditEducationWindow : Window
    {
        public EducationPlaceView EducationPlaceView { get; set; }
        public bool ApplyClicked { get; set; }

        public EditEducationWindow()
        {
            InitializeComponent();
            ApplyClicked = false;
            Loaded += OnLoaded;
        }

        private void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {
            FillData(EducationPlaceView.EducationPlace);
        }

        private void ApplyButton_OnClick(object sender, RoutedEventArgs e)
        {
            EducationPlaceView.Education = EducationText.Text;
            EducationPlaceView.EducationName = EducationPlaceNameText.Text;
            EducationPlaceView.InstitutionType = InstitutionTypeText.Text;
            DateTime tmpDate;
            if (DateTime.TryParse(EndDateText.Text, out tmpDate))
            {
                EducationPlaceView.EndDate = tmpDate;
            }
            else
            {
                EducationPlaceView.EndDate = null;
            }
            EducationPlaceView.Faculty = FacultyText.Text;
            EducationPlaceView.Specialty = SpecialtyText.Text;
            ApplyClicked = true;
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