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
using WeaponStore.TableConnection;


namespace WeaponStore
{
    /// <summary>
    /// Логика взаимодействия для PreyscourantWeapon.xaml
    /// </summary>
    public partial class PreyscourantWeapon : Window
    {
        private TableConnection.ConnectionWeapon connectionWeapon;
        List<TableConnection.ConnectionWeapon> Weapons;
        List<TableConnection.ConnectionWeaponDetail> ListWeapons;

        public string extension = string.Empty;
        private string QR = "";
        public PreyscourantWeapon()
        {
            InitializeComponent();
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            ListWeapons = (new DBProcedures()).getWeaponListDetail();
            dgWeapon.ItemsSource = ListWeapons;
        }

        DBProcedures procedures = new DBProcedures();

        //List<DataRowView> list = new List<DataRowView>();
        List<string> list = new List<string>();
        //string[] stringArray = new string [99];
        public void Button_Click(object sender, RoutedEventArgs e)
        {
            ////[dgWeapon.SelectedIndex]
            //foreach (DataRowView dataRow in (DataView)dgWeapon.ItemsSource)
            //{
            //    if (dataRow.Row.ItemArray[1] == dgWeapon.SelectedItem ||
            //        dataRow.Row.ItemArray[2] == dgWeapon.SelectedItem ||
            //        dataRow.Row.ItemArray[3] == dgWeapon.SelectedItem ||
            //        dataRow.Row.ItemArray[4] == dgWeapon.SelectedItem ||
            //        dataRow.Row.ItemArray[7] == dgWeapon.SelectedItem)
            //    {
            //        //dgWeapon.SelectedItem = dataRow;
            //        list.Add(dataRow);
            //        return;
            //    }      
            //}

            //list.Add((DataView)dgWeapon.SelectedItem);
            //Korzina korzina = new Korzina(list);
            //korzina.Show();
            //Visibility = Visibility.Collapsed;     

            //string selectedIndex = dgWeapon.SelectedValue.ToString();
            ////korz = selectedIndex;
            //list.Add(selectedIndex);
            //Korzina korzina = new Korzina(list);
            //korzina.Show();
            //Visibility = Visibility.Collapsed; 



            //int selectedIndex = dgWeapon.SelectedIndex;
            //var ap = new DBProcedures().getWeaponList();
            //foreach (var it in ap)
            //{
            //    if (it.ID_Weapon == Weapons[selectedIndex].ID_Weapon);
            //    {
            //        connectionWeapon = it;
            //        break;
            //    }
            //}

            //ConnectionWeapon connectionWeapon = dgWeapon.SelectedItem as ConnectionWeapon;
            //string ID_Weapon = Convert.ToString(connectionWeapon.ID_Weapon);
            //string Name_Weapon = connectionWeapon.Name_Weapon;
            //string Accuracy = connectionWeapon.Accuracy;
            //string Fire_Rate = connectionWeapon.Fire_Rate;
            //string Shells_In_Store = connectionWeapon.Shells_In_Store;
            //string Ammount_Weapon = Convert.ToString(connectionWeapon.Ammount_Weapon);
            //string Cost = connectionWeapon.Cost;
            //string Type_Weapon_ID = Convert.ToString(connectionWeapon.Type_Weapon_ID);
            //list.Add(ID_Weapon + " " + Name_Weapon + " " + Accuracy + " " + Fire_Rate + " " + Shells_In_Store + " " + Ammount_Weapon + " " + Cost + " " + Type_Weapon_ID);
            //Korzina korzina = new Korzina(list);
            //korzina.Show();
            //Visibility = Visibility.Collapsed;
        }
    }
}
