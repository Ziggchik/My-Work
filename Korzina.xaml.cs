using System;
using System.Collections.Generic;
using System.Data;
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
    /// Логика взаимодействия для Korzina.xaml
    /// </summary>
    public partial class Korzina : Window
    {
        private List<string> list;
        private List<DataView> list1;

        public Korzina(List<string> list)
        {
            this.list = list;
            this.list1 = list1;
            InitializeComponent();
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            dgKorzina.ItemsSource = list;
            dgKorzina1.ItemsSource = list1;
            //dgKorzina.ItemsSource = PreyscourantWeapon.stringArray
        }
    }
}
