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
        public WorkDetailDialog(int id)
        {
            InitializeComponent();
            idWork = id;
            ShowListUser();
            ShowComment();
             
        }
        private void Button_Click_Cancel(object sender, RoutedEventArgs e)
        {            
            Close();
        }

        private void ShowDetailWork()
        {
            
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

        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {

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
                //ListViewComment.Items.Add(new DTO_Comment(19, UserSingleTon.Instance.User.UserFullName, idWork, TextBoxInputComment.Text));
                TextBoxInputComment.Clear();
                //CollectionViewSource.GetDefaultView(ListViewComment.ItemsSource).Refresh();
                ShowComment();
            }
        }

    }
}
