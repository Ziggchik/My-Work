using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeaponStore.TableConnection
{
    class ConnectionWeaponDetail
    {
        public int ID_Weapon { get; set; }
        public string WeaponInfo { get; set; }
        public string Accuracy { get; set; }
        public string Fire_Rate { get; set; }
        public string Shells_In_Store { get; set; }
        public int Ammount_Weapon { get; set; }
        public string Cost { get; set; }
        public ConnectionWeaponDetail(int iD_Weapon, string weaponInfo, string accuracy, string fire_Rate, string shells_In_Store, int ammount_Weapon, string cost)
        {
            ID_Weapon = iD_Weapon;
            WeaponInfo = weaponInfo;
            Accuracy = accuracy;
            Fire_Rate = fire_Rate;
            Shells_In_Store = shells_In_Store;
            Ammount_Weapon = ammount_Weapon;
            Cost = cost;
        }
    }
}
