using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace WeaponStore.TableConnection
{
    class ConnectionNakladnaya
    {
        public static SqlConnection connection = new SqlConnection(
                   "Data Source = DESKTOP-TEG5PUS\\SEX_MACHINE; " +
                   " Initial Catalog = Weapon_Store; Persist Security Info = True;" +
                   " User ID = sa; Password = \"s453153s\"");
        public DataTable dtNakladnaya = new DataTable("Nakladnaya");

        public static string qrNakladnaya = "SELECT[ID_Nakladnaya]," +
            "[Number_Nakladnaya] as \"Номер_накладной\",[Supply_ID],[ID_Supply],[Date] as \"Дата поставки\",[Ammount_Accepted_Weapon] as \"Кол-во принятых оружий\",[Ammount_Accepted_Modifications] as \"Кол-во принятых модификаций\",[Ammount_Accepted_Ammo] as \"Кол-во принятых патронов\",[Supplier_ID],[ID_Supplier],[Name_Organization] as \"Название организации поставщика\",[Dogovor_ID],[ID_Dogovor],[Number_Dogovor] as \"Номер договора\" FROM" +
            "[dbo].[Nakladnaya] INNER JOIN [dbo].[Supply]" +
            " ON [dbo].[Nakladnaya].[Supply_ID]" +
            " =[dbo].[Supply].[ID_Supply]" +
            "INNER JOIN[dbo].[Supplier]" +
            "ON [dbo].[Supply].[Supplier_ID]" +
            "=[dbo].[Supplier].[ID_Supplier]" +
            "INNER JOIN[dbo].[Dogovor]" +
            "ON [dbo].[Supply].[Dogovor_ID]" +
            "=[dbo].[Dogovor].[ID_Dogovor]";
        //public int ID_Nakladnaya { get; set; }
        //public string Number_Nakladnaya { get; set; }
        //public int Supply_ID { get; set; }
        //public ConnectionNakladnaya(int iD_Nakladnaya, string number_Nakladnaya, int supply_ID)
        //{
        //    ID_Nakladnaya = iD_Nakladnaya;
        //    Number_Nakladnaya = number_Nakladnaya;
        //    Supply_ID = supply_ID;
        //}

        private SqlCommand command = new SqlCommand("", connection);
        private void dtFill(DataTable table, string query)
        {
            command.CommandText = query;
            connection.Open();
            table.Load(command.ExecuteReader());
            connection.Close();
        }
        public void Nakladnaya_Fill()
        {
            dtFill(dtNakladnaya, qrNakladnaya);
        }
    }
}
