using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeaponStore.TableConnection
{
    class ConnectionPosition
    {
        public int ID_Position { get; set; }
        public string Name_Position { get; set; }
        public string Salary { get; set; }
        public ConnectionPosition(int iD_Position, string name_Position, string salary)
        {
            ID_Position = iD_Position;
            Name_Position = name_Position;
            Salary = salary;
        }
    }
}
