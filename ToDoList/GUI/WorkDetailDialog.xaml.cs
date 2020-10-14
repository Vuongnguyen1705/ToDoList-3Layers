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
        string iduser;
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
            if (Int32.Parse(UserSingleTon.Instance.User.UserRoleID) == 3)
            {
                DatePickerStartDate.IsEnabled = false ;
                DatePickerEndDate.IsEnabled = false;
            }
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
                    //MessageBox.Show(item.WorkRange);
                }

                //MessageBox.Show(item.WorkCoWorker);
                if (item.WorkCoWorker == "")
                {
                    MessageBox.Show("bi null");
                    item.WorkCoWorker = "0";
                }
                string tenNhanVien=bLL_User.getFullNameByID(Convert.ToInt32(item.WorkCoWorker)).ToString();
                //ComboBoxListUser.Text = tenNhanVien;
                NguoiLamChung.Text = tenNhanVien;
                //MessageBox.Show("--"+tenNhanVien+"--");
                TextBlockAttachment.Text = item.WorkAttachment;
                WorkId.Text = item.WorkID.ToString();
                iduser =item.WorkUserID;
                //MessageBox.Show("coworker: " + bLL_User.getFullNameByID(Convert.ToInt32(item.WorkCoWorker)).ToString());
                //MessageBox.Show("da load xong");
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
            openFileDialog.Filter = "Text files (*.txt, *.doc, *.docx, *.pdf, *.ppt,*.pptx, *.ppsx)|*.txt; *.doc; *.docx; *.pdf; *.ppt; *.pptx; *.ppsx" +
                "|Image files (*.png, *jpg)|*.png; *jpg";
            //"|All files (*.*)|*.*";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (openFileDialog.ShowDialog() == true)
            {

                Uri fileUri = new Uri(openFileDialog.FileName);
                string filePath = fileUri.ToString().Remove(0, 8);
                TextBlockAttachment.Text = System.IO.Path.GetFileName(filePath);
                string destinationDir = "..\\..\\..\\Attachments\\";
                System.IO.File.Copy(filePath, destinationDir + System.IO.Path.GetFileName(filePath), true);
            }
        }

        private void TextBlockAttachment_Click_File(object sender, RoutedEventArgs e)
        {
            if (TextBlockAttachment.Text != null)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Text files (*.txt, *.doc, *.docx, *.pdf, *.ppt,*.pptx, *.ppsx)|*.txt; *.doc; *.docx; *.pdf; *.ppt; *.pptx; *.ppsx" +
                    "|Image files (*.png, *jpg)|*.png; *jpg";                

                if (saveFileDialog.ShowDialog() == true)
                {
                    Uri fileUri = new Uri(saveFileDialog.FileName);
                    string destinationDir = fileUri.ToString().Remove(0, 8); //path + filename
                    string filePath = "..\\..\\..\\Attachments\\" + TextBlockAttachment.Text;
                    System.IO.File.Copy(filePath, destinationDir, true);
                }
            }
        }

        private void Button_Click_Update(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("zo");
            string id = WorkId.Text;
            //MessageBox.Show(id);
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
            if (ComboBoxListUser.Text.Equals(""))
            {
                //MessageBox.Show("cbb user rong");
                //MessageBox.Show(NguoiLamChung.Text);
                work.WorkCoWorker = bLL_User.getIDByFullName(NguoiLamChung.Text).ToString();
                //MessageBox.Show(work.WorkCoWorker);
            }
            else
            {
                //MessageBox.Show("cbb user khac rong");
                //MessageBox.Show(NguoiLamChungHT.Text);
                work.WorkCoWorker = bLL_User.getIDByFullName(NguoiLamChungHT.Text).ToString();
                //MessageBox.Show(work.WorkCoWorker);
            }
            work.WorkAttachment = TextBlockAttachment.Text;
            work.WorkUserID = iduser;
            bLL_Work.UpdateWork(work);
            MessageBox.Show("Update thành công");
            Close();
        }

        private void Button_Click_Comment(object sender, RoutedEventArgs e)
        {
            if (!TextBoxInputComment.Text.Equals(""))
            {
                bLL_Comment.insertComment(new DTO_Comment(1, UserSingleTon.Instance.User.UserID.ToString(), idWork, TextBoxInputComment.Text));
                TextBoxInputComment.Clear();
                ShowComment();
            }

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

        private void ComboBoxListUser_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int id = ComboBoxListUser.SelectedIndex;
            id = id + 2;
            NguoiLamChungHT.Text = bLL_User.getFullNameByID(id);
        }

    }
}
