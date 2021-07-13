using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeaponStore.TableConnection
{
    class ConnectionType_Weapon
    {
        public int ID_Type_Weapon { get; set; }
        public string Name_Type_Weapon { get; set; }
        

        public ConnectionType_Weapon(int iD_Type_Weapon, string name_Type_Weapon)
        {
            ID_Type_Weapon = iD_Type_Weapon;
            Name_Type_Weapon = name_Type_Weapon;
        }
    }
}
