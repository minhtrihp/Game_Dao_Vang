using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace GameDaoVang
{
    public partial class ManChoi : Form
    {
        //Tạo đường dẫn ảnh
        String duongDanAnh = Application.StartupPath + @"\Image\ManChoi\";
        public ManChoi()
        {
            InitializeComponent();
        }
        //Phương thức load màn chơi
        private void ManChoi_Load(object sender, EventArgs e)
        {
            khoiTaoPicManChoi();//Load các banner và content
            khoiTaoNhanVat();//Load các nhân vật
            khoiTaoCacCot();//Load bảng tính điểm và bảng level
            khoiTaoManChoi();
            khoiTaoCacButton();
            kiemTraVatPhamMua();
            anMenu();
            menuParent();
        }
        //Phương thức khởi tạo picManChoi
        private void khoiTaoPicManChoi()//Tạo banner và content của màn chơi
        {
            //Khởi tạo các biến số ngẫu nhiên
            Random rand = new Random();
            //Banner bằng 1/3 form
            picBanner.Height = this.Height / 3;
            //Content bằng 2/3 form
            picContent.Height = ((this.Height * 2) / 3) - 35; //Trừ 35 đơn vị cho task phía trên form
            //Lấy số ngẫu nhiên để tạo banner và content ngẫu nhiên
            int randBanner = rand.Next(1, 25); //Có 25 nền khác nhau
            int randContent = rand.Next(1, 6); //Có 6 đất khác nhau
            //Lấy đường dẫn ảnh banner
            picBanner.Image = Image.FromFile(duongDanAnh + "nen" + randBanner + ".jpg");
            //Lấy đường dẫn ảnh banner
            picContent.Image = Image.FromFile(duongDanAnh + "dat" + randContent + ".jpg");
            //Căn hình ảnh full
            picBanner.SizeMode = PictureBoxSizeMode.StretchImage;
            picContent.SizeMode = PictureBoxSizeMode.StretchImage;
        }
        int toaDoXNhanVat = 0; //Tạo nhân vật của màn chơi
        int toaDoYNhanVat = 0;
        int toaDoXMoc = 0;
        int toaDoYMoc = 0;
        //Phương thức khởi tạo nhân vật
        private void khoiTaoNhanVat()
        {
            picNhanVat.Parent = picBanner;//Ảnh nhân vật đè lên banner
            //Ảnh móc phải đè lên content
            picMoc.Parent = picContent;
            //Set size của móc
            picMoc.Size = new Size(30, 30);
            //Canh chỉnh tọa độ phù hợp nhân vật và móc
            toaDoXNhanVat = (this.Width / 2) - (picNhanVat.Width / 2); //Tọa độ X nằm giữa và trừ lại phần dư nhân vật
            //Tọa độ Y nằm trên content và trừ đi độ cao nhân vật và số lẻ
            toaDoYNhanVat = picBanner.Height - picNhanVat.Height - 2;//Theo tọa độ của picBanner
            //Tọa độ X nằm giữa và trừ lại phần dư móc
            toaDoXMoc = (this.Width / 2) - (picMoc.Width / 2) - 10;
            //Tọa độ Y nằm ngay dưới banner
            toaDoYMoc = 10;//Vì picMoc là cha của picContent cho nên phải theo tọa độ từ picContent
            picNhanVat.Location = new Point(toaDoXNhanVat, toaDoYNhanVat); //Set tọa độ nhân vật
            picMoc.Location = new Point(toaDoXMoc, toaDoYMoc); //Set tọa độ móc
            //Load hình ảnh của nhân vật và móc
            picNhanVat.Image = Image.FromFile(duongDanAnh + "NhanVatKhoiTao.png");
            picMoc.Image = Image.FromFile(duongDanAnh + "moc1.png");
            //Canh chỉnh hình ảnh
            picNhanVat.SizeMode = PictureBoxSizeMode.StretchImage;
            picMoc.SizeMode = PictureBoxSizeMode.StretchImage;
            diemXDayBanDau = diemXDayLucSau = toaDoXMoc + (picMoc.Height / 2);//Dây vào chính giữa móc
            diemYDayBanDau = 0;//Nằm ngay dưới content
            diemYDayLucSau = toaDoYMoc;//Nằm trên móc
            tempPicContent = new Bitmap(picContent.Image);//Tạo bản sao ảnh ban đầu
        }
        //Tạo các cộc mốc điểm, thời gian, mục tiêu
        String manSo = "";
        String mucTieu = "";
        String diemHienTai = "";
        //Phương thức khởi tạo các cột
        private void khoiTaoCacCot()
        {
            khoiTaoMSVaMT();
            layDiemHienTai();
            //Ảnh level và mục tiêu phải đè lên banner
            picLevel.Parent = picBanner;
            picMucTieu.Parent = picBanner;
            //Set size các cột
            int kichThuocCot = 80;
            picMucTieu.Size = new Size(kichThuocCot, kichThuocCot);
            picLevel.Size = new Size(kichThuocCot, kichThuocCot);
            //Canh chỉnh cách thước phù hợp của các bảng
            //Bảng level nằm trên góc trái
            int toaDoXLevel = 0;
            int toaDoYLevel = 0;
            int toaDoXMucTieu = (this.Width / 2) + (picNhanVat.Width / 2); //Bảng mục tiêu kế nhân vật
            int ToaDoYMucTieu = picBanner.Height - picMucTieu.Height - 2; //Bảng mục tiêu bằng với nhân vật
            //Set các tọa độ
            picLevel.Location = new Point(toaDoXLevel, toaDoYLevel);
            picMucTieu.Location = new Point(toaDoXMucTieu, ToaDoYMucTieu);
            //Load hình các bảng
            picLevel.Image = Image.FromFile(duongDanAnh + "CotTinhThoiGian.png");
            picMucTieu.Image = Image.FromFile(duongDanAnh + "CotTinhDiem.png");
            //Canh chỉnh các ảnh
            picLevel.SizeMode = PictureBoxSizeMode.StretchImage;
            picMucTieu.SizeMode = PictureBoxSizeMode.StretchImage;
            //Set label đếm thời gian
            lbThoiGian.Parent = picLevel;
            lbThoiGian.Location = new Point(10, picLevel.Height - lbThoiGian.Height - 5);
            lbThoiGian.Size = new Size(25, 25);
            //Set label mục tiêu
            lbMucTieu.Parent = picMucTieu;
            lbMucTieu.Location = new Point(0, 40);
            lbMucTieu.Size = new Size(picMucTieu.Width, 25);
            lbMucTieu.Text = mucTieu;
            //Set label điểm
            lbDiem.Parent = picMucTieu;
            lbDiem.Location = new Point(0, 10);
            lbDiem.Size = new Size(picMucTieu.Width, 25);
            lbDiem.Text = diemHienTai;
            //Giá trị cộng dồn đọc file ở đây
            giaTriCongDon = int.Parse(diemHienTai);
            //Set label level
            lbLevel.Parent = picLevel;
            lbLevel.Location = new Point(25, 17);
            lbLevel.Size = new Size(25, 25);
            lbLevel.Text = manSo;
            //Set pic pháo và label pháo
            picPhao.Parent = picBanner;
            int toaDoXPhao = (picBanner.Width / 2) - picNhanVat.Width;
            int toaDoYPhao = picBanner.Height - picPhao.Height;
            picPhao.Location = new Point(toaDoXPhao, toaDoYPhao);
            picPhao.Image = Image.FromFile(duongDanAnh + "Phao.png");
        }
        //Phương thức dùng để xoay ảnh
        //Góc quay số dương thì quay theo chiều kim đồng hồ
        //Góc quay số âm thì quay ngược chiều kim đồng hồ
        public static Image RotateImage(Image img, float rotationAngle)
        {
            //Tạo ảnh Bitmap mới, rỗng
            Bitmap bmp = new Bitmap(img.Width, img.Height);
            //Chuyển Bitmap thành Graphics object
            Graphics gfx = Graphics.FromImage(bmp);
            //Đặt điểm xoay nằm chính giữa ảnh móc
            gfx.TranslateTransform((float)bmp.Width / 2, (float)bmp.Height / 2);
            //Xoay ảnh
            gfx.RotateTransform(rotationAngle);
            gfx.TranslateTransform(-(float)bmp.Width / 2, -(float)bmp.Height / 2);
            //set the InterpolationMode to HighQualityBicubic so to ensure a high
            //quality image once it is transformed to the specified size
            gfx.InterpolationMode = InterpolationMode.HighQualityBicubic;
            //now draw our new image onto the graphics object
            gfx.DrawImage(img, new Point(0, 0));
            //dispose of our Graphics object: hủy Graphics object
            gfx.Dispose();
            //Trở về ảnh bitmap
            return bmp;
        }
        /*
         * tenVatPham: tên hình ảnh của loại vàng
         * thuTu: số thứ tự xuất hiện của vảng
         */
        int demDSTenVP = 0;
        //Phương thức khởi tạo nhiều loại vật phẩm
        private PictureBox khoiTaoNhieuLoai(String tenVatPham, int thuTu)
        {
            PictureBox vatPham = new PictureBox();
            //Tạo kích thước hình của vàng và kim cương
            int kichThuocVang = 0;
            int kichThuocKimCuong = 0;
            //Hình này là cha của content
            vatPham.Parent = picContent;
            //Canh chỉnh ảnh
            vatPham.SizeMode = PictureBoxSizeMode.StretchImage;
            //Chuyển back color của vàng sang trong suốt 
            vatPham.BackColor = System.Drawing.Color.Transparent;
            if (tenVatPham.Equals("VangVua"))
            {
                //Set kích thước
                kichThuocVang = this.Width / 20;//Kích thước của vàng loại vừa là bằng 1/20 chiều dài
                vatPham.Width = vatPham.Height = kichThuocVang; //Hình vuông
            }
            else if (tenVatPham.Equals("VangLon"))
            {
                //Kích thước của vàng loại vừa là bằng 1/16 chiều dài form có hình vuông;
                //Set kích thước
                kichThuocVang = this.Width / 16;
                vatPham.Width = vatPham.Height = kichThuocVang; //Hình vuông
            }
            else if (tenVatPham.Equals("VangSieuLon"))
            {
                //Kích thước của vàng loại vừa là bằng 1/12 chiều dài form có hình vuông;
                //Set kích thước
                kichThuocVang = this.Width / 12;
                vatPham.Width = vatPham.Height = kichThuocVang;//Hình vuông
            }
            else //Trường hợp kim cương
            {
                kichThuocKimCuong = this.Width / 25; //Bằng 1/25 chiều dài form
                vatPham.Width = vatPham.Height = kichThuocKimCuong;
            }
            //Load ảnh lên picture box
            vatPham.Image = Image.FromFile(duongDanAnh + tenVatPham + thuTu + ".png");
            return vatPham;
        }
        //Lưu danh sách tên vật phẩm
        String[] dSTenVatPham = new String[20];
        //Đây là PT load các vật phẩm lên form
        //tenVatPham: tên vật phẩm phải giống tên của ảnh
        private PictureBox khoiTao1Loai(String tenVatPham)
        {
            PictureBox vatPham = new PictureBox();
            int kichThuocVatPham = 0;
            vatPham.Parent = picContent;//Đè lên content
            vatPham.BackColor = System.Drawing.Color.Transparent;//Set màu trong suốt
            if (tenVatPham == "Da")
            {
                //Kích thước bằng với vàng lớn
                kichThuocVatPham = this.Width / 20;//Bằng 1/20 chiều dài form
                vatPham.Image = Image.FromFile(duongDanAnh + "Da.png");
                vatPham.Size = new Size(kichThuocVatPham, kichThuocVatPham);//Hinh vuông
            }
            else if (tenVatPham == "TuiNgauNhien")
            {
                //Kích thước bằng với vàng vừa
                kichThuocVatPham = this.Width / 16;//Bằng 1/16 chiều dài form
                vatPham.Image = Image.FromFile(duongDanAnh + "TuiNgauNhien.png");
                vatPham.Size = new Size(kichThuocVatPham, kichThuocVatPham);//Hinh vuông
                //Khởi tạo giá trị ngẫu nhiên cho túi
                Random rand = new Random();
                int giaTriNgauNhien = rand.Next(100, 501);

            }
            //Canh chỉnh hình ảnh
            vatPham.SizeMode = PictureBoxSizeMode.StretchImage;
            dSTenVatPham[demDSTenVP] = tenVatPham;
            demDSTenVP++;
            return vatPham;
        }
        //Phương thức tạo vàng ngẫu nhiên
        private PictureBox taoVangNgauNhien(int vatPhamNgauNhien)
        {
            PictureBox vatPham = new PictureBox();
            switch (vatPhamNgauNhien)
            {
                case 1:
                    vatPham = khoiTaoNhieuLoai("VangVua", 1);
                    dSTenVatPham[demDSTenVP] = "VangVua";
                    break;
                case 2:
                    vatPham = khoiTaoNhieuLoai("VangLon", 1);
                    dSTenVatPham[demDSTenVP] = "VangLon";
                    break;
                case 3:
                    vatPham = khoiTaoNhieuLoai("VangSieuLon", 1);
                    dSTenVatPham[demDSTenVP] = "VangSieuLon";
                    break;
            }
            demDSTenVP++;
            return vatPham;
        }
        //Phương thức tạo kim cương ngẫu nhiên
        private PictureBox taoKimCuongNgauNhien(int vatPhamNgauNhien)
        {
            PictureBox vatPham = new PictureBox();
            switch (vatPhamNgauNhien)
            {
                case 1:
                    vatPham = khoiTaoNhieuLoai("KimCuongXanh", 1);
                    dSTenVatPham[demDSTenVP] = "KimCuongXanh";
                    break;
                case 2:
                    vatPham = khoiTaoNhieuLoai("KimCuongLuc", 1);
                    dSTenVatPham[demDSTenVP] = "KimCuongLuc";
                    break;
                case 3:
                    vatPham = khoiTaoNhieuLoai("KimCuongHong", 1);
                    dSTenVatPham[demDSTenVP] = "KimCuongHong";
                    break;
            }
            demDSTenVP++;
            return vatPham;
        }
        //Lưu các picture box
        PictureBox[] cacVatPham = new PictureBox[20];
        int soLuongVatPham = 0;
        //PT khởi tạo 2 vật phẩm
        private void khoiTaoVatPham(String tenVP1, int soLuongVP1, String tenVP2, int soLuongVP2)
        {
            //Số lương vật phẩm tạo ra
            soLuongVatPham = soLuongVP1 + soLuongVP2;
            int soLuongKhung = 0;
            if (soLuongVatPham % 2 != 0) soLuongKhung = (soLuongVatPham / 2) + 1;
            else soLuongKhung = soLuongVatPham / 2;
            //Khởi tạo PT rand để lấy ngẫu nhiên các vật phẩm
            Random rand = new Random();
            int soNgauNhien = 0;
            //Tính kích thước khung chia vàng trên nền content
            int doDaiKhungChia = picContent.Width / soLuongKhung;
            int doCaoKhungChia = 0;
            int doDaiBanDau = 0;
            int doCaoBanDau = 0 + picMoc.Height;
            int doDaiLucSau = doDaiKhungChia - this.Height / 12;
            int doCaoLucSau = doCaoKhungChia;
            //
            int demKhung = 0;
            int demVatPham = 0;
            while (demKhung < soLuongKhung)
            {
                PictureBox vatPham = new PictureBox();
                if (demKhung == 1)
                {
                    doDaiBanDau += this.Height / 12;
                }
                //Mỗi lần load 2 vật phẩm
                int soLan = 0;
                //Vật phẩm số lẻ
                if (soLuongVatPham % 2 != 0 && demKhung == soLuongKhung - 1)
                {
                    bool vatPhamCon;
                    do
                    {
                        vatPhamCon = true;
                        soNgauNhien = rand.Next(1, 3);
                        if ((soNgauNhien == 1 && soLuongVP1 == 0)) vatPhamCon = false;
                        else if ((soNgauNhien == 2 && soLuongVP2 == 0)) vatPhamCon = false;
                    } while (vatPhamCon == false);
                    //Lấy vật phẩm ngẫu nhiên của vật phẩm nhiều loại
                    int vatPhamNgauNhien = rand.Next(1, 4);
                    switch (soNgauNhien)
                    {
                        case 1:
                            if (tenVP1.ToLower().Equals("vang") || tenVP1.ToLower().Equals("kimcuong"))
                            {
                                if (tenVP1.ToLower().Equals("vang"))
                                {
                                    //Chọn vật phẩm ngẫu nhiên
                                    vatPham = taoVangNgauNhien(vatPhamNgauNhien);
                                }
                                else
                                {
                                    //Chọn vật phẩm ngẫu nhiên
                                    vatPham = taoKimCuongNgauNhien(vatPhamNgauNhien);
                                }
                            }
                            else
                            {
                                vatPham = khoiTao1Loai(tenVP1);
                            }
                            break;
                        case 2:
                            if (tenVP2.ToLower().Equals("vang") || tenVP2.ToLower().Equals("kimcuong"))
                            {
                                if (tenVP2.ToLower().Equals("vang"))
                                {
                                    //Chọn vật phẩm ngẫu nhiên
                                    vatPham = taoVangNgauNhien(vatPhamNgauNhien);
                                }
                                else
                                {
                                    //Chọn vật phẩm ngẫu nhiên
                                    vatPham = taoKimCuongNgauNhien(vatPhamNgauNhien);
                                }
                            }
                            else
                            {
                                vatPham = khoiTao1Loai(tenVP2);
                            }
                            break;
                    }
                    cacVatPham[demVatPham] = vatPham;//Lấy vật phẩm trong danh sách các vật phẩm
                    demVatPham++;
                    int chieuCaoVatPham = vatPham.Height;
                    doCaoKhungChia = picContent.Height - chieuCaoVatPham;
                    //Tính vị trí và tọa độ các vật phẩm
                    int toaDoXVatPham = rand.Next(doDaiBanDau, doDaiLucSau);
                    int toaDoYVatPham = rand.Next(doCaoBanDau, doCaoKhungChia);
                    vatPham.Location = new Point(toaDoXVatPham, toaDoYVatPham);
                    demKhung++;
                }
                else
                {
                    PictureBox vatPhamTruoc = new PictureBox();
                    while (soLan < 2)
                    {
                        bool vatPhamCon;
                        do
                        {
                            vatPhamCon = true;
                            soNgauNhien = rand.Next(1, 3);
                            if ((soNgauNhien == 1 && soLuongVP1 == 0)) vatPhamCon = false;
                            else if ((soNgauNhien == 2 && soLuongVP2 == 0)) vatPhamCon = false;
                        } while (vatPhamCon == false);
                        //Lấy vật phẩm ngẫu nhiên của vật phẩm nhiều loại
                        int vatPhamNgauNhien = rand.Next(1, 4);
                        switch (soNgauNhien)
                        {
                            case 1:
                                if (tenVP1.ToLower().Equals("vang") || tenVP1.ToLower().Equals("kimcuong"))
                                {
                                    if (tenVP1.ToLower().Equals("vang"))
                                    {
                                        //Chọn vật phẩm ngẫu nhiên
                                        vatPham = taoVangNgauNhien(vatPhamNgauNhien);
                                    }
                                    else
                                    {
                                        //Chọn vật phẩm ngẫu nhiên
                                        vatPham = taoKimCuongNgauNhien(vatPhamNgauNhien);
                                    }
                                }
                                else
                                {
                                    vatPham = khoiTao1Loai(tenVP1);
                                }
                                break;
                            case 2:
                                if (tenVP2.ToLower().Equals("vang") || tenVP2.ToLower().Equals("kimcuong"))
                                {
                                    if (tenVP2.ToLower().Equals("vang"))
                                    {
                                        //Chọn vật phẩm ngẫu nhiên
                                        vatPham = taoVangNgauNhien(vatPhamNgauNhien);
                                    }
                                    else
                                    {
                                        //Chọn vật phẩm ngẫu nhiên
                                        vatPham = taoKimCuongNgauNhien(vatPhamNgauNhien);
                                    }
                                }
                                else
                                {
                                    vatPham = khoiTao1Loai(tenVP2);
                                }
                                break;
                        }
                        int chieuCaoVatPham = vatPham.Height;
                        doCaoKhungChia = picContent.Height - chieuCaoVatPham;
                        //Tính vị trí và tọa độ các vật phẩm
                        int toaDoXVatPham = rand.Next(doDaiBanDau, doDaiLucSau);
                        int toaDoYVatPham = rand.Next(doCaoBanDau, doCaoKhungChia);
                        vatPham.Location = new Point(toaDoXVatPham, toaDoYVatPham);
                        //Xét số lần xuất hiện của vật phẩm
                        if (soLan < 1)
                        {
                            if (soNgauNhien == 1)
                                soLuongVP1--;
                            else
                                soLuongVP2--;
                            vatPhamTruoc.Location = new Point(toaDoXVatPham, toaDoYVatPham);
                            cacVatPham[demVatPham] = vatPham;
                            demVatPham++;
                        }
                        //Xét số lần xuất hiện của vật phẩm
                        if (soLan == 1)
                        {
                            toaDoXVatPham = rand.Next(doDaiBanDau, doDaiLucSau);
                            toaDoYVatPham = rand.Next(doCaoBanDau, doCaoKhungChia);
                            vatPham.Location = new Point(toaDoXVatPham, toaDoYVatPham);
                            //PT kiểm tra 2 picture box đụng nhau
                            if (vatPham.Bounds.IntersectsWith(new Rectangle(vatPhamTruoc.Location, vatPhamTruoc.Size)))
                            {
                                demDSTenVP--;
                                vatPham.Dispose();//Xoá vật phẩm hiện tại
                                soLan--;
                            }
                        }
                        soLan++;
                        //Xét số lần xuất hiện của vật phẩm
                        if (soLan > 1)
                        {
                            vatPhamTruoc.Dispose();
                            //Trừ các vật phẩm đã tạo
                            if (soNgauNhien == 1)
                                soLuongVP1--;
                            else
                                soLuongVP2--;
                            cacVatPham[demVatPham] = vatPham;
                            demVatPham++;
                        }
                    }
                    demKhung++;
                    doDaiBanDau += doDaiKhungChia;
                    doDaiLucSau += doDaiKhungChia;
                }
            }
        }
        //PT khởi tạo 3 vật phẩm
        private void khoiTaoVatPham(String tenVP1, int soLuongVP1, String tenVP2, int soLuongVP2,
                                    String tenVP3, int soLuongVP3)
        {
            soLuongVatPham = soLuongVP1 + soLuongVP2 + soLuongVP3;
            int soLuongKhung = 0;
            if (soLuongVatPham % 2 != 0) soLuongKhung = (soLuongVatPham / 2) + 1;
            else soLuongKhung = soLuongVatPham / 2;
            //Khởi tạo PT rand để lấy ngẫu nhiên các vật phẩm
            Random rand = new Random();
            int soNgauNhien = 0;
            //Tính kích thước khung chia vàng trên nền content
            int doDaiKhungChia = picContent.Width / soLuongKhung;
            int doCaoKhungChia = 0;
            int doDaiBanDau = 0;
            int doCaoBanDau = 0 + picMoc.Height;
            int doDaiLucSau = doDaiKhungChia - this.Height / 12;
            int doCaoLucSau = doCaoKhungChia;
            //
            int demKhung = 0;
            int demVatPham = 0;
            while (demKhung < soLuongKhung)
            {
                PictureBox vatPham = new PictureBox();
                if (demKhung == 1)
                {
                    doDaiBanDau += this.Height / 12;
                }
                //Mỗi lần load 2 vật phẩm
                int soLan = 0;
                //Vật phẩm số lẻ
                if (soLuongVatPham % 2 != 0 && demKhung == soLuongKhung - 1)
                {
                    bool vatPhamCon;
                    do
                    {
                        vatPhamCon = true;
                        soNgauNhien = rand.Next(1, 4); //3 vật phẩm
                        if ((soNgauNhien == 1 && soLuongVP1 == 0))
                            vatPhamCon = false;
                        else if ((soNgauNhien == 2 && soLuongVP2 == 0))
                            vatPhamCon = false;
                        else if ((soNgauNhien == 3 && soLuongVP3 == 0))
                            vatPhamCon = false;
                    } while (vatPhamCon == false);
                    //Lấy vật phẩm ngẫu nhiên của vật phẩm nhiều loại
                    int vatPhamNgauNhien = rand.Next(1, 4);
                    switch (soNgauNhien)
                    {
                        case 1:
                            if (tenVP1.ToLower().Equals("vang") || tenVP1.ToLower().Equals("kimcuong"))
                            {
                                if (tenVP1.ToLower().Equals("vang"))
                                {
                                    //Chọn vật phẩm ngẫu nhiên
                                    vatPham = taoVangNgauNhien(vatPhamNgauNhien);
                                }
                                else
                                {
                                    //Chọn vật phẩm ngẫu nhiên
                                    vatPham = taoKimCuongNgauNhien(vatPhamNgauNhien);
                                }
                            }
                            else
                            {
                                vatPham = khoiTao1Loai(tenVP1);
                            }
                            break;
                        case 2:
                            if (tenVP2.ToLower().Equals("vang") || tenVP2.ToLower().Equals("kimcuong"))
                            {
                                if (tenVP2.ToLower().Equals("vang"))
                                {
                                    //Chọn vật phẩm ngẫu nhiên
                                    vatPham = taoVangNgauNhien(vatPhamNgauNhien);
                                }
                                else
                                {
                                    //Chọn vật phẩm ngẫu nhiên
                                    vatPham = taoKimCuongNgauNhien(vatPhamNgauNhien);
                                }
                            }
                            else
                            {
                                vatPham = khoiTao1Loai(tenVP2);
                            }
                            break;
                        case 3:
                            if (tenVP3.ToLower().Equals("vang") || tenVP3.ToLower().Equals("kimcuong"))
                            {
                                if (tenVP3.ToLower().Equals("vang"))
                                {
                                    //Chọn vật phẩm ngẫu nhiên
                                    vatPham = taoVangNgauNhien(vatPhamNgauNhien);
                                }
                                else
                                {
                                    //Chọn vật phẩm ngẫu nhiên
                                    vatPham = taoKimCuongNgauNhien(vatPhamNgauNhien);
                                }
                            }
                            else
                            {
                                vatPham = khoiTao1Loai(tenVP3);
                            }
                            break;
                    }
                    cacVatPham[demVatPham] = vatPham;//Lấy vật phẩm trong danh sách các vật phẩm
                    demVatPham++;
                    int chieuCaoVatPham = vatPham.Height;
                    doCaoKhungChia = picContent.Height - chieuCaoVatPham;
                    //Tính vị trí và tọa độ các vật phẩm
                    int toaDoXVatPham = rand.Next(doDaiBanDau, doDaiLucSau);
                    int toaDoYVatPham = rand.Next(doCaoBanDau, doCaoKhungChia);
                    vatPham.Location = new Point(toaDoXVatPham, toaDoYVatPham);
                    demKhung++;
                }
                else
                {
                    PictureBox vatPhamTruoc = new PictureBox();
                    while (soLan < 2)
                    {
                        bool vatPhamCon;
                        do
                        {
                            vatPhamCon = true;
                            soNgauNhien = rand.Next(1, 4);//3 vật phẩm
                            if ((soNgauNhien == 1 && soLuongVP1 == 0)) vatPhamCon = false;
                            else if ((soNgauNhien == 2 && soLuongVP2 == 0)) vatPhamCon = false;
                            else if ((soNgauNhien == 3 && soLuongVP3 == 0)) vatPhamCon = false;
                        } while (vatPhamCon == false);
                        //Lấy vật phẩm ngẫu nhiên của vật phẩm nhiều loại
                        int vatPhamNgauNhien = rand.Next(1, 4);
                        switch (soNgauNhien)
                        {
                            case 1:
                                if (tenVP1.ToLower().Equals("vang") || tenVP1.ToLower().Equals("kimcuong"))
                                {
                                    if (tenVP1.ToLower().Equals("vang"))
                                    {
                                        //Chọn vật phẩm ngẫu nhiên
                                        vatPham = taoVangNgauNhien(vatPhamNgauNhien);
                                    }
                                    else
                                    {
                                        //Chọn vật phẩm ngẫu nhiên
                                        vatPham = taoKimCuongNgauNhien(vatPhamNgauNhien);
                                    }
                                }
                                else
                                {
                                    vatPham = khoiTao1Loai(tenVP1);
                                }
                                break;
                            case 2:
                                if (tenVP2.ToLower().Equals("vang") || tenVP2.ToLower().Equals("kimcuong"))
                                {
                                    if (tenVP2.ToLower().Equals("vang"))
                                    {
                                        //Chọn vật phẩm ngẫu nhiên
                                        vatPham = taoVangNgauNhien(vatPhamNgauNhien);
                                    }
                                    else
                                    {
                                        //Chọn vật phẩm ngẫu nhiên
                                        vatPham = taoKimCuongNgauNhien(vatPhamNgauNhien);
                                    }
                                }
                                else
                                {
                                    vatPham = khoiTao1Loai(tenVP2);
                                }
                                break;
                            case 3:
                                if (tenVP3.ToLower().Equals("vang") || tenVP3.ToLower().Equals("kimcuong"))
                                {
                                    if (tenVP3.ToLower().Equals("vang"))
                                    {
                                        //Chọn vật phẩm ngẫu nhiên
                                        vatPham = taoVangNgauNhien(vatPhamNgauNhien);
                                    }
                                    else
                                    {
                                        //Chọn vật phẩm ngẫu nhiên
                                        vatPham = taoKimCuongNgauNhien(vatPhamNgauNhien);
                                    }
                                }
                                else
                                {
                                    vatPham = khoiTao1Loai(tenVP3);
                                }
                                break;
                        }
                        int chieuCaoVatPham = vatPham.Height;
                        doCaoKhungChia = picContent.Height - chieuCaoVatPham;
                        //Tính vị trí và tọa độ các vật phẩm
                        int toaDoXVatPham = rand.Next(doDaiBanDau, doDaiLucSau);
                        int toaDoYVatPham = rand.Next(doCaoBanDau, doCaoKhungChia);
                        vatPham.Location = new Point(toaDoXVatPham, toaDoYVatPham);
                        //Xét số lần xuất hiện của vật phẩm
                        if (soLan < 1)
                        {
                            if (soNgauNhien == 1) soLuongVP1--;
                            else if (soNgauNhien == 2) soLuongVP2--;
                            else soLuongVP3--;
                            vatPhamTruoc.Location = new Point(toaDoXVatPham, toaDoYVatPham);
                            cacVatPham[demVatPham] = vatPham;
                            demVatPham++;
                        }
                        //Xét số lần xuất hiện của vật phẩm
                        if (soLan == 1)
                        {
                            toaDoXVatPham = rand.Next(doDaiBanDau, doDaiLucSau);
                            toaDoYVatPham = rand.Next(doCaoBanDau, doCaoKhungChia);
                            vatPham.Location = new Point(toaDoXVatPham, toaDoYVatPham);
                            //PT kiểm tra 2 picture box đụng nhau
                            if (vatPham.Bounds.IntersectsWith(new Rectangle(vatPhamTruoc.Location, vatPhamTruoc.Size)))
                            {
                                demDSTenVP--;
                                vatPham.Dispose();//Xoá vật phẩm hiện tại
                                soLan--;
                            }
                        }
                        soLan++;
                        //Xét số lần xuất hiện của vật phẩm
                        if (soLan > 1)
                        {
                            vatPhamTruoc.Dispose();
                            //Trừ các vật phẩm đã tạo
                            if (soNgauNhien == 1)
                                soLuongVP1--;
                            else if (soNgauNhien == 2)
                                soLuongVP2--;
                            else
                                soLuongVP3--;
                            cacVatPham[demVatPham] = vatPham;
                            demVatPham++;
                        }
                    }
                    demKhung++;
                    doDaiBanDau += doDaiKhungChia;
                    doDaiLucSau += doDaiKhungChia;
                }
            }
        }
        //PT khởi tạo 4 vật phẩm
        private void khoiTaoVatPham(String tenVP1, int soLuongVP1, String tenVP2, int soLuongVP2,
                                    String tenVP3, int soLuongVP3, String tenVP4, int soLuongVP4)
        {
            soLuongVatPham = soLuongVP1 + soLuongVP2 + soLuongVP3 + soLuongVP4;
            int soLuongKhung = 0;
            if (soLuongVatPham % 2 != 0) soLuongKhung = (soLuongVatPham / 2) + 1;
            else soLuongKhung = soLuongVatPham / 2;
            //Khởi tạo PT rand để lấy ngẫu nhiên các vật phẩm
            Random rand = new Random();
            int soNgauNhien = 0;
            //Tính kích thước khung chia vàng trên nền content
            int doDaiKhungChia = picContent.Width / soLuongKhung;
            int doCaoKhungChia = 0;
            int doDaiBanDau = 0;
            int doCaoBanDau = 0 + picMoc.Height;
            int doDaiLucSau = doDaiKhungChia - this.Height / 12;
            int doCaoLucSau = doCaoKhungChia;
            //
            int demKhung = 0;
            int demVatPham = 0;
            while (demKhung < soLuongKhung)
            {
                PictureBox vatPham = new PictureBox();
                if (demKhung == 1)
                {
                    doDaiBanDau += this.Height / 12;
                }
                //Mỗi lần load 2 vật phẩm
                int soLan = 0;
                //Vật phẩm số lẻ
                if (soLuongVatPham % 2 != 0 && demKhung == soLuongKhung - 1)
                {
                    bool vatPhamCon;
                    do
                    {
                        vatPhamCon = true;
                        soNgauNhien = rand.Next(1, 5);//4 vật phẩm
                        if ((soNgauNhien == 1 && soLuongVP1 == 0))
                            vatPhamCon = false;
                        else if ((soNgauNhien == 2 && soLuongVP2 == 0))
                            vatPhamCon = false;
                        else if ((soNgauNhien == 3 && soLuongVP3 == 0))
                            vatPhamCon = false;
                        else if ((soNgauNhien == 4 && soLuongVP4 == 0))
                            vatPhamCon = false;
                    } while (vatPhamCon == false);
                    //Lấy vật phẩm ngẫu nhiên của vật phẩm nhiều loại
                    int vatPhamNgauNhien = rand.Next(1, 4);
                    switch (soNgauNhien)
                    {
                        case 1:
                            if (tenVP1.ToLower().Equals("vang") || tenVP1.ToLower().Equals("kimcuong"))
                            {
                                if (tenVP1.ToLower().Equals("vang"))
                                {
                                    //Chọn vật phẩm ngẫu nhiên
                                    vatPham = taoVangNgauNhien(vatPhamNgauNhien);
                                }
                                else
                                {
                                    //Chọn vật phẩm ngẫu nhiên
                                    vatPham = taoKimCuongNgauNhien(vatPhamNgauNhien);
                                }
                            }
                            else
                            {
                                vatPham = khoiTao1Loai(tenVP1);
                            }
                            break;
                        case 2:
                            if (tenVP2.ToLower().Equals("vang") || tenVP2.ToLower().Equals("kimcuong"))
                            {
                                if (tenVP2.ToLower().Equals("vang"))
                                {
                                    //Chọn vật phẩm ngẫu nhiên
                                    vatPham = taoVangNgauNhien(vatPhamNgauNhien);
                                }
                                else
                                {
                                    //Chọn vật phẩm ngẫu nhiên
                                    vatPham = taoKimCuongNgauNhien(vatPhamNgauNhien);
                                }
                            }
                            else
                            {
                                vatPham = khoiTao1Loai(tenVP2);
                            }
                            break;
                        case 3:
                            if (tenVP3.ToLower().Equals("vang") || tenVP3.ToLower().Equals("kimcuong"))
                            {
                                if (tenVP3.ToLower().Equals("vang"))
                                {
                                    //Chọn vật phẩm ngẫu nhiên
                                    vatPham = taoVangNgauNhien(vatPhamNgauNhien);
                                }
                                else
                                {
                                    //Chọn vật phẩm ngẫu nhiên
                                    vatPham = taoKimCuongNgauNhien(vatPhamNgauNhien);
                                }
                            }
                            else
                            {
                                vatPham = khoiTao1Loai(tenVP3);
                            }
                            break;
                        case 4:
                            if (tenVP4.ToLower().Equals("vang") || tenVP4.ToLower().Equals("kimcuong"))
                            {
                                if (tenVP4.ToLower().Equals("vang"))
                                {
                                    //Chọn vật phẩm ngẫu nhiên
                                    vatPham = taoVangNgauNhien(vatPhamNgauNhien);
                                }
                                else
                                {
                                    //Chọn vật phẩm ngẫu nhiên
                                    vatPham = taoKimCuongNgauNhien(vatPhamNgauNhien);
                                }
                            }
                            else
                            {
                                vatPham = khoiTao1Loai(tenVP4);
                            }
                            break;
                    }
                    cacVatPham[demVatPham] = vatPham;//Lấy vật phẩm trong danh sách các vật phẩm
                    demVatPham++;
                    int chieuCaoVatPham = vatPham.Height;
                    doCaoKhungChia = picContent.Height - chieuCaoVatPham;
                    //Tính vị trí và tọa độ các vật phẩm
                    int toaDoXVatPham = rand.Next(doDaiBanDau, doDaiLucSau);
                    int toaDoYVatPham = rand.Next(doCaoBanDau, doCaoKhungChia);
                    vatPham.Location = new Point(toaDoXVatPham, toaDoYVatPham);
                    demKhung++;
                }
                else
                {
                    PictureBox vatPhamTruoc = new PictureBox();
                    while (soLan < 2)
                    {
                        bool vatPhamCon;
                        do
                        {
                            vatPhamCon = true;
                            soNgauNhien = rand.Next(1, 5);//4 vật phẩm
                            if ((soNgauNhien == 1 && soLuongVP1 == 0)) vatPhamCon = false;
                            else if ((soNgauNhien == 2 && soLuongVP2 == 0)) vatPhamCon = false;
                            else if ((soNgauNhien == 3 && soLuongVP3 == 0)) vatPhamCon = false;
                            else if ((soNgauNhien == 4 && soLuongVP4 == 0)) vatPhamCon = false;
                        } while (vatPhamCon == false);
                        //Lấy vật phẩm ngẫu nhiên của vật phẩm nhiều loại
                        int vatPhamNgauNhien = rand.Next(1, 4);
                        switch (soNgauNhien)
                        {
                            case 1:
                                if (tenVP1.ToLower().Equals("vang") || tenVP1.ToLower().Equals("kimcuong"))
                                {
                                    if (tenVP1.ToLower().Equals("vang"))
                                    {
                                        //Chọn vật phẩm ngẫu nhiên
                                        vatPham = taoVangNgauNhien(vatPhamNgauNhien);
                                    }
                                    else
                                    {
                                        //Chọn vật phẩm ngẫu nhiên
                                        vatPham = taoKimCuongNgauNhien(vatPhamNgauNhien);
                                    }
                                }
                                else
                                {
                                    vatPham = khoiTao1Loai(tenVP1);
                                }
                                break;
                            case 2:
                                if (tenVP2.ToLower().Equals("vang") || tenVP2.ToLower().Equals("kimcuong"))
                                {
                                    if (tenVP2.ToLower().Equals("vang"))
                                    {
                                        //Chọn vật phẩm ngẫu nhiên
                                        vatPham = taoVangNgauNhien(vatPhamNgauNhien);
                                    }
                                    else
                                    {
                                        //Chọn vật phẩm ngẫu nhiên
                                        vatPham = taoKimCuongNgauNhien(vatPhamNgauNhien);
                                    }
                                }
                                else
                                {
                                    vatPham = khoiTao1Loai(tenVP2);
                                }
                                break;
                            case 3:
                                if (tenVP3.ToLower().Equals("vang") || tenVP3.ToLower().Equals("kimcuong"))
                                {
                                    if (tenVP3.ToLower().Equals("vang"))
                                    {
                                        //Chọn vật phẩm ngẫu nhiên
                                        vatPham = taoVangNgauNhien(vatPhamNgauNhien);
                                    }
                                    else
                                    {
                                        //Chọn vật phẩm ngẫu nhiên
                                        vatPham = taoKimCuongNgauNhien(vatPhamNgauNhien);
                                    }
                                }
                                else
                                {
                                    vatPham = khoiTao1Loai(tenVP3);
                                }
                                break;
                            case 4:
                                if (tenVP4.ToLower().Equals("vang") || tenVP4.ToLower().Equals("kimcuong"))
                                {
                                    if (tenVP4.ToLower().Equals("vang"))
                                    {
                                        //Chọn vật phẩm ngẫu nhiên
                                        vatPham = taoVangNgauNhien(vatPhamNgauNhien);
                                    }
                                    else
                                    {
                                        //Chọn vật phẩm ngẫu nhiên
                                        vatPham = taoKimCuongNgauNhien(vatPhamNgauNhien);
                                    }
                                }
                                else
                                {
                                    vatPham = khoiTao1Loai(tenVP4);
                                }
                                break;
                        }
                        int chieuCaoVatPham = vatPham.Height;
                        doCaoKhungChia = picContent.Height - chieuCaoVatPham;
                        //Tính vị trí và tọa độ các vật phẩm
                        int toaDoXVatPham = rand.Next(doDaiBanDau, doDaiLucSau);
                        int toaDoYVatPham = rand.Next(doCaoBanDau, doCaoKhungChia);
                        vatPham.Location = new Point(toaDoXVatPham, toaDoYVatPham);
                        //Xét số lần xuất hiện của vật phẩm
                        if (soLan < 1)
                        {
                            if (soNgauNhien == 1)
                                soLuongVP1--;
                            else if (soNgauNhien == 2)
                                soLuongVP2--;
                            else if (soNgauNhien == 3)
                                soLuongVP3--;
                            else
                                soLuongVP4--;
                            vatPhamTruoc.Location = new Point(toaDoXVatPham, toaDoYVatPham);
                            cacVatPham[demVatPham] = vatPham;
                            demVatPham++;
                        }
                        //Xét số lần xuất hiện của vật phẩm
                        if (soLan == 1)
                        {
                            toaDoXVatPham = rand.Next(doDaiBanDau, doDaiLucSau);
                            toaDoYVatPham = rand.Next(doCaoBanDau, doCaoKhungChia);
                            vatPham.Location = new Point(toaDoXVatPham, toaDoYVatPham);
                            //PT kiểm tra 2 picture box đụng nhau
                            if (vatPham.Bounds.IntersectsWith(new Rectangle(vatPhamTruoc.Location, vatPhamTruoc.Size)))
                            {
                                demDSTenVP--;
                                vatPham.Dispose();//Xoá vật phẩm hiện tại
                                soLan--;
                            }
                        }
                        soLan++;
                        //Xét số lần xuất hiện của vật phẩm
                        if (soLan > 1)
                        {
                            vatPhamTruoc.Dispose();
                            //Trừ các vật phẩm đã tạo
                            if (soNgauNhien == 1)
                                soLuongVP1--;
                            else if (soNgauNhien == 2)
                                soLuongVP2--;
                            else if (soNgauNhien == 3)
                                soLuongVP3--;
                            else
                                soLuongVP4--;
                            cacVatPham[demVatPham] = vatPham;
                            demVatPham++;
                        }
                    }
                    demKhung++;
                    doDaiBanDau += doDaiKhungChia;
                    doDaiLucSau += doDaiKhungChia;
                }
            }
        }
        //Khởi tạo các button tương ứng
        PictureBox btMenu = new PictureBox();
        PictureBox btPlay = new PictureBox();
        //Khởi tạo trạng thái Play/Pause;
        bool playKeyDown = true;
        bool playKeyUp = true;
        private void khoiTaoCacButton()
        {
            //Set size cho hình và chỉnh màu
            int sizeHinh = 50; //Size hình là 40
            //Hình vuông
            btMenu.Width = btMenu.Height = sizeHinh;
            btPlay.Width = btPlay.Height = sizeHinh;
            //Tạo nền màu trong suốt
            btPlay.BackColor = System.Drawing.Color.Transparent;
            btMenu.BackColor = System.Drawing.Color.Transparent;
            //Set Parent với banner
            btMenu.Parent = picBanner;
            btPlay.Parent = picBanner;
            //Set tọa độ nằm góc phải trên
            int khoangCachCacButton = 10;//Khoảng các button là 10
            int toaDoXButton = this.picBanner.Width - sizeHinh;//Bằng kích thước form và X phải đôn lên
            int toaDoYButton = 0;
            btMenu.Location = new Point(toaDoXButton, toaDoYButton);
            toaDoXButton -= sizeHinh;//Đôn tiếp cho hình kế
            btPlay.Location = new Point(toaDoXButton - khoangCachCacButton, toaDoYButton);
            //Load hình
            btMenu.Image = Image.FromFile(duongDanAnh + "menu1.png");
            btPlay.Image = Image.FromFile(duongDanAnh + "pause1.png");
            //Canh hình
            btMenu.SizeMode = PictureBoxSizeMode.StretchImage;
            btPlay.SizeMode = PictureBoxSizeMode.StretchImage;
            //Set các sự kiện cho các button
            //Button Menu
            btMenu.MouseDown += btMenu_MouseDown;
            btMenu.MouseUp += btMenu_MouseUp;
            btMenu.DoubleClick += btMenu_DoubleClick;
            //Button Menu Hover, Leave
            btMenu.MouseHover += btMenu_MouseHover;
            btMenu.MouseLeave += btMenu_MouseLeave;
            //Button Play
            btPlay.MouseDown += btPlay_MouseDown;
            btPlay.MouseUp += btPlay_MouseUp;
            btPlay.MouseHover += btPlay_MouseHover;
            btPlay.MouseLeave += btPlay_MouseLeave;
            //
            hinh = new Bitmap(picMoc.Image);
            a = (this.Width / 2) - (picMoc.Width / 2) - 10;
            //Tọa độ Y nằm ngay dưới banner
            b = 0;//Vì picMoc là cha của picContent cho nên phải theo tọa độ từ picContent
            tempA = a;
            //picMoc.Image = RotateBitmap(hinh, 0);
            c = a; //Lấy bản sao của vị trí xMoc
            d = b; //Lấy bản sao của vị trí yMoc
            //Đổi Cursor
            btMenu.Cursor = Cursors.Hand;
            btPlay.Cursor = Cursors.Hand;
        }
        //Sau khi chuột nhả play ra
        void btPlay_MouseUp(object sender, MouseEventArgs e)
        {
            if (playKeyUp == true)
            {
                btPlay.Image = Image.FromFile(duongDanAnh + "play1.png");
                playKeyUp = false;
                timerMoc.Enabled = false;
                timerDemThoiGian.Enabled = false;
            }
            else
            {
                btPlay.Image = Image.FromFile(duongDanAnh + "pause1.png");
                playKeyUp = true;
                timerMoc.Enabled = true;
                timerDemThoiGian.Enabled = true;
            }
        }
        //Sau khi chuột nhấn play xuống
        void btPlay_MouseDown(object sender, MouseEventArgs e)
        {
            if (playKeyDown == true)
            {
                btPlay.Image = Image.FromFile(duongDanAnh + "pause2.png");
                playKeyDown = false;
            }
            else
            {
                btPlay.Image = Image.FromFile(duongDanAnh + "play2.png");
                playKeyDown = true;
            }
        }
        private void anMenu()
        {
            btChoiTuDau.Hide();
            btVeMenu.Hide();
        }
        //Set Parent với banner
        private void menuParent()
        {
            btChoiTuDau.Parent = picBanner;
            btChoiTuDau.Cursor = Cursors.Hand;
            btVeMenu.Parent = picBanner;
            btVeMenu.Cursor = Cursors.Hand;
            //Set size cho hình và chỉnh màu
            int sizeHinh = 40;
            //Set tọa độ nằm góc phải trên
            //int khoangCachCacButton = 10;//Khoảng cách button là 10
            int toaDoXButton = this.picBanner.Width - sizeHinh;//Bằng kích thước form và X phải đôn lên
            btChoiTuDau.Location = new Point(toaDoXButton, 52);
            btVeMenu.Location = new Point(toaDoXButton, 90);
        }
        //Sau khi chuột nhả menu ra
        void btMenu_MouseUp(object sender, MouseEventArgs e)
        {
            btMenu.Image = Image.FromFile(duongDanAnh + "menu1.png");

        }
        //Sau khi chuột được nhấn menu xuống
        void btMenu_MouseDown(object sender, MouseEventArgs e)
        {
            btMenu.Image = Image.FromFile(duongDanAnh + "menu2.png");
            btChoiTuDau.Show();
            btVeMenu.Show();
        }
        void btMenu_DoubleClick(object sender, EventArgs e)
        {
            btChoiTuDau.Hide();
            btVeMenu.Hide();
        }
        //Set độ quay của móc
        int doQuay = 0;
        bool gocQuayDuong = true;
        Bitmap hinh;
        int a = 0; //a là location X của picMoc
        int tempA = 0;
        int b = 0;//b là location Y của picMoc
        int x = 0;//X là toc do moc chay ngang
        int y = 0;//Y là tốc độ móc chạy xuống
        int c = 0, d = 0;
        //
        bool kTSpace = false;
        bool kTMoc = true;
        bool kTBanDau = true;
        //
        int diemXDayBanDau = 0;
        int diemYDayBanDau = 0;
        int diemXDayLucSau = 0;
        int diemYDayLucSau = 0;
        PaintEventArgs sKVe;
        Bitmap tempPicContent;
        bool chonGocQuay = false;
        int viTriVangDuocGap = -1;
        bool kTTrung = false;
        int intervalMacDinh = 100;
        int intervalLucGap = 0;
        int giaTriLucGap = 0;
        int giaTriCongDon = 0;//Giá trị cộng dồn đọc file từ điểm hiện tại
        //Timer set thời gian móc quay
        private void timerMoc_Tick(object sender, EventArgs z)
        {
            taoLableDiemGap();
            if (gocQuayDuong == true && chonGocQuay == false)
            {
                doQuay += 5;
                picMoc.Image = RotateBitmap(hinh, doQuay);
                if (doQuay == 80)
                {
                    gocQuayDuong = false;
                }
            }
            else if ((gocQuayDuong == false && chonGocQuay == false))
            {
                doQuay -= 5;
                picMoc.Image = RotateBitmap(hinh, doQuay);
                if (doQuay == -80)
                {
                    gocQuayDuong = true;
                }
            }
            //Điểm dưới cùng cực ở phía dưới bên trái là 55
            //Nửa phần trên
            if (doQuay <= 55 && doQuay >= -55)
            {
                x = (doQuay / 5) * 2;
                y = 12;
            }
            //Nửa phần dưới
            else
            {
                x = (int)((doQuay / 5) * 3);
                y = 10;
            }
            //Lấy sự kiện
            this.KeyDown += ManChoi_KeyDown;
            //Kiểm tra sự kiện nhấn phím Space
            if (kTSpace == true)
            {  
                if (kTMoc == true && kTBanDau == false)
                {
                    a -= x;
                    b += y;
                    diemXDayLucSau -= x;
                    diemYDayLucSau += y;
                }
                else if (kTMoc == false)
                {
                    a += x;
                    b -= y;
                    diemXDayLucSau += x;
                    diemYDayLucSau -= y;
                }
                picContent.Image = tempPicContent;
                OnPaint(sKVe);
                picMoc.Location = new Point(a, b);
                //Kiểm tra móc đụng vàng
                if (kTTrung == true)
                {
                    cacVatPham[viTriVangDuocGap].Location = new Point(a, b);
                    timerMoc.Interval = intervalLucGap;
                }
                for (int i = 0; i < soLuongVatPham; i++)
                {
                    if (picMoc.Bounds.IntersectsWith(cacVatPham[i].Bounds))
                    {
                        kTMoc = false;
                        kTTrung = true;
                        picMoc.Parent = cacVatPham[i];
                        picMoc.Location = new Point(5, 0);
                        picMoc.Size = new Size(20, 15);
                        intervalLucGap = kiemTraIntervalVP(dSTenVatPham[i]);
                        giaTriLucGap = kiemTraGiaTriVP(dSTenVatPham[i]);
                        Bitmap mocGap = new Bitmap(duongDanAnh + "MocLucGap.png");
                        picMoc.Image = RotateBitmap(mocGap, doQuay);
                        viTriVangDuocGap = i;
                        break;
                    }
                }
                //Đụng dưới đáy và 2 bên góc
                if (b >= picContent.Height - picMoc.Height || (a <= 0 || a >= picContent.Width - picMoc.Width))
                {
                    kTMoc = false;
                    giaTriLucGap = 0;
                }
                //Về vị trí cũ
                else if (a == toaDoXMoc && b <= 10)
                {
                    picMoc.Size = new Size(30, 30);
                    timerMoc.Interval = intervalMacDinh;
                    picMoc.Location = new Point(toaDoXMoc, 10);
                    kTBanDau = true;
                    kTMoc = true;
                    chonGocQuay = false;
                    picMoc.Parent = picContent;
                    if (giaTriLucGap > 0)
                    {
                        giaTriCongDon += giaTriLucGap;
                        lbDiemGap.Text = giaTriLucGap.ToString();
                        lbDiem.Text = giaTriCongDon.ToString();
                        giaTriLucGap = 0;
                    }
                    if (viTriVangDuocGap >= 0)
                    {
                        cacVatPham[viTriVangDuocGap].Location = new Point(0, 0);
                        cacVatPham[viTriVangDuocGap].Dispose();
                        viTriVangDuocGap = -1;
                    }
                    kTTrung = false;
                }
            }
        }
        //Phương thức kiểm tra giá trị các vật phẩm
        private int kiemTraGiaTriVP(String tenVatPham)
        {
            int giaTriVatPham = 0;
            switch (tenVatPham)
            {
                case "VangVua":
                    giaTriVatPham = 200;
                    break;
                case "VangLon":
                    giaTriVatPham = 300;
                    break;
                case "VangSieuLon":
                    giaTriVatPham = 500;
                    break;
                case "KimCuongXanh":
                    giaTriVatPham = 550;
                    break;
                case "KimCuongLuc":
                    giaTriVatPham = 600;
                    break;
                case "KimCuongHong":
                    giaTriVatPham = 650;
                    break;
                case "Da":
                    giaTriVatPham = 50;
                    break;
                case "TuiNgauNhien":
                    Random rand = new Random();
                    giaTriVatPham = rand.Next(100, 501);
                    break;
            }
            return giaTriVatPham;
        }
        //Phương thức kiểm tra tốc độ kéo các vật phẩm
        private int kiemTraIntervalVP(String tenVatPham)
        {
            int interval = 0;
            switch (tenVatPham)
            {
                case "VangVua":
                    interval = 300;
                    break;
                case "VangLon":
                    interval = 350;
                    break;
                case "VangSieuLon":
                    interval = 650;
                    break;
                case "KimCuongXanh":
                    interval = 350;
                    break;
                case "KimCuongLuc":
                    interval = 350;
                    break;
                case "KimCuongHong":
                    interval = 350;
                    break;
                case "Da":
                    interval = 500;
                    break;
                case "TuiNgauNhien":
                    interval = 550;
                    break;
            }
            return interval;
        }
        //Phương thức tạo lable điểm gắp được vật phẩm
        private void taoLableDiemGap()
        {
            int chieuDaiLabel = 200;
            int chieuCaoLabel = 100;
            lbDiemGap.Parent = picBanner;
            lbDiemGap.Location = new Point(chieuDaiLabel, chieuCaoLabel);
        }
        //Phương thức GetPointBounds
        private void GetPointBounds(PointF[] points, out float xmin, out float xmax, out float ymin, out float ymax)
        {
            xmin = points[0].X;
            xmax = xmin;
            ymin = points[0].Y;
            ymax = ymin;
            foreach (PointF point in points)
            {
                if (xmin > point.X) xmin = point.X;
                if (xmax < point.X) xmax = point.X;
                if (ymin > point.Y) ymin = point.Y;
                if (ymax < point.Y) ymax = point.Y;
            }
        }
        //Phương thức xoay hình
        private Bitmap RotateBitmap(Bitmap bm, float angle)
        {
            Matrix rotate_at_origin = new Matrix();
            rotate_at_origin.Rotate(angle);
            PointF[] points =
            {
                new PointF(0, 0),
                new PointF(bm.Width, 0),
                new PointF(bm.Width, bm.Height),
                new PointF(0, bm.Height),
            };
            rotate_at_origin.TransformPoints(points);
            float xmin, xmax, ymin, ymax;
            GetPointBounds(points, out xmin, out xmax, out ymin, out ymax);
            //
            int wid = (int)Math.Round(xmax - xmin);
            int hgt = (int)Math.Round(ymax - ymin);
            Bitmap result = new Bitmap(wid, hgt);
            //
            Matrix rotate_at_center = new Matrix();
            rotate_at_center.RotateAt(angle,new PointF(wid / 2f, hgt / 2f));
            using (Graphics gr = Graphics.FromImage(result))
            {
                gr.InterpolationMode = InterpolationMode.High;

                gr.Clear(bm.GetPixel(0, 0));
                gr.Transform = rotate_at_center;

                int x = (wid - bm.Width) / 2;
                int y = (hgt - bm.Height) / 2;
                gr.DrawImage(bm, x, y);
            }
            return result;
        }
        //Phương thức xử lý khi nhấn phím space
        void ManChoi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                lbDiemGap.ResetText();
                chonGocQuay = true;
                kTBanDau = false;
                kTSpace = true;
            }
        }
        //Rê chuột vào button chơi từ đầu để màu button sậm hơn
        private void btChoiTuDau_MouseHover(object sender, EventArgs e)
        {
            btChoiTuDau.Image = Image.FromFile(duongDanAnh + "choiTuDau2.png");
        }
        //Rời chuột khỏi button chơi từ đầu để màu button sáng trở lại
        private void btChoiTuDau_MouseLeave(object sender, EventArgs e)
        {
            btChoiTuDau.Image = Image.FromFile(duongDanAnh + "choiTuDau2.png");
            btChoiTuDau.Image = Image.FromFile(duongDanAnh + "choiTuDau1.png");
        }
        //Rê chuột vào button về menu để màu button sậm hơn
        private void btVeMenu_MouseHover(object sender, EventArgs e)
        {
            btVeMenu.Image = Image.FromFile(duongDanAnh + "menu2.png");
        }
        //Rời chuột khỏi button về menu để màu button sáng trở lại
        private void btVeMenu_MouseLeave(object sender, EventArgs e)
        {
            btVeMenu.Image = Image.FromFile(duongDanAnh + "menu2.png");
            btVeMenu.Image = Image.FromFile(duongDanAnh + "menu1.png");
        }
        //Click vào button chơi từ đầu để quay lại chơi từ màn đầu
        private void btChoiTuDau_Click(object sender, EventArgs e)
        {
            this.Hide();
            ManChoi menu = new ManChoi();
            menu.ShowDialog();
            this.Close();
        }
        //Click vào button cvề menu để quay về menu
        private void btVeMenu_Click(object sender, EventArgs e)
        {
            this.Hide();
            Menu menu = new Menu();
            menu.ShowDialog();
            this.Close();
        }
        //Phương thức OnPaint
        protected override void OnPaint(PaintEventArgs z)
        {
            Bitmap DrawArea;
            DrawArea = new Bitmap(picContent.Image, picContent.Size.Width, picContent.Size.Height);//Lấy hình ảnh, tọa độ x, tọa độ y
            Graphics g = Graphics.FromImage(DrawArea);//Khởi tạo khu vực vẽ
            Pen p = new Pen(Color.Black, 3);
            g.DrawLine(p, new Point(diemXDayBanDau, diemYDayBanDau), new Point(diemXDayLucSau, diemYDayLucSau));
            picContent.Image = DrawArea;
        }
        //Phương thức khởi tạo màn chơi
        private void khoiTaoManChoi()//Lựa màn chơi để khởi tạo vật phẩm cho phù hợp.
        {
            switch (manSo)//ManSo: Màn chơi số mấy.
            {
                case "1":
                    khoiTaoVatPham("vang", 3, "Da", 4);//khoiTaoVatPham("vang", 5, "kimcuong", 5, "TuiNgauNhien", 2, "Da", 2);//Chưa xử lí số lẻ
                    break;
                case "2":
                    khoiTaoVatPham("vang", 3, "Da", 5, "KimCuong", 2);
                    break;
                case "3":
                    khoiTaoVatPham("vang", 4, "TuiNgauNhien", 3, "KimCuong", 4, "Da", 4);
                    break;
                default:
                    break;
            }
        }
        //
        int demThoiGian = 35;
        //Timer set thời gian của mỗi màn chơi
        private void timerDemThoiGian_Tick(object sender, EventArgs e)
        {
            demThoiGian--;
            lbThoiGian.Text = demThoiGian.ToString();
            if (demThoiGian == 0)
            {
                //Xử lí
                if (giaTriCongDon < int.Parse(mucTieu))
                {
                    Thua t = new Thua();
                    timerDemThoiGian.Enabled = false;
                    this.Hide();
                    t.ShowDialog();
                    this.Close();
                }
                else
                {
                    diemHienTai = lbDiem.Text;
                    luuDiemHienTai();
                    this.Hide();
                    if (kiemTraThang() == true)
                    {
                        StreamWriter manSoWrite = new StreamWriter("ManSo.txt");
                        manSoWrite.Flush();
                        int mS = int.Parse(manSo);
                        mS++;
                        manSoWrite.WriteLine(mS);
                        manSoWrite.Close();
                        MucTieu mT = new MucTieu();
                        mT.ShowDialog();
                    }
                    else
                    {
                        BanHang bH = new BanHang();                     
                        bH.ShowDialog();
                    }  
                    timerMoc.Dispose();
                    timerDemThoiGian.Dispose();
                    demThoiGian = 0;
                    this.Close();
                }
            }
        }
        //Đóng form màn chơi
        private void ManChoi_FormClosed(object sender, FormClosedEventArgs e)
        {
            StreamWriter manSoWrite = new StreamWriter("ManSo.txt");
            manSoWrite.Flush();
            manSoWrite.WriteLine(1);
            manSoWrite.Close();
            //Trả về điểm 0
            diemHienTai = "0";
            luuDiemHienTai();
        }
        //Khởi tạo màn số mấy và mục tiêu của màn
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
            }
            else
            {
                lbMucTieu.Text = mucTieu + "$";
            }
            manSoRead.Close();
            mucTieuRead.Close();
        }
        //Phương thức lưu điểm hiện tại
        private void luuDiemHienTai()
        {
            StreamWriter diemWriter = new StreamWriter("DiemHienTai.txt");
            diemWriter.Flush();
            diemWriter.WriteLine(diemHienTai);
            diemWriter.Close();
        }
        //Phương thức lấy điểm hiện tại
        private void layDiemHienTai()
        {
            StreamReader diemReader = new StreamReader("DiemHienTai.txt");
            diemHienTai = diemReader.ReadLine();
            diemReader.Close();
        }
        //Phương thức kiểm tra vật phẩm mua
        private void kiemTraVatPhamMua()
        {
            BanHang bH = new BanHang();
            if(bH.Phao == true)
            {
                //Phá hủy vật phẩm
            }
            if(bH.co4La == true)
            {
                //Tăng sức mạnh tinh thần
            }
            if(bH.tangDa == true)
            {
                //Tăng giá trị đá
            }
            if(bH.thuocSucManh == true)
            {
                //Tăng sức mạnh
            }
        }
        private bool kiemTraThang()
        {
            StreamReader manSoRead = new StreamReader("ManSo.txt");
            StreamReader mucTieuRead = new StreamReader("MucTieu.txt");
            int soThuTu = int.Parse(manSoRead.ReadLine());
            manSoRead.Close();
            for(int i = 0; i <= soThuTu; i++)
            {
                if(mucTieuRead.ReadLine() == null)
                {
                    mucTieuRead.Close();
                    return true;
                }
            }
            return false;
        }
        //Tạo MouseHover, MouseLeave cho button Play, button Menu
        //Button Menu
        //Rê chuột vào button menu để màu button sậm hơn
        void btMenu_MouseHover(object sender, EventArgs e)
        {
            btMenu.Image = Image.FromFile(duongDanAnh + "menu2.png");
        }
        //Rời chuột khỏi button menu để màu button sáng trở lại
        void btMenu_MouseLeave(object sender, EventArgs e)
        {
            btMenu.Image = Image.FromFile(duongDanAnh + "menu2.png");
            btMenu.Image = Image.FromFile(duongDanAnh + "menu1.png");
        }
        //Button Play
        //Rê chuột vào button play để màu button sậm hơn
        void btPlay_MouseHover(object sender, EventArgs e)
        {
            btPlay.Image = Image.FromFile(duongDanAnh + "pause2.png");
        }
        //Rời chuột khỏi button play để màu button sáng trở lại
        void btPlay_MouseLeave(object sender, EventArgs e)
        {
            btPlay.Image = Image.FromFile(duongDanAnh + "pause2.png");
            btPlay.Image = Image.FromFile(duongDanAnh + "pause1.png");
        }
    }
}
