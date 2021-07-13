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
    /// Логика взаимодействия для LMG.xaml
    /// </summary>
    public partial class LMG : Window
    {
        public LMG()
        {
            InitializeComponent();
        }

        private void BtDevotion_Click(object sender, RoutedEventArgs e)
        {
            PreyscourantWeaponTest preyscourantWeaponTest = new PreyscourantWeaponTest();
            preyscourantWeaponTest.Show();
            Visibility = Visibility.Collapsed;
        }

        private void BtSpitfire_Click(object sender, RoutedEventArgs e)
        {
            PreyscourantWeaponTest preyscourantWeaponTest = new PreyscourantWeaponTest();
            preyscourantWeaponTest.Show();
            Visibility = Visibility.Collapsed;
        }

        private void BtL_Star_Click(object sender, RoutedEventArgs e)
        {
            PreyscourantWeaponTest preyscourantWeaponTest = new PreyscourantWeaponTest();
            preyscourantWeaponTest.Show();
            Visibility = Visibility.Collapsed;
        }
    }
}
