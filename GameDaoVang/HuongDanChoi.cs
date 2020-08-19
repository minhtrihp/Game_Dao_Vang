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
    public partial class HuongDanChoi : Form
    {
        String duongDanAnh = Application.StartupPath + @"\Image\HuongDan\";
        public HuongDanChoi()
        {
            InitializeComponent();
        }
        //Click button back để quay về menu
        private void btBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            Menu menu = new Menu();
            menu.ShowDialog();
            this.Close();
        }
        //Rê chuột vào button quay về để màu button sậm hơn
        private void btBack_MouseHover_1(object sender, EventArgs e)
        {
            btBack.Image = Image.FromFile(duongDanAnh + "back2.png");
        }
        //Rời chuột khỏi button quay về để màu button sáng trở lại
        private void btBack_MouseLeave_1(object sender, EventArgs e)
        {
            btBack.Image = Image.FromFile(duongDanAnh + "back2.png");
            btBack.Image = Image.FromFile(duongDanAnh + "back1.png");
        }
    }
}
