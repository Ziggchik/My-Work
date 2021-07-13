using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeaponStore.TableConnection
{
    class ConnectionSupplier
    {
        public int ID_Supplier { get; set; }
        public string Name_Organization { get; set; }

        public ConnectionSupplier(int iD_Supplier, string name_Organization)
        {
            ID_Supplier = iD_Supplier;
            Name_Organization = name_Organization;
        }
    }
}
