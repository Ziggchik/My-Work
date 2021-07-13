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
    /// Логика взаимодействия для Katalog.xaml
    /// </summary>
    public partial class Katalog : Window
    {
        public Katalog()
        {
            InitializeComponent();
        }

        private void BtAssault_Rifles_Click(object sender, RoutedEventArgs e)
        {
            AssaultRifles assaultRifles = new AssaultRifles();
            assaultRifles.Show();
            Visibility = Visibility.Collapsed;
        }

        private void BtSubMuchineGuns_Click(object sender, RoutedEventArgs e)
        {
            SMG sMG = new SMG();
            sMG.Show();
            Visibility = Visibility.Collapsed;
        }

        private void MuchineGuns_Click(object sender, RoutedEventArgs e)
        {
            LMG lMG = new LMG();
            lMG.Show();
            Visibility = Visibility.Collapsed;
        }

        private void SniperRifles_Click(object sender, RoutedEventArgs e)
        {
            SniperRifles sniperRifles = new SniperRifles();
            sniperRifles.Show();
            Visibility = Visibility.Collapsed;
        }

        private void Shotguns_Click(object sender, RoutedEventArgs e)
        {
            Shotguns shotguns = new Shotguns();
            shotguns.Show();
            Visibility = Visibility.Collapsed;
        }

        private void Pistols_Click(object sender, RoutedEventArgs e)
        {
            Pistols pistols = new Pistols();
            pistols.Show();
            Visibility = Visibility.Collapsed;
        }

        private void Weapon_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Вы находитесь на этой вкладке");
            return;
        }

        private void Ammo_Click(object sender, RoutedEventArgs e)
        {
            Katalog1 katalog1 = new Katalog1();
            katalog1.Show();
            Visibility = Visibility.Collapsed;
            //Test test = new Test();
            //test.Show();
            //Visibility = Visibility.Collapsed;
        }

        private void Modifications_Click(object sender, RoutedEventArgs e)
        {
            Katalog2 katalog2 = new Katalog2();
            katalog2.Show();
            Visibility = Visibility.Collapsed;
        }

        private void BtBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Visibility = Visibility.Collapsed;
        }
    }
}
