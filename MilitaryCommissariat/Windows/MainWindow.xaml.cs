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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MilitaryCommissariat
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            List<Some> list = new List<Some>();
            Some some = new Some();
            some.id = 2;
            some.name = "типа текст";
            some.year = 1997;
            list.Add(some);

            some = new Some();
            some.id = 4;
            some.name = "типа текст 2";
            some.year = 1998;
            list.Add(some);

            some = new Some();
            some.id = 6332453;
            some.name = "типа текст 23333333333333";
            some.year = 1998554;
            list.Add(some);

            myListView.ItemsSource = list;
        }
    }

    public class Some
    {
        public int id { get; set; }
        public string name { get; set; }
        public int year { get; set; }
    }
}
