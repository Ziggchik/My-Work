using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeaponStore.TableConnection
{
    class ConnectionWeapon
    {
        public int ID_Weapon { get; set; }
        public string Name_Weapon { get; set; }
        public string Accuracy { get; set; }
        public string Fire_Rate { get; set; }
        public string Shells_In_Store { get; set; }
        public int Ammount_Weapon { get; set; }
        public string Cost { get; set; }
        public int Type_Weapon_ID { get; set; }

        public ConnectionWeapon(int iD_Weapon, string name_Weapon, string accuracy, string fire_Rate, string shells_In_Store, int ammount_Weapon, string cost, int type_Weapon_ID)
        {
            ID_Weapon = iD_Weapon;
            Name_Weapon = name_Weapon;
            Accuracy = accuracy;
            Fire_Rate = fire_Rate;
            Shells_In_Store = shells_In_Store;
            Ammount_Weapon = ammount_Weapon;
            Cost = cost;
            Type_Weapon_ID = type_Weapon_ID;
        }
    }
}
