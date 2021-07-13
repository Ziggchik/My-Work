using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeaponStore.TableConnection
{
    class ConnectionEmployee1
    {
        public int ID_Authorization { get; set; }
        public string First_Name_Employee { get; set; }
        public string Name_Employee { get; set; }
        public string Middle_Name_Employee { get; set; }
        public string Job_Experience { get; set; }
        public string Employment_Data { get; set; }
        public int Position_ID { get; set; }

        public ConnectionEmployee1(int iD_Authorization, string first_Name_Employee, string name_Employee, string middle_Name_Employee, string job_Experience, string employment_Data, int position_ID)
        {
            ID_Authorization = iD_Authorization;
            First_Name_Employee = first_Name_Employee;
            Name_Employee = name_Employee;
            Middle_Name_Employee = middle_Name_Employee;
            Job_Experience = job_Experience;
            Employment_Data = employment_Data;
            Position_ID = position_ID;
        }
    }
}
