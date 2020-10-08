using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GUI
{
    /// <summary>
    /// Interaction logic for MainAdminWindow.xaml
    /// </summary>
    public partial class MainAdminWindow : Window
    {
        private bool IsSort = false;
        BLL_User bLL_User = new BLL_User();
        BLL_Role role = new BLL_Role();
        public MainAdminWindow()
        {
            InitializeComponent();
            ShowUser();
            ShowHi();
            Filter();
        }

        private void ShowUser()
        {
            ObservableCollection<DTO_User> u = new ObservableCollection<DTO_User>();
            foreach (var item in bLL_User.getUserEnable())
            {
                if (!item.UserRoleID.Equals(""))
                {
                    u.Add(new DTO_User(item.UserID, item.UserAvatar, item.UserFullName, item.UserPhoneNumber, item.UserEmail, item.UserPassword, item.UserAddress, item.UserBirthday, item.UserGender,item.UserIsEnable,role.getRoleNameByID(Int32.Parse(item.UserRoleID))));
                }
                else
                {
                    u.Add(new DTO_User(item.UserID, item.UserAvatar, item.UserFullName, item.UserPhoneNumber, item.UserEmail, item.UserPassword, item.UserAddress, item.UserBirthday, item.UserGender, item.UserIsEnable, item.UserRoleID));
                }
            }

            ListViewUser.ItemsSource = u;

            //ListViewUser.ItemsSource = bLL_User.getUserEnable();
        }

        private void Filter()
        {
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(ListViewUser.ItemsSource);

            view.Filter = UserFilter;

        }

        private void TextBoxSearchMainAdmin_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(ListViewUser.ItemsSource).Refresh();
        }


        private void ButtonAddUser_Click(object sender, RoutedEventArgs e)
        {
            var addUser = new AddUserDialog();
            addUser.ShowDialog();
        }

        private void IconLogout_MouseDown_Logout(object sender, MouseButtonEventArgs e)
        {
            var logout = new LoginWindow();
            logout.Show();
            Close();
        }

        private bool UserFilter(object item)
        {
            if (String.IsNullOrEmpty(TextBoxSearchMainAdmin.Text))
                return true;
            else
                return ((item as DTO_User).UserFullName.IndexOf(TextBoxSearchMainAdmin.Text, StringComparison.OrdinalIgnoreCase) >= 0);

        }

        private void GridViewColumnHeader_Click_Sort(object sender, RoutedEventArgs e)
        {
            GridViewColumnHeader header = sender as GridViewColumnHeader;
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(ListViewUser.ItemsSource);
            if (IsSort)
            {
                view.SortDescriptions.Clear();
                view.SortDescriptions.Add(new SortDescription(header.Tag.ToString(), ListSortDirection.Descending));
            }
            else
            {
                view.SortDescriptions.Clear();
                view.SortDescriptions.Add(new SortDescription(header.Tag.ToString(), ListSortDirection.Ascending));
            }
            IsSort = !IsSort;
        }

        private void Ellipse_MouseDown_InfoUser(object sender, MouseButtonEventArgs e)
        {
            var info = new InfoUserDialog();
            info.ShowDialog();
        }
        private void ShowHi()
        {
            TextBlockHi.Text += UserSingleTon.Instance.User.UserFullName;
        }

        private void ButtonDeleteUser_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
