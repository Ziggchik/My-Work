using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeaponStore.TableConnection
{
    class ConnectionLicense
    {
        public int ID_License { get; set; }
        public string License_Number { get; set; }

        public ConnectionLicense(int iD_License, string license_Number)
        {
            ID_License = iD_License;
            License_Number = license_Number;
        }
    }
}
