using PasswordManager.Data;
using PasswordManager.Data.Exceptions;
using PasswordManager.Data.ManageAuthentication;
using PasswordManager.Domain.Models;
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
using PasswordManager.Windows;

using static PasswordManager.Data.ManageAuthentication.Authenticator;

namespace PasswordManager
{
    /// <summary>
    /// Interaction logic for RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        private Window _mainWindow;
        public RegistrationWindow(Window mainWindow)
        {
            _mainWindow = mainWindow;
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }

        private async void FinishButton_Click(object sender, RoutedEventArgs e)
        {
            Authenticator auth = new Authenticator();
            try
            {
                RegistrationResult registrationResult = await auth.Register(emailBox.Text, usernameBox.Text, passwordBoxFirst.Password, passwordBoxSecond.Password);

                switch (registrationResult)
                {
                    case RegistrationResult.Success:
                        this.Hide();
                        _mainWindow.Show();
                        break;
                    case RegistrationResult.PasswordsDoNotMatch:
                        MessageBox.Show("Password does not match confirm password.");
                        break;
                    case RegistrationResult.EmailAlreadyExists:
                        MessageBox.Show("An account for this email already exists.");
                        break;
                    case RegistrationResult.UsernameAlreadyExists:
                        MessageBox.Show("An account for this username already exists.");
                        break;
                    default:
                        MessageBox.Show("Registration failed.");
                        break;
                }
            }
            catch (MissingValueException ex)
            {
                MessageBox.Show("Some values are missing! Check if you gave all necessary credentials");
            }
            catch (Exception)
            {
                MessageBox.Show("Registration failed.");
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            _mainWindow.Show();
        }
    }
}
