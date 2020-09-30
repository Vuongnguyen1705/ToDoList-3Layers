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
            this.Close();
        }
        private void Button_Login(object sender, RoutedEventArgs e)
        {
            BLL_DangNhap dangNhap = new BLL_DangNhap();
            if (dangNhap.TryLogin(Email.Text, Password.Password))
            {
                var mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Sai thông tin đăng nhập");
            }
        }

        private void Bold_MouseLeftButtonUp_Register(object sender, MouseButtonEventArgs e)
        {
            var registerWindow = new RegisterWindow();
            registerWindow.Show();
            this.Close();
        }

        
    }
}

