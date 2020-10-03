using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool IsSort = false;
        public MainWindow()
        {
            InitializeComponent();
            ShowStatus();
            ShowRange();
            ShowWork();
            Filter();

            //test user
            //BLL_User u = new BLL_User();
            //u.AddUser(new DTO_User(99, "File hinh anh", "NVC", "0941201209", "abc@gmail.com", "123456", "Q11, TPHCM", new DateTime(1999,01,01), "Nam", true, 3));
            //u.UpdateUser(new DTO_User(9,"File hinh", "BBB", "0934571234", "bbb@gmail.com", "123456", "Q11,  TPHCM", new DateTime(1990, 01, 01), "Nu", true, 3));
            //u.DeleteUser(9);

            //test work
            //BLL_Work w = new BLL_Work();
            //w.AddWork(new DTO_Work(99, "1 Viec eo nao do", new DateTime(2020, 09, 09), new DateTime(2020, 09, 10), "Đang làm", "Public", "", "", 10));
            //w.UpdateWork(new DTO_Work(6, "Some fricking work", new DateTime(2020, 09, 05), new DateTime(2020, 09, 12), "Trễ hạn", "Private", "", "", 10));
            //w.DeleteWork(6);
        }   

        private void ShowWork()
        {
            BLL_Work bLL_Work = new BLL_Work();
            ListViewWork.ItemsSource = bLL_Work.getAll();            
        }

        public void ShowStatus()
        {
            BLL_Work bLL_Work = new BLL_Work();
            ComboBoxStatus.ItemsSource = bLL_Work.getStatus();
            
        }

        private void ShowRange()
        {
            BLL_Work bLL_Work = new BLL_Work();
            ComboBoxRange.ItemsSource = bLL_Work.getRange();
        }
        
        private void Filter()
        {
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(ListViewWork.ItemsSource);           

            view.Filter = StatusFilter;
            
        }
        private bool WorkTitleFilter(object item)
        {
            if (String.IsNullOrEmpty(TextBoxSearchMain.Text))
                return true;
            else
                return ((item as DTO_Work).WorkTitle.IndexOf(TextBoxSearchMain.Text, StringComparison.OrdinalIgnoreCase) >= 0);

        }

        private bool StatusFilter(object item)
        {            
            if ( String.IsNullOrEmpty(ComboBoxStatus.Text) || ComboBoxStatus.SelectedItem.ToString().Equals("Tất cả"))
                return true;
            else
                return ((item as DTO_Work).WorkStatus.IndexOf(ComboBoxStatus.SelectedItem.ToString(), StringComparison.OrdinalIgnoreCase) >= 0);

        }

        private void GridViewColumnHeader_Click_Sort(object sender, RoutedEventArgs e)
        {
            GridViewColumnHeader header = sender as GridViewColumnHeader;
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(ListViewWork.ItemsSource);
            if (IsSort)
            {
                view.SortDescriptions.Clear();
                view.SortDescriptions.Add(new SortDescription(header.Content.ToString(), ListSortDirection.Descending));
            }
            else
            {
                view.SortDescriptions.Clear();
                view.SortDescriptions.Add(new SortDescription(header.Content.ToString(), ListSortDirection.Ascending));
            }
            IsSort = !IsSort;
        }

        private void TextBoxSearchMain_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(ListViewWork.ItemsSource).Refresh();
        }

        private void IconLogout_MouseDown_Logout(object sender, MouseButtonEventArgs e)
        {
            var login = new LoginWindow();
            login.Show();
            Close();
        }

        private void ComboBoxStatus_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            CollectionViewSource.GetDefaultView(ListViewWork.ItemsSource).Refresh();
            //MessageBox.Show(ComboBoxStatus.SelectedIndex.ToString() + "--" + ComboBoxStatus.SelectedItem.ToString()+"--"+ComboBoxStatus.Text);
        }
    }
}
