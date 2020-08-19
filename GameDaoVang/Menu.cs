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
    public partial class Menu : Form
    {
        public PaintEventArgs sKVe;
        public Menu()
        {
            InitializeComponent();
        }
        //Điểm xuất phát của chuột
        int diemBanDau = 0;
        private void Menu_Load(object sender, EventArgs e)
        {
            //Menu
            //Load hình của banner tương ứng với kích thước của form
            //this là lấy PT của hiện tại
            picMenu1.Height = this.Height / 3;
            picMenu2.Height = ((this.Height * 2) / 3);
            //Load hình lên Menu
            //Lấy đường dẫn
            String duongDanAnh = Application.StartupPath + @"\Image\Menu\";
            //Truyền hình cho mỗi phần
            picMenu1.Image = Image.FromFile(duongDanAnh + "menu1.jpg");
            picMenu2.Image = Image.FromFile(duongDanAnh + "menu2.jpg");
            //Cho ảnh canh giữa
            picMenu1.SizeMode = PictureBoxSizeMode.StretchImage;
            picMenu2.SizeMode = PictureBoxSizeMode.StretchImage;
            //Các button
            //Lấy chiều dài giữa form và trừ lại cho phần lòi của button
            int trucXButton = (this.Width / 2) - (btChoi.Width / 2);
            int trucYButton = (int)(this.Height / 3.5); //Lấy chiều cao bằng 3.5 của form
            //Set lại vị trí cho cái button khi load form
            btChoi.Location = new Point(trucXButton, trucYButton);
            //Mỗi cái button phải cách nhau 33 đơn vị
            int cachNhau = 33;
            btHuongDan.Location = new Point(trucXButton, trucYButton + cachNhau);
            cachNhau += 33;
            btThoat.Location = new Point(trucXButton, trucYButton + cachNhau);
            //Load ảnh cho mỗi cái menu
            btChoi.Image = Image.FromFile(duongDanAnh + "play.jpg");
            btHuongDan.Image = Image.FromFile(duongDanAnh + "play.jpg");
            btThoat.Image = Image.FromFile(duongDanAnh + "play.jpg");
            //Set chuột chạy trên menu kết hợp với timer
            picChuotChay.Parent = picMenu1;//Parent là cha con với các thuộc tính khác cha.parent = con;
            //Khởi tạo bảng tên
            picBangTen.Parent = picMenu1;
            //Lấy điểm xuất phát của chuột
            diemBanDau = this.Width; //set điểm ban đầu của chuột bằng độ rộng form
            //Set vị trí cho chuột đúng với vị trí trên form, -10 để nằm đều trên banner
            picChuotChay.Location = new Point(diemBanDau, trucYButton - 10);
        }
        private void chuotChay(int so)
        {
            String duongDanAnh = Application.StartupPath + @"\Image\Menu\";
            picChuotChay.Image = Image.FromFile(duongDanAnh + "chuotchay" + so + ".png");
            picChuotChay.SizeMode = PictureBoxSizeMode.StretchImage;
        }
        //Set thứ tự bằng 0
        int thuTu = 0;
        private void timerChuotChay_Tick(object sender, EventArgs e)
        {
            thuTu++;
            if (thuTu > 6) //nếu thứ tự hình lớn hơn 6 thì quay lại thứ tự hình 1
                thuTu = 1;  //có 6 hình chuột chạy
            chuotChay(thuTu);
            if (picChuotChay.Left <= -picChuotChay.Width)
                picChuotChay.Left = diemBanDau;
            picChuotChay.Left = picChuotChay.Left - 5;
        }
        //Button hướng dẫn người chơi
        private void btHuongDan_Click(object sender, EventArgs e)
        {
            this.Hide(); //Tạm thời ẩn form cũ
            //Tạo mới đối tượng
            HuongDanChoi hDC = new HuongDanChoi();
            hDC.ShowDialog(); //Câu lệnh hiển thị form mới tạo
            this.Close();
        }
        //Click nút thoát hoặc nút đỏ x để thoát game
        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //Đóng form menu
        private void Menu_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Không sử dụng được vì chuyển form sẽ vướng lại bảng câu hỏi form cũ
            //if (MessageBox.Show("Bạn chắc chắn muốn thoát ?", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            //{
            //    e.Cancel = true;
            //}
        }
        //Click vào nút chơi ngay
        private void btChoi_Click(object sender, EventArgs e)
        {
            MucTieu mT = new MucTieu();
            this.Hide();
            this.timerChuotChay.Dispose();
            mT.ShowDialog();
            this.Close();
        }
    }
}
