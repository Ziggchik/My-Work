using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeaponStore.TableConnection
{
    class ConnectionDogovor
    {
        public int ID_Dogovor { get; set; }
        public string Number_Dogovor { get; set; }

        public ConnectionDogovor(int iD_Dogovor, string number_Dogovor)
        {
            ID_Dogovor = iD_Dogovor;
            Number_Dogovor = number_Dogovor;
        }
    }
}
