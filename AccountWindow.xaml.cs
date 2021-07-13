
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
    /// Логика взаимодействия для AccountWindow.xaml
    /// </summary>
    public partial class AccountWindow : Window
    {
        private List<Button> buttons = new List<Button>();
        public AccountWindow()
        {
            var roleList = new DBProcedures().getRoleList(Session.currentUser.ID_Role);
            InitializeComponent();

            if (roleList.Count == 1)
            {
                buttons.Clear();

                var role = roleList[0];

                this.Title = role.Title_Role;


                if (role.Klient == 1)
                {
                    buttons.Add(createButton("Информация для клиента", Button_Hanle_KlientInfo));
                    //buttonsRole.Add(new ButtonRole() { Caption = "Учет автомобилей", HandleName = "Button_Hanle" });
                }

                if (role.Admin == 1)
                {
                    buttons.Add(createButton("Справочники", Button_Handle_Spravochnik));
                    //buttonsRole.Add(new ButtonRole() { Caption = "Учет автомобилей", HandleName = "Button_Hanle" });
                }

                if (role.Employee == 1)
                {
                    buttons.Add(createButton("Список клиентов", Button_Hanle_AddCustomerWindow));
                    //buttonsRole.Add(new ButtonRole() { Caption = "Добавление клиента", HandleName = "Button_Hanle" });
                }

                for (int i = 0; i < buttons.Count; i++)
                {

                    sp.Children.Add(buttons[i]);
                }

            }
        }
        private Button createButton(string content, RoutedEventHandler handler)
        {
            var b = new Button();
            b.Content = content;
            b.Click += handler;
            return b;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var roleList = new DBProcedures().getRoleList(Session.currentUser.ID_Role);
            InitializeComponent();

            if (roleList.Count == 1)
            {
                buttons.Clear();

                var role = roleList[0];

                this.Title = role.Title_Role;

                if (role.Klient == 1)
                {
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    Session.currentUser = null;
                }
                else
                {
                    //MessageBox.Show("Вы не клиент");
                    Authorization authorization = new Authorization();
                    authorization.Show();
                    Visibility = Visibility.Collapsed;
                }
            }
        }

        private void Button_Handle_Weapon(object sender, RoutedEventArgs e)
        {
            var window = new Weapon();
            window.ShowDialog();
        }

        private void Button_Hanle_Ammo(object sender, RoutedEventArgs e)
        {
            var window = new Ammo();
            window.ShowDialog();
        }

        private void Button_Hanle_Modifications(object sender, RoutedEventArgs e)
        {
            var window = new Modifications();
            window.ShowDialog();
        }

        private void Button_Hanle_ClientLockWindow(object sender, RoutedEventArgs e)
        {
            var window = new BlockKlient();
            window.ShowDialog();
        }

        private void Button_Hanle_AddCustomerWindow(object sender, RoutedEventArgs e)
        {
            var window = new Klients();
            window.ShowDialog();
        }

        private void Button_Hanle_KlientInfo(object sender, RoutedEventArgs e)
        {
            var window = new KlientInfo();
            window.ShowDialog();
        }

        private void Button_Handle_Spravochnik(object sender, RoutedEventArgs e)
        {
            var window = new Spravochnik();
            window.ShowDialog();
        }
    }
}
  
