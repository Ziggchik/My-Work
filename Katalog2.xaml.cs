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
    /// Логика взаимодействия для Katalog2.xaml
    /// </summary>
    public partial class Katalog2 : Window
    {
        public Katalog2()
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
            Katalog1 katalog1 = new Katalog1();
            katalog1.Show();
            Visibility = Visibility.Collapsed;
        }

        private void Modifications_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Вы находитесь на этой вкладке");
            return;
        }

        private void Buy_Click(object sender, RoutedEventArgs e)
        {
            //PreyscourantModifications preyscourantModifications = new PreyscourantModifications();
            //preyscourantModifications.Show();
            //Visibility = Visibility.Collapsed;
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
