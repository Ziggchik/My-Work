using WeaponStore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using System.Windows.Forms.Integration;

namespace WeaponStore
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Process.Start(@"C:\Users\1\Desktop\Новый семестр-новые страдания\Курсовой\WeaponStore\bin\Debug\WeaponStore.exe");
        }
    }
}
