using SalorMoon.MainCellProfitDataSetTableAdapters;
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

namespace SalorMoon
{
    /// <summary>
    /// Логика взаимодействия для Page2.xaml
    /// </summary>
    public partial class Page2 : Page
    {
        UsersTableAdapter users = new UsersTableAdapter();
        RoleTableAdapter role = new RoleTableAdapter();
        TeamTableAdapter team = new TeamTableAdapter();
        public Page2()
        {
            InitializeComponent();
            UserGrid.ItemsSource = users.GetData();
            znachenieIdTeam.ItemsSource = team.GetDataBy();
            znachenieIdTeam.DisplayMemberPath = "Наименование команды";
            znachenieIdTeam.SelectedValuePath = "TeamID";
            znachenieIdRole.ItemsSource = role.GetDataBy3();
            znachenieIdRole.DisplayMemberPath = "Наименование роли";
            znachenieIdRole.SelectedValuePath = "RoleID";
        }

        private void CreateBut_Click(object sender, RoutedEventArgs e)
        {
            users.InsertQuery(znachenieNameUser.Text, znachenieUserPassword.Text, Convert.ToInt32(znachenieIdRole.SelectedValue), Convert.ToInt32(znachenieIdTeam.SelectedValue));

            UserGrid.ItemsSource = users.GetData();
        }

        private void ChangeBut_Click(object sender, RoutedEventArgs e)
        {
            int selectedIndex = UserGrid.SelectedIndex;
            int id = (int)users.GetDataBy().Rows[selectedIndex][4];
            users.UpdateQuery(znachenieNameUser.Text, znachenieUserPassword.Text, Convert.ToInt32(znachenieIdRole.SelectedValue), Convert.ToInt32(znachenieIdTeam.SelectedValue), Convert.ToInt32(id), Convert.ToInt32(id));
            UserGrid.ItemsSource = users.GetData();
        }

        private void UserGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            if (UserGrid.SelectedItem != null)
            {
                object name = (UserGrid.SelectedItem as DataRowView).Row[0];
                znachenieNameUser.Text = name.ToString();
                object pass = (UserGrid.SelectedItem as DataRowView).Row[1];
                znachenieUserPassword.Text = pass.ToString();
                object RoleID = (UserGrid.SelectedItem as DataRowView).Row[3];
                znachenieIdRole.SelectedItem = RoleID;
                znachenieIdRole.Text = RoleID.ToString();
                object TeamID = (UserGrid.SelectedItem as DataRowView).Row[2];
                znachenieIdTeam.SelectedItem = TeamID;
                znachenieIdTeam.Text = TeamID.ToString();
            }

        }

        private void DelBut_Click(object sender, RoutedEventArgs e)
        {
            int selectedIndex = UserGrid.SelectedIndex;
            int id = (int)users.GetDataBy().Rows[selectedIndex][4];
            users.DeleteQuery(Convert.ToInt32(id));
            UserGrid.ItemsSource = users.GetData();
        }
    }
}
