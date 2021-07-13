using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeaponStore.TableConnection
{
    public class ConnectionModifications
    {
        public int ID_Modification { get; set; }
        public string Name_Modification { get; set; }
        public int Ammount_Modifications { get; set; }
        public string Cost { get; set; }

        public ConnectionModifications(int iD_Modification, string name_Modification, int ammount_Modifications, string cost)
        {
            ID_Modification = iD_Modification;
            Name_Modification = name_Modification;
            Ammount_Modifications = ammount_Modifications;
            Cost = cost;
        }
    }
}
