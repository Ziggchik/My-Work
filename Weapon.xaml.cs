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
    /// Логика взаимодействия для Weapon.xaml
    /// </summary>
    ///
    public partial class Weapon : Window
    {
        private TableConnection.ConnectionType_Weapon connectionType_Weapon;
        private TableConnection.ConnectionWeapon connectionWeapon;
        List<TableConnection.ConnectionWeapon> Weapons;
        List<TableConnection.ConnectionType_Weapon> Type_Weapons;
        List<TableConnection.ConnectionWeaponDetail> ListWeapons;

        public string extension = string.Empty;
        private string QR = "";
        public Weapon()
        {
            InitializeComponent();
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            //dgWeapon.Visibility = Visibility.Hidden;
            //lbTypeWeapons.Visibility = Visibility.Hidden;
            //ListWeapons = (new DBProcedures()).getWeaponListDetail();
            //dgWeapon.ItemsSource = ListWeapons;
            //dgWeapon.Columns[0].Visibility = Visibility.Collapsed;
            //Type_Weapons = (new DBProcedures()).getType_WeaponList();
            //lbTypeWeapons.ItemsSource = Type_Weapons;
            //lbTypeWeapons.SelectedValuePath = "ID_Type_Weapon";
            //lbTypeWeapons.DisplayMemberPath = "Name_Type_Weapon";
        }

        DBProcedures procedures = new DBProcedures();
        private void BtInsert_Click(object sender, RoutedEventArgs e)
        {
            if (tbNameWeapon.Text == string.Empty ||
               tbAccuracy.Text == string.Empty ||
               tbFireRate.Text == string.Empty ||
               tbShellsInStore.Text == string.Empty ||
               tbAmmount_Weapon.Text == string.Empty ||
               tbCost.Text == string.Empty ||
               lbTypeWeapons.SelectedIndex < 0)
            {
                MessageBox.Show("Ошибка");
                return;
            }

            new DBProcedures().spWeapon_insert(new TableConnection.ConnectionWeapon(
                -1,
                tbNameWeapon.Text,
                tbAccuracy.Text,
                tbFireRate.Text,
                tbShellsInStore.Text,
                Convert.ToInt32(tbAmmount_Weapon.Text),
                tbCost.Text,
                Convert.ToInt32(lbTypeWeapons.SelectedValue)
                )) ;
                ListWeapons = (new DBProcedures()).getWeaponListDetail();
                dgWeapon.ItemsSource = ListWeapons;
                dgWeapon.Columns[0].Visibility = Visibility.Collapsed;
        }

        private void BtDelete_Click(object sender, RoutedEventArgs e)
        {
            if (tbNameWeapon.Text == string.Empty ||
              tbAccuracy.Text == string.Empty ||
              tbFireRate.Text == string.Empty ||
              tbShellsInStore.Text == string.Empty ||
              tbAmmount_Weapon.Text == string.Empty ||
              tbCost.Text == string.Empty ||
              lbTypeWeapons.SelectedIndex < 0)
            {
                MessageBox.Show("Ошибка");
                return;
            }
            int selectedIndex = dgWeapon.SelectedIndex;
            new DBProcedures().spWeapon_delete(ListWeapons[selectedIndex].ID_Weapon);
            MessageBox.Show("Операция выполнена");
            ListWeapons = (new DBProcedures()).getWeaponListDetail();
            dgWeapon.ItemsSource = ListWeapons;
            dgWeapon.Columns[0].Visibility = Visibility.Collapsed;
        }

        private void BtUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (tbNameWeapon.Text == string.Empty ||
              tbAccuracy.Text == string.Empty ||
              tbFireRate.Text == string.Empty ||
              tbShellsInStore.Text == string.Empty ||
              tbAmmount_Weapon.Text == string.Empty ||
              tbCost.Text == string.Empty ||
             lbTypeWeapons.SelectedIndex < 0)
            {
                MessageBox.Show("Ошибка");
                return;
            }

            int selectedIndex = dgWeapon.SelectedIndex;
            var ap = new DBProcedures().getWeaponList();
            foreach (var it in ap)
            {
                if (it.ID_Weapon == Weapons[selectedIndex].ID_Weapon);
                {
                    connectionWeapon = it;
                    break;
                }
            }

            new DBProcedures().spWeapon_update(new TableConnection.ConnectionWeapon(
                this.connectionWeapon.ID_Weapon,
                tbNameWeapon.Text,
                tbAccuracy.Text,
                tbFireRate.Text,
                tbShellsInStore.Text,
                Convert.ToInt32(tbAmmount_Weapon.Text),
                tbCost.Text,
                Convert.ToInt32(lbTypeWeapons.SelectedValue)
                ));
                ListWeapons = (new DBProcedures()).getWeaponListDetail();
                dgWeapon.ItemsSource = ListWeapons;
                dgWeapon.Columns[0].Visibility = Visibility.Collapsed;
        }

        private void BtInsertTypeWeapon_Click(object sender, RoutedEventArgs e)
        {
            if  (tbName_Type_Weapon.Text == string.Empty)
            {
                MessageBox.Show("Ошибка");
                return;
            }

            new DBProcedures().spType_Weapon_insert(new TableConnection.ConnectionType_Weapon(
                -1,
                tbName_Type_Weapon.Text
                ));
                Type_Weapons = (new DBProcedures()).getType_WeaponList();
                lbTypeWeapons.ItemsSource = Type_Weapons;
                lbTypeWeapons.SelectedValuePath = "ID_Type_Weapon";
                lbTypeWeapons.DisplayMemberPath = "Name_Type_Weapon";
        }

        private void BtUpdateTypeWeapon_Click(object sender, RoutedEventArgs e)
        {
            int selectedIndex = lbTypeWeapons.SelectedIndex;
            var ap = new DBProcedures().getType_WeaponList();
            foreach (var it in ap)
            {
                if (it.ID_Type_Weapon == Type_Weapons[selectedIndex].ID_Type_Weapon) ;
                {
                    connectionType_Weapon = it;
                    break;
                }
            }

            if (tbName_Type_Weapon.Text == string.Empty)
            {
                MessageBox.Show("Ошибка");
                return;
            }

            new DBProcedures().spType_Weapon_update(new TableConnection.ConnectionType_Weapon(
               this.connectionType_Weapon.ID_Type_Weapon,
               tbName_Type_Weapon.Text
               ));
               Type_Weapons = (new DBProcedures()).getType_WeaponList();
               lbTypeWeapons.ItemsSource = Type_Weapons;
               lbTypeWeapons.SelectedValuePath = "ID_Type_Weapon";
               lbTypeWeapons.DisplayMemberPath = "Name_Type_Weapon";
        }

        private void BtDeleteTypeWeapon_Click(object sender, RoutedEventArgs e)
        {
            int selectedIndex = lbTypeWeapons.SelectedIndex;
            new DBProcedures().spType_Weapon_delete(Type_Weapons[selectedIndex].ID_Type_Weapon);
            MessageBox.Show("Операция выполнена");
            Type_Weapons = (new DBProcedures()).getType_WeaponList();
            lbTypeWeapons.ItemsSource = Type_Weapons;
        }

        private void BtSearch_Click(object sender, RoutedEventArgs e)
        {
            foreach (DataRowView dataRow in (DataView)dgWeapon.ItemsSource)
            {
                if (dataRow.Row.ItemArray[1].ToString() == tbSearch.Text ||
                    dataRow.Row.ItemArray[2].ToString() == tbSearch.Text ||
                    dataRow.Row.ItemArray[3].ToString() == tbSearch.Text ||
                    dataRow.Row.ItemArray[4].ToString() == tbSearch.Text ||
                    dataRow.Row.ItemArray[5].ToString() == tbSearch.Text ||
                    dataRow.Row.ItemArray[6].ToString() == tbSearch.Text)
                {
                    dgWeapon.SelectedItem = dataRow;
                }
            }
        }

        private void BtFilter_Click(object sender, RoutedEventArgs e)
        { 
                 string newQR = QR + " where [Name_Weapon] like '%" + tbSearch.Text + "%' or " +
                "[Accuracy] like '%" + tbSearch.Text + "%' or " +
                "[Fire_Rate] like '%" + tbSearch.Text + "%'or " +
                "[Shells_In_Store] like '%" + tbSearch.Text + "%'or " +
                "[Ammount_Weapon] like '%" + tbSearch.Text + "%'or " +
                "[Cost] like '%" + tbSearch.Text + "%'or " +
                "[Type_Weapon_ID] like '%" + tbSearch.Text + "%'";
                ListWeapons = (new DBProcedures()).getWeaponListDetail();
                dgWeapon.ItemsSource = ListWeapons;
        }

        private void DgWeapon_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            //switch (e.Column.Header)
            //{
            //    case ("Name_Weapon"):
            //        e.Column.Header = "Фамилия заключённого";
            //        break;
            //    case ("Name_Prisoner"):
            //        e.Column.Header = "Имя заколючённого";
            //        break;
            //    case ("MiddleName_Prisoner"):
            //        e.Column.Header = "Отчество заключённого";
            //        break;
            //    case ("Name_of_block"):
            //        e.Column.Header = "Название блока";
            //        break;
            //    case ("Surname_Guardian"):
            //        e.Column.Header = "Фамилия охранника";
            //        break;
            //    case ("Name_Guardian"):
            //        e.Column.Header = "Имя охранника";
            //        break;
            //    case ("MiddleName_Guardian"):
            //        e.Column.Header = "Отчество охранника";
            //        break;
            //}
        }

        private void BtClose_Click(object sender, RoutedEventArgs e)
        {
            Spravochnik spravochnik = new Spravochnik();
            spravochnik.Show();
            Visibility = Visibility.Collapsed;
        }

        private void ChdgWeapon_Checked(object sender, RoutedEventArgs e)
        {
            dgWeapon.Visibility = Visibility.Visible;
            lbTypeWeapons.Visibility = Visibility.Visible;
        }

        private void ChdgWeapon_Unchecked(object sender, RoutedEventArgs e)
        {
            dgWeapon.Visibility = Visibility.Hidden;
            lbTypeWeapons.Visibility = Visibility.Hidden;
        }

        MediaPlayer player = new MediaPlayer();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            player.Open(new Uri("C:/Users/1/Desktop/Новый семестр-новые страдания/Курсовой/Интерфейс1/Fortnite Default Dance Bass Boosted.mp3", System.UriKind.RelativeOrAbsolute));
            player.Play();
            dgWeapon.Visibility = Visibility.Hidden;
            lbTypeWeapons.Visibility = Visibility.Hidden;
            ListWeapons = (new DBProcedures()).getWeaponListDetail();
            dgWeapon.ItemsSource = ListWeapons;
            dgWeapon.Columns[0].Visibility = Visibility.Collapsed;
            Type_Weapons = (new DBProcedures()).getType_WeaponList();
            lbTypeWeapons.ItemsSource = Type_Weapons;
            lbTypeWeapons.SelectedValuePath = "ID_Type_Weapon";
            lbTypeWeapons.DisplayMemberPath = "Name_Type_Weapon";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            player.Open(new Uri("C:/Users/1/Desktop/Новый семестр-новые страдания/Курсовой/Интерфейс1/Fortnite Default Dance Bass Boosted.mp3", System.UriKind.RelativeOrAbsolute));
            player.Play();
        }
    }
}
