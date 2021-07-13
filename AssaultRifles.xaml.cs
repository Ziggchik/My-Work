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
using System.Data;

namespace WeaponStore
{
    /// <summary>
    /// Логика взаимодействия для AssaultRifles.xaml
    /// </summary>
    public partial class AssaultRifles : Window
    {
        public AssaultRifles()
        {
            InitializeComponent();
        }

        private void BtHemlok_Click(object sender, RoutedEventArgs e)
        {
            PreyscourantWeaponTest preyscourantWeaponTest = new PreyscourantWeaponTest();
            preyscourantWeaponTest.Show();
            //preyscourantWeaponTest.BtSearch_Click(null,null);
            Visibility = Visibility.Collapsed;
        }

        private void BtFlatline_Click(object sender, RoutedEventArgs e)
        {
            PreyscourantWeaponTest preyscourantWeaponTest = new PreyscourantWeaponTest();
            preyscourantWeaponTest.Show();
            Visibility = Visibility.Collapsed;
        }

        private void BtR_301_Click(object sender, RoutedEventArgs e)
        {
            PreyscourantWeaponTest preyscourantWeaponTest = new PreyscourantWeaponTest();
            preyscourantWeaponTest.Show();
            Visibility = Visibility.Collapsed;
        }

        private void Havok_Click(object sender, RoutedEventArgs e)
        {
            PreyscourantWeaponTest preyscourantWeaponTest = new PreyscourantWeaponTest();
            preyscourantWeaponTest.Show();
            Visibility = Visibility.Collapsed;
        }
    }
}
