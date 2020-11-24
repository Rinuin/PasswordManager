using Microsoft.EntityFrameworkCore;
using PasswordManager.Data;
using PasswordManager.Data.Exceptions;
using PasswordManager.Data.ManageAuthentication;
using PasswordManager.Data.ManageData;
using PasswordManager.Windows;
using PasswordManager.Domain.Models;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PasswordManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //private readonly UserDataManager udm;
        //private readonly AccountDataManager adm;

        public MainWindow()
        {
            InitializeComponent();

            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;

            //udm = new UserDataManager();
            //adm = new AccountDataManager();

            //------------------------------------------TO DO----------------------------------------------------------------

            //using (PasswordManagerDatabaseContext passDb = new PasswordManagerDatabaseContext())
            //{
            //    passDb.Database.EnsureCreated();
            //}

            //_passDb = new PasswordManagerDatabaseContext();
            //_passDb.Database.EnsureCreated();
        }


        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private async void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            //Authenticator auth = new Authenticator(new DataManager<User>(new PasswordManagerDatabaseContextFactory("Data Source=PasswordManagerDatabaseContext.db")));
            Authenticator auth = new Authenticator();
            try
            {
                await auth.Login(usernameBox.Text, passwordBox.Password);

                if (PasswordManager.Properties.Settings.Default.LoggedInUserId != 0)
                {
                    LoggedInWindow liw = new LoggedInWindow(this);
                    this.usernameBox.Text = "";
                    this.passwordBox.Password = "";
                    this.Hide();
                    liw.Show();
                }
            }
            catch (UserNotFoundException ex)
            {
                MessageBox.Show("User: " + ex.Username + " not found");
            }
            catch (InvalidPasswordException ex)
            {
                MessageBox.Show("Invalid password: " + ex.Password + " for user: " + ex.Username);
            }
            catch (MissingValueException)
            {
                MessageBox.Show("Some values are missing! Check if you gave all necessary credentials");
            }
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            RegistrationWindow rw = new RegistrationWindow(this);
            this.Hide();
            rw.Show();

            
        }
    }
}
