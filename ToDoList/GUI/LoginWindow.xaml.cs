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
using Microsoft.Win32;
using System.IO;

namespace GUI
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        BLL_DangNhap dangNhap = new BLL_DangNhap();
        BLL_User bLL_User = new BLL_User();
        General general = new General();
        public LoginWindow()
        {
            InitializeComponent();            
            Directory.CreateDirectory("..\\..\\..\\Attachments");
            Directory.CreateDirectory("..\\..\\..\\Avatar");            
            //string destinationDir = "..\\Avatar\\";
            //File.Copy("../../../Images/favicon.png", destinationDir + "favicon.png", true);
        }

        private void Button_Exit(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void Button_Login(object sender, RoutedEventArgs e)
        {            
            string password = Password.Password;
            //pass encode
            string passCode = general.passEncode;
            string passDecode = general.EncryptString(password, passCode);
            int roleID = bLL_User.getRoleIDByEmail(Email.Text);

            if (dangNhap.TryLogin(Email.Text, passDecode))
            {                
                UserSingleTon.Instance.User=bLL_User.getUserByEmail(Email.Text);
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
       

        private void test_MouseDown(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                Uri fileUri = new Uri(openFileDialog.FileName);
                test.Source = new BitmapImage(fileUri);
                MessageBox.Show(test.Source.ToString());
                byte[] arr= { };
                File.WriteAllBytes("Foo.txt", arr);
            }
        }

        private void Grid_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                string password = Password.Password;
                //pass encode
                string passCode = general.passEncode;
                string passDecode = general.EncryptString(password, passCode);
                int roleID = bLL_User.getRoleIDByEmail(Email.Text);

                if (dangNhap.TryLogin(Email.Text, passDecode))
                {
                    UserSingleTon.Instance.User = bLL_User.getUserByEmail(Email.Text);
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
        }
    }
}

