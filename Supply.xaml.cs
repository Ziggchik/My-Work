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


namespace WeaponStore
{
    /// <summary>
    /// Логика взаимодействия для Supply.xaml
    /// </summary>
    public partial class Supply : Window
    {
        private TableConnection.ConnectionSupply1 connectionSupply1;
        List<TableConnection.ConnectionSupply1> Supplies;
        private TableConnection.ConnectionWeapon connectionWeapon;
        List<TableConnection.ConnectionWeapon> Weapon;
        private TableConnection.ConnectionAmmo connectionAmmo;
        private TableConnection.ConnectionModifications connectionModifications;
        private TableConnection.ConnectionDogovor connectionDogovor;
        List<TableConnection.ConnectionDogovor> Dogovors;
        private TableConnection.ConnectionSupplier connectionSupplier;
        List<TableConnection.ConnectionSupplier> Suppliers;

        public string extension = string.Empty;
        private string QR = "";
        public Supply()
        {
            InitializeComponent();
        }
        DBProcedures procedures = new DBProcedures();
        private void Window_Activated(object sender, EventArgs e)
        {
            //Supplies = (new DBProcedures()).getSupplyList();
            //dgSupply.ItemsSource = Supplies;
            //Dogovors = (new DBProcedures()).getDogovorList();
            //lbDogovor.ItemsSource = Dogovors;
            //Suppliers = (new DBProcedures()).getSupplierList();
            //lbSupplier.ItemsSource = Suppliers;
        }
        private void dgFill(string qr)
        {
            ConnectionSupply connection = new ConnectionSupply();
            ConnectionSupply.qrSupply = qr;
            connection.Supply_Fill();
            dgSupply.ItemsSource = connection.dtSupply.DefaultView;
            dgSupply.Columns[0].Visibility = Visibility.Collapsed;
            dgSupply.Columns[5].Visibility = Visibility.Collapsed;
            dgSupply.Columns[6].Visibility = Visibility.Collapsed;
            dgSupply.Columns[8].Visibility = Visibility.Collapsed;
            dgSupply.Columns[9].Visibility = Visibility.Collapsed;
        }

        private void BtInsert_Click(object sender, RoutedEventArgs e)
        {
            //new DBProcedures().spSupply_insert(new TableConnection.ConnectionSupply(
            //    -1,
            //    tbDate.Text,
            //    Convert.ToInt32(tbAmmount_Accepted_Weapon.Text),
            //    Convert.ToInt32(tbAmmount_Accepted_Modifications.Text),
            //    Convert.ToInt32(tbAmmount_Accepted_Ammo.Text),
            //    Convert.ToInt32(lbSupplier.SelectedValue),
            //    Convert.ToInt32(lbDogovor.SelectedValue)
            //    ));
            //Supplies= (new DBProcedures()).getSupplyList();
            //dgSupply.ItemsSource = Supplies;
            if (tbAmmount_Accepted_Ammo.Text == string.Empty)
            {
                MessageBox.Show("Ошибка");
                return;
            }
            procedures.spSupply_insert(tbDate.Text, Convert.ToInt32(tbAmmount_Accepted_Weapon.Text), Convert.ToInt32(tbAmmount_Accepted_Modifications.Text), Convert.ToInt32(tbAmmount_Accepted_Ammo.Text), Convert.ToInt32(lbSupplier.SelectedValue), Convert.ToInt32(lbDogovor.SelectedValue)); 
            dgFill(QR);
        }

        private void BtUpdate_Click(object sender, RoutedEventArgs e)
        {
            //new DBProcedures().spSupply_update(new TableConnection.ConnectionSupply(
            //    this.connectionSupply.ID_Supply,
            //    tbDate.Text,
            //    Convert.ToInt32(tbAmmount_Accepted_Weapon.Text),
            //    Convert.ToInt32(tbAmmount_Accepted_Modifications.Text),
            //    Convert.ToInt32(tbAmmount_Accepted_Ammo.Text),
            //    Convert.ToInt32(lbSupplier.SelectedValue),
            //    Convert.ToInt32(lbDogovor.SelectedValue)
            //    ));
            //Supplies = (new DBProcedures()).getSupplyList();
            //dgSupply.ItemsSource = Supplies;
            if (tbAmmount_Accepted_Ammo.Text == string.Empty)
            {
                MessageBox.Show("Ошибка");
                return;
            }
            try
            {
                DataRowView ID = (DataRowView)dgSupply.SelectedItems[0];
                if (ID == null)
                    MessageBox.Show("", "");
                else
                    procedures.spSupply_update(tbDate.Text, Convert.ToInt32(ID["ID_Supply"]),Convert.ToInt32(tbAmmount_Accepted_Weapon.Text), Convert.ToInt32(tbAmmount_Accepted_Modifications.Text), Convert.ToInt32(tbAmmount_Accepted_Ammo.Text), Convert.ToInt32(lbSupplier.SelectedValue), Convert.ToInt32(lbDogovor.SelectedValue));
                dgFill(QR);
            }
            catch
            {

            }
        }

        private void BtDelete_Click(object sender, RoutedEventArgs e)
        {
            //Supplies = (new DBProcedures()).getSupplyList();
            //int selectedIndex = dgSupply.SelectedIndex;
            //var ap = new DBProcedures().getSupplyList();
            //foreach (var it in ap)
            //{
            //    if (it.ID_Supply == Supplies[selectedIndex].ID_Supply);
            //    {
            //        connectionSupply1 = it;
            //        break;
            //    }
            //}

            //var ap1 = new DBProcedures().getWeaponList();
            //foreach (var it in ap1)
            //{
            //    if (it.ID_Weapon == Weapon[Convert.ToInt32("Ammount_Weapon")].ID_Weapon);
            //    {
            //        connectionWeapon = it;
            //        break;
            //    }
            //}

            //int Amm_weapon = connectionSupply1.Ammount_Accepted_Weapon;
            //int Amm_ammo = connectionSupply1.Ammount_Accepted_Ammo;
            //int Amm_modifications = connectionSupply1.Ammount_Accepted_Modifications;
            if (tbAmmount_Accepted_Ammo.Text == string.Empty)
            {
                MessageBox.Show("Ошибка");
                return;
            }
            switch (MessageBox.Show("Разгрузить поставку?",
              "Разгрузка поставки", MessageBoxButton.YesNo,
              MessageBoxImage.Warning))
            {
                case MessageBoxResult.Yes:
                    //connectionWeapon.Ammount_Weapon = connectionWeapon.Ammount_Weapon + Amm_weapon;
                    //connectionAmmo.Ammount_Ammo =connectionAmmo.Ammount_Ammo + Amm_ammo;
                    //connectionModifications.Ammount_Modifications = connectionModifications.Ammount_Modifications + Amm_modifications;
                    DataRowView ID =
                      (DataRowView)dgSupply.SelectedItems[0];
                    procedures.spSupply_delete(
                       Convert.ToInt32(ID["ID_Supply"]));
                    dgFill(QR);
                    break;
            }
        }

        private void BtInsertSupplier_Click(object sender, RoutedEventArgs e)
        {
            new DBProcedures().spSupplier_insert(new TableConnection.ConnectionSupplier(
               -1,
               tbName_Organization.Text
               ));
            Suppliers = (new DBProcedures()).getSupplierList();
            lbSupplier.ItemsSource = Suppliers;
        }

        private void BtUpdateSupplier_Click(object sender, RoutedEventArgs e)
        {
            new DBProcedures().spSupplier_update(new TableConnection.ConnectionSupplier(
            this.connectionSupplier.ID_Supplier,
            tbName_Organization.Text
               ));
            Suppliers = (new DBProcedures()).getSupplierList();
            lbSupplier.ItemsSource = Suppliers;
        }

        private void BtDeleteSupplier_Click(object sender, RoutedEventArgs e)
        {
            switch (MessageBox.Show("Удалить выбранную запись?",
                "Удаление записи", MessageBoxButton.YesNo,
                MessageBoxImage.Warning))
            {
                case MessageBoxResult.Yes:
                    procedures.spSupplier_delete(
                    Convert.ToInt32(lbSupplier.
                    SelectedValue.ToString()));
                    Suppliers = (new DBProcedures()).getSupplierList();
                    lbSupplier.ItemsSource = Suppliers;
                    break;
            }
        }

        private void BtInsertDogovor_Click(object sender, RoutedEventArgs e)
        {
            new DBProcedures().spDogovor_insert(new TableConnection.ConnectionDogovor(
               -1,
               tbNumber_Dogovor.Text
               ));
            Dogovors = (new DBProcedures()).getDogovorList();
            lbDogovor.ItemsSource = Dogovors;
        }

        private void BtUpdateDogovor_Click(object sender, RoutedEventArgs e)
        {
            new DBProcedures().spDogovor_update(new TableConnection.ConnectionDogovor(
            this.connectionDogovor.ID_Dogovor,
            tbNumber_Dogovor.Text
               ));
            Dogovors = (new DBProcedures()).getDogovorList();
            lbDogovor.ItemsSource = Dogovors;
        }

        private void BtDeleteDogovor_Click(object sender, RoutedEventArgs e)
        {
            switch (MessageBox.Show("Удалить выбранную запись?",
                "Удаление записи", MessageBoxButton.YesNo,
                MessageBoxImage.Warning))
            {
                case MessageBoxResult.Yes:
                    procedures.spEmployee_delete(
                    Convert.ToInt32(lbDogovor.
                    SelectedValue.ToString()));
                    Dogovors = (new DBProcedures()).getDogovorList();
                    lbDogovor.ItemsSource = Dogovors;
                    break;
            }
        }

        private void BtSearch_Click(object sender, RoutedEventArgs e)
        {
            foreach (DataRowView dataRow in (DataView)dgSupply.ItemsSource)
            {
                if (dataRow.Row.ItemArray[1].ToString() == tbSearch.Text ||
                    dataRow.Row.ItemArray[2].ToString() == tbSearch.Text ||
                    dataRow.Row.ItemArray[3].ToString() == tbSearch.Text ||
                    dataRow.Row.ItemArray[4].ToString() == tbSearch.Text ||
                    dataRow.Row.ItemArray[7].ToString() == tbSearch.Text ||
                    dataRow.Row.ItemArray[10].ToString() == tbSearch.Text)
                {
                    dgSupply.SelectedItem = dataRow;
                }
            }
        }

        private void BtFilter_Click(object sender, RoutedEventArgs e)
        {
            switch (chbFilter.IsChecked)
            {
                case (true):
                    string newQR = QR + " where [Date] like '%" + tbSearch.Text + "%' or " +
                "[Ammount_Accepted_Weapon] like '%" + tbSearch.Text + "%' or " +
                "[Ammount_Accepted_Modifications] like '%" + tbSearch.Text + "%' or " +
                "[Ammount_Accepted_Ammo] like '%" + tbSearch.Text + "%' or " +
                "[Supplier_ID] like '%" + tbSearch.Text + "%' or " +
                "[Dogovor_ID] like '%" + tbSearch.Text + "%'";
                    dgFill(newQR);
                    break;
                case (false):
                    dgFill(QR);
                    break;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dgSupply.Visibility = Visibility.Hidden;
            QR = ConnectionSupply.qrSupply;
            dgFill(QR);
            Dogovors = (new DBProcedures()).getDogovorList();
            lbDogovor.ItemsSource = Dogovors;
            lbDogovor.SelectedValuePath = "ID_Dogovor";
            lbDogovor.DisplayMemberPath = "Number_Dogovor";
            Suppliers = (new DBProcedures()).getSupplierList();
            lbSupplier.ItemsSource = Suppliers;
            lbSupplier.SelectedValuePath = "ID_Supplier";
            lbSupplier.DisplayMemberPath = "Name_Organization";
        }

        private void BtBack_Click(object sender, RoutedEventArgs e)
        {
            Spravochnik spravochnik = new Spravochnik();
            spravochnik.Show();
            Visibility = Visibility.Collapsed;
        }

        private void ChbdgSupply_Checked(object sender, RoutedEventArgs e)
        {
            dgSupply.Visibility = Visibility.Visible;
            dgFill(QR);      
        }

        private void ChbdgSupply_Unchecked(object sender, RoutedEventArgs e)
        {
            dgSupply.Visibility = Visibility.Hidden;
            dgFill(QR);
        }
    }
}
