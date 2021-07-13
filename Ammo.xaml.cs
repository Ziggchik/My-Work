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
using System.Data.SqlClient;
using WeaponStore.TableConnection;
using System.Text.RegularExpressions;

namespace WeaponStore
{
    /// <summary>
    /// Логика взаимодействия для Ammo.xaml
    /// </summary>
    public partial class Ammo : Window
    {
        private TableConnection.ConnectionAmmo connectionAmmo;
        List<TableConnection.ConnectionAmmo> Ammos;

        public string extension = string.Empty;
        private string QR = "";
        public Ammo()
        {
            InitializeComponent();
        }
        DBProcedures procedures = new DBProcedures();
        private void Window_Activated(object sender, EventArgs e)
        {
            //Ammos= (new DBProcedures()).getAmmoList();
            //dgAmmo.ItemsSource = Ammos;
            //dgAmmo.Columns[0].Visibility = Visibility.Collapsed;
            Action action = () =>
            {
                Ammos = (new DBProcedures()).getAmmoList();
                dgAmmo.ItemsSource = Ammos;
            };

            Dispatcher.Invoke(action);
        }

        private void BtInsert_Click(object sender, RoutedEventArgs e)
        {
            if (tbAmmountAmmo.Text.Length > 4)
            {
                MessageBox.Show("Много символов");
                return;
            }


            if (tbTypeAmmo.Text == string.Empty ||
               tbAmmountAmmo.Text == string.Empty ||
               tbCost.Text == string.Empty)
            {
                MessageBox.Show("Ошибка");
                return;
            }

            new DBProcedures().spAmmo_insert(new TableConnection.ConnectionAmmo(
                -1,
                tbTypeAmmo.Text,
                Convert.ToInt32(tbAmmountAmmo.Text),
                tbCost.Text
                ));
            Ammos = (new DBProcedures()).getAmmoList();
            dgAmmo.ItemsSource = Ammos;
            dgAmmo.Columns[0].Visibility = Visibility.Collapsed;
        }

        private void BtUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (tbTypeAmmo.Text == string.Empty ||
                tbAmmountAmmo.Text == string.Empty ||
                tbCost.Text == string.Empty)
            {
                MessageBox.Show("Ошибка");
                return;
            }
            int selectedIndex = dgAmmo.SelectedIndex;
            var ap = new DBProcedures().getAmmoList();
            foreach (var it in ap)
            {
                if (it.ID_Ammo == Ammos[selectedIndex].ID_Ammo);
                {
                    connectionAmmo = it;
                    break;
                }
            }

            new DBProcedures().spAmmo_update(new TableConnection.ConnectionAmmo(
             this.connectionAmmo.ID_Ammo,
                tbTypeAmmo.Text,
                Convert.ToInt32(tbAmmountAmmo.Text),
                tbCost.Text
                ));
            Ammos = (new DBProcedures()).getAmmoList();
            dgAmmo.ItemsSource = Ammos;
            dgAmmo.Columns[0].Visibility = Visibility.Collapsed;
        }

        private void BtDelete_Click(object sender, RoutedEventArgs e)
        {
            if (tbAmmountAmmo.Text == string.Empty ||
                tbTypeAmmo.Text == string.Empty ||
                tbCost.Text == string.Empty)
            {
                MessageBox.Show("Ошибка");
                return;
            }

            int selectedIndex = dgAmmo.SelectedIndex;
            new DBProcedures().spAmmo_delete(Ammos[selectedIndex].ID_Ammo);
            MessageBox.Show("Операция выполнена");
            Ammos = (new DBProcedures()).getAmmoList();
            dgAmmo.ItemsSource = Ammos;
            dgAmmo.Columns[0].Visibility = Visibility.Collapsed;
        }

        private void BtSearch_Click(object sender, RoutedEventArgs e)
        {
            foreach(DataRowView dataRow in (DataView)dgAmmo.ItemsSource)
            {
                if (dataRow.Row.ItemArray[1].ToString() == tbSearch.Text ||
                    dataRow.Row.ItemArray[2].ToString() == tbSearch.Text ||
                    dataRow.Row.ItemArray[3].ToString() == tbSearch.Text ||
                    dataRow.Row.ItemArray[4].ToString() == tbSearch.Text ||
                    dataRow.Row.ItemArray[7].ToString() == tbSearch.Text)
                {
                    dgAmmo.SelectedItem = dataRow;
                }
            }
        }

        private void BtFilter_Click(object sender, RoutedEventArgs e)
        {
            string newQR = QR + " where [Type_Ammo] like '%" + tbSearch.Text + "%' or " +
                "[Ammount_Ammo] like '%" + tbSearch.Text + "%' or " +
                "[Cost] like '%" + tbSearch.Text + "%'";
            Ammos = (new DBProcedures()).getAmmoList();
            dgAmmo.ItemsSource = Ammos;
        }

        private void BtBack_Click(object sender, RoutedEventArgs e)
        {
            Spravochnik spravochnik = new Spravochnik();
            spravochnik.Show();
            Visibility = Visibility.Collapsed;
        }

        private void ChbdgAmmo_Checked(object sender, RoutedEventArgs e)
        {
            dgAmmo.Visibility = Visibility.Visible;
        }

        private void ChbdgAmmo_Unchecked(object sender, RoutedEventArgs e)
        {
            dgAmmo.Visibility = Visibility.Hidden;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dgAmmo.Visibility = Visibility.Hidden;
            Ammos = (new DBProcedures()).getAmmoList();
            dgAmmo.ItemsSource = Ammos;
            dgAmmo.Columns[0].Visibility = Visibility.Collapsed;
        }

        private void TbCost_TextChanged(object sender, TextChangedEventArgs e)
        {
            tbCost.Text = Regex.Replace(tbCost.Text, "[A-Za-zА-Яа-я]", "");
            tbCost.SelectionStart = tbCost.Text.Length;
        }
    }
}
