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
    /// Логика взаимодействия для Test.xaml
    /// </summary>
    public partial class Test : Window
    {
        int purshace_item = 0;
        int[] count = new int[9999]; int step = 0;
        int[] pushcar = new int[9999];
        public Test()
        {
            InitializeComponent();
        }

        private void BtShotgun_ammo_Click(object sender, RoutedEventArgs e)
        {
            count[step] = 1;
            step++;

            MessageBox.Show("Товар добавлен в корзину!");

            purshace_item++;
            Car.Header = "Корзина(" + purshace_item.ToString() + ")";

            pushcar[1]++;
           

            count[step++] = 0;
        }

        private void BtHeavy_ammo_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtLight_ammo_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtSniper_ammo_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
