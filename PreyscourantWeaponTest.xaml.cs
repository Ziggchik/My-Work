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
    /// Логика взаимодействия для PreyscourantWeaponTest.xaml
    /// </summary>
    public partial class PreyscourantWeaponTest : Window
    {
        List<TableConnection.ConnectionWeaponDetail> ListWeapons;
        private TableConnection.ConnectionWeaponDetail connectionWeapon;


        public string extension = string.Empty;
        private string QR = "";

        int purshace_item = 0;
        int[] count = new int[9999]; int step = 0;
        int[] pushcar = new int[9999];
        string korz;
        public PreyscourantWeaponTest()
        {
            InitializeComponent();
        }
  
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            count[step] = 1;
            step++;
            MessageBox.Show("Товар добавлен в корзину!");
            purshace_item++;
            Car.Header = "Корзина(" + purshace_item.ToString() + ")";
            pushcar[1]++;
            count[step++] = 0;


            //TableConnection.ConnectionWeapon connectionWeapon = dgWeapon.SelectedItem as TableConnection.ConnectionWeapon;
            //string ID_Weapon = Convert.ToString(connectionWeapon.ID_Weapon);
            //string Name_Weapon = connectionWeapon.Name_Weapon;
            //string Accuracy = connectionWeapon.Accuracy;
            //string Fire_Rate = connectionWeapon.Fire_Rate;
            //string Shells_In_Store = connectionWeapon.Shells_In_Store;
            //string Ammount_Weapon = Convert.ToString(connectionWeapon.Ammount_Weapon);
            //string Cost = connectionWeapon.Cost;
            //string Type_Weapon_ID = Convert.ToString(connectionWeapon.Type_Weapon_ID);
            tbKorz.Text =tbKorz.Text.ToString() +"     "+ tbPrey.Text.ToString() + "       " + tbAccuracy.Text.ToString() + "               " + tbFire_Rate.Text.ToString() + "                                 " + tbShells_in_store.Text.ToString() + "                                      " + tbAmmount_Weapon.Text.ToString() + "                     " + tbCost.Text.ToString()+Environment.NewLine;
            //int result;
            //int summ;
            //result = Convert.ToInt32(tbCost.Text) * Convert.ToInt32(tbAmmount_Weapon.Text);
            //summ = Convert.ToInt32(tbSumm.Text) + result;
            //tbSumm.Text = Convert.ToString(summ);
            Double db1, db2, db3,result,result2;
            db1 = Double.Parse(tbCost.Text);
            db2 = Double.Parse(tbAmmount_Weapon.Text);
            db3 = Double.Parse(tbSumm.Text);
            result = db1 * db2;
            result2 = db3 + result;
            tbSumm.Text =Convert.ToString(result2);
         }

        private void Window_Activated(object sender, EventArgs e)
        {
            //ListWeapons = (new DBProcedures()).getWeaponListDetail();
            //dgWeapon.ItemsSource = ListWeapons;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Katalog katalog = new Katalog();
            katalog.Show();
            Visibility = Visibility.Collapsed;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dgWeapon.Visibility = Visibility.Hidden;
            ListWeapons = (new DBProcedures()).getWeaponListDetail();
            dgWeapon.ItemsSource = ListWeapons;
            dgWeapon.Columns[0].Visibility = Visibility.Collapsed;
            //QR = ConnectionWeapon1.qrWeapon;
            //dgFill(QR);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            //if ((Convert.ToInt32(tbAmmount_Weapon.Text)) > connectionWeapon.Ammount_Weapon)
            //   MessageBox.Show("На складе больше нет столько товара");
            //else
            int selectedIndex = dgWeapon.SelectedIndex;
            var ap = new DBProcedures().getWeaponListDetail();
            foreach (var it in ap)
            {
                if (it.ID_Weapon == ListWeapons[selectedIndex].ID_Weapon);
                {
                    connectionWeapon = it;
                    break;
                }
            }
            switch ((Convert.ToInt32(tbAmmount_Weapon.Text)) >= connectionWeapon.Ammount_Weapon)
            {
                case (true):
                    MessageBox.Show("Столько товара нет на складе");
                    break;
                case (false):
                    lbAmmount.Visibility = Visibility.Visible;
                    tbAmmount_Weapon.Visibility = Visibility.Visible;
                    int a = 1;
                    int b = Convert.ToInt32(tbAmmount_Weapon.Text);
                    int result = a + b;
                    tbAmmount_Weapon.Text = Convert.ToString(result);
                    break;
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            switch ((Convert.ToInt32(tbAmmount_Weapon.Text)) <= 1)
            {
                case (true):
                    System.Windows.Forms.MessageBox.Show("Значение не может быть меньше 1");
                    break;
                case (false):
                    lbAmmount.Visibility = Visibility.Visible;
                    tbAmmount_Weapon.Visibility = Visibility.Visible;
                    int a = 1;
                    int p = Convert.ToInt32(tbAmmount_Weapon.Text);
                    tbAmmount_Weapon.Text = Convert.ToString(p - a);
                    break;
            }

        }
        private void BtPrint_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.PrintDialog p = new System.Windows.Controls.PrintDialog();
            if (p.ShowDialog() == true)
            {
                p.PrintVisual(grid1, "Печать");
            }
        }

        public void BtSearch_Click(object sender, RoutedEventArgs e)
        {
            //string newQR = QR + "[Name_Type_Weapon] like '%" +"Shotgun" + "%'"; ;
            //dgFill(newQR);
        }

        private void dgFill(string qr)
        {
            ConnectionWeapon1 connection = new ConnectionWeapon1();
            ConnectionWeapon1.qrWeapon = qr;
            connection.Weapon_Fill();
            dgWeapon.ItemsSource = connection.dtWeapon.DefaultView;
            dgWeapon.Columns[0].Visibility = Visibility.Collapsed;
            dgWeapon.Columns[8].Visibility = Visibility.Collapsed;
            dgWeapon.Columns[9].Visibility = Visibility.Collapsed;
        }

        private void ChbdgKorz_Checked(object sender, RoutedEventArgs e)
        {
            dgWeapon.Visibility = Visibility.Visible;
        }

        private void ChbdgKorz_Unchecked(object sender, RoutedEventArgs e)
        {
            dgWeapon.Visibility = Visibility.Hidden;
        }
    }
}
