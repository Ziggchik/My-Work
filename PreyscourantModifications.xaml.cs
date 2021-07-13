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


namespace WeaponStore
{
    /// <summary>
    /// Логика взаимодействия для PreyscourantModifications.xaml
    /// </summary>
    public partial class PreyscourantModifications : Window
    {
        List<TableConnection.ConnectionModifications> Modifications;

        public string extension = string.Empty;
        private string QR = "";
        public PreyscourantModifications()
        {
            InitializeComponent();
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            Modifications = (new DBProcedures()).getModificationsList();
            dgModifications.ItemsSource = Modifications;
        }

        List<DataView> list1 = new List<DataView>();
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //list1.Add((DataView)dgModifications.SelectedItem);
            //Korzina korzina = new Korzina(list1);
            //korzina.Show();
            //Visibility = Visibility.Collapsed;
        }
    }
}
