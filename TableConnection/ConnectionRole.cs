using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeaponStore.TableConnection
{
    class ConnectionRole
    {
        public int ID_Role { get; set; }
        public string Title_Role { get; set; }
        public int Klient { get; set; }
        public int Employee { get; set; }
        public int Admin { get; set; }

        public ConnectionRole(int iD_Role, string title_Role, int klient, int employee, int admin)
        {
            ID_Role = iD_Role;
            Title_Role = title_Role;
            Klient = klient;
            Employee = employee;
            Admin = admin; 
        }
    }
}
