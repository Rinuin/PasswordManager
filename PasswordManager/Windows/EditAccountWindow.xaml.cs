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
using PasswordManager.Domain.Models;
using PasswordManager.Windows;

namespace PasswordManager.Windows
{
    /// <summary>
    /// Interaction logic for EditAccountWindow.xaml
    /// </summary>
    public partial class EditAccountWindow : Window
    {
        //private Window _loggedWindow;

        private Account _account;
        public EditAccountWindow(Account account)
        {
            InitializeComponent();

            _account = account;

            accountNameBox.Text = _account.AccountName;
            emailBox.Text = _account.Email;
            usernameBox.Text = _account.Username;
            passwordBox.Text = _account.Password;
            notesBox.Text = _account.Notes;

            //_loggedWindow = loggedWindow;
        }

        private void EditAccountButton_Click(object sender, RoutedEventArgs e)
        {
            _account.AccountName = accountNameBox.Text;
            _account.Email = emailBox.Text;
            _account.Username = usernameBox.Text;
            _account.Password = passwordBox.Text;
            _account.Notes = notesBox.Text;


            this.Close();
            LoggedInWindow liw = new LoggedInWindow(new MainWindow());
            liw.Show();
            //_loggedWindow.Show();
        }
    }
}
