using System;
using System.Collections.Generic;
using System.Data;
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
using First.praktDataSetTableAdapters;

namespace First
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ProductTableAdapter Prodict = new ProductTableAdapter();
        FactoryPriceTableAdapter price = new FactoryPriceTableAdapter();
        public MainWindow()
        {
            InitializeComponent();
            GridF.ItemsSource = Prodict.GetData();
            zmachenieCombobox.ItemsSource = price.GetData();
            zmachenieCombobox.DisplayMemberPath = "Цена";
        }

        private void sec_Click(object sender, RoutedEventArgs e)
        {
            Window1 mainForm = new Window1();
            mainForm.Show();
            this.Close();
        }

        private void th_Click(object sender, RoutedEventArgs e)
        {
            Window2 mainForm = new Window2();
            mainForm.Show();
            this.Close();
        }

        private void zmacheniePrice_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(zmachenieName.Text) || string.IsNullOrEmpty(zmachenieModel.Text) || string.IsNullOrEmpty(zmachenieCombobox.Text))
            {

            }
            else
            {
                Prodict.InsertQuery(zmachenieName.Text, zmachenieModel.Text, zmachenieCombobox.SelectedIndex + 1);
            }
            MainWindow mainForm = new MainWindow();
            mainForm.Show();
            this.Close();
        }

        private void zmachenieDel_Click(object sender, RoutedEventArgs e)
        {

            object id = (GridF.SelectedItem as DataRowView).Row[0];
            Prodict.DeleteQuery(Convert.ToString(id));
            MainWindow mainForm = new MainWindow();
            mainForm.Show();
            this.Close();
        }

        private void GridF_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object name = (GridF.SelectedItem as DataRowView).Row[0];
            zmachenieName.Text = (Convert.ToString(name));
            object contacts = (GridF.SelectedItem as DataRowView).Row[1];
            zmachenieModel.Text = (Convert.ToString(contacts));
            object numFactory = (GridF.SelectedItem as DataRowView).Row[2];
            zmachenieCombobox.Text = (Convert.ToString(numFactory));
        }

        private void Changed_Click(object sender, RoutedEventArgs e)
        {
            object id = (GridF.SelectedItem as DataRowView).Row[0];
            Prodict.UpdateQuery(zmachenieName.Text, zmachenieModel.Text, Convert.ToInt32(zmachenieCombobox.SelectedIndex + 1), Convert.ToString(id));
            MainWindow mainForm = new MainWindow();
            mainForm.Show();
            this.Close();
        }
    }
}
