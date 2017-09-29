﻿using System.Windows;
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

        public static readonly RoutedEvent DeleteButtonClickedEvent;
        public static readonly RoutedEvent EditButtonClickedEvent;

        public RelativeView()
        {
            InitializeComponent();
        }

        static RelativeView()
        {
            RelativeProperty = DependencyProperty.Register("Relative", typeof(Relative),
                typeof(RelativeView), new FrameworkPropertyMetadata(OnRelativePropertyChanged));
            RelationshipTypeProperty = DependencyProperty.Register("RelationshipType", typeof(string),
                typeof(RelativeView));
            FullNameProperty = DependencyProperty.Register("FullName", typeof(string),
                typeof(RelativeView));
            BirthYearProperty = DependencyProperty.Register("BirthYear", typeof(int),
                typeof(RelativeView));
            BirthPlaceProperty = DependencyProperty.Register("BirthPlace", typeof(string),
                typeof(RelativeView));
            WorkPlaceProperty = DependencyProperty.Register("WorkPlace", typeof(string),
                typeof(RelativeView));

            CollapseButtonsProperty = DependencyProperty.Register("CollapseButtons", typeof(bool),
                typeof(RelativeView), new FrameworkPropertyMetadata(OnCollapseButtonsChanged));

            DeleteButtonClickedEvent = EventManager.RegisterRoutedEvent("DeleteButtonClicked", RoutingStrategy.Bubble,
                typeof(RoutedPropertyChangedEventHandler<Relative>), typeof(RelativeView));
            EditButtonClickedEvent = EventManager.RegisterRoutedEvent("EditButtonClicked", RoutingStrategy.Bubble,
                typeof(RoutedPropertyChangedEventHandler<Relative>), typeof(RelativeView));
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

        private static void OnRelativePropertyChanged(DependencyObject sender,
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

        public event RoutedPropertyChangedEventHandler<RelativeView> DeleteButtonClicked
        {
            add { AddHandler(DeleteButtonClickedEvent, value); }
            remove { RemoveHandler(DeleteButtonClickedEvent, value); }
        }

        public event RoutedPropertyChangedEventHandler<RelativeView> EditButtonClicked
        {
            add { AddHandler(EditButtonClickedEvent, value); }
            remove { RemoveHandler(EditButtonClickedEvent, value); }
        }
    }
}