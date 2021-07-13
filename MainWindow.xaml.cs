using System;
using System.Collections.Generic;
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

namespace WeaponStore
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Window_Activated(object sender, EventArgs e)
        {
            InitializeComponent();
            Session.mainWindow = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Katalog katalog = new Katalog();
            katalog.Show();
            Visibility = Visibility.Collapsed;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Kontacts kontacts = new Kontacts();
            kontacts.Show();
            Visibility = Visibility.Collapsed;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            //Session.currentUser = null;
            //var roleList = new DBProcedures().getRoleList(Session.currentUser.ID_Role);
            //if (roleList.Count == 1)
            //{
            //    var role = roleList[0];

            //    this.Title = role.Title_Role;

            //    switch (role.Title_Role == "Администратор")
            //    {
            //        case (true):
            //Spravochnik spravochnik = new Spravochnik();
            //spravochnik.Show();
            //Visibility = Visibility.Collapsed;
            //            break;
            //        case (false):
            //            MessageBox.Show("Вы не администратор");
            //        break;
            //    }
            //}
            MessageBox.Show("Вы не администратор");
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Vakansii vakansii = new Vakansii();
            vakansii.Show();
            Visibility = Visibility.Collapsed;
        }
    }
}
