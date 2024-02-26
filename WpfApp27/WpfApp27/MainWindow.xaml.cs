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

namespace WpfApp27
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            bAdd.IsEnabled = false;
            bDelete.IsEnabled = false;
            bEdit.IsEnabled = false;
            bSave.IsEnabled = false;
            bRand.IsEnabled = false;
            UserList.ItemsSource = User.Users;
        }
        private void bAdd_Click(object sender, RoutedEventArgs e)
        {
            User.Users.Add(new User(usrName.Text, usrSurname.Text, usrNumberPhone.Text, usrEmail.Text));
            UserList.Items.Refresh();
        }
        private void bDelete_Click(object sender, RoutedEventArgs e)
        {
            if(UserList.SelectedItem != null)
            {
                User.Users.RemoveAt(UserList.SelectedIndex);

            } else 
            { 
                bDelete.IsEnabled = false; 
            }
            UserList.Items.Refresh();
        }
        private void bClear_Click(object sender, RoutedEventArgs e)
        {
            usrName.Text = "";
            usrSurname.Text = "";
            usrNumberPhone.Text = "";
            usrEmail.Text = "";
        }
        private void bEdit_Click(object sender, RoutedEventArgs e)
        {
            if(UserList.SelectedIndex != -1)
            {
                var usr = User.Users[UserList.SelectedIndex];

                usrName.Text = usr.Name;
                usrSurname.Text = usr.Surname;
                usrNumberPhone.Text = usr.Number;
                usrEmail.Text = usr.Email;
            }
            else
            {
                bEdit.IsEnabled = false;
            }
        }
        private void bSave_Click(object sender, RoutedEventArgs e)
        {
            User.Users[UserList.SelectedIndex] = new User(usrName.Text, usrSurname.Text, usrNumberPhone.Text, usrEmail.Text);
            UserList.Items.Refresh();
            bSave.IsEnabled = false;
        }
        private void usrTextChanged(object sender, TextChangedEventArgs e)
        {
            if(usrName.Text.Length > 3 & usrEmail.Text.Length > 3 & usrSurname.Text.Length > 3 & usrNumberPhone.Text.Length > 3)
            {
                bAdd.IsEnabled = true;
            }
            else
            {
                bAdd.IsEnabled = false;
            }
            if(UserList.SelectedItem != null)
            {
                if(User.Users[UserList.SelectedIndex].Name != usrName.Text & User.Users[UserList.SelectedIndex].Surname != usrSurname.Text & User.Users[UserList.SelectedIndex].Number != usrNumberPhone.Text & User.Users[UserList.SelectedIndex].Email != usrEmail.Text )
                {
                    bEdit.IsEnabled = true;
                    bSave.IsEnabled = false;
                } else 
                { 
                    bSave.IsEnabled = true;
                    bEdit.IsEnabled = false; 
                }
            }
        }
        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            UserList.Height = window.Height - 40;
        }
        private void UserList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(UserList.SelectedItem != null | UserList.SelectedItems != null)
            {
                bDelete.IsEnabled = true;
                bEdit.IsEnabled = true;
            }
            else
            {
                bEdit.IsEnabled = false;
                bDelete.IsEnabled = false;
            }

        }
    }
}
