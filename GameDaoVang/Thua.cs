using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameDaoVang
{
    public partial class Thua : Form
    {
        public Thua()
        {
            InitializeComponent();
        }

        int demThoiGianTat = 0;
        private void timerDemTat_Tick(object sender, EventArgs e)
        {
            demThoiGianTat++;
            if(demThoiGianTat == 3)
            {
                Menu m = new Menu();
                this.Hide();
                m.ShowDialog();
                timerDemTat.Enabled = false;
                this.Close();
            }
        }
    }
    

}
