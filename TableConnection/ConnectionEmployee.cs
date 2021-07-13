using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace WeaponStore.TableConnection
{
    class ConnectionEmployee
    {
        public static SqlConnection connection = new SqlConnection(
                  "Data Source = DESKTOP-TEG5PUS\\SEX_MACHINE; " +
                  " Initial Catalog = Weapon_Store; Persist Security Info = True;" +
                  " User ID = sa; Password = \"s453153s\"");

        public DataTable dtEmployee = new DataTable("Employee");
        public static string qrEmployee = "SELECT[ID_Authorization],[First_Name_Employee] as \"Фамилия\", [Name_Employee] as \"Имя\", [Middle_Name_Employee] as \"Отчество\",[Job_Experience] as \"Опыт_работы\",[Employment_Data] as \"Дата_трудоустройства\",[Position_ID],[ID_Position],[Name_Position] as \"Название_должности\",[Salary] as \"Оплата\" FROM" +
            "[dbo].[Employee] INNER JOIN [dbo].[Position]" +
            "ON [dbo].[Employee].[Position_ID]" +
            "=[dbo].[Position].[ID_Position]";

        public SqlCommand command = new SqlCommand("", connection);
        private void dtFill(DataTable table, string query)
        {
            command.CommandText = query;
            connection.Open();
            table.Load(command.ExecuteReader());
            connection.Close();
        }
        public void Employee_Fill()
        {
            dtFill(dtEmployee, qrEmployee);
        }
    }
}
