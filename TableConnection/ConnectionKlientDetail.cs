using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeaponStore.TableConnection
{
    class ConnectionKlientDetail
    {
        public int ID_Authorization { get; set; }
        public string KlientInfo { get; set; }
        public string NumberLicense { get; set; }
        public ConnectionKlientDetail (int iD_Authorization, string klientInfo, string numberLicense)
        {
            ID_Authorization = iD_Authorization;
            KlientInfo = klientInfo;
            NumberLicense = numberLicense;
        }
    }
}
