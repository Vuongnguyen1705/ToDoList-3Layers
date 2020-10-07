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
            List<string> user = new List<string>();
            BLL_User bLL_User = new BLL_User();
            ComboBoxListUser.ItemsSource = bLL_User.getFullName();
        }
        private void Attachment_MouseDown_Upload_File(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;
            openFileDialog.Filter = "Text files (*.txt, *.doc, *.docx, *.pdf, *.ppt,*.pptx, *.ppsx)|*.txt; *.doc; *.docx; *.pdf; *.ppt; *.pptx; *.ppsx" +
                "|Image files (*.png, *jpg)|*.png; *jpg";
                //"|All files (*.*)|*.*";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (openFileDialog.ShowDialog() == true)
            {
                foreach (string filename in openFileDialog.FileNames)
                    TextBlockAttachment.Text = System.IO.Path.GetFileName(filename);
            }
        }

        private void TextBlockAttachment_Click_File(object sender, RoutedEventArgs e)
        {
            
        }

        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            BLL_Work bLL_Work = new BLL_Work();
            BLL_User bLL_User = new BLL_User();
            string range;
            if (RadioPublic.IsChecked==true)
            {
                range = "Public";
            }
            else
            {
                range = "Private";
            }
            bLL_Work.AddWork(TextBoxTitle.Text,Convert.ToDateTime(DatePickerStartDate.Text),Convert.ToDateTime(DatePickerEndDate.Text),ComboBoxState.Text,range,bLL_User.getIDByFullName(ComboBoxListUser.Text).ToString(),TextBlockAttachment.Text,UserSingleTon.Instance.User.UserID);
            Close();
            MessageBox.Show("Thêm thành công");
        }

        //-----------updateeee
        public AddWorkDialog(string Id)
        {
            InitializeComponent();
            BLL_Work bLL_Work = new BLL_Work();
            DTO_Work res = new DTO_Work();
            int id = Convert.ToInt32(Id);
            List<DTO_Work> list=bLL_Work.getById(id);
            foreach(var item in list)
            {
                //res.WorkTitle=
            }
        }
    }
}
