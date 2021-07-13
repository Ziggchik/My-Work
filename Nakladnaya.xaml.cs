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
    /// Логика взаимодействия для Nakladnaya.xaml
    /// </summary>
    public partial class Nakladnaya : Window
    {
        //private TableConnection.ConnectionNakladnaya connectionNakladnaya;
        //List<TableConnection.ConnectionNakladnaya> Nakladnayas;
        //private TableConnection.ConnectionSupply connectionSupply;
        //List<TableConnection.ConnectionSupply> Supplies;
        public string extension = string.Empty;
        private string QR = "";
        public Nakladnaya()
        {
            InitializeComponent();
        }

        DBProcedures procedures = new DBProcedures();
        private void Window_Activated(object sender, EventArgs e)
        {
            //Nakladnayas = (new DBProcedures()).getNakladnayaList();
            //dgNakladnaya.ItemsSource = Nakladnayas;
            //Supplies = (new DBProcedures()).getSupplyList();
            //lbSupply.ItemsSource = Supplies;
        }

        private void dgFill(string qr)
        {
            ConnectionNakladnaya connection = new ConnectionNakladnaya();
            ConnectionNakladnaya.qrNakladnaya = qr;
            connection.Nakladnaya_Fill();
            dgNakladnaya.ItemsSource = connection.dtNakladnaya.DefaultView;
            dgNakladnaya.Columns[0].Visibility = Visibility.Collapsed;
            dgNakladnaya.Columns[2].Visibility = Visibility.Collapsed;
            dgNakladnaya.Columns[3].Visibility = Visibility.Collapsed;
            dgNakladnaya.Columns[8].Visibility = Visibility.Collapsed;
            dgNakladnaya.Columns[9].Visibility = Visibility.Collapsed;
            dgNakladnaya.Columns[11].Visibility = Visibility.Collapsed;
            dgNakladnaya.Columns[12].Visibility = Visibility.Collapsed;
        }

        private void lbFill()
        {
            ConnectionSupply connection = new ConnectionSupply();
            connection.Supply_Fill();
            lbSupply.ItemsSource
             = connection.dtSupply.DefaultView;
            lbSupply.SelectedValuePath = "ID_Supply";
            lbSupply.DisplayMemberPath = "Дата_поставки";
        }


        private void BtInsert_Click(object sender, RoutedEventArgs e)
        {
            //new DBProcedures().spNakladnaya_insert(new TableConnection.ConnectionNakladnaya(
            //    -1,
            //    tbNumberNakladnaya.Text,
            //    Convert.ToInt32(lbSupply.SelectedValue)
            //    ));
            //Nakladnayas = (new DBProcedures()).getNakladnayaList();
            //dgNakladnaya.ItemsSource = Nakladnayas;
            if (tbNumberNakladnaya.Text == string.Empty )
            {
                MessageBox.Show("Ошибка");
                return;
            }
            procedures.spNakladnaya_insert(tbNumberNakladnaya.Text, Convert.ToInt32(lbSupply.SelectedValue));
            dgFill(QR);
        }

        private void BtUpdate_Click(object sender, RoutedEventArgs e)
        {
            //new DBProcedures().spNakladnaya_update(new TableConnection.ConnectionNakladnaya(
            //this.connectionNakladnaya.ID_Nakladnaya,
            //tbNumberNakladnaya.Text,
            //    Convert.ToInt32(lbSupply.SelectedValue)
            //    ));
            //Nakladnayas = (new DBProcedures()).getNakladnayaList();
            if (tbNumberNakladnaya.Text == string.Empty)
            {
                MessageBox.Show("Ошибка");
                return;
            }
            //dgNakladnaya.ItemsSource = Nakladnayas;
            try
            {
                DataRowView ID = (DataRowView)dgNakladnaya.SelectedItems[0];
                if (ID == null)
                    MessageBox.Show("", "");
                else
                    procedures.spNakladnaya_update(tbNumberNakladnaya.Text, Convert.ToInt32(ID["ID_Nakladnaya"]), Convert.ToInt32(lbSupply.SelectedValue));
            dgFill(QR);
            }
            catch
            {

            }
        }

        private void BtDelete_Click(object sender, RoutedEventArgs e)
        {
            //switch (MessageBox.Show("Удалить выбранную запись?",
            //    "Удаление записи", MessageBoxButton.YesNo,
            //    MessageBoxImage.Warning))
            //{
            //    case MessageBoxResult.Yes:
            //        procedures.spNakladnaya_delete(
            //        Convert.ToInt32(dgNakladnaya.
            //        SelectedValue.ToString()));
            //        Nakladnayas = (new DBProcedures()).getNakladnayaList();
            //        dgNakladnaya.ItemsSource = Nakladnayas;
            //        break;
            //}
            if (tbNumberNakladnaya.Text == string.Empty)
            {
                MessageBox.Show("Ошибка");
                return;
            }
            switch (MessageBox.Show("Удалить выбранную запись?",
              "Удаление записи", MessageBoxButton.YesNo,
              MessageBoxImage.Warning))
            {
                case MessageBoxResult.Yes:
                    DataRowView ID =
                      (DataRowView)dgNakladnaya.SelectedItems[0];
                    procedures.spNakladnaya_delete(
                       Convert.ToInt32(ID["ID_Nakladnaya"]));
                    dgFill(QR);
                    break;
            }
        }

        private void BtSearch_Click(object sender, RoutedEventArgs e)
        {
            foreach (DataRowView dataRow in (DataView)dgNakladnaya.ItemsSource)
            {
                if (dataRow.Row.ItemArray[1].ToString() == tbSearch.Text ||
                    dataRow.Row.ItemArray[4].ToString() == tbSearch.Text ||
                    dataRow.Row.ItemArray[5].ToString() == tbSearch.Text ||
                    dataRow.Row.ItemArray[6].ToString() == tbSearch.Text ||
                    dataRow.Row.ItemArray[7].ToString() == tbSearch.Text ||
                    dataRow.Row.ItemArray[10].ToString() == tbSearch.Text ||
                    dataRow.Row.ItemArray[13].ToString() == tbSearch.Text)
                {
                    dgNakladnaya.SelectedItem = dataRow;
                }
            }
        }

        private void BtFilter_Click(object sender, RoutedEventArgs e)
        {
            switch (chbFilter.IsChecked)
            {
                case (true):
                    string newQR = QR + " where [Number_Nakladnaya] like '%" + tbSearch.Text + "%' or " +
            "[Supply_ID] like '%" + tbSearch.Text + "%'";
                    dgFill(newQR); 
                    break;
                case (false):
                    dgFill(QR);
                    break;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dgNakladnaya.Visibility = Visibility.Hidden;
            QR = ConnectionNakladnaya.qrNakladnaya;
            dgFill(QR);
            lbFill();
        }

        private void BtBack_Click(object sender, RoutedEventArgs e)
        {
            Spravochnik spravochnik = new Spravochnik();
            spravochnik.Show();
            Visibility = Visibility.Collapsed;
        }

        private void ChbdgNakladnaya_Checked(object sender, RoutedEventArgs e)
        {
            dgNakladnaya.Visibility = Visibility.Visible;
        }

        private void ChbdgNakladnaya_Unchecked(object sender, RoutedEventArgs e)
        {
            dgNakladnaya.Visibility = Visibility.Hidden;
        }
    }
}
