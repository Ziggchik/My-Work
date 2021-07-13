using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace WeaponStore.TableConnection
{
    class ConnectionWeapon1
    {
        public static SqlConnection connection = new SqlConnection(
                 "Data Source = DESKTOP-TEG5PUS\\SEX_MACHINE; " +
                 " Initial Catalog = Weapon_Store; Persist Security Info = True;" +
                 " User ID = sa; Password = \"s453153s\"");

        public DataTable dtWeapon = new DataTable("Weapon");
        public static string qrWeapon = "SELECT[ID_Weapon],[Name_Weapon] as \"Название оружия\", [Accuracy] as \"Точность\", [Fire_Rate] as \"Скорострельность\",[Shells_In_Store] as \"Патронов в обойме\",[Ammount_Weapon] as \"Кол-во оружия на складе\",[Cost] as \"Цена\",[Type_Weapon_ID],[ID_Type_Weapon],[Name_Type_Weapon] as \"Название типа оружия\" FROM" + 
            "[dbo].[Weapon] INNER JOIN [dbo].[Type_Weapon]" +
            "ON [dbo].[Weapon].[Type_Weapon_ID]" +
            "=[dbo].[Type_Weapon].[ID_Type_Weapon]";

        public SqlCommand command = new SqlCommand("", connection);
        private void dtFill(DataTable table, string query)
        {
            command.CommandText = query;
            connection.Open();
            table.Load(command.ExecuteReader());
            connection.Close();
        }
        public void Weapon_Fill()
        {
            dtFill(dtWeapon, qrWeapon);
        }
    }
}
