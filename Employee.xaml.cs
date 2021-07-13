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
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace WeaponStore
{
    /// <summary>
    /// Логика взаимодействия для Employee.xaml
    /// </summary>
    public partial class Employee : Window
    {
        private TableConnection.ConnectionEmployee connectionEmployee;
        List<TableConnection.ConnectionEmployee> Employees;
        private TableConnection.ConnectionEmployee1 connectionEmployee1;
        List<TableConnection.ConnectionEmployee> Employees1;
        private TableConnection.ConnectionPosition connectionPosition;
        List<TableConnection.ConnectionPosition> Positions;
        private List<TableConnection.ConnectionRole> roles;

        public string extension = string.Empty;
        private string QR = "";
        public Employee()
        {
            InitializeComponent();
            roles = new DBProcedures().getRoleList();
            ObservableCollection<string> listPositions = new ObservableCollection<string>();
            foreach (var it in roles)
            {
                listPositions.Add(it.Title_Role);
            }
            this.lbPosition.ItemsSource = listPositions;

            this.connectionEmployee1 = connectionEmployee1;

            if (this.connectionEmployee != null)
            {
                tbFirstName.Text = this.connectionEmployee1.First_Name_Employee;
                tbName.Text = this.connectionEmployee1.Name_Employee;
                tbMiddleName.Text = this.connectionEmployee1.Middle_Name_Employee;
                tbJobExpirience.Text = this.connectionEmployee1.Job_Experience;
                tbEmploymentData.Text = this.connectionEmployee1.Employment_Data;
                
                lbPosition.IsEnabled = false;
                txtBoxLogin.Visibility = Visibility.Hidden;
                txtBoxPassword.Visibility = Visibility.Hidden;
                txtBoxPassword2.Visibility = Visibility.Hidden;
                labelPass.Visibility = Visibility.Hidden;
                labelPass2.Visibility = Visibility.Hidden;
                labelLogin.Visibility = Visibility.Hidden;

                int idlistRoles = -1;
                for (idlistRoles = 0; idlistRoles < roles.Count; idlistRoles++)
                {
                    TableConnection.ConnectionAuthorization authorization = null;
                    foreach (var it in new DBProcedures().getAuthorizationList())
                    {
                        if (it.ID_Authorization == this.connectionEmployee1.ID_Authorization)
                        {
                            authorization = it;
                            break;
                        }
                    }
                    if (authorization != null)
                    {
                        if (roles[idlistRoles].ID_Role == authorization.ID_Role)
                        {
                            break;
                        }
                    }

                }
                lbPosition.SelectedIndex = idlistRoles;
            }
            else
            {
                tbName.Text = string.Empty;
                tbMiddleName.Text = string.Empty;
                tbJobExpirience.Text = string.Empty;
                tbEmploymentData.Text = string.Empty;
            }
        }
    
        DBProcedures procedures = new DBProcedures();
        private void Window_Activated(object sender, EventArgs e)
        {
            //Employees = (new DBProcedures()).getEmployeeList();
            //dgEmployee.ItemsSource = Employees;
            //Positions = (new DBProcedures()).getPositionList();
            //lbPosition.ItemsSource = Positions;
        }
        private void dgFill(string qr)
        {
            ConnectionEmployee connection = new ConnectionEmployee();
            ConnectionEmployee.qrEmployee = qr;
            connection.Employee_Fill();
            dgEmployee.ItemsSource = connection.dtEmployee.DefaultView;
            dgEmployee.Columns[0].Visibility = Visibility.Collapsed;
            dgEmployee.Columns[6].Visibility = Visibility.Collapsed;
            dgEmployee.Columns[7].Visibility = Visibility.Collapsed;
        }

        private void BtInsert_Click(object sender, RoutedEventArgs e)
        {
            if (tbFirstName.Text == string.Empty)
            {
                MessageBox.Show("Ошибка");
                return;
            }
            int idAuth(string Login)
            {
                var dbprocedures = new DBProcedures();
                var auths = dbprocedures.getAuthorizationList();
                foreach (var a in auths)
                {
                    if (a.Login == txtBoxLogin.Text)
                    {
                        return a.ID_Authorization;
                    }
                }
                return -1;
            }

            TableConnection.ConnectionAuthorization newAuthorization = new TableConnection.ConnectionAuthorization(-1, txtBoxLogin.Text, txtBoxPassword.Text, 4);
            new DBProcedures().spAuthorization_insert(newAuthorization);

            int ID_Position = Positions[lbPosition.SelectedIndex].ID_Position;
            int id_Auth = idAuth(txtBoxLogin.Text);

            TableConnection.ConnectionEmployee1 employee1 = new TableConnection.ConnectionEmployee1(
                id_Auth,
                tbFirstName.Text,
                tbName.Text,
                tbMiddleName.Text,
                tbJobExpirience.Text,
                tbEmploymentData.Text,
                ID_Position
                );

            new DBProcedures().spEmployee_insert1(employee1);
            MessageBox.Show("Регистрация прошла успешно");
            dgFill(QR);
            txtBoxLogin.Text = string.Empty; 
            txtBoxPassword.Text = string.Empty;
            txtBoxPassword2.Text = string.Empty;
            //new DBProcedures().spEmployee_insert(new TableConnection.ConnectionEmployee(
            //    -1,
            //    tbFirstName.Text,
            //    tbName.Text,
            //    tbMiddleName.Text,
            //    tbJobExpirience.Text,
            //    tbEmploymentData.Text,
            //    Convert.ToInt32(lbPosition.SelectedValue)
            //    ));
            //Employees = (new DBProcedures()).getEmployeeList();
            //dgEmployee.ItemsSource = Employees;

            //procedures.spEmployee_insert(idAuth,tbFirstName.Text,tbName.Text, tbMiddleName.Text, tbJobExpirience.Text,tbEmploymentData.Text ,Convert.ToInt32(lbPosition.SelectedValue));
        }

        private void BtUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (tbFirstName.Text == string.Empty)
            {
                MessageBox.Show("Ошибка");
                return;
            }
            //new DBProcedures().spEmployee_update(new TableConnection.ConnectionEmployee(
            //this.connectionEmployee.ID_Authorization,
            // tbFirstName.Text,
            //    tbName.Text,
            //    tbMiddleName.Text,
            //    tbJobExpirience.Text,
            //    tbEmploymentData.Text,
            //    Convert.ToInt32(lbPosition.SelectedValue)
            //    ));
            //Employees = (new DBProcedures()).getEmployeeList();
            //dgEmployee.ItemsSource = Employees;
            try
            {
                DataRowView ID = (DataRowView)dgEmployee.SelectedItems[0];
                if (ID == null)
                    MessageBox.Show("", "");
                else
                    procedures.spEmployee_update(tbFirstName.Text, tbName.Text, tbMiddleName.Text, tbJobExpirience.Text, tbEmploymentData.Text, Convert.ToInt32(ID["ID_Authorization"]), Convert.ToInt32(lbPosition.SelectedValue));
                dgFill(QR);
            }
            catch
            {

            }
        }

        private void BtDelete_Click(object sender, RoutedEventArgs e)
        {
            if (tbFirstName.Text == string.Empty)
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
                      (DataRowView)dgEmployee.SelectedItems[0];
                    procedures.spEmployee_delete(
                       Convert.ToInt32(ID["ID_Authorization"]));
                    dgFill(QR);
                    break;
            }
        }

        private void BtSearch_Click(object sender, RoutedEventArgs e)
        {
            foreach (DataRowView dataRow in (DataView)dgEmployee.ItemsSource)
            {
                if (dataRow.Row.ItemArray[1].ToString() == tbSearch.Text ||
                    dataRow.Row.ItemArray[2].ToString() == tbSearch.Text ||
                    dataRow.Row.ItemArray[3].ToString() == tbSearch.Text ||
                    dataRow.Row.ItemArray[4].ToString() == tbSearch.Text ||
                    dataRow.Row.ItemArray[5].ToString() == tbSearch.Text ||
                    dataRow.Row.ItemArray[8].ToString() == tbSearch.Text ||
                    dataRow.Row.ItemArray[9].ToString() == tbSearch.Text)
                {
                    dgEmployee.SelectedItem = dataRow;
                }
            }
        }

        private void BtFilter_Click(object sender, RoutedEventArgs e)
        {
            switch (chbFilter.IsChecked)
            {
                case (true):
                    string newQR = QR + " where [First_Name_Employee] like '%" + tbSearch.Text + "%' or " +
                "[Name_Employee] like '%" + tbSearch.Text + "%' or " +
                "[Middle_Name_Employee] like '%" + tbSearch.Text + "%' or " +
                "[Job_Experience] like '%" + tbSearch.Text + "%' or " +
                "[Employment_Data] like '%" + tbSearch.Text + "%' or " +
                "[Position_ID] like '%" + tbSearch.Text + "%'";
                    dgFill(newQR);
                    break;
                case (false):
                    dgFill(QR);
                    break;
            }
        }

        private void BtInsertPosition_Click(object sender, RoutedEventArgs e)
        {
            new DBProcedures().spPosition_insert(new TableConnection.ConnectionPosition(
               -1,
               tbName_Position.Text,
               tbSalary.Text
               ));
            Positions = (new DBProcedures()).getPositionList();
            lbPosition.ItemsSource = Positions;
        }

        private void BtUpdatePosition_Click(object sender, RoutedEventArgs e)
        {
           new DBProcedures().spPosition_update(new TableConnection.ConnectionPosition(
           this.connectionPosition.ID_Position,
           tbName_Position.Text,
               tbSalary.Text
               ));
            Positions = (new DBProcedures()).getPositionList();
            lbPosition.ItemsSource = Positions;
        }

        private void BtDeletePosition_Click(object sender, RoutedEventArgs e)
        {
            switch (MessageBox.Show("Удалить выбранную запись?",
               "Удаление записи", MessageBoxButton.YesNo,
               MessageBoxImage.Warning))
            {
                case MessageBoxResult.Yes:
                    procedures.spPosition_delete(
                    Convert.ToInt32(lbPosition.
                    SelectedValue.ToString()));
                    Positions = (new DBProcedures()).getPositionList();
                    lbPosition.ItemsSource = Positions;
                    break;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dgEmployee.Visibility = Visibility.Hidden;
            QR = ConnectionEmployee.qrEmployee;
            dgFill(QR);
            Positions = (new DBProcedures()).getPositionList();
            lbPosition.ItemsSource = Positions;
            lbPosition.SelectedValuePath = "ID_Position";
            lbPosition.DisplayMemberPath = "Name_Position";
        }

        private void BtBack_Click(object sender, RoutedEventArgs e)
        {
            Spravochnik spravochnik = new Spravochnik();
            spravochnik.Show();
            Visibility = Visibility.Collapsed;
        }

        private void ChbdgNakladnaya_Checked(object sender, RoutedEventArgs e)
        {
            dgEmployee.Visibility = Visibility.Visible;
        }

        private void ChbdgNakladnaya_Unchecked(object sender, RoutedEventArgs e)
        {
            dgEmployee.Visibility = Visibility.Hidden;
        }
    }
}
