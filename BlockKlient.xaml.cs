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
    /// Логика взаимодействия для BlockKlient.xaml
    /// </summary>
    public partial class BlockKlient : Window
    {
        public BlockKlient()
        {
            InitializeComponent();
        }

        List<TableConnection.ConnectionKlientDetail> listKlientDetail;

        private void updateData()
        {
            listKlientDetail = (new DBProcedures()).getKlientListDetail();
            dataGridClients.ItemsSource = listKlientDetail;
            dataGridClients.Columns[0].Visibility = Visibility.Collapsed;
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            //updateData();
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            Spravochnik spravochnik = new Spravochnik();
            spravochnik.Show();
            Visibility = Visibility.Collapsed;
        }

        private void ButtonBlock_Click(object sender, RoutedEventArgs e)
        {
            int selectedIndex = dataGridClients.SelectedIndex;
            if (selectedIndex < 0)
            {
                MessageBox.Show("Не выбран клиент");
                return;
            }

            var ap = new DBProcedures().getKlientList();

            TableConnection.ConnectionKlient connectionKlient = null;
            foreach (var it in ap)
            {
                if (it.ID_Authorization == listKlientDetail[selectedIndex].ID_Authorization)
                {
                    connectionKlient = it;
                    break;
                }
            }

            connectionKlient.License_ID = 3;
            new DBProcedures().spKlient_update(connectionKlient);

            MessageBox.Show("Операция выполнена");
            updateData();
        }

        private void ButtonUnBlock_Click(object sender, RoutedEventArgs e)
        {
            int selectedIndex = dataGridClients.SelectedIndex;
            if (selectedIndex < 0)
            {
                MessageBox.Show("Не выбран клиент");
                return;
            }
            var ap = new DBProcedures().getKlientList();

            TableConnection.ConnectionKlient connectionKlient = null;
            foreach (var it in ap)
            {
                if (it.ID_Authorization == listKlientDetail[selectedIndex].ID_Authorization)
                {
                    connectionKlient = it;
                    break;
                }
            }

            connectionKlient.License_ID = 2;
            new DBProcedures().spKlient_update(connectionKlient);

            MessageBox.Show("Операция выполнена");
            updateData();
        }

        private void ChbdgBlockklient_Checked(object sender, RoutedEventArgs e)
        {
            dataGridClients.Visibility = Visibility.Visible;
        }

        private void ChbdgBlockklient_Unchecked(object sender, RoutedEventArgs e)
        {
            dataGridClients.Visibility = Visibility.Hidden;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            updateData();
            dataGridClients.Visibility = Visibility.Hidden;
        }
    }
}
