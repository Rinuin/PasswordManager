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
using PasswordManager.Data.Exceptions;
using PasswordManager.Data.ManageData;
using PasswordManager.Domain.Models;
using PasswordManager.Windows;

namespace PasswordManager.Windows
{
    /// <summary>
    /// Interaction logic for AddAccountWindow.xaml
    /// </summary>
    public partial class AddAccountWindow : Window
    {
        //private Window _loggedWindow;

        private readonly AccountDataManager _adm;
        public AddAccountWindow()
        {
            InitializeComponent();
            _adm = new AccountDataManager();
            //_loggedWindow = loggedWindow;
        }

        private async void AddAccountButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                await _adm.CreateAccount(accountNameBox.Text, emailBox.Text, usernameBox.Text, passwordBox.Text, notesBox.Text);
            }
            catch (MissingValueException ex)
            {
                MessageBox.Show("Some values are missing! Check if you gave all necessary credentials");
            }
            this.Close();
            LoggedInWindow liw = new LoggedInWindow(new MainWindow());
            liw.Show();
            //_loggedWindow.Show();
        }
    }
}
