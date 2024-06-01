using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLPT_PBL
{
    public partial class Main : Form
    {
        public object ResetFormControls { get; private set; }

        public Main()
        {
            InitializeComponent();
        }
        #region Custom Group Box
        public class CustomGroupBox : GroupBox
        {
            public CustomGroupBox()
            {
                this.DoubleBuffered = true;
                this.TitleBackColor = Color.SteelBlue;
                this.TitleForeColor = Color.White;
                this.TitleFont = new Font(this.Font.FontFamily, Font.Size + 8, FontStyle.Bold);
                this.BackColor = Color.Transparent;
                this.Radious = 25;
                this.TitleHatchStyle = HatchStyle.Percent60;
            }

            protected override void OnPaint(PaintEventArgs e)
            {
                base.OnPaint(e);
                GroupBoxRenderer.DrawParentBackground(e.Graphics, this.ClientRectangle, this);
                var rect = ClientRectangle;
                using (var path = GetRoundRectagle(this.ClientRectangle, Radious))
                {
                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    rect = new Rectangle(0, 0, rect.Width, TitleFont.Height + Padding.Bottom + Padding.Top);
                    if (this.BackColor != Color.Transparent)
                    {
                        using (var brush = new SolidBrush(BackColor))
                        {
                            e.Graphics.FillPath(brush, path);
                        }
                    }

                    var clip = e.Graphics.ClipBounds;
                    e.Graphics.SetClip(rect);

                    using (var brush = new HatchBrush(TitleHatchStyle, TitleBackColor, ControlPaint.Light(TitleBackColor)))
                    {
                        e.Graphics.FillPath(brush, path);
                    }

                    using (var pen = new Pen(TitleBackColor, 1))
                    {
                        e.Graphics.DrawPath(pen, path);
                    }

                    TextRenderer.DrawText(e.Graphics, Text, TitleFont, rect, TitleForeColor);
                    e.Graphics.SetClip(clip);

                    using (var pen = new Pen(TitleBackColor, 1))
                    {
                        e.Graphics.DrawPath(pen, path);
                    }
                }
            }

            public Color TitleBackColor { get; set; }
            public HatchStyle TitleHatchStyle { get; set; }
            public Font TitleFont { get; set; }
            public Color TitleForeColor { get; set; }
            public int Radious { get; set; }

            private GraphicsPath GetRoundRectagle(Rectangle b, int r)
            {
                GraphicsPath path = new GraphicsPath();
                path.AddArc(b.X, b.Y, r, r, 180, 90);
                path.AddArc(b.X + b.Width - r - 1, b.Y, r, r, 270, 90);
                path.AddArc(b.X + b.Width - r - 1, b.Y + b.Height - r - 1, r, r, 0, 90);
                path.AddArc(b.X, b.Y + b.Height - r - 1, r, r, 90, 90);
                path.CloseAllFigures();
                return path;
            }

        }
        #endregion
        //----------------------------------------------------------------------------------------
        #region Khởi tạo màn hình
        private void Main_Load(object sender, EventArgs e)
        {
            DataTable target = BUS_Phong.Instance.GetPhongMaPhong();
            this.InitGroupBoxTrangChu(target);
            this.InitComboboxTrangThaiPhi();
            this.InitComboboxTrangThaiPhong();
            this.InitComboboxPhongTheoLoai();
          
            this.InitComboBoxTabKhachHang();

            this.InitTabDienNuoc(BUS_DienNuoc.Instance.GetDienNuocAll());

            this.InitComboBoxTabThanhToanTraPhong();
            this.InitTabThanhToanTraPhong(BUS_TongTien.Instance.getTongTien());

            InitComboBoxInitTabQuanLyTienPhong();
        }
        #region Tab_Phòng
        private void InitGroupBoxTrangChu(DataTable target)
        {
            // khai báo biến
            int sophongthue = 0;
            int sophongtrong = 0;
            int y = 15;
            int x = 15;
            int rowCnt = 0;
            string searchStr = string.Empty;
            string trangThaiPhong = string.Empty;
            string trangThaiPhi = string.Empty;
            this.panelPhong.Controls.Clear();

            if (this.cbTrangThaiPhong.SelectedValue != null)
            {
                trangThaiPhong = this.cbTrangThaiPhong.SelectedValue.ToString();
            }

            if (this.cbTinhTien.SelectedValue != null)
            {
                trangThaiPhi = this.cbTinhTien.SelectedValue.ToString();
            }

            if (!string.IsNullOrEmpty(this.txtSoPhong.Text.ToString()))
            {
                searchStr = this.txtSoPhong.Text;
            }
            if (target != null && target.Rows.Count > 0)
            {
                // lặp qua sanh sách phòng
                foreach (DataRow row in target.Rows)
                {
                    int ii = 0;
                    // Group box phòng
                    CustomGroupBox gb = new CustomGroupBox();
                    gb.Name = "groupBoxPhong" + row["ID_Phong"].ToString();
                    gb.Text = "Phòng " + row["ID_Phong"].ToString();
                    gb.Size = new Size(230, 140);

                    if (row["TrangThai"].ToString() == "1")
                    {
                        sophongthue += 1;
                        gb.TitleBackColor = Color.Tan;
                    }
                    if (row["TrangThai"].ToString() == "0")
                    {
                        sophongtrong += 1;
                    }
                    // chiều ngang
                    x = 15 + (15 * rowCnt) + (230 * rowCnt);

                    // chiều dọc
                    // xuống dòng khi đủ 3 phòng trên 1 row
                    if (x > 750)
                    {
                        x = 15;
                        y = y + 175;
                        rowCnt = 0;
                    }

                    // set vị trí cho group box
                    gb.Location = new Point(x, y);

                    // label tên khách hàng
                    // Value tên khách hàng
                    Label LabName = new Label();
                    Label valueName = new Label();
                    //if (string.IsNullOrEmpty(row["ID_KhachHang"].ToString()))
                    //{
                    //    LabName.Name = "LabelTenKhachHang" + ii;
                    //    valueName.Name = "TenKhachHang" + ii;
                    //    valueName.Text = "Chưa thuê";
                    //}
                    //else
                    //{
                    //    LabName.Name = "LabelTenKhachHang" + row["ID_KhachHang"].ToString();
                    //    valueName.Name = "TenKhachHang" + row["ID_KhachHang"].ToString();
                    //    valueName.Text = row["TenKhachHang"].ToString();
                    //}

                    //LabName.Text = "Khách hàng:";
                    //LabName.Location = new Point(15, 35);
                    //gb.Controls.Add(LabName);

                    Button btnChiTiet = new Button();
                    btnChiTiet.Name = "btnChiTiet" + row["ID_Phong"].ToString();
                    btnChiTiet.Text = "Xem";
                    btnChiTiet.Size = new Size(56, 25);
                    btnChiTiet.Location = new Point(35, 105);
                    btnChiTiet.Click += btnChiTiet_Click;
                    gb.Controls.Add(btnChiTiet);

                    // button xóa
                    Button btnXoa = new Button();
                    btnXoa.Name = "btnXoa" + row["ID_Phong"].ToString();
                    btnXoa.Text = "Xóa";
                    btnXoa.Size = new Size(56, 25);
                    btnXoa.Location = new Point(141, 105);
                    btnXoa.Click += ButtonXoa_Click;
                    gb.Controls.Add(btnXoa);

                    valueName.Location = new Point(113, 35);
                    gb.Controls.Add(valueName);

                    // label giá
                    Label LabGia = new Label();
                    LabGia.Name = "LabelGia" + row["ID_Phong"].ToString();
                    LabGia.Text = "Giá:";
                    LabGia.Location = new Point(15, 58);
                    gb.Controls.Add(LabGia);

                    // Value giá
                    Label valueGia = new Label();
                    valueGia.Name = "txtGia" + row["ID_Phong"].ToString();
                    valueGia.Text = row["Gia"].ToString();
                    valueGia.Location = new Point(113, 58);
                    valueGia.BorderStyle = BorderStyle.None;
                    gb.Controls.Add(valueGia);

                    // label loại phòng
                    Label labLoaiPhong = new Label();
                    labLoaiPhong.Name = "LabLoaiPhong" + row["ID_Phong"].ToString();
                    labLoaiPhong.Text = "Loại phòng:";
                    labLoaiPhong.Location = new Point(15, 81);
                    labLoaiPhong.Size = new Size(80, 20);
                    gb.Controls.Add(labLoaiPhong);

                    // Value giá
                    Label valueLoaiPhong = new Label();
                    valueLoaiPhong.Name = "cbLoaiPhong" + row["ID_Phong"].ToString();
                    valueLoaiPhong.Text = row["TenLoaiPhong"].ToString();
                    valueLoaiPhong.Location = new Point(113, 81);
                    valueLoaiPhong.Size = new Size(60, 20);
                    gb.Controls.Add(valueLoaiPhong);

                    // thêm group box vào danh sách phòng
                    panelPhong.Controls.Add(gb);
                    rowCnt++;
                    ii++;

                    labelSoPhongChoThue.Text = sophongtrong.ToString();
                    labelSoPhongTrong.Text = sophongthue.ToString();
                }
            }
        }
        private void btnChiTiet_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            string id = button.Name.Substring(button.Name.Length -3, 3); ;
            ChiTiet f = new ChiTiet(id);
            this.Hide();
            f.ShowDialog();
            this.Show();
            //this.InitGroupBoxTrangChu();
        }
        private void ButtonXoa_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            string id = button.Name.Substring(button.Name.Length - 3, 3);

            DataTable dt = BUS_Phong.Instance.GetPhongMaPhongByTinhTrangAndID("1", id);
            if (dt != null && dt.Rows.Count > 0)
            {
                MessageBox.Show("Phòng đang được thuê, không thể xóa");
                return;
            }

            BUS_Phong bUS_Phong = new BUS_Phong();
            bUS_Phong.Delete(id);
            BUS_TongTien.Instance.DeleteByID(id);
            

            DataTable target = BUS_Phong.Instance.GetPhongMaPhong();
            this.InitGroupBoxTrangChu(target);
            target = BUS_TongTien.Instance.getTongTien();
            this.InitTabThanhToanTraPhong(target);

        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            DataTable target = BUS_Phong.Instance.GetPhongMaPhong();
            InitGroupBoxTrangChu(target);
        }
        private void InitComboboxTrangThaiPhong()
        {
            var trangThaiPhong = new BindingList<KeyValuePair<string, string>>();
            trangThaiPhong.Add(new KeyValuePair<string, string>("", " --- Trạng thái phòng --- "));
            trangThaiPhong.Add(new KeyValuePair<string, string>("0", " --- Chưa thuê --- "));
            trangThaiPhong.Add(new KeyValuePair<string, string>("1", " ---  Đã thuê  --- "));

            this.cbTrangThaiPhong.DataSource = trangThaiPhong;
            this.cbTrangThaiPhong.ValueMember = "Key";
            this.cbTrangThaiPhong.DisplayMember = "Value";
            this.cbTrangThaiPhong.SelectedIndex = 0;
        }
        private void InitComboboxPhongTheoLoai()
        {
            DataTable dt = new DataTable();
            dt = BUS_LoaiPhong.Instance.GetLoaiPhong();
            var trangThaiPhi = new BindingList<KeyValuePair<string, string>>();
            trangThaiPhi.Add(new KeyValuePair<string, string>("", " --- Loại phòng --- "));

            foreach (DataRow dr in dt.Rows)
            {
                trangThaiPhi.Add(new KeyValuePair<string, string>(dr["ID_LoaiPhong"].ToString(), dr["TenLoaiPhong"].ToString()));
            }
            this.cbTinhTien.DataSource = trangThaiPhi;
            this.cbTinhTien.ValueMember = "Key";
            this.cbTinhTien.DisplayMember = "Value";
            this.cbTinhTien.SelectedIndex = 0;
        }
        private void InitComboboxTrangThaiPhi()
        {
            var trangThaiPhi = new BindingList<KeyValuePair<string, string>>();
            trangThaiPhi.Add(new KeyValuePair<string, string>("", " --- Trạng thái phí --- "));
            trangThaiPhi.Add(new KeyValuePair<string, string>("1", " --- Chưa thu phí  --- "));
            trangThaiPhi.Add(new KeyValuePair<string, string>("0", " --- Đã thu phí --- "));

            this.cbTinhTien.DataSource = trangThaiPhi;
            this.cbTinhTien.ValueMember = "Key";
            this.cbTinhTien.DisplayMember = "Value";
            this.cbTinhTien.SelectedIndex = 0;
        }
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string maPhong = txtSoPhong.Text.Trim();
            string trangThaiPhong = cbTrangThaiPhong.SelectedValue?.ToString() ?? string.Empty;
            string loaiPhong = cbTinhTien.SelectedValue?.ToString() ?? string.Empty;

            DataTable target = new DataTable();

            if (!string.IsNullOrEmpty(maPhong))
            {
                // Nếu nhập mã phòng, tìm theo mã phòng
                if (!string.IsNullOrEmpty(trangThaiPhong) && (trangThaiPhong == "0" || trangThaiPhong == "1"))
                {
                    target = BUS_Phong.Instance.GetPhongMaPhongByTinhTrangAndID(trangThaiPhong, maPhong);
                }
                else
                {
                    target = BUS_Phong.Instance.GetPhongMaPhongByID(maPhong);
                }
            }
            else if (!string.IsNullOrEmpty(trangThaiPhong) && (trangThaiPhong == "0" || trangThaiPhong == "1"))
            {
                if (!string.IsNullOrEmpty(loaiPhong))
                {
                    // Nếu chọn cả tình trạng phòng và loại phòng
                    target = BUS_Phong.Instance.GetPhongByTinhTrangAndLoaiPhong(trangThaiPhong, loaiPhong);
                }
                else
                {
                    // Nếu chỉ chọn tình trạng phòng
                    target = BUS_Phong.Instance.GetPhongMaPhongByTinhTrang(trangThaiPhong);
                }
            }
            else if (!string.IsNullOrEmpty(loaiPhong))
            {
                // Nếu chỉ chọn loại phòng
                target = BUS_Phong.Instance.GetPhongByLoaiPhong(loaiPhong);
            }
            else
            {
                // Nếu không chọn gì hoặc không nhập mã phòng, trả về tất cả các phòng
                target = BUS_Phong.Instance.GetPhongMaPhong();
            }
            this.InitGroupBoxTrangChu(target);
        }
        private void btnThemPhongTro_Click(object sender, EventArgs e)
        {
            ThemPhongTro f = new ThemPhongTro();
            this.Hide();
            f.ShowDialog();
            this.Show();
            DataTable target = BUS_Phong.Instance.GetPhongMaPhong();
            this.InitGroupBoxTrangChu(target);
        }

        #endregion
        #region Tab_KhachHang
        private void InitComboBoxTabKhachHang()
        {
            DataTable a = BUS_Phong.Instance.GetPhong();
            foreach (DataRow row in a.Rows)
            {
                cbPhong.Items.Add(row["ID_Phong"].ToString());
            }
            dataGridViewDsKhachHang.DataSource = BUS_Phong.Instance.GetThongTinKhachHang();
        }
        private void btnResert_Click(object sender, EventArgs e)
        {
            dataGridViewDsKhachHang.DataSource = BUS_Phong.Instance.GetThongTinKhachHang();

        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            string id = txtMaKhachHang.Text;
            string ten = txtTenKhachHang.Text;
            string cccd = txtCMNN.Text;
            string sdt = txtSdt.Text;
            string diachi = txtDiaChi.Text;
            string phong = cbPhong.SelectedItem.ToString();
            string tk = txtTenTaiKhoan.Text;
            string pass = txtPassWord.Text;
            string matk = txtMaTaiKhoan.Text;
            DTO_TaiKhoan taikhoan = new DTO_TaiKhoan(matk, pass, tk, "6666", 0, true);
            DTO_KhachHang kh = new DTO_KhachHang(id, ten, tk, pass, cccd, sdt, 0, diachi, true, phong);

            if (MessageBox.Show("Bạn muốn thêm khách hàng " + ten + " không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                DataTable dt = BUS_KhachHang.Instance.GetKhachHangByIdPhong(phong);
                if (dt.Rows.Count < 1)
                {
                    BUS_Phong.Instance.UpdateTrangThai(phong, 1);
                }
                BUS_TaiKhoan.Instance.Update(taikhoan);
                BUS_KhachHang.Instance.Update(kh);
                MessageBox.Show("thanh cong");

                dataGridViewDsKhachHang.DataSource = BUS_Phong.Instance.GetThongTinKhachHang();
            }
            // Đặt lại giá trị rỗng cho tất cả các TextBox
            txtMaKhachHang.Text = string.Empty;
            txtTenKhachHang.Text = string.Empty;
            txtCMNN.Text = string.Empty;
            txtSdt.Text = string.Empty;
            txtDiaChi.Text = string.Empty;
            txtTenTaiKhoan.Text = string.Empty;
            txtPassWord.Text = string.Empty;
            txtMaTaiKhoan.Text = string.Empty;

            // Đặt lại ComboBox về trạng thái mặc định (không chọn mục nào)
            cbPhong.ResetText();

        }
        private void cbPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable a = BUS_LoaiPhong.Instance.GetThongTinPhong(cbPhong.SelectedItem.ToString());
            foreach (DataRow dr in a.Rows)
            {
                txtLoaiPhong.Text = dr["TenLoaiPhong"].ToString();
                txtGia.Text = dr["Gia"].ToString();

            }
        }
        private void btnTimKiemKH_Click(object sender, EventArgs e)
        {
            string id = txtTimKiemKH.Text;
            dataGridViewDsKhachHang.DataSource = BUS_Phong.Instance.GetThongTinKhachHangByID(id);
            if (txtTimKiemKH.Text.Equals(""))
                dataGridViewDsKhachHang.DataSource = BUS_Phong.Instance.GetThongTinKhachHang();
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            string id = dataGridViewDsKhachHang.SelectedRows[0].Cells["ID"].Value.ToString();
            string tk = dataGridViewDsKhachHang.SelectedRows[0].Cells["Tài khoản"].Value.ToString();
            string pass = dataGridViewDsKhachHang.SelectedRows[0].Cells["Mật khẩu"].Value.ToString();
            string maphong = dataGridViewDsKhachHang.SelectedRows[0].Cells["Phòng"].Value.ToString();

            if (MessageBox.Show("Bạn có chắc chắn xóa khách hàng "+ dataGridViewDsKhachHang.SelectedRows[0].Cells["Tên khách hàng"].Value.ToString()+" không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                MessageBox.Show("Xóa khách hàng thành công!");
                BUS_KhachHang.Instance.Delete(id);
                BUS_TaiKhoan.Instance.DeleteByUserNameAndPassword(tk, pass);
                DataTable dt = BUS_KhachHang.Instance.GetKhachHangByIdPhong(maphong);
                if(dt.Rows.Count < 1)
                {
                    BUS_Phong.Instance.UpdateTrangThai(maphong, 0);
                }
                dataGridViewDsKhachHang.DataSource = BUS_Phong.Instance.GetThongTinKhachHang();
            }

         
        }

        #endregion
        #region Tab_DienNuoc
        private void InitTabDienNuoc(DataTable dt)
        {
            DataGridViewColumn columnA = dataGridViewSoDienNuoc.Columns["TienPhong"];
            columnA.DisplayIndex = dataGridViewSoDienNuoc.Columns.Count - 2;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if(dt.Rows[i]["TrangThai"].ToString().Equals("1"))
                {
                    dataGridViewSoDienNuoc.RowCount = dt.Rows.Count;
                    dataGridViewSoDienNuoc.Rows[i].Cells["ID_Phong1"].Value = dt.Rows[i]["ID_Phong"].ToString();

                    dataGridViewSoDienNuoc.Rows[i].Cells["SoDienCu"].Value = dt.Rows[i]["SoDienHienTai"].ToString();
                    dataGridViewSoDienNuoc.Rows[i].Cells["TrangThai"].Value = "Đang thuê";
                    dataGridViewSoDienNuoc.Rows[i].Cells["SoDienMoi"].Value = '0';

                    dataGridViewSoDienNuoc.Rows[i].Cells["SoNuocCu"].Value = dt.Rows[i]["SoNuocHienTai"].ToString();
                    dataGridViewSoDienNuoc.Rows[i].Cells["TienPhong"].Value = dt.Rows[i]["Gia"].ToString();
                    dataGridViewSoDienNuoc.Rows[i].Cells["SoNuocMoi"].Value = '0';

                    dataGridViewSoDienNuoc.Rows[i].Cells["SoDienSuDung"].Value = '0';
                    dataGridViewSoDienNuoc.Rows[i].Cells["SoNuocSuDung"].Value = '0';

                    dataGridViewSoDienNuoc.Rows[i].Cells["DonGiaDien"].Value = "5000";
                    dataGridViewSoDienNuoc.Rows[i].Cells["DonGiaNuoc"].Value = "6000";

                    dataGridViewSoDienNuoc.Rows[i].Cells["SoTienThanhToan1"].Value = '0';
                }
                else
                {
                    dataGridViewSoDienNuoc.RowCount = dt.Rows.Count;
                    dataGridViewSoDienNuoc.Rows[i].Cells["ID_Phong1"].Value = dt.Rows[i]["ID_Phong"].ToString();

                    dataGridViewSoDienNuoc.Rows[i].Cells["SoDienCu"].Value = dt.Rows[i]["SoDienHienTai"].ToString();
                    dataGridViewSoDienNuoc.Rows[i].Cells["TrangThai"].Value = "Hiện trống";
                    dataGridViewSoDienNuoc.Rows[i].Cells["SoDienMoi"].Value = '0';

                    dataGridViewSoDienNuoc.Rows[i].Cells["SoNuocCu"].Value = dt.Rows[i]["SoNuocHienTai"].ToString();
                    dataGridViewSoDienNuoc.Rows[i].Cells["TienPhong"].Value = dt.Rows[i]["Gia"].ToString();
                    dataGridViewSoDienNuoc.Rows[i].Cells["SoNuocMoi"].Value = '0';

                    dataGridViewSoDienNuoc.Rows[i].Cells["SoDienSuDung"].Value = '0';
                    dataGridViewSoDienNuoc.Rows[i].Cells["SoNuocSuDung"].Value = '0';

                    dataGridViewSoDienNuoc.Rows[i].Cells["DonGiaDien"].Value = "5000";
                    dataGridViewSoDienNuoc.Rows[i].Cells["DonGiaNuoc"].Value = "6000";

                    dataGridViewSoDienNuoc.Rows[i].Cells["SoTienThanhToan1"].Value = '0';
                }
            

            }
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            if (dataGridViewSoDienNuoc.SelectedRows.Count > 0)
            {
                txtChiSoDienCu.Text = dataGridViewSoDienNuoc.SelectedRows[0].Cells["SoDienCu"].Value.ToString();
                txtChiSoNuocCu.Text = dataGridViewSoDienNuoc.SelectedRows[0].Cells["SoNuocCu"].Value.ToString();
                txtPhongUpd.Text = dataGridViewSoDienNuoc.SelectedRows[0].Cells["ID_Phong1"].Value.ToString();
            }
            else
            {
                MessageBox.Show("Vui long chon phong can lay du lieu");
            }

            
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            dataGridViewSoDienNuoc.SelectedRows[0].Cells["SoDienMoi"].Value = txtChiSoDienMoi.Text;
            dataGridViewSoDienNuoc.SelectedRows[0].Cells["SoNuocMoi"].Value = txtChiSoNuocMoi.Text;

            int sodiensudung = Convert.ToInt32(dataGridViewSoDienNuoc.SelectedRows[0].Cells["SoDienMoi"].Value.ToString())
                - Convert.ToInt32(dataGridViewSoDienNuoc.SelectedRows[0].Cells["SoDienCu"].Value.ToString());

            dataGridViewSoDienNuoc.SelectedRows[0].Cells["SoDienSuDung"].Value = sodiensudung.ToString();

            int sonuocsudung = Convert.ToInt32(dataGridViewSoDienNuoc.SelectedRows[0].Cells["SoNuocMoi"].Value.ToString())
       - Convert.ToInt32(dataGridViewSoDienNuoc.SelectedRows[0].Cells["SoNuocCu"].Value.ToString());

            dataGridViewSoDienNuoc.SelectedRows[0].Cells["SoNuocSuDung"].Value = sonuocsudung.ToString();

            int dien = Convert.ToInt32(dataGridViewSoDienNuoc.SelectedRows[0].Cells["DonGiaDien"].Value.ToString());
            int nuoc = Convert.ToInt32(dataGridViewSoDienNuoc.SelectedRows[0].Cells["DonGiaNuoc"].Value.ToString());
            int thanhtien = dien * sodiensudung + nuoc * sonuocsudung;
            int giaphong = Convert.ToInt32(dataGridViewSoDienNuoc.SelectedRows[0].Cells["TienPhong"].Value.ToString());
            dataGridViewSoDienNuoc.SelectedRows[0].Cells["ThanhTien"].Value = (giaphong+ thanhtien).ToString();

            BUS_DienNuoc.Instance.UpdateDienNuoc(Convert.ToInt32(txtChiSoDienMoi.Text), Convert.ToInt32(txtChiSoNuocMoi.Text), dataGridViewSoDienNuoc.SelectedRows[0].Cells["ID_phong1"].Value.ToString());

           DataTable dt =  BUS_Phong.Instance.GetPhongByID(txtPhongUpd.Text);
            int gia = 0;

            foreach (DataRow dr in dt.Rows)
                gia = Convert.ToInt32(dr["Gia"].ToString());
            int tt = 0;
            tt = gia + thanhtien;

            BUS_ThongKe.Instance.InsertDienNuoc(txtPhongUpd.Text, cbbTime.SelectedItem.ToString(), sodiensudung, sonuocsudung, gia, tt);
            dt = BUS_TongTien.Instance.getTongTienByID(txtPhongUpd.Text);
            foreach (DataRow dr in dt.Rows)
            {
                //2110000
                if (Convert.ToInt32(dr["TongTien"].ToString()) - Convert.ToInt32(dr["TienDaThanhToan"].ToString()) != 0)
                {
                    BUS_TongTien.Instance.UpdateTienNo(Convert.ToInt32(dr["DuNo"].ToString()) + Convert.ToInt32(dr["TongTien"].ToString()) - Convert.ToInt32(dr["TienDaThanhToan"].ToString()), txtPhongUpd.Text);
                }

            }
            BUS_TongTien.Instance.UpdateThangMoi(tt, 0, txtPhongUpd.Text);
            InitTabThanhToanTraPhong(BUS_TongTien.Instance.getTongTien());

        }

        private void InitComboBoxInitTabQuanLyTienPhong()
        {
            var trangThaiPhong = new BindingList<KeyValuePair<string, string>>();
            trangThaiPhong.Add(new KeyValuePair<string, string>("", " --- Trạng thái phòng --- "));
            trangThaiPhong.Add(new KeyValuePair<string, string>("0", " --- Trống --- "));
            trangThaiPhong.Add(new KeyValuePair<string, string>("1", " ---  Đang thuê --- "));

            this.cbTrangThai.DataSource = trangThaiPhong;
            this.cbTrangThai.ValueMember = "Key";
            this.cbTrangThai.DisplayMember = "Value";
            this.cbTrangThai.SelectedIndex = 0;
        }
        private void btnTimKiemSoDienNuoc_Click(object sender, EventArgs e)
        {
            string id = txtPhongTimKiem.Text;
            if (cbTrangThai.SelectedValue.ToString().Equals(""))
                InitTabDienNuoc(BUS_DienNuoc.Instance.GetDienNuocAllById(id));
            else
            {
                if (cbTrangThai.SelectedValue.ToString().Equals("0"))
                {
                    if (BUS_DienNuoc.Instance.GetDienNuocAllByIdAndTinhTrang(id, 0).Rows.Count < 0)
                    {
                        MessageBox.Show("Không có phòng hợp lệ");
                        txtPhongTimKiem.Text = "";
                    }
                    else
                        InitTabDienNuoc(BUS_DienNuoc.Instance.GetDienNuocAllByIdAndTinhTrang(id, 0));

                }
                if (cbTrangThai.SelectedValue.ToString().Equals("1"))
                    if (BUS_DienNuoc.Instance.GetDienNuocAllByIdAndTinhTrang(id, 1).Rows.Count < 0)
                    {
                        MessageBox.Show("Không có phòng hợp lệ");
                        txtPhongTimKiem.Text = "";
                    }
                    else
                        InitTabDienNuoc(BUS_DienNuoc.Instance.GetDienNuocAllByIdAndTinhTrang(id, 1));
            }
        }
        private void btnNew_Click(object sender, EventArgs e)
            {
                InitTabDienNuoc(BUS_DienNuoc.Instance.GetDienNuocAll());

            }
        private void cbTrangThai_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbTrangThai.SelectedValue.ToString().Equals(""))
                InitTabDienNuoc(BUS_DienNuoc.Instance.GetDienNuocAll());
            if (cbTrangThai.SelectedValue.ToString().Equals("0"))
                InitTabDienNuoc(BUS_DienNuoc.Instance.GetDienNuocAllByTrangThai(0));
            if (cbTrangThai.SelectedValue.ToString().Equals("1"))
              InitTabDienNuoc(BUS_DienNuoc.Instance.GetDienNuocAllByTrangThai(1));
        }
    
    #endregion
    #region Tab_ThanhToanTraPhong
    private void InitTabThanhToanTraPhong(DataTable dt)
    {
        for (int i = 0; i < dt.Rows.Count; i++)
        {
                int tongtien = Convert.ToInt32(dt.Rows[i]["TongTien"].ToString());
                int dathanhtoan = Convert.ToInt32(dt.Rows[i]["TienDaThanhToan"].ToString());

                dataGridViewTinhTien.RowCount = dt.Rows.Count;
              
            dataGridViewTinhTien.Rows[i].Cells["ID_Phong2"].Value = dt.Rows[i]["ID_Phong"].ToString();
                dataGridViewTinhTien.Rows[i].Cells["DuNo"].Value = dt.Rows[i]["DuNo"].ToString();

                dataGridViewTinhTien.Rows[i].Cells["TongSoTien"].Value = dt.Rows[i]["TongTien"].ToString();
                dataGridViewTinhTien.Rows[i].Cells["TongSoTienDaThanhToan"].Value = dt.Rows[i]["TienDaThanhToan"].ToString();
                dataGridViewTinhTien.Rows[i].Cells["TongSoTienChuaThanhToan"].Value = (tongtien-dathanhtoan).ToString();
        }

        }
        private void btnThanhToan_Click(object sender, EventArgs e)
        {
           if (dataGridViewTinhTien.SelectedRows.Count > 0)
            {
                if(txtThang.Text.Length > 0)
                {
                    int tongtien = Convert.ToInt32(dataGridViewTinhTien.SelectedRows[0].Cells["TongSoTien"].Value);
                    int tienthanhtoan = Convert.ToInt32(dataGridViewTinhTien.SelectedRows[0].Cells["TongSoTienDaThanhToan"].Value);
                    dataGridViewTinhTien.SelectedRows[0].Cells["TongSoTienDaThanhToan"].Value = tienthanhtoan + Convert.ToInt32(txtThang.Text);
                    dataGridViewTinhTien.SelectedRows[0].Cells["TongSoTienChuaThanhToan"].Value = (tongtien - tienthanhtoan- Convert.ToInt32(txtThang.Text)).ToString();
                    BUS_TongTien.Instance.UpdateTienThanhToan(tienthanhtoan + Convert.ToInt32(txtThang.Text), dataGridViewTinhTien.SelectedRows[0].Cells["ID_Phong2"].Value.ToString());
                }

                if (txtNo.Text.Length > 0)
                {
                    int tienno = Convert.ToInt32(dataGridViewTinhTien.SelectedRows[0].Cells["DuNo"].Value);
                    dataGridViewTinhTien.SelectedRows[0].Cells["DuNo"].Value = tienno - Convert.ToInt32(txtNo.Text);
                    BUS_TongTien.Instance.UpdateTienNo(tienno - Convert.ToInt32(txtNo.Text), dataGridViewTinhTien.SelectedRows[0].Cells["ID_Phong2"].Value.ToString());
                }
            }

        }
        private void InitComboBoxTabThanhToanTraPhong()
        {
            var trangThaiPhong = new BindingList<KeyValuePair<string, string>>();
            trangThaiPhong.Add(new KeyValuePair<string, string>("", " --- Trạng thái phòng --- "));
            trangThaiPhong.Add(new KeyValuePair<string, string>("0", " --- Trống --- "));
            trangThaiPhong.Add(new KeyValuePair<string, string>("1", " ---  Đang thuê --- "));

            this.cbbTinhTrangPhong.DataSource = trangThaiPhong;
            this.cbbTinhTrangPhong.ValueMember = "Key";
            this.cbbTinhTrangPhong.DisplayMember = "Value";
            this.cbbTinhTrangPhong.SelectedIndex = 0;
        }
       private void btnTImKiemTinhTien_Click(object sender, EventArgs e)
        {
                string id = txtTImKiemTinhTien.Text;
                if (cbbTinhTrangPhong.SelectedValue.ToString().Equals(""))
                {
                    if(id.Equals(""))
                    InitTabThanhToanTraPhong(BUS_TongTien.Instance.getTongTien());
                    else
                    InitTabThanhToanTraPhong(BUS_TongTien.Instance.getTongTienByID(id));
            }
            else
                {
                    if (cbbTinhTrangPhong.SelectedValue.ToString().Equals("0"))
                    {
                        if (BUS_TongTien.Instance.getTongTienByTinhTrangAndID(0,id).Rows.Count < 0)
                        {
                            MessageBox.Show("Không có phòng hợp lệ");
                        txtTImKiemTinhTien.Text = "";
                        }
                        else
                        InitTabThanhToanTraPhong(BUS_TongTien.Instance.getTongTienByTinhTrangAndID(0, id));

                    }
                    if (cbbTinhTrangPhong.SelectedValue.ToString().Equals("1"))
                        if (BUS_TongTien.Instance.getTongTienByTinhTrangAndID(1, id).Rows.Count < 0)
                        {
                            MessageBox.Show("Không có phòng hợp lệ");
                        txtTImKiemTinhTien.Text = "";
                        }
                        else
                        InitTabThanhToanTraPhong(BUS_TongTien.Instance.getTongTienByTinhTrangAndID(1, id));
                }
            }
        private void cbbTinhTrangPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbTinhTrangPhong.SelectedValue.ToString().Equals(""))
                InitTabThanhToanTraPhong(BUS_TongTien.Instance.getTongTien());
            if (cbbTinhTrangPhong.SelectedValue.ToString().Equals("0"))
                InitTabThanhToanTraPhong(BUS_TongTien.Instance.getTongTienByTinhTrang(0));
            if (cbbTinhTrangPhong.SelectedValue.ToString().Equals("1"))
                InitTabThanhToanTraPhong(BUS_TongTien.Instance.getTongTienByTinhTrang(1));
        }

        private void btnRESET_Click(object sender, EventArgs e)
        {
            this.InitTabThanhToanTraPhong(BUS_TongTien.Instance.getTongTien());
        }

     
    }
    #endregion


}
#endregion
