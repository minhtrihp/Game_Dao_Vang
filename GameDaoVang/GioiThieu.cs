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
    public partial class GioiThieu : Form
    {
        String duongDanAnh = Application.StartupPath + @"\Image\GioiThieu\";
        public GioiThieu()
        {
            InitializeComponent();
        }
        //Tạo biến cho thanh loading và chuyển hình chuột chạy
        int soLoad = 0;
        int soThuTu = 0;
        //Timer set tốc độ loading
        private void timerLoading_Tick(object sender, EventArgs e)
        {
            //Load
            soLoad++;
            lbLoading.Text = "Loading " + soLoad + "%";
            //Chuột chạy
            soThuTu++;
            if (soThuTu > 6) //nếu thứ tự hình lớn hơn 6 thì quay lại thứ tự hình 1, có 6 hình chuột chạy
                soThuTu = 1; 
            picChuotChay.Left -= (lbLoading.Width - picChuotChay.Width) / 100;
            picChuotChay.Image = Image.FromFile(duongDanAnh + "chuot" + soThuTu + ".png");
            picChuotChay.SizeMode = PictureBoxSizeMode.StretchImage;
            //Load xong sẽ chuyển vào màn hình menu
            if (soLoad == 100)
            {
                Menu m = new Menu();
                this.Hide();
                m.ShowDialog();
                this.Close();
            }
        }
        //Load form giới thiệu
        private void GioiThieu_Load(object sender, EventArgs e)
        {
            //Set vị trí cho chuột chạy
            picChuotChay.Location = new Point(lbLoading.Location.X + lbLoading.Width - picChuotChay.Width, this.Height - 100);
        }
    }
}
