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
    /// Interaction logic for EditDrafteeCommonInfoWindow.xaml
    /// </summary>
    public partial class EditDrafteeCommonInfoWindow : Window
    {
        public long DrafteeId { get; set; }

        public EditDrafteeCommonInfoWindow()
        {
            InitializeComponent();
        }
    }
}
