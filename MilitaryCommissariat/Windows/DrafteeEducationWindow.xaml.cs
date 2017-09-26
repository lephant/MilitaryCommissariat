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

namespace MilitaryCommissariat.Windows
{
    /// <summary>
    /// Interaction logic for DrafteeEducationWindow.xaml
    /// </summary>
    public partial class DrafteeEducationWindow : Window
    {
        public long DrafteeId { get; set; }

        public DrafteeEducationWindow()
        {
            InitializeComponent();
        }
    }
}
