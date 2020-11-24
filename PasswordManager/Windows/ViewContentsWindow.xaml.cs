using PasswordManager.Domain.Models;
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

namespace PasswordManager.Windows
{
    /// <summary>
    /// Interaction logic for ViewContentsWindow.xaml
    /// </summary>
    public partial class ViewContentsWindow : Window
    {
        private Window _loggedWindow;
        private readonly Account _account;
        public ViewContentsWindow(Window loggedWindow, Account account)
        {
            InitializeComponent();
            _loggedWindow = loggedWindow;
            _account = account;

            accountNameBox.Text = _account.AccountName;
            emailBox.Text = _account.Email;
            usernameBox.Text = _account.Username;
            passwordBox.Text = _account.Password;
            notesBox.Text = _account.Notes;
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            _loggedWindow.Show();
        }

        private void copyAccountNameButton_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(accountNameBox.Text);
        }

        private void copyEmailButton_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(emailBox.Text);
        }

        private void copyUsernameButton_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(usernameBox.Text);
        }

        private void copyPasswordButton_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(passwordBox.Text);
        }

        private void copyNotesButton_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(notesBox.Text);
        }
    }
}
