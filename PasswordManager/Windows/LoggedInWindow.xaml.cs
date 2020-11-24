using PasswordManager.Data.ManageData;
using PasswordManager.Domain.Models;
using PasswordManager.Windows;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for LoggedInWindow.xaml
    /// </summary>
    public partial class LoggedInWindow : Window
    {
        private Window _mainWindow;

        //private readonly IEnumerable<Account>

        //possible result?

        //private async void getAccountList()
        //{
        //    AccountDataManager adm = new AccountDataManager();
        //    await accountList.ItemsSource = adm.GetAllAccountsByOwnerId(PasswordManager.Properties.Settings.Default.LoggedInUserId).Result;
        //}

        public LoggedInWindow(Window mainWindow)
        {
            InitializeComponent();

            _mainWindow = mainWindow;

            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;

            //============================= tworzenie listy kont dla zalogowanego użytkownika


            //await?
            AccountDataManager adm = new AccountDataManager();

            accountList.ItemsSource = adm.GetAllAccountsByOwnerId(PasswordManager.Properties.Settings.Default.LoggedInUserId).Result;

        }

        private void AddAccountButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            AddAccountWindow aaw = new AddAccountWindow();
            aaw.Show();
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            _mainWindow.Show();
        }

        private void editButton_Click(object sender, RoutedEventArgs e)
        {
            //odwolanie do accounta 
            Button button = sender as Button;
            Account account = button.DataContext as Account;

            EditAccountWindow eaw = new EditAccountWindow(account);
            this.Close();
            eaw.Show();
        }

        private async void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            Account account = button.DataContext as Account;
            AccountDataManager adm = new AccountDataManager();
            await adm.Delete(account.Id);
            this.Close();
            LoggedInWindow liw = new LoggedInWindow(_mainWindow);
            liw.Show();
        }

        private void viewButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            Account account = button.DataContext as Account;

            this.Hide();
            ViewContentsWindow vcw = new ViewContentsWindow(this, account);
            vcw.Show();
        }
    }
}
