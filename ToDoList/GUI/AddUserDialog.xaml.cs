using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for AddUserDialog.xaml
    /// </summary>
    public partial class AddUserDialog : Window
    {
        BLL_Work bLL_Work = new BLL_Work();
        BLL_User bLL_User = new BLL_User();
        BLL_Role bLL_Role = new BLL_Role();
        public AddUserDialog()
        {
            InitializeComponent();
        }

        private void Button_Click_Cancel(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Ellipse_MouseDown_Change_Avatar(object sender, MouseButtonEventArgs e)
        {


        }
        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            if (Validate() == 0)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");                
            }
            else if(Validate() == 2)
            {
                MessageBox.Show("Mật khẩu không khớp");
                PasswordBoxPassCofirm.Focus();
            }
            else if (Validate() == 3)
            {
                MessageBox.Show("Email không đúng định dạng");
                TextBoxEmail.Focus();
            }else if (Validate() == 4)
            {
                MessageBox.Show("Số điện thoại không hợp lệ");
            }
            

        }

        private int Validate()
        {
            Regex regexMail =new Regex(@"^[a-z][a-z0-9_\.]{4,32}@[a-z0-9]{2,}(\.[a-z0-9]{2,4}){1,2}$");
            Regex regexPhone = new Regex(@"^(03|07|08|09|01[2|6|8|9])+([0-9]{8})$");
            if (string.IsNullOrEmpty(TextBoxFullName.Text.Trim()) || string.IsNullOrEmpty(TextBoxPhone.Text.Trim())
                || string.IsNullOrEmpty(TextBoxEmail.Text.Trim()) || string.IsNullOrEmpty(PasswordBoxPass.Password.Trim())
                || string.IsNullOrEmpty(PasswordBoxPassCofirm.Password.Trim()) || string.IsNullOrEmpty(ComboBoxRole.Text)
                || string.IsNullOrEmpty(DatePickerBirthday.Text))
            {

                return 0;//rỗng
            }
            else if (!PasswordBoxPass.Password.Equals(PasswordBoxPassCofirm.Password))
            {
                return 2;//sai pass
            }
            else if (!regexMail.IsMatch(TextBoxEmail.Text))
            {
                return 3;//sai mail
            }else if (!regexPhone.IsMatch(TextBoxPhone.Text))
            {
                return 4;//sai sdt
            }
            return 1;
        }
    }
}
