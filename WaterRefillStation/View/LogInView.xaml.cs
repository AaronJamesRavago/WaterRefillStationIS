using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WaterRefillStation.View
{
    /// <summary>
    /// Interaction logic for LogInView.xaml
    /// </summary>
    public partial class LogInView : Elysium.Controls.Window
    {
        public LogInView()
        {
            InitializeComponent();
            btnCancel.Click += btnCancel_Click;
            btnLogIn.Click += btnLogIn_Click;
        }

        void btnLogIn_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }

        void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
