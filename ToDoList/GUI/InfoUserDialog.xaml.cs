using BLL;
using DAL;
using DTO;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Reflection.Metadata;
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
    /// Interaction logic for InfoUserWindow.xaml
    /// </summary>
    public partial class InfoUserDialog : Window
    {
        General general = new General();
        BLL_User user = new BLL_User();

        public InfoUserDialog()
        {
            InitializeComponent();
            SetInfo();
        }

        private void SetInfo()
        {
            //ImageBrushAvatar.ImageSource = new ImageBrush();
            //ImageBrushAvatar.ImageSource = new BitmapImage(new Uri(@"Images/favicon.png"));
            TextBoxFullName.Text = UserSingleTon.Instance.User.UserFullName;
            TextBoxPhone.Text = UserSingleTon.Instance.User.UserPhoneNumber;
            TextBoxAddress.Text = UserSingleTon.Instance.User.UserAddress;
            TextBoxEmail.Text = UserSingleTon.Instance.User.UserEmail;
            DatePickerBirthday.Text = UserSingleTon.Instance.User.UserBirthday.ToString();
            ComboBoxGender.Text = UserSingleTon.Instance.User.UserGender.ToString();
            
        }
        private void Button_Click_Apply(object sender, RoutedEventArgs e)
        {
            if (CheckBoxChangePass.IsChecked.Equals(false))
            {
                Close();
            }
            else
            {
                if (string.IsNullOrEmpty(PasswordBoxOldPass.Password))
                {
                    MessageBox.Show("nhap pass di ban ei");
                }
                else
                {
                    if (!general.EncryptString( PasswordBoxOldPass.Password,general.passEncode).Equals(UserSingleTon.Instance.User.UserPassword))
                    {
                        MessageBox.Show("nhap sai r ba ");
                    }
                    else
                    {
                        if (!PasswordBoxNewPassConfirm.Password.Equals(PasswordBoxNewPass.Password))
                        {
                            MessageBox.Show("Nhap 2 pass khac nhau roi kia <('')> ");
                        }
                        else 
                        {
                            user.UpdateUserPassword(UserSingleTon.Instance.User.UserID,general.EncryptString(PasswordBoxNewPass.Password,general.passEncode));
                            MessageBox.Show("da luu thanh cong ");
                            Close(); 
                        }
                    }
                }
            }
            
            
        }

        private void Button_Click_Cancel(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void checkChangePassWordCheckBox_Is_Check ( object sender, RoutedEventArgs e)
        {
            if (CheckBoxChangePass.IsChecked.Equals(true))
            {
                MessageBox.Show("Sai thông tin đăng nhập");
            }
        }
        private void CheckBoxChangePass_Unchecked_Pass(object sender, RoutedEventArgs e)
        {
            if (CheckBoxChangePass.IsChecked.Equals(false))
            {
                PasswordBoxOldPass.IsEnabled = false;
                PasswordBoxNewPass.IsEnabled = false;
                PasswordBoxNewPassConfirm.IsEnabled = false;
            }
            else
            {
                PasswordBoxOldPass.IsEnabled = true;
                PasswordBoxNewPass.IsEnabled = true;
                PasswordBoxNewPassConfirm.IsEnabled = true;
            }
        }

        private void Ellipse_MouseDown_Change_Avatar(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                Uri fileUri = new Uri(openFileDialog.FileName);
                ImageBrushAvatar.ImageSource = new BitmapImage(fileUri);
                MessageBox.Show(ImageBrushAvatar.ImageSource.ToString());
                
            }

        }
    }
}
