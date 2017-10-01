using System;
using System.Windows;
using MilitaryCommissariat.Controls;
using MilitaryCommissariat.Domain;

namespace MilitaryCommissariat.Windows
{
    /// <summary>
    /// Interaction logic for EditRelativeWindow.xaml
    /// </summary>
    public partial class EditRelativeWindow : Window
    {
        public RelativeView RelativeView { get; set; }
        public bool ApplyClicked { get; set; }

        public EditRelativeWindow()
        {
            InitializeComponent();
            ApplyClicked = false;
            Loaded += OnLoaded;
        }

        private void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {
            FillData(RelativeView.Relative);
        }

        private void ApplyButton_OnClick(object sender, RoutedEventArgs e)
        {
            RelativeView.RelationshipType = RelationshipText.Text;
            RelativeView.FullName = FullNameText.Text;
            RelativeView.BirthYear = Convert.ToInt32(BirthYearText.Text);
            RelativeView.BirthPlace = BirthPlaceText.Text;
            RelativeView.WorkPlace = WorkPlaceText.Text;
            ApplyClicked = true;
            Close();
        }

        private void CancelButton_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void FillData(Relative relative)
        {
            RelationshipText.Text = relative.RelationshipType;
            FullNameText.Text = relative.FullName;
            BirthYearText.Text = relative.BirthYear.ToString();
            BirthPlaceText.Text = relative.BirthPlace;
            WorkPlaceText.Text = relative.WorkPlace;
        }
    }
}