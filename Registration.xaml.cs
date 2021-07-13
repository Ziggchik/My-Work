using WeaponStore.TableConnection;
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

namespace WeaponStore
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    /// 
    public partial class Registration : Window
    {
        private TableConnection.ConnectionLicense connectionLicense;
        List<TableConnection.ConnectionLicense> Licenses;
        async Task<bool> Symb(string str)
        {
            bool znach = false;
            await Task.Run(() =>
            {
                if (
                str.Contains("?") || str.Contains("!") || str.Contains("@") ||
                str.Contains("#") || str.Contains("№") || str.Contains("~") ||
                str.Contains(";") || str.Contains("%") || str.Contains("$") ||
                str.Contains("^") || str.Contains("&") || str.Contains(":") ||
                str.Contains("*") || str.Contains("(") || str.Contains(")") ||
                str.Contains("_") || str.Contains("=") || str.Contains("+") ||
                str.Contains("/") || str.Contains("|") || str.Contains("[") ||
                str.Contains("]") || str.Contains("{") || str.Contains("}") ||
                str.Contains("<") || str.Contains(">") || str.Contains("-") ||
                str.Contains(",") || str.Contains("`") || str.Contains("."))
                    znach = true;
            });
            return znach;
        }

        List<TableConnection.ConnectionLicense> licenses;
        bool isAdmin { get; set; }

        private ConnectionKlient connectionKlient;
        public Registration (ConnectionKlient connectionKlient, bool isConnection = false)
        {
            InitializeComponent();

            this.connectionKlient = connectionKlient;

            this.isAdmin = isAdmin;

            licenses = new DBProcedures().getLicenseList();
            ObservableCollection<string> listLicense = new ObservableCollection<string>();
            foreach (var licence in licenses)
            {
                listLicense.Add(licence.License_Number);
            }
            this.comboBoxID_Licence.ItemsSource = listLicense;

            if (this.connectionKlient != null)
            {
                int idlistLicence = -1;
                for (idlistLicence = 0; idlistLicence < licenses.Count; idlistLicence++)
                {
                    if (licenses[idlistLicence].ID_License == this.connectionKlient.License_ID)
                    {
                        break;
                    }
                }
                this.comboBoxID_Licence.ItemsSource = listLicense;

                txtBoxSurname.Text = connectionKlient.First_Name_Klient;
                txtBoxName.Text = connectionKlient.Name_Klient;
                txtBoxMiddle_Name.Text = connectionKlient.Middle_Name_Klient;
                txtBoxTelephone_Number.Text = connectionKlient.Phone_Number;
                //txtBoxLicense.Text = Convert.ToString (connectionKlient.License_ID);
                txtBoxLogin.Text = Login (connectionKlient.ID_Authorization); 
                txtBoxPassword.Visibility = Visibility.Hidden;
               
            }
            else
            {
                txtBoxSurname.Text = string.Empty;
                txtBoxName.Text = string.Empty;
                txtBoxMiddle_Name.Text = string.Empty;
                txtBoxTelephone_Number.Text = string.Empty;
                txtBoxLicense.Text = string.Empty;
                txtBoxLogin.Text = string.Empty;
                //txtBoxPassword.Visibility = Visibility.Hidden;
            }

            if (isAdmin)
            {
                txtBoxSurname.IsReadOnly = true;
                txtBoxName.IsReadOnly = true;
                txtBoxMiddle_Name.IsReadOnly = true;
                txtBoxTelephone_Number.IsReadOnly = true;
                comboBoxID_Licence.IsReadOnly = true;
                //txtBoxLicense.IsReadOnly = true;
                txtBoxLogin.IsReadOnly = true;
                txtBoxPassword.Visibility = Visibility.Hidden;
                txtBoxPassword2.Visibility = Visibility.Hidden;
                btRegistration.Content = "Close";
            }



            string Login(int ID_Authorization)
            {
                var dbprocedures = new DBProcedures();
                var auths = dbprocedures.getAuthorizationList();
                foreach (var a in auths)
                {
                    if (a.ID_Authorization == ID_Authorization)
                    {
                        return a.Login;
                    }
                }
                return string.Empty;
            }
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

        int idLicence(string Licence)
        {
            var dbprocedures = new DBProcedures();
            var auths = dbprocedures.getLicenseList();
            foreach (var a in auths)
            {
                if (a.License_Number == txtBoxLogin.Text)
                {
                    return a.ID_License;
                }
            }
            return -1;
        }

        private async void BtRegistration_Click(object sender, RoutedEventArgs e)
        {
            if (isAdmin)
            {
                Close();
                return;
            }

            bool znach2 = await Symb(txtBoxSurname.Text);

            if (txtBoxSurname.Text == String.Empty || znach2)
            {
                MessageBox.Show("Есть ошибка в указании Фамилии");
                return;
            }

            bool znach1 = await Symb(txtBoxName.Text);

            if (txtBoxName.Text == String.Empty || znach1)
            {
                MessageBox.Show("Есть ошибка в указании Имени");
                return;
            }

            bool znach3 = await Symb(txtBoxMiddle_Name.Text);

            if (txtBoxMiddle_Name.Text == String.Empty || znach3)
            {
                MessageBox.Show("Есть ошибка в указании Отчества");
                return;
            }

            bool znach4 = await Symb(txtBoxTelephone_Number.Text);

            if (txtBoxTelephone_Number.Text == String.Empty || znach4)
            {
                MessageBox.Show("Есть ошибка в указании телефонного номера");
                return;
            }

            if (comboBoxID_Licence.SelectedIndex < 0)
            {
                MessageBox.Show("Не выбрана категория");
                return;
            }

            if (txtBoxLogin.Text == String.Empty)
            {
                MessageBox.Show("Не указан логин");
                return;
            }

            if (txtBoxPassword .Text == String.Empty)
            {
                MessageBox.Show("Не указан пароль");
                return;
            }

            if (txtBoxPassword.Text != txtBoxPassword2.Text)
            {
                MessageBox.Show("Введенные пароли не совпадают");
                return;
            }

            if (idAuth(txtBoxLogin.Text) >= 0)
            {
                MessageBox.Show("Такой логин уже есть в базе");
                return;
            }

            if (ch1.IsChecked == false)
            {
                MessageBox.Show("Проверка на робота не пройдена");
                return;
            }



            int ID_License = licenses[comboBoxID_Licence.SelectedIndex].ID_License;
            //int ID_License = idLicence(txtBoxLicense.Text);

            TableConnection.ConnectionAuthorization newAuthorization = new TableConnection.ConnectionAuthorization(-1, txtBoxLogin.Text, txtBoxPassword.Text, 2);
            new DBProcedures().spAuthorization_insert(newAuthorization);

            int id_Auth = idAuth(txtBoxLogin.Text);

            TableConnection.ConnectionKlient klient = new TableConnection.ConnectionKlient(
                id_Auth,
                txtBoxSurname.Text,
                txtBoxName.Text,
                txtBoxMiddle_Name.Text,
                txtBoxTelephone_Number.Text,
                ID_License
                );

            new DBProcedures().spKlient_insert(klient);

            MessageBox.Show("Регистрация прошла успешно");
            Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LicenceSogl licenceSogl = new LicenceSogl();
            licenceSogl.Show();
        }

        private void BtInsert_Click(object sender, RoutedEventArgs e)
        {
            if (txtBoxLicense.Text == string.Empty)
            {
                MessageBox.Show("Ошибка");
                return;
            }

            new DBProcedures().spLicense_insert(new TableConnection.ConnectionLicense(
                -1,
                txtBoxLicense.Text
                ));
            Licenses = (new DBProcedures()).getLicenseList();
            comboBoxID_Licence.ItemsSource = Licenses;
            comboBoxID_Licence.SelectedValuePath = "ID_License";
            comboBoxID_Licence.DisplayMemberPath = "License_Number";
        }

        private void Window_Activated(object sender, EventArgs e)
        {
        }
    }
}
    
