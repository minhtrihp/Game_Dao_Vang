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
    public partial class BanHang : Form
    {
        //Tạo đường dẫn ảnh bán hàng
        String duongDanAnh = Application.StartupPath + @"\Image\BanHang\";
        //Tạo biến cờ kiểm tra người chơi có mua hàng hay không
        Boolean daMua = false;
        //Tạo biến cờ kiểm tra người chơi có mua vật phẩm nào hay không
        public bool Phao = false;
        public bool co4La = false;
        public bool tangDa = false;
        public bool thuocSucManh = false;
        public BanHang()
        {
            InitializeComponent();
        }
        //Tạo các vật phẩm
        private void taoCacVatPham()
        {
            //Load hình các vật phẩm;
            picCoBonLa.Image = Image.FromFile(duongDanAnh + "Co4La.png");
            picPhao.Image = Image.FromFile(duongDanAnh + "Phao.png");
            picThuocSucManh.Image = Image.FromFile(duongDanAnh + "ThuocSucManh.png");
            picTangDa.Image = Image.FromFile(duongDanAnh + "TangGiaTriDa.png");
            //Canh chỉnh hình ảnh
            picCoBonLa.SizeMode = PictureBoxSizeMode.StretchImage;
            picPhao.SizeMode = PictureBoxSizeMode.AutoSize;
            picThuocSucManh.SizeMode = PictureBoxSizeMode.StretchImage;
            picTangDa.SizeMode = PictureBoxSizeMode.StretchImage;
        }
        //Tạo bàn mua
        private void taoBanMua()
        {
            //Load hình bàn mua
            picBanMua.Image = Image.FromFile(duongDanAnh + "BanMua.png");
            //
            //Canh chỉnh ảnh
            picBanMua.SizeMode = PictureBoxSizeMode.StretchImage;
        }
        //Tạo người bán
        private void nguoiBan(int so, String hanhDong)
        {
            //Load ảnh
            picNguoiBan.Image = Image.FromFile(duongDanAnh + hanhDong + so + ".png");
            //Chỉnh ảnh
            picNguoiBan.SizeMode = PictureBoxSizeMode.StretchImage;
            //Load ảnh
            picLoiNoi.Image = Image.FromFile(duongDanAnh + "NguoiBanNoi.png");
            //Canh chỉnh ảnh
            picLoiNoi.SizeMode = PictureBoxSizeMode.StretchImage;
        }
        //Load form bán hàng
        private void BanHang_Load(object sender, EventArgs e)
        {
            taoBanMua();//Load bàn mua
            taoCacVatPham();//Load các vật phẩm lên form
        }
        //Set thứ tự bằng 0
        int thuTu = 0;
        //Timer set chuyển hình động người bán
        private void timerNguoiBan_Tick(object sender, EventArgs e)
        {
            thuTu++;
            nguoiBan(thuTu, "ChuaBan");
            if (thuTu == 6) //nếu thứ tự hình bằng 6 thì quay lại thứ tự hình 1, có 6 hình người bán
                thuTu = 1;
        }
        //Sự kiện click button tiếp tục
        private void btTiepTuc_Click(object sender, EventArgs e)
        {
            this.Hide();
            chuyenMan();
            //Nếu không mua sẽ hiện form chủ giận trong thời gian ngắn
            if (daMua == false)
            {
                ChuGian chuGian = new ChuGian();
                chuGian.ShowDialog();
            }
            //Nếu mua sẽ chuyển sang form mục tiêu để sang màn chơi mới
            else
            {
                MucTieu mucTieu = new MucTieu();
                mucTieu.ShowDialog();
            }
            this.Close();
        }
        //Hình sẽ mờ đi khi chuột đang ở trên ảnh
        private void btTiepTuc_MouseHover(object sender, EventArgs e)
        {
            btTiepTuc.Image = Image.FromFile(duongDanAnh + "TiepTuc2.png");
        }
        //Hình sẽ trở lại bình thường khi chuột rời khỏi ảnh
        private void btTiepTuc_MouseLeave(object sender, EventArgs e)
        {
            btTiepTuc.Image = Image.FromFile(duongDanAnh + "TiepTuc1.png");
        }
        //Click chọn mua cỏ bốn lá
        private void picCoBonLa_Click(object sender, EventArgs e)
        {
            picCoBonLa.Hide();
            lbGia1.Hide();
            daMua = true; //Biến cờ để kiểm tra người chơi có mua hàng hay ko.
            co4La = true;
        }
        //Click chọn mua pháo
        private void picPhao_Click(object sender, EventArgs e)
        {
            picPhao.Hide();
            lbGia2.Hide();
            daMua = true;
            Phao = true;
        }
        //Click chọn mua thuốc sức mạnh
        private void picThuocSucManh_Click(object sender, EventArgs e)
        {
            picThuocSucManh.Hide();
            lbGia3.Hide();
            daMua = true;
            thuocSucManh = true;
        }
        //Click chọn mua sách tăng điểm đá
        private void picTangDa_Click(object sender, EventArgs e)
        {
            picTangDa.Hide();
            lbGia4.Hide();
            daMua = true;
            tangDa = true;
        }
        //Rê chuột đến hình cỏ bốn lá sẽ hiện dòng chức năng của cỏ 4 lá
        private void picCoBonLa_MouseEnter(object sender, EventArgs e)
        {
            String chucNang = "Tăng may mắn";
            lbLoiNoi.Text = chucNang;
        }
        //Rê chuột đến hình pháo sẽ hiện dòng chức năng của pháo
        private void picPhao_MouseEnter(object sender, EventArgs e)
        {
            String chucNang = "Nổ những thứ gắp mà không cần";
            lbLoiNoi.Text = chucNang;
        }
        //Rê chuột đến hình thuốc sức mạnh sẽ hiện dòng chức năng của thuốc sức mạnh
        private void picThuocSucManh_MouseEnter(object sender, EventArgs e)
        {
            String chucNang = "Tăng lực kéo";
            lbLoiNoi.Text = chucNang;
        }
        //Rê chuột đến hình sách tăng đá sẽ hiện dòng chức năng của sách tăng đá
        private void picTangDa_MouseEnter(object sender, EventArgs e)
        {
            String chucNang = "Tăng giá trị của đá";
            lbLoiNoi.Text = chucNang;
        }
        //Đọc ghi lại số màn trước khi chuyển sang màn mới
        private void chuyenMan()
        {
            int soMan = 0;
            //Đọc từ file text
            StreamReader soManRead = new StreamReader("ManSo.txt");
            soMan= int.Parse(soManRead.ReadLine());
            soManRead.Close();
            //Ghi vào file text
            StreamWriter manSoWrite = new StreamWriter("ManSo.txt");
            manSoWrite.Flush();
            manSoWrite.WriteLine(++soMan);
            manSoWrite.Close();
        }
        //Set điểm hiện tại bằng 0
        String diemHienTai = "0";
        //Đóng form bán hàng
        private void BanHang_FormClosed(object sender, FormClosedEventArgs e)
        {
            StreamWriter manSoWrite = new StreamWriter("ManSo.txt");
            manSoWrite.Flush();
            manSoWrite.WriteLine(1);
            manSoWrite.Close();
            //Trả về điểm 0
            diemHienTai = "0";
            luuDiemHienTai();
        }
        //Lưu điểm hiện tại
        private void luuDiemHienTai()
        {
            StreamWriter diemWriter = new StreamWriter("DiemHienTai.txt");
            diemWriter.Flush();
            diemWriter.WriteLine(diemHienTai);
            diemWriter.Close();
        }
    }
}
