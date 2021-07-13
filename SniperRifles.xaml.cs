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
    /// Логика взаимодействия для SniperRifles.xaml
    /// </summary>
    public partial class SniperRifles : Window
    {
        public SniperRifles()
        {
            InitializeComponent();
        }

        private void BtScout_G7_Click(object sender, RoutedEventArgs e)
        {
            PreyscourantWeaponTest preyscourantWeaponTest = new PreyscourantWeaponTest();
            preyscourantWeaponTest.Show();
            Visibility = Visibility.Collapsed;
        }

        private void BtTriple_Take_Click(object sender, RoutedEventArgs e)
        {
            PreyscourantWeaponTest preyscourantWeaponTest = new PreyscourantWeaponTest();
            preyscourantWeaponTest.Show();
            Visibility = Visibility.Collapsed;
        }

        private void BtLongbow_Click(object sender, RoutedEventArgs e)
        {
            PreyscourantWeaponTest preyscourantWeaponTest = new PreyscourantWeaponTest();
            preyscourantWeaponTest.Show();
            Visibility = Visibility.Collapsed;
        }

        private void BtKraber_Click(object sender, RoutedEventArgs e)
        {
            PreyscourantWeaponTest preyscourantWeaponTest = new PreyscourantWeaponTest();
            preyscourantWeaponTest.Show();
            Visibility = Visibility.Collapsed;
        }
    }
}
