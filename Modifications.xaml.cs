using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace WeaponStore
{
    /// <summary>
    /// Логика взаимодействия для Modifications.xaml
    /// </summary>
    public partial class Modifications : Window
    {
        private TableConnection.ConnectionModifications connectionModifications;
        List<TableConnection.ConnectionModifications> Modification;
       
        public string extension = string.Empty;
        private string QR = "";

        public Modifications()
        {
            InitializeComponent();
        }


       //public Modifications(TableConnection.ConnectionModifications connectionModifications)
       //{
       //    InitializeComponent();
       //}

       DBProcedures procedures = new DBProcedures();
        private void BtInsert_Click(object sender, RoutedEventArgs e)
        {
            if (tbNameModification.Text == string.Empty ||
               tbAmmountModifications.Text == string.Empty ||
               tbCost.Text == string.Empty)
            {
                MessageBox.Show("Ошибка");
                return;
            }

            new DBProcedures().spModifications_insert(new TableConnection.ConnectionModifications(
                -1,
                tbNameModification.Text,
                Convert.ToInt32(tbAmmountModifications.Text),
                tbCost.Text
                ));
                Modification = (new DBProcedures()).getModificationsList();
                dgModifications.ItemsSource = Modification;
                dgModifications.Columns[0].Visibility = Visibility.Collapsed;
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            //dgModifications.Visibility = Visibility.Hidden;
            //Modification = (new DBProcedures()).getModificationsList();
            //dgModifications.ItemsSource = Modification;
            //dgModifications.Columns[0].Visibility = Visibility.Collapsed;
        }

        private void BtUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (tbNameModification.Text == string.Empty ||
              tbAmmountModifications.Text == string.Empty ||
              tbCost.Text == string.Empty)
            {
                MessageBox.Show("Ошибка");
                return;
            }

            int selectedIndex = dgModifications.SelectedIndex;
            var ap = new DBProcedures().getModificationsList();
            foreach (var it in ap)
            {
                if (it.ID_Modification == Modification[selectedIndex].ID_Modification) ;
                {
                    connectionModifications = it;
                    break;
                }
            }

            new DBProcedures().spModifications_update(new TableConnection.ConnectionModifications(
            this.connectionModifications.ID_Modification,
                tbNameModification.Text,
                Convert.ToInt32(tbAmmountModifications.Text),
                tbCost.Text
                ));
                Modification = (new DBProcedures()).getModificationsList();
                dgModifications.ItemsSource = Modification;
                dgModifications.Columns[0].Visibility = Visibility.Collapsed;
        }

        private void BtDelete_Click(object sender, RoutedEventArgs e)
        {
            if (tbNameModification.Text == string.Empty ||
             tbAmmountModifications.Text == string.Empty ||
             tbCost.Text == string.Empty)
            {
                MessageBox.Show("Ошибка");
                return;
            }
            int selectedIndex = dgModifications.SelectedIndex;
            new DBProcedures().spModifications_delete(Modification[selectedIndex].ID_Modification);
            MessageBox.Show("Операция выполнена");
            Modification = (new DBProcedures()).getModificationsList();
            dgModifications.ItemsSource = Modification;
            dgModifications.Columns[0].Visibility = Visibility.Collapsed;
        }

        private void BtSearch_Click(object sender, RoutedEventArgs e)
        {
            foreach (DataRowView dataRow in (DataView)dgModifications.ItemsSource)
            {
                if (dataRow.Row.ItemArray[1].ToString() == tbSearch.Text ||
                    dataRow.Row.ItemArray[2].ToString() == tbSearch.Text ||
                    dataRow.Row.ItemArray[3].ToString() == tbSearch.Text ||
                    dataRow.Row.ItemArray[4].ToString() == tbSearch.Text ||
                    dataRow.Row.ItemArray[7].ToString() == tbSearch.Text)
                {
                    dgModifications.SelectedItem = dataRow;
                }
            }
        }

        private void BtFilter_Click(object sender, RoutedEventArgs e)
        {
            string newQR = QR + " where [Name_Modification] like '%" + tbSearch.Text + "%' or " +
                "[Ammount_Modifications] like '%" + tbSearch.Text + "%' or " +
                "[Cost] like '%" + tbSearch.Text + "%'";
            Modification = (new DBProcedures()).getModificationsList();
            dgModifications.ItemsSource = Modification;
        }

        private void BtBack_Click(object sender, RoutedEventArgs e)
        {
            Spravochnik spravochnik = new Spravochnik();
            spravochnik.Show();
            Visibility = Visibility.Collapsed;
        }

        private void ChbdgModifications_Checked(object sender, RoutedEventArgs e)
        {
            dgModifications.Visibility = Visibility.Visible;
        }

        private void ChbdgModifications_Unchecked(object sender, RoutedEventArgs e)
        {
            dgModifications.Visibility = Visibility.Hidden;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dgModifications.Visibility = Visibility.Hidden;
            Modification = (new DBProcedures()).getModificationsList();
            dgModifications.ItemsSource = Modification;
            dgModifications.Columns[0].Visibility = Visibility.Collapsed;
        }
    }
}
