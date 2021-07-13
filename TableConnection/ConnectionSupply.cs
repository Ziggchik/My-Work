using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace WeaponStore.TableConnection
{
    public class ConnectionSupply
    {
        public static SqlConnection connection = new SqlConnection(
                  "Data Source = DESKTOP-TEG5PUS\\SEX_MACHINE; " +
                  " Initial Catalog = Weapon_Store; Persist Security Info = True;" +
                  " User ID = sa; Password = \"s453153s\"");

        public DataTable dtSupply = new DataTable("Supply");

        public static string qrSupply = "SELECT[ID_Supply],[Date] as \"Дата_поставки\", [Ammount_Accepted_Weapon] as \"Кол-во_принятых_оружий\", [Ammount_Accepted_Modifications] as \"Кол-во_принятых_модификаций\",[Ammount_Accepted_Ammo] as \"Кол-во_принятых_патронов\",[Supplier_ID],[ID_Supplier],[Name_Organization] as \"Название_организации_поставщика\",[Dogovor_ID],[ID_Dogovor],[Number_Dogovor] as \"Номер_договора\" FROM" +
             "[dbo].[Supply] INNER JOIN [dbo].[Supplier]" +
            "ON [dbo].[Supply].[Supplier_ID]" +
            "=[dbo].[Supplier].[ID_Supplier]" +
            "INNER JOIN[dbo].[Dogovor]" +
            "ON [dbo].[Supply].[Dogovor_ID]" +
            "=[dbo].[Dogovor].[ID_Dogovor]";
        //public int ID_Supply { get; set; }
        //public string Date { get; set; }
        //public int Ammount_Accepted_Weapon { get; set; }
        //public int Ammount_Accepted_Modifications { get; set; }
        //public int Ammount_Accepted_Ammo{ get; set; }
        //public int Supplier_ID { get; set; }
        //public int Dogovor_ID { get; set; }

        //public ConnectionSupply(int iD_Supply, string date, int ammount_Accepted_Weapon, int ammount_Accepted_Modifications, int ammount_Accepted_Ammo , int supplier_ID, int dogovor_ID)
        //{
        //    ID_Supply = iD_Supply;
        //    Date = date;
        //    Ammount_Accepted_Weapon = ammount_Accepted_Weapon;
        //    Ammount_Accepted_Modifications = ammount_Accepted_Modifications;
        //    Ammount_Accepted_Ammo = ammount_Accepted_Ammo;
        //    Supplier_ID = supplier_ID;
        //    Dogovor_ID = dogovor_ID;
        //}
        public SqlCommand command = new SqlCommand("", connection);
        private void dtFill(DataTable table, string query)
        {
            command.CommandText = query;
            connection.Open();
            table.Load(command.ExecuteReader());
            connection.Close();
        }
        public void Supply_Fill()
        {
            dtFill(dtSupply, qrSupply);
        }
    }
}
