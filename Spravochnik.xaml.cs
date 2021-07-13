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
using System.Windows.Shapes;

namespace WeaponStore
{
    /// <summary>
    /// Логика взаимодействия для Spravochnik.xaml
    /// </summary>
    public partial class Spravochnik : Window
    {
        public Spravochnik()
        {
            InitializeComponent();
        }

        private void BtWeapon_Click(object sender, RoutedEventArgs e)
        {
            Weapon weapon = new Weapon();
            weapon.Show();
            Visibility = Visibility.Collapsed;
        }

        private void BtModifications_Click(object sender, RoutedEventArgs e)
        {
            Modifications modifications = new Modifications();
            modifications.Show();
            Visibility = Visibility.Collapsed; ;
        }

        private void BtAmmo_Click(object sender, RoutedEventArgs e)
        {
            Ammo ammo = new Ammo();
            ammo.Show();
            Visibility = Visibility.Collapsed;
        }

        private void BtKlients_Click(object sender, RoutedEventArgs e)
        {
            Klients klients = new Klients();
            klients.Show();
            Visibility = Visibility.Collapsed;
        }

        private void BtBlockKlient_Click(object sender, RoutedEventArgs e)
        {
            BlockKlient blockKlient = new BlockKlient();
            blockKlient.Show();
            Visibility = Visibility.Collapsed;
        }

        private void BtSupply_Click(object sender, RoutedEventArgs e)
        {
            Supply supply = new Supply();
            supply.Show();
            Visibility = Visibility.Collapsed;
        }

        private void BtEmployee_Click(object sender, RoutedEventArgs e)
        {
            Employee employee = new Employee();
            employee.Show();
            Visibility = Visibility.Collapsed;
        }

        private void BtBack_Click(object sender, RoutedEventArgs e)
        {
            //Authorization authorization = new Authorization();
            //authorization.Show();
            //Visibility = Visibility.Collapsed;
            Close();
        }

        private void BtNakladnaya_Click(object sender, RoutedEventArgs e)
        {
            Nakladnaya nakladnaya = new Nakladnaya();
            nakladnaya.Show();
            Visibility = Visibility.Collapsed;
        }
    }
}
