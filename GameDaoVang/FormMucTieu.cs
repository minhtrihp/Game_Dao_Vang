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
    public partial class FormMucTieu : Form
    {
        public FormMucTieu()
        {
            InitializeComponent();
        }
        int mucTieu;
        int manSo = 1;
        String s = "THUA!!!!";
        private void xetMucTieu()
        {
            String m;
            switch (manSo)
            {
                case 1:
                    MucTieu = 650;
                    m = String.Format("{0}$", MucTieu);
                    lbMucTieu.Text = m;
                    break;
                case 2:
                    MucTieu = 1500;
                    m = String.Format("{0}$", MucTieu);
                    lbMucTieu.Text = m;
                    break;
                case 3:
                    MucTieu = 3000;
                    m = String.Format("{0}$", MucTieu);
                    lbMucTieu.Text = m;
                    break;
                default:
                    lbMucTieu.Text = s;
                    break;
            }
        }

        private void FormMucTieu_Load(object sender, EventArgs e)
        {
            xetMucTieu();
        }

        int tght = 0; //thời gian hiển thị form này.
        private void timerSangMan_Tick(object sender, EventArgs e)
        {

            tght++;
            if (tght == 18 && s == "THUA!!!!") //thua thì trở lại menu
            {
                this.Hide(); //Tạm thời ẩn form cũ
                Menu m = new Menu(); //Tạo mới đối tượng
                m.ShowDialog(); //Câu lệnh hiển thị menu.
                this.Close();//Đóng form.
            } 
            else if (tght == 18 && s != "THUA!!!!") //sang màn sau
            {
                this.Hide(); //Tạm thời ẩn form cũ
                ManChoi mc = new ManChoi(); //Tạo mới đối tượng
                mc.ShowDialog(); //Câu lệnh hiển thị màn chơi tiếp theo.
                this.Close();//Đóng form.
            }
            
        }

        public int ManSo
        {
            get
            {
                return manSo;
            }

            set
            {
                manSo = value;
            }
        }

        public int MucTieu
        {
            get
            {
                return mucTieu;
            }

            set
            {
                mucTieu = value;
            }
        }
    }

}
