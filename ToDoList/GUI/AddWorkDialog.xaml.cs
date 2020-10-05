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
        }

        private void Button_Click_Cancel_AddWork(object sender, RoutedEventArgs e)
        {
            Close();
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
    }
}
