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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PasswordManager.Controls
{
    /// <summary>
    /// Interaction logic for AccountListItem.xaml
    /// </summary>
    public partial class AccountListItem : UserControl
    {

        public Action ShowContentWindowCallback { get; set; }

        public Account AccountContext { get => this.DataContext as Account; }
        public AccountListItem()
        {
            InitializeComponent();
        }

        private void ButtonsClicked(object sender, RoutedEventArgs e)
        {
            switch(int.Parse(((Button)sender).Uid))
            {
                case 1: if (!AccountNull) Clipboard.SetText(AccountContext.Email); break; //Copy Email
                case 2: if (!AccountNull) Clipboard.SetText(AccountContext.Password); break; //Copy Password
                case 3: break; //View Contents
            }
        }

        public bool AccountNull => AccountContext == null;
    }
}
