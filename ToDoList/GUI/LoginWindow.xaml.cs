using DAL;
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
using BLL;
using System.Data.SqlClient;
using System.Security.Cryptography;
using DTO;

namespace GUI
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void Button_Exit(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void Button_Login(object sender, RoutedEventArgs e)
        {
            BLL_DangNhap dangNhap = new BLL_DangNhap();
            BLL_User bLL_User = new BLL_User();
            General general = new General();
            string password = Password.Password;
            //pass encode
            string passCode = general.passEncode;
            string passDecode = general.EncryptString(password, passCode);
            int roleID = bLL_User.getRoleIDByEmail(Email.Text);

            if (dangNhap.TryLogin(Email.Text, passDecode))
            {
                if (roleID == 1)
                {
                    var mainAdmin = new MainAdminWindow();
                    mainAdmin.Show();
                }
                else
                {
                    var mainWindow = new MainWindow();
                    mainWindow.Show();
                }
                Close();
            }
            else
            {
                MessageBox.Show("Sai thông tin đăng nhập");
            }
        }

        private void Bold_MouseLeftButtonUp_Register(object sender, MouseButtonEventArgs e)
        {
   
        }

        

    }
}

