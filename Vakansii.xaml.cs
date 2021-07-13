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
    /// Логика взаимодействия для Vakansii.xaml
    /// </summary>
    public partial class Vakansii : Window
    {
        public Vakansii()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow spravochnik = new MainWindow();
            spravochnik.Show();
            Visibility = Visibility.Collapsed;
        }
    }
}
