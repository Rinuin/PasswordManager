using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PasswordManager
{
    /// <summary>
    /// Interaction logic for RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow()
        {
            InitializeComponent();
        }

        private void FinishButton_Click(object sender, RoutedEventArgs e)
        {
            Trace.WriteLine(usernameBox.Text.ToString());
            Trace.WriteLine(passwordBoxFirst.Password.ToString());
            Trace.WriteLine(passwordBoxSecond.Password.ToString());
            Trace.WriteLine(emailBox.Text.ToString());

            MainWindow mw = new MainWindow();
            this.Close();
            mw.Show();
        }
    }
}
