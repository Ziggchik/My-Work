using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeaponStore.TableConnection
{
    class ConnectionAmmo
    {
        public int ID_Ammo { get; set; }
        public string Type_Ammo { get; set; }
        public int Ammount_Ammo { get; set; }
        public string Cost { get; set; }

        public ConnectionAmmo(int iD_Ammo, string type_Ammo, int ammount_Ammo, string cost)
        {
            ID_Ammo = iD_Ammo;
            Type_Ammo = type_Ammo;
            Ammount_Ammo = ammount_Ammo;
            Cost = cost;
        }
    }
}
