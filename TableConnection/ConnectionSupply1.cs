using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeaponStore.TableConnection
{
    public class ConnectionSupply1
    {
        public int ID_Supply { get; set; }
        public string Date { get; set; }
        public int Ammount_Accepted_Weapon { get; set; }
        public int Ammount_Accepted_Modifications { get; set; }
        public int Ammount_Accepted_Ammo { get; set; }
        public int Supplier_ID { get; set; }
        public int Dogovor_ID { get; set; }

        public ConnectionSupply1(int iD_Supply, string date, int ammount_Accepted_Weapon, int ammount_Accepted_Modifications, int ammount_Accepted_Ammo, int supplier_ID, int dogovor_ID)
        {
            ID_Supply = iD_Supply;
            Date = date;
            Ammount_Accepted_Weapon = ammount_Accepted_Weapon;
            Ammount_Accepted_Modifications = ammount_Accepted_Modifications;
            Ammount_Accepted_Ammo = ammount_Accepted_Ammo;
            Supplier_ID = supplier_ID;
            Dogovor_ID = dogovor_ID;
        }
    }
}
