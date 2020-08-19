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
    public partial class ChuGian : Form
    {
        public ChuGian()
        {
            InitializeComponent();
        }
        //Tạo biến xét thời gian chạy của timer.
        int soLoad = 0;
        //Timer set thời gian chủ giận
        private void timerChuGian_Tick_1(object sender, EventArgs e)
        {
            //Load
            soLoad++;
            if (soLoad == 10)
            {
                this.Hide();
                ManChoi m = new ManChoi();
                m.ShowDialog();
                this.Close();
            }
        }
    }
}
