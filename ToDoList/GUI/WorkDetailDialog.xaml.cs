using BLL;
using DTO;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for WorkDetailDialog.xaml
    /// </summary>
    public partial class WorkDetailDialog : Window
    {
        int idWork;
        ObservableCollection<string> names = new ObservableCollection<string>();
        BLL_Comment bLL_Comment = new BLL_Comment();
        BLL_User bLL_User = new BLL_User();
        BLL_Work bLL_Work = new BLL_Work();
        public WorkDetailDialog(int id)
        {
            InitializeComponent();
            idWork = id;
            ShowListUser();
            ShowComment();
            ShowDetailWork();

        }

        private void Button_Click_Cancel(object sender, RoutedEventArgs e)
        {            
            Close();
        }

        private void ShowDetailWork()
        {
            ObservableCollection<DTO_Work> list = bLL_Work.getById(idWork);
            foreach (var item in list)
            {
                TextBoxTitle.Text = item.WorkTitle;
                DatePickerStartDate.Text = item.WorkStartDate.ToString();
                DatePickerEndDate.Text = item.WorkEndDate.ToString();
                ComboBoxState.Text = item.WorkStatus;
                if (item.WorkRange.Trim().Equals("Public"))
                {

                }
                else
                {
                    RadioPrivate.IsChecked = true;
                    MessageBox.Show(item.WorkRange);
                }
                string tenNhanVien = bLL_User.getFullNameByID(Convert.ToInt32(item.WorkCoWorker)).Trim().ToString();
                ComboBoxListUser.Text = tenNhanVien;
                MessageBox.Show("--"+tenNhanVien+"--");
                TextBlockAttachment.Text = item.WorkAttachment;
                WorkId.Text = item.WorkID.ToString();
                MessageBox.Show("coworker: " + bLL_User.getFullNameByID(Convert.ToInt32(item.WorkCoWorker)).ToString());
                MessageBox.Show("da load xong");
            }
        }

        private void ShowComment()
        {
            ObservableCollection<DTO_Comment> comments = new ObservableCollection<DTO_Comment>();
            foreach(var item in bLL_Comment.getCommentByIDWork(idWork))
            {
                comments.Add(new DTO_Comment(item.CommentID, bLL_User.getFullNameByID(Int32.Parse(item.CommentUserID)), item.CommentWorkID, item.CommentContent));
            }
            ListViewComment.ItemsSource = comments;
        }
        private void ShowListUser()
        {
            ComboBoxListUser.ItemsSource = bLL_User.getUserEnable();         
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

        private void Button_Click_Update(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("zo");
            string id = WorkId.Text;
            MessageBox.Show(id);
            string range;
            if (RadioPublic.IsChecked == true)
            {
                range = "Public";
            }
            else
            {
                range = "Private";
            }
            DTO_Work work = new DTO_Work();
            work.WorkID = Convert.ToInt32(id);
            work.WorkTitle = TextBoxTitle.Text;
            work.WorkStartDate = Convert.ToDateTime(DatePickerStartDate.Text);
            work.WorkEndDate = Convert.ToDateTime(DatePickerEndDate.Text);
            work.WorkStatus = ComboBoxState.Text;
            work.WorkRange = range;
            work.WorkCoWorker = bLL_User.getIDByFullName(ComboBoxListUser.Text).ToString();
            work.WorkAttachment = TextBlockAttachment.Text;
            work.WorkUserID=UserSingleTon.Instance.User.UserID;
            MessageBox.Show(ComboBoxListUser.Text);
            bLL_Work.UpdateWork(work);
            MessageBox.Show("Update thành công");
            Close();
        }

        private void Button_Click_Comment(object sender, RoutedEventArgs e)
        {            
            bLL_Comment.insertComment(new DTO_Comment(1, UserSingleTon.Instance.User.UserID.ToString(), idWork, TextBoxInputComment.Text));
            TextBoxInputComment.Clear();

        }

        private void TextBoxInputComment_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && !TextBoxInputComment.Text.Equals(""))
            {
                bLL_Comment.insertComment(new DTO_Comment(1,UserSingleTon.Instance.User.UserID.ToString(),idWork,TextBoxInputComment.Text));                
                TextBoxInputComment.Clear();             
                ShowComment();
            }
        }

    }
}
