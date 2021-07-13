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
    /// Логика взаимодействия для Katalog1.xaml
    /// </summary>
    public partial class Katalog1 : Window
    {
        public Katalog1()
        {
            InitializeComponent();
        }

        private void Weapon_Click(object sender, RoutedEventArgs e)
        {
            Katalog katalog = new Katalog();
            katalog.Show();
            Visibility = Visibility.Collapsed;
        }

        private void Ammo_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Вы находитесь на этой вкладке");
            return;
        }

        private void Modifications_Click(object sender, RoutedEventArgs e)
        {
            Katalog2 katalog2 = new Katalog2();
            katalog2.Show();
            Visibility = Visibility.Collapsed;
        }

        private void BtShotgun_ammo_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Ознакомьтесь с информацией для клиентов!В ближайшее время черный рынок возобновит свою работу.");
        }

        private void BtHeavy_ammo_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Ознакомьтесь с информацией для клиентов!В ближайшее время черный рынок возобновит свою работу.");
        }

        private void BtLight_ammo_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Ознакомьтесь с информацией для клиентов!В ближайшее время черный рынок возобновит свою работу.");
        }

        private void BtSniper_ammo_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Ознакомьтесь с информацией для клиентов!В ближайшее время черный рынок возобновит свою работу.");
        }

        private void BtBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Visibility = Visibility.Collapsed;
        }
    }
}
