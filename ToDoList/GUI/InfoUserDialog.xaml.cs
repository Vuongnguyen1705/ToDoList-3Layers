using BLL;
using DAL;
using DTO;
using Microsoft.Win32;
using System;
using System.Collections.Generic;

using System.Data.SqlClient;
using System.Reflection.Metadata;
using System.IO;
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
            //ImageBrushAvatar.ImageSource = new BitmapImage(new Uri(@UserSingleTon.Instance.User.UserAvatar));
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
                user.UpdateUser(new DTO_User(UserSingleTon.Instance.User.UserID, UserSingleTon.Instance.User.UserAvatar, TextBoxFullName.Text.Trim(), TextBoxPhone.Text.Trim(), UserSingleTon.Instance.User.UserEmail, UserSingleTon.Instance.User.UserPassword, TextBoxAddress.Text.Trim(), DatePickerBirthday.DisplayDate, ComboBoxGender.Text, true, UserSingleTon.Instance.User.UserRoleID));
                UserSingleTon.Instance.User = user.getUserByEmail(UserSingleTon.Instance.User.UserEmail);
                MessageBox.Show("Đã lưu");                
                Close();
            }
            else
            {
                if (string.IsNullOrEmpty(PasswordBoxOldPass.Password))
                {
                    MessageBox.Show("Vui lòng nhập mật khẩu cũ");
                }
                else
                {
                    if (!general.EncryptString( PasswordBoxOldPass.Password,general.passEncode).Equals(UserSingleTon.Instance.User.UserPassword))
                    {
                        MessageBox.Show("Mật khẩu cũ không chính xác");
                    }
                    else
                    {
                        if (PasswordBoxNewPass.Password.Equals(""))
                        {
                            MessageBox.Show("Vui lòng nhập mật khẩu mới");

                        }else
                            if (!PasswordBoxNewPassConfirm.Password.Equals(PasswordBoxNewPass.Password))
                            {
                                MessageBox.Show("Mật khẩu không khớp");
                            }
                            else 
                            {
                                user.UpdateUser(new DTO_User(UserSingleTon.Instance.User.UserID, UserSingleTon.Instance.User.UserAvatar, TextBoxFullName.Text.Trim(), TextBoxPhone.Text.Trim(), UserSingleTon.Instance.User.UserEmail, general.EncryptString(PasswordBoxNewPass.Password.Trim(),general.passEncode), TextBoxAddress.Text.Trim(), DatePickerBirthday.DisplayDate, ComboBoxGender.Text, true, UserSingleTon.Instance.User.UserRoleID));
                                UserSingleTon.Instance.User = user.getUserByEmail(UserSingleTon.Instance.User.UserEmail);
                                MessageBox.Show("Đã lưu");
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
           
        }

        private void Ellipse_MouseDown_Change_Avatar(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {

                Uri fileUri = new Uri(openFileDialog.FileName);
                ImageBrushAvatar.ImageSource = new BitmapImage(fileUri);
                string filePath = fileUri.ToString().Remove(0, 8);
                string destinationDir = "..\\Avatar\\";
                System.IO.File.Copy(filePath, destinationDir + System.IO.Path.GetFileName(filePath), true);
            }

        }
    }
}
