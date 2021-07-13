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
    /// Логика взаимодействия для Pistols.xaml
    /// </summary>
    public partial class Pistols : Window
    {
        public Pistols()
        {
            InitializeComponent();
        }

        private void BtWingman_Click(object sender, RoutedEventArgs e)
        {
            PreyscourantWeaponTest preyscourantWeaponTest = new PreyscourantWeaponTest();
            preyscourantWeaponTest.Show();
            Visibility = Visibility.Collapsed;
        }

        private void BtP_2020_Click(object sender, RoutedEventArgs e)
        {
            PreyscourantWeaponTest preyscourantWeaponTest = new PreyscourantWeaponTest();
            preyscourantWeaponTest.Show();
            Visibility = Visibility.Collapsed;
        }

        private void BtRE_45_Click(object sender, RoutedEventArgs e)
        {
            PreyscourantWeaponTest preyscourantWeaponTest = new PreyscourantWeaponTest();
            preyscourantWeaponTest.Show();
            Visibility = Visibility.Collapsed;
        }
    }
}
