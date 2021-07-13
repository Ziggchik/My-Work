using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeaponStore.TableConnection;

namespace WeaponStore
{
    class Session
    {
        public static ConnectionAuthorization currentUser = null;
        public static MainWindow mainWindow = null;
        public static string baseDir = @"C:\Users\1\Desktop\";
    }
}
