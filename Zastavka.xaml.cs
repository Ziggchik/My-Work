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

namespace WeaponStore.TableConnection
{
    /// <summary>
    /// Логика взаимодействия для Zastavka.xaml
    /// </summary>
    public partial class Zastavka : Window
    {
        public Zastavka()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!(new DBProcedures().IsConnection))
            {
                MessageBox.Show("Ошибка подкл к БД");
            }
            else
            {
                new Authorization().Show();
            }

            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            Visibility = Visibility.Collapsed;
        }
    }
}
