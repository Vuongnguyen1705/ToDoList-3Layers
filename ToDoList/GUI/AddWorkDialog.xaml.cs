using BLL;
using DTO;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for AddWorkDialog.xaml
    /// </summary>
    public partial class AddWorkDialog : Window
    {
        BLL_Work bLL_Work = new BLL_Work();
        BLL_User bLL_User = new BLL_User();
        public AddWorkDialog()
        {
            InitializeComponent();
            ShowListUser();
        }

        private void Button_Click_Cancel_AddWork(object sender, RoutedEventArgs e)
        {      
            Close();
        }

        private void ShowListUser()
        {
            ComboBoxListUser.ItemsSource = bLL_User.getFullName();
        }
        private void Attachment_MouseDown_Upload_File(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.txt, *.doc, *.docx, *.pdf, *.ppt,*.pptx, *.ppsx)|*.txt; *.doc; *.docx; *.pdf; *.ppt; *.pptx; *.ppsx" +
                "|Image files (*.png, *jpg)|*.png; *jpg";
            //"|All files (*.*)|*.*";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (openFileDialog.ShowDialog() == true)
            {

                Uri fileUri = new Uri(openFileDialog.FileName);
                string filePath = fileUri.ToString().Remove(0, 8);
                TextBlockAttachment.Text = System.IO.Path.GetFileName(filePath);
                string destinationDir = "..\\Attachments\\";
                System.IO.File.Copy(filePath, destinationDir + System.IO.Path.GetFileName(filePath), true);
            }
        }

        private void TextBlockAttachment_Click_File(object sender, RoutedEventArgs e)
        {
            
        }

        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {            
            string range;
            if (Validate() == 1)
            {
                if (RadioPublic.IsChecked == true)
                {
                    range = "Public";
                }
                else
                {
                    range = "Private";
                }
                bLL_Work.AddWork(TextBoxTitle.Text, Convert.ToDateTime(DatePickerStartDate.Text), Convert.ToDateTime(DatePickerEndDate.Text), ComboBoxState.Text, range, bLL_User.getIDByFullName(ComboBoxListUser.Text).ToString(), TextBlockAttachment.Text, UserSingleTon.Instance.User.UserID);
                Close();
                MessageBox.Show("Thêm thành công");
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
            }
            
        }
        private int Validate()
        {
            if(string.IsNullOrEmpty(TextBoxTitle.Text.Trim()) || string.IsNullOrEmpty(DatePickerStartDate.Text.Trim()) 
                || string.IsNullOrEmpty(DatePickerEndDate.Text.Trim()) || string.IsNullOrEmpty(ComboBoxState.Text.Trim())
                || string.IsNullOrEmpty(ComboBoxListUser.Text.Trim())){
                
                return 0;
            }
            return 1;
        }

    }
}
