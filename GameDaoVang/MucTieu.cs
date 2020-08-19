using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace GameDaoVang
{
    public partial class MucTieu : Form
    {
        public MucTieu()
        {
            InitializeComponent();
        }
        //
        String mucTieu = "";
        String manSo = "";
        int a = 0;
        private void khoiTaoMSVaMT()
        {
            StreamReader manSoRead = new StreamReader("ManSo.txt");
            StreamReader mucTieuRead = new StreamReader("MucTieu.txt");
            manSo = manSoRead.ReadLine();
                int soThuTu = int.Parse(manSo);
                //Đọc tới dòng thứ manSo
                for (int i = 0; i < soThuTu; i++)
                {
                    mucTieu = mucTieuRead.ReadLine();
                }
                if (mucTieu == null)
                {
                    manSo = "0";
                    lbMucTieu.Text = "Win";
                    timerSangMan.Enabled = false;
                }
                else
                {
                    lbMucTieu.Text = mucTieu + "$";
                }
            manSoRead.Close();
            mucTieuRead.Close();
        }
        Boolean s = true;//Khởi tạo true trước, false khi người chơi thua.
        //Load form mục tiêu
        private void FormMucTieu_Load(object sender, EventArgs e)
        {
            khoiTaoMSVaMT();
        }
        //Thời gian hiển thị form này
        int tght = 0; 
        //Timer set thời gian sang màn
        private void timerSangMan_Tick(object sender, EventArgs e)
        {
            tght++;
            if (tght == 15 && s == false) //thua thì trở lại menu
            {
                this.Hide(); //Tạm thời ẩn form cũ
                Menu m = new Menu(); //Tạo mới đối tượng
                m.ShowDialog(); //Câu lệnh hiển thị menu.
                this.Close();//Đóng form.
            }
            else if (tght == 15) //sang màn sau
            {
                this.Hide(); //Tạm thời ẩn form cũ
                ManChoi mc = new ManChoi(); //Tạo mới đối tượng
                mc.ShowDialog(); //Câu lệnh hiển thị màn chơi tiếp theo.
                this.Close();//Đóng form.
            }
        }
        //Set điểm hiện tại bằng 0
        String diemHienTai = "0";
        //Đóng form mục tiêu
        private void MucTieu_FormClosed(object sender, FormClosedEventArgs e)
        {
            StreamWriter manSoWrite = new StreamWriter("ManSo.txt");
            manSoWrite.Flush();
            manSoWrite.WriteLine(1);
            manSoWrite.Close();
            //Trả về điểm 0
            luuDiemHienTai();
            //
            tght++;
            if (tght == 15 && s == false) //thua thì trở lại menu
            {
                this.Hide(); //Tạm thời ẩn form cũ
                Menu m = new Menu(); //Tạo mới đối tượng
                m.ShowDialog(); //Câu lệnh hiển thị menu.
                this.Close();//Đóng form.
            }
            else if (tght == 15) //sang màn sau
            {
                this.Hide(); //Tạm thời ẩn form cũ
                ManChoi mc = new ManChoi(); //Tạo mới đối tượng
                mc.ShowDialog(); //Câu lệnh hiển thị màn chơi tiếp theo.
                this.Close();//Đóng form.
            }
        }
        //Phương thức lưu điểm hiện tại
        private void luuDiemHienTai()
        {
            StreamWriter diemWriter = new StreamWriter("DiemHienTai.txt");
            diemWriter.Flush();
            diemWriter.WriteLine(diemHienTai);
            diemWriter.Close();
        }
    }
}
