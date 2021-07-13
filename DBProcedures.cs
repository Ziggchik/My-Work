using WeaponStore.TableConnection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WeaponStore
{
    class DBProcedures
    {
        private SqlCommand command
          = new SqlCommand("", ConnectionNakladnaya.connection);

        private SqlCommand command1
          = new SqlCommand("", ConnectionSupply.connection);
        public void commandConfig(string config)
        {
            command.CommandType =
                System.Data.CommandType.StoredProcedure;
            command.CommandText = "[dbo].[" + config + "]";
            command.Parameters.Clear();
        }
        public void commandConfig1(string config)
        {
            command1.CommandType =
                System.Data.CommandType.StoredProcedure;
            command1.CommandText = "[dbo].[" + config + "]";
            command1.Parameters.Clear();
        }

        public string connectionString = @"Data Source=DESKTOP-TEG5PUS\SEX_MACHINE;Initial Catalog=Weapon_Store;Persist Security Info = True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;User ID = sa; Password = s453153s";

        public SqlDependency Dependency = new SqlDependency();
        //public DataTable dtMark = new DataTable("Mark");

        SqlConnection connection;

        public bool IsConnection { get; set; }

        public DBProcedures()
        {
            connection = new SqlConnection(connectionString);
            IsConnection = true;
            try
            {
                connection.Open();

            }
            catch
            {
                IsConnection = false;
            }
        }
        public SqlDataReader execProc(string procName, Dictionary<string, Object> args)
        {

            SqlCommand command = new SqlCommand(procName, connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            if (args != null)
            {
                foreach (var it in args)
                {
                    SqlParameter nameParam;
                    nameParam = new SqlParameter
                    {
                        ParameterName = it.Key,
                        Value = it.Value
                    };
                    command.Parameters.Add(nameParam);
                }
            }

            SqlDataReader reader = command.ExecuteReader();

            return reader;
        }

        public List<ConnectionWeapon> getWeaponList()
        {
            List<ConnectionWeapon> connectionWeapon = new List<ConnectionWeapon>();

            var reader = execProc("Weapon_select", null);

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    connectionWeapon.Add(new ConnectionWeapon(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetInt32(5), reader.GetString(6), reader.GetInt32(7)));
                }
            }
            reader.Close();
            return connectionWeapon;
        }

        public List<ConnectionWeaponDetail> getWeaponListDetail()
        {
            List<ConnectionWeaponDetail> connectionWeaponDetail = new List<ConnectionWeaponDetail>();
            var reader = execProc("Weapon_select_detail", null);
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    connectionWeaponDetail.Add(new ConnectionWeaponDetail(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetInt32(5), reader.GetString(6)));
                }
            }
            reader.Close();
            return connectionWeaponDetail;
        }

        public void spWeapon_insert(TableConnection.ConnectionWeapon connection)
        {
            execProc("Weapon_insert", new Dictionary<string, object> {
                {"Name_Weapon ",connection.Name_Weapon},
                {"Accuracy",connection.Accuracy },
                {"Fire_Rate ",connection.Fire_Rate },
                {"Shells_In_Store",connection.Shells_In_Store},
                {"Ammount_Weapon ",connection.Ammount_Weapon},
                {"Cost ",connection.Cost},
                {"Type_Weapon_ID ",connection.Type_Weapon_ID},              
            });
        }
        public void spWeapon_update(TableConnection.ConnectionWeapon connection)
        {
            execProc("Weapon_update", new Dictionary<string, object> {
                {"ID_Weapon",connection.ID_Weapon},
                {"Name_Weapon",connection.Name_Weapon},
                {"Accuracy",connection.Accuracy },
                {"Fire_Rate ",connection.Fire_Rate },
                {"Shells_In_Store",connection.Shells_In_Store},
                {"Ammount_Weapon ",connection.Ammount_Weapon},
                {"Cost ",connection.Cost},
                {"Type_Weapon_ID ",connection.Type_Weapon_ID},     
            });
        }

        public void spWeapon_delete(int ID_Weapon)
        {
            execProc("Weapon_delete", new Dictionary<string, object> {
                {"ID_Weapon",ID_Weapon},
                });
        }
        public List<ConnectionAmmo> getAmmoList()
        {
            List<ConnectionAmmo> connectionAmmo = new List<ConnectionAmmo>();

            var reader = execProc("Ammo_select", null);

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    connectionAmmo.Add(new ConnectionAmmo(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), reader.GetString(3)));
                }
            }
            reader.Close();
            return connectionAmmo;
        }
        public void spAmmo_insert(TableConnection.ConnectionAmmo connection)
        {
            execProc("Ammo_insert", new Dictionary<string, object> {
                {"Type_Ammo ",connection.Type_Ammo},
                {"Ammount_Ammo",connection.Ammount_Ammo},
                {"Cost ",connection.Cost}
            });
        }
        public void spAmmo_update(TableConnection.ConnectionAmmo connection)
        {
            execProc("Ammo_update", new Dictionary<string, object> {
                {"ID_Ammo ",connection.ID_Ammo},
                {"Type_Ammo ",connection.Type_Ammo},
                {"Ammount_Ammo",connection.Ammount_Ammo},
                {"Cost ",connection.Cost}
            });
        }
        public void spAmmo_delete(int ID_Ammo)
        {
            execProc("Ammo_delete", new Dictionary<string, object> {
                {"ID_Ammo",ID_Ammo},
                });
        }

        public List<ConnectionAuthorization> getAuthorizationList()
        {
            List<ConnectionAuthorization> connectionAuthorization = new List<ConnectionAuthorization>();

            var reader = execProc("Authorization_select", null);

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    connectionAuthorization.Add(new ConnectionAuthorization(
                        reader.GetInt32(0),
                        reader.GetString(1),
                        reader.GetString(2),
                        reader.GetInt32(3)));
                }
            }
            reader.Close();
            return connectionAuthorization;
        }

        public void spAuthorization_insert(TableConnection.ConnectionAuthorization connection)
        {
            execProc("Authorization_insert", new Dictionary<string, object> {
                { "Login", connection.Login },
                { "Password", connection.Password },
                { "ID_Role", connection.ID_Role }
            });
        }

        public void spAuthorization_update(TableConnection.ConnectionAuthorization connection)
        {
            execProc("Authorization_update", new Dictionary<string, object> {
                { "ID_Authorization",connection.ID_Authorization},
                { "Login", connection.Login },
                { "Password", connection.Password },
                { "ID_Role", connection.ID_Role }
            });
        }
        public void deleteAuthorization(int ID_Authorization)
        {
            execProc("Authorization_delete", new Dictionary<string, object> {
                { "ID_Authorization ", ID_Authorization }

            });
        }
        public List<ConnectionDogovor> getDogovorList()
        {
            List<ConnectionDogovor> connectionDogovor = new List<ConnectionDogovor>();

            var reader = execProc("Dogovor_select", null);

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    connectionDogovor.Add(new ConnectionDogovor(reader.GetInt32(0), reader.GetString(1)));
                }
            }
            reader.Close();
            return connectionDogovor;
        }
        public void spDogovor_insert(TableConnection.ConnectionDogovor connection)
        {
            execProc("Dogovor_insert", new Dictionary<string, object> {
                { "Number_Dogovor", connection.Number_Dogovor }
            });
        }
        public void spDogovor_update(TableConnection.ConnectionDogovor connection)
        {
            execProc("Dogovor_update", new Dictionary<string, object> {
                { "ID_Dogovor",connection.ID_Dogovor},
                { "Number_Dogovor", connection.Number_Dogovor }
            });
        }
        public void spDogovor_delete(int ID_Dogovor)
        {
            execProc("Dogovor_delete", new Dictionary<string, object> {
                { "ID_Dogovor ", ID_Dogovor}

            });
        }

        //public List<ConnectionEmployee> getEmployeeList()
        //{
        //    List<ConnectionEmployee> connectionEmployee = new List<ConnectionEmployee>();

        //    var reader = execProc("Employee_select", null);

        //    if (reader.HasRows)
        //    {
        //        while (reader.Read())
        //        {
        //            connectionEmployee.Add(new ConnectionEmployee(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetInt32(6)));
        //        }
        //    }
        //    reader.Close();
        //    return connectionEmployee;
        //}

        public void spEmployee_insert(int ID_Authorization, string First_Name_Employee, string Name_Employee, string Middle_Name_Employee, string Job_Experience, string Employment_Data,  Int32 Position_ID)
        {
            commandConfig("Employee_insert");
            command.Parameters.AddWithValue("@ID_Authorization",
                ID_Authorization);
            command.Parameters.AddWithValue("@First_Name_Employee",
                 First_Name_Employee);
            command.Parameters.AddWithValue("@Name_Employee",
                 Name_Employee);
            command.Parameters.AddWithValue("@Middle_Name_Employee",
                 Middle_Name_Employee);
            command.Parameters.AddWithValue("@Job_Experience",
                Job_Experience);
            command.Parameters.AddWithValue("@Employment_Data",
                 Employment_Data);
            command.Parameters.AddWithValue("@Position_ID", Position_ID);
            ConnectionNakladnaya.connection.Open();
            command.ExecuteNonQuery();
            ConnectionNakladnaya.connection.Close();
            //execProc("Employee_insert", new Dictionary<string, object> {
            //    {"ID_Authorization",connection.ID_Authorization},
            //    {"First_Name_Employee", connection.First_Name_Employee },
            //    {"Name_Employee ", connection.Name_Employee },
            //    {"Middle_Name_Employee", connection.Middle_Name_Employee},
            //    {"Job_Experience", connection.Job_Experience},
            //    {"Employment_Data", connection.Employment_Data},
            //    {"Position_ID", connection.Position_ID}
            //});
        }

        public void spEmployee_insert1(TableConnection.ConnectionEmployee1 connection)
        {
            execProc("Employee_insert", new Dictionary<string, object> {
                {"ID_Authorization",connection.ID_Authorization},
                {"First_Name_Employee", connection.First_Name_Employee},
                {"Name_Employee ", connection.Name_Employee },
                {"Middle_Name_Employee", connection.Middle_Name_Employee},
                {"Job_Experience", connection.Job_Experience},
                {"Employment_Data", connection.Employment_Data},
                {"Position_ID", connection.Position_ID}
            });
        }
        public void spEmployee_update(string First_Name_Employee, string Name_Employee, string Middle_Name_Employee, string Job_Experience, string Employment_Data, 
            Int32 ID_Authorization, Int32 Position_ID)
        {
            //execProc("Employee_update", new Dictionary<string, object> {
            //    {"ID_Authorization",connection.ID_Authorization},
            //    {"First_Name_Employee", connection.First_Name_Employee },
            //    {"Name_Employee ", connection.Name_Employee },
            //    {"Middle_Name_Employee", connection.Middle_Name_Employee},
            //    {"Job_Experience", connection.Job_Experience},
            //    {"Employment_Data", connection.Employment_Data},
            //    {"Position_ID", connection.Position_ID}
            //});
            commandConfig("Employee_update");
            command.Parameters.AddWithValue("@ID_Authorization", ID_Authorization);
            command.Parameters.AddWithValue("@First_Name_Employee",
                  First_Name_Employee);
            command.Parameters.AddWithValue("@Name_Employee",
                 Name_Employee);
            command.Parameters.AddWithValue("@Middle_Name_Employee",
                 Middle_Name_Employee);
            command.Parameters.AddWithValue("@Job_Experience",
                Job_Experience);
            command.Parameters.AddWithValue("@Employment_Data",
                 Employment_Data);
            command.Parameters.AddWithValue("@Position_ID", Position_ID);
            ConnectionNakladnaya.connection.Open();
            command.ExecuteNonQuery();
            ConnectionNakladnaya.connection.Close();
        }
        public void spEmployee_delete(int ID_Authorization)
        {
            //execProc("Employee_delete", new Dictionary<string, object> {
            //    { "ID_Authorization ", ID_Authorization }
            //});
            commandConfig("Employee_delete");
            command.Parameters.AddWithValue("@ID_Authorization", ID_Authorization);
            ConnectionNakladnaya.connection.Open();
            command.ExecuteNonQuery();
            ConnectionNakladnaya.connection.Close();
        }
        public List<ConnectionKlient> getKlientList()
        {
            List<ConnectionKlient> connectionKlient = new List<ConnectionKlient>();

            var reader = execProc("Klient_select", null);

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    connectionKlient.Add(new ConnectionKlient(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetInt32(5)));
                }
            }
            reader.Close();
            return connectionKlient;
        }

        public List<ConnectionKlientDetail> getKlientListDetail()
        {
            List<ConnectionKlientDetail> connectionKlientDetail = new List<ConnectionKlientDetail>();

            var reader = execProc("Klient_select_detail", null);

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    connectionKlientDetail.Add(new ConnectionKlientDetail(reader.GetInt32(0), reader.GetString(1), reader.GetString(2)));
                }
            }
            reader.Close();
            return connectionKlientDetail;
        }

        public void spKlient_insert(TableConnection.ConnectionKlient connection)
        {
            execProc("Klient_insert", new Dictionary<string, object> {
                {"ID_Authorization", connection.ID_Authorization} ,
                {"First_Name_Klient",connection.First_Name_Klient},
                {"Name_Klient ",connection.Name_Klient},
                {"Middle_Name_Klient",connection.Middle_Name_Klient },
                {"Phone_Number",connection.Phone_Number},
                {"License_ID",connection.License_ID},
            });
        }
        public void spKlient_update(TableConnection.ConnectionKlient connection)
        {
            execProc("Klient_update", new Dictionary<string, object> {
                { "ID_Authorization", connection.ID_Authorization} ,
                {"First_Name_Klient",connection.First_Name_Klient},
                {"Name_Klient ",connection.Name_Klient},
                {"Middle_Name_Klient",connection.Middle_Name_Klient },
                {"Phone_Number",connection.Phone_Number},
                {"License_ID",connection.License_ID},
            });
        }
        public void spKlient_delete(int ID_Authorization)
        {
            execProc("Klient_delete", new Dictionary<string, object> {
                { "ID_Authorization", ID_Authorization}
            });
        }

        public List<ConnectionLicense> getLicenseList()
        {
            List<ConnectionLicense> connectionLicense = new List<ConnectionLicense>();

            var reader = execProc("License_select", null);

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    connectionLicense.Add(new ConnectionLicense(reader.GetInt32(0), reader.GetString(1)));
                }
            }
            reader.Close();
            return connectionLicense;
        }
        public void spLicense_insert(TableConnection.ConnectionLicense connection)
        {
            execProc("License_insert", new Dictionary<string, object> {
                { "License_Number", connection.License_Number}
            });
        }
        public void spLicense_update(TableConnection.ConnectionLicense connection)
        {
            execProc("License_update", new Dictionary<string, object> {
                { "ID_License",connection.ID_License},
                { "License_Number", connection.License_Number}
            });
        }
        public void spLicense_delete(int ID_License)
        {
            execProc("License_delete", new Dictionary<string, object> {
                { "ID_License ", ID_License}

            });
        }

        public List<ConnectionModifications> getModificationsList()
        {
            List<ConnectionModifications> connectionModifications = new List<ConnectionModifications>();

            var reader = execProc("Modifications_select", null);

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    connectionModifications.Add(new ConnectionModifications(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), reader.GetString(3)));
                }
            }
            reader.Close();
            return connectionModifications;
        }
        public void spModifications_insert(TableConnection.ConnectionModifications connection)
        {
            execProc("Modifications_insert", new Dictionary<string, object> {
                {"Name_Modification",connection.Name_Modification},
                {"Ammount_Modifications",connection.Ammount_Modifications},
                {"Cost",connection.Cost}
            });
        }
        public void spModifications_update(TableConnection.ConnectionModifications connection)
        {
            execProc("Modifications_update", new Dictionary<string, object> {
                {"ID_Modification ",connection.ID_Modification},
                {"Name_Modification ",connection.Name_Modification},
                {"Ammount_Modifications",connection.Ammount_Modifications},
                {"Cost ",connection.Cost}
            });
        }
        public void spModifications_delete(int ID_Modification)
        {
            execProc("Modifications_delete", new Dictionary<string, object> {
                {"ID_Modification",ID_Modification},
                });
        }

        //public List<ConnectionNakladnaya> getNakladnayaList()
        //{
        //    List<ConnectionNakladnaya> connectionNakladnaya = new List<ConnectionNakladnaya>();

        //    var reader = execProc("Nakladnaya_select", null);

        //    if (reader.HasRows)
        //    {
        //        while (reader.Read())
        //        {
        //            connectionNakladnaya.Add(new ConnectionNakladnaya(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2)));
        //        }
        //    }
        //    reader.Close();
        //    return connectionNakladnaya;
        //}

        //public void spNakladnaya_insert(TableConnection.ConnectionNakladnaya connection)
        //{
        //    execProc("Nakladnaya_insert", new Dictionary<string, object> {
        //        { "Number_Nakladnaya", connection.Number_Nakladnaya},
        //        { "Supply_ID", connection.Supply_ID}
        //    });
        //}
        public void spNakladnaya_insert (string Number_Nakladnaya, Int32 Supply_ID)
        {
            commandConfig("Nakladnaya_insert");
            command.Parameters.AddWithValue("@Number_Nakladnaya",
                 Number_Nakladnaya);
            command.Parameters.AddWithValue("@Supply_ID", Supply_ID);
            ConnectionNakladnaya.connection.Open();
            command.ExecuteNonQuery();
            ConnectionNakladnaya.connection.Close();
        }

        //public void spNakladnaya_update(TableConnection.ConnectionNakladnaya connection)
        //{
        //    execProc("Nakladnaya_update", new Dictionary<string, object> {
        //        { "ID_Nakladnaya",connection.ID_Nakladnaya},
        //        { "Number_Nakladnaya", connection.Number_Nakladnaya},
        //        { "Supply_ID", connection.Supply_ID}
        //    });
        //}
        public void spNakladnaya_update(string Number_Nakladnaya,
           Int32 ID_Nakladnaya, Int32 Supply_ID)
        {
            commandConfig("Nakladnaya_update");
            command.Parameters.AddWithValue("@ID_Nakladnaya", ID_Nakladnaya);
            command.Parameters.AddWithValue("@Number_Nakladnaya", Number_Nakladnaya);
            command.Parameters.AddWithValue("@Supply_ID", Supply_ID);
            ConnectionNakladnaya.connection.Open();
            command.ExecuteNonQuery();
            ConnectionNakladnaya.connection.Close();
        }
        //public void spNakladnaya_delete(int ID_Nakladnaya)
        //{
        //    execProc("Nakladnaya_delete", new Dictionary<string, object> {
        //        { "ID_Nakladnaya ", ID_Nakladnaya}

        //    });
        //}
        public void spNakladnaya_delete(int ID_Nakladnaya)
        {
            commandConfig("Nakladnaya_delete");
            command.Parameters.AddWithValue("@ID_Nakladnaya", ID_Nakladnaya);
            ConnectionNakladnaya.connection.Open();
            command.ExecuteNonQuery();
            ConnectionNakladnaya.connection.Close();
        }
        public List<ConnectionPosition> getPositionList()
        {
            List<ConnectionPosition> connectionPosition = new List<ConnectionPosition>();

            var reader = execProc("Position_select", null);

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    connectionPosition.Add(new ConnectionPosition(reader.GetInt32(0), reader.GetString(1), reader.GetString(2)));
                }
            }
            reader.Close();
            return connectionPosition;
        }
        public void spPosition_insert(TableConnection.ConnectionPosition connection)
        {
            execProc("Position_insert", new Dictionary<string, object> {
                { "Name_Position", connection.Name_Position},
                { "Salary", connection.Salary}
            });
        }
        public void spPosition_update(TableConnection.ConnectionPosition connection)
        {
            execProc("Position_update", new Dictionary<string, object> {
                { "ID_Position",connection.ID_Position},
                { "Name_Position", connection.Name_Position},
                { "Salary", connection.Salary}
            });
        }
        public void spPosition_delete(int ID_Position)
        {
            execProc("Position_delete", new Dictionary<string, object> {
                { "ID_Position ", ID_Position}

            });
        }

        public List<ConnectionSupplier> getSupplierList()
        {
            List<ConnectionSupplier> connectionSupplier = new List<ConnectionSupplier>();

            var reader = execProc("Supplier_select", null);

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    connectionSupplier.Add(new ConnectionSupplier(reader.GetInt32(0), reader.GetString(1)));
                }
            }
            reader.Close();
            return connectionSupplier;
        }
        public void spSupplier_insert(TableConnection.ConnectionSupplier connection)
        {
            execProc("Supplier_insert", new Dictionary<string, object> {
                { "Name_Organization", connection.Name_Organization}
            });
        }
        public void spSupplier_update(TableConnection.ConnectionSupplier connection)
        {
            execProc("Supplier_insert", new Dictionary<string, object> {
                {"ID_Supplier", connection.ID_Supplier},
                {"Name_Organization", connection.Name_Organization}
            });
        }
        public void spSupplier_delete(int ID_Supplier)
        {
            execProc("Supplier_delete", new Dictionary<string, object> {
                { "ID_Supplier ", ID_Supplier}

            });
        }

        public List<ConnectionSupply1> getSupplyList()
        {
            List<ConnectionSupply1> connectionSupply1 = new List<ConnectionSupply1>();

            var reader = execProc("Supply_select", null);

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    connectionSupply1.Add(new ConnectionSupply1(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), reader.GetInt32(3), reader.GetInt32(4), reader.GetInt32(5), reader.GetInt32(5)));
                }
            }
           reader.Close();
            return connectionSupply1;
        }
        public void spSupply_insert(string Date, 
            Int32 Ammount_Accepted_Weapon, Int32 Ammount_Accepted_Modifications, Int32 Ammount_Accepted_Ammo, Int32 Supplier_ID, Int32 Dogovor_ID)
        {
            //execProc("Supply_insert", new Dictionary<string, object> {
            //    { "Date", connection.Date} ,
            //    {"Ammount_Accepted_Weapon",connection.Ammount_Accepted_Weapon},
            //    {"Ammount_Accepted_Modifications",connection.Ammount_Accepted_Modifications},
            //    {"Ammount_Accepted_Ammo",connection.Ammount_Accepted_Ammo},
            //    {"Supplier_ID",connection.Supplier_ID},
            //    {"Dogovor_ID",connection.Dogovor_ID},
            //});
            commandConfig1("Supply_insert");
            command1.Parameters.AddWithValue("@Date",
                Date);
            command1.Parameters.AddWithValue("@Ammount_Accepted_Weapon",
                 Ammount_Accepted_Weapon);
            command1.Parameters.AddWithValue("@Ammount_Accepted_Modifications",
                 Ammount_Accepted_Modifications);
            command1.Parameters.AddWithValue("@Ammount_Accepted_Ammo",
                Ammount_Accepted_Ammo);
            command1.Parameters.AddWithValue("@Supplier_ID",
                  Supplier_ID);
            command1.Parameters.AddWithValue("@Dogovor_ID", Dogovor_ID);
            ConnectionSupply.connection.Open();
            command1.ExecuteNonQuery();
            ConnectionSupply.connection.Close();
        }
        public void spSupply_update(string Date,
            Int32 ID_Supply, Int32 Ammount_Accepted_Weapon, Int32 Ammount_Accepted_Modifications, Int32 Ammount_Accepted_Ammo, Int32 Supplier_ID, Int32 Dogovor_ID)
        {
            commandConfig1("Supply_update");
            command1.Parameters.AddWithValue("@ID_Supply",
                 ID_Supply);
            command1.Parameters.AddWithValue("@Date",
                 Date);
            command1.Parameters.AddWithValue("@Ammount_Accepted_Weapon",
                 Ammount_Accepted_Weapon);
            command1.Parameters.AddWithValue("@Ammount_Accepted_Modifications",
                 Ammount_Accepted_Modifications);
            command1.Parameters.AddWithValue("@Ammount_Accepted_Ammo",
                Ammount_Accepted_Ammo);
            command1.Parameters.AddWithValue("@Supplier_ID",
                  Supplier_ID);
            command1.Parameters.AddWithValue("@Dogovor_ID", Dogovor_ID);
            ConnectionSupply.connection.Open();
            command1.ExecuteNonQuery();
            ConnectionSupply.connection.Close();
        }
        public void spSupply_delete(int ID_Supply)
        {
            execProc("Supply_delete", new Dictionary<string, object> {
                { "ID_Supply", ID_Supply}
            });
        }

        public List<ConnectionType_Weapon> getType_WeaponList()
        {
            List<ConnectionType_Weapon> connectionType_Weapon = new List<ConnectionType_Weapon>();

            var reader = execProc("Type_Weapon_select", null);

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    connectionType_Weapon.Add(new ConnectionType_Weapon(reader.GetInt32(0), reader.GetString(1)));
                }
            }
            reader.Close();
            return connectionType_Weapon;
        }
        public void spType_Weapon_insert(TableConnection.ConnectionType_Weapon connection)
        {
            execProc("Type_Weapon_insert", new Dictionary<string, object> {
                { "Name_Type_Weapon", connection.Name_Type_Weapon}
            });
        }
        public void spType_Weapon_update(TableConnection.ConnectionType_Weapon connection)
        {
            execProc("Type_Weapon_update", new Dictionary<string, object> {
                {"ID_Type_Weapon", connection.ID_Type_Weapon},
                {"Name_Type_Weapon", connection.Name_Type_Weapon}
            });
        }
        public void spType_Weapon_delete(int ID_Type_Weapon)
        {
            execProc("Type_Weapon_delete", new Dictionary<string, object> {
                { "ID_Type_Weapon ", ID_Type_Weapon}

            });
        }


        public List<ConnectionRole> getRoleList(int idRole = -1)
        {
            List<ConnectionRole> connectionRole = new List<ConnectionRole>();

            Dictionary<string, Object> param = null;

            if (idRole >= 0)
            {
                param = new Dictionary<string, Object> { { "ID_ROLE", idRole } };
            }
            else
            {
                param = new Dictionary<string, Object> { { "ID_ROLE", "" } };
            }

            var reader = execProc("Role_select", param);

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    connectionRole.Add(new ConnectionRole(reader.GetInt32(0),
                        reader.GetString(1),
                        reader.GetInt32(2),
                        reader.GetInt32(3),
                        reader.GetInt32(4)));
                }
            }
            reader.Close();
            return connectionRole;
        }

        public void insertRole(TableConnection.ConnectionRole role)
        {
            execProc("Role_insert", new Dictionary<string, object> {
                {"Title_Role",role.Title_Role },
                {"Klient",role.Klient },
                {"Employee",role.Employee },
                {"Admin",role.Admin }
            });

        }

        public void deleteRole(int ID_Role)
        {
            execProc("Role_delete", new Dictionary<string, object> {
                { "ID_Role ", ID_Role }

            });
        }

        public void updateRole(TableConnection.ConnectionRole role)
        {
            execProc("Role_update", new Dictionary<string, object> {
                {"ID_Role ", role.ID_Role } ,
                {"Title_Role",role.Title_Role },
                 {"Klient",role.Klient },
                {"Employee",role.Employee },
                {"Admin",role.Admin }
            });

        }
    }
}
