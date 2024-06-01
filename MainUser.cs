using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace QLPT_PBL
{
    public partial class MainUser : Form
    {
        string user = string.Empty;
        string pass = string.Empty;
        public MainUser()
        {
            InitializeComponent();
        }
        public MainUser(string username, string password) : this()
        {
            this.user = username;
            this.pass = password;

            DataInitThongTinKhachHang(this.user,this.pass);
        }
        private void btnShow_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = BUS_ThongKe.Instance.GetThongKebyID(txtPhong.Text);
            dataGridView1.DataSource = dt;
        }

        private void DataInitThongTinKhachHang(string user, string pass)
        {
            DataTable dt = new DataTable();
            dt = BUS_KhachHang.Instance.GetKhachHangByUserNameAndPassWord(user,pass);

            txtTenKhachHang.Text = dt.Rows[0]["TenKhachHang"].ToString();
            txtCMNN.Text = dt.Rows[0]["CCCD"].ToString();
            txtDiaChi.Text = dt.Rows[0]["DiaChi"].ToString();
            txtSdt.Text = dt.Rows[0]["SoDienThoai"].ToString();
            txtTenKhachHang.Text = dt.Rows[0]["TenKhachHang"].ToString();
            txtTenKhachHang.Text = dt.Rows[0]["TenKhachHang"].ToString();

            dt = BUS_KhachHang.Instance.GetPhongByUserNamePassWord(user,pass);
            string Phong = dt.Rows[0]["MaPhong"].ToString();

            dt = BUS_LoaiPhong.Instance.GetThongTinPhong(Phong);

            txtPhong.Text = dt.Rows[0]["ID_Phong"].ToString();
            txtLoaiPhong.Text = dt.Rows[0]["TenLoaiPhong"].ToString();
            txtGia.Text = dt.Rows[0]["Gia"].ToString();
            
            dt = BUS_DienNuoc.Instance.GetDienNuocByIDPhong(txtPhong.Text);
            lbValueSoDien.Text = dt.Rows[0]["SoDienHienTai"].ToString();
            lbValueSoNuoc.Text = dt.Rows[0]["SoNuocHienTai"].ToString();


            dt = BUS_TaiKhoan.Instance.GetLogin(user, pass);

            txtMaTaiKhoan.Text = dt.Rows[0]["ID_TaiKhoan"].ToString();
            txtTenTaiKhoan.Text = dt.Rows[0]["TenTaiKhoan"].ToString();
            txtPasswordHienTai.Text = dt.Rows[0]["Password"].ToString();



        }

        private void btnSuaDoi_Click(object sender, EventArgs e)
        {
            txtTenKhachHang.ReadOnly = false;
            txtCMNN.ReadOnly = false;
            txtDiaChi.ReadOnly = false;
            txtSdt.ReadOnly = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = BUS_KhachHang.Instance.GetKhachHangByUserNameAndPassWord(this.user, this.pass);

          
            string name = txtTenKhachHang.Text;
            string cmnd = txtCMNN.Text;
            string phone = txtSdt.Text;
            string diachi = txtDiaChi.Text;
            string id = dt.Rows[0]["ID_KhachHang"].ToString();
            string maphong = dt.Rows[0]["MaPhong"].ToString();
            int flag =  Convert.ToInt32(dt.Rows[0]["DelFlg"]);
            
            DTO_KhachHang kh = new DTO_KhachHang(name,this.user,this.pass,cmnd,phone,flag,diachi,false,maphong);

            BUS_KhachHang.Instance.Update(kh, id);
            txtTenKhachHang.ReadOnly = true;
            txtCMNN.ReadOnly = true;
            txtDiaChi.ReadOnly = true;
            txtSdt.ReadOnly = true;
               MessageBox.Show("Thay đổi thông tin thành công");
                DataInitThongTinKhachHang(this.user, this.pass);
    
        }

        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            string newPass = txtMatKhauMoi.Text;
            string againPass = txtNhaplaimatkhau.Text;
            DataTable dt = new DataTable();
            dt = BUS_TaiKhoan.Instance.GetLogin(this.user, this.pass);

            string id = dt.Rows[0]["ID_TaiKhoan"].ToString();
            string pass = dt.Rows[0]["Password"].ToString();
            string ten = dt.Rows[0]["TenTaiKhoan"].ToString();
            string quyen = dt.Rows[0]["Quyen"].ToString();
            int Flg = 6666;
            bool insetFlag = false;
            if(newPass.Equals(pass))
            {
                MessageBox.Show("Trùng mật khẩu cũ!");

            }
            else
            {
                if (newPass == "" || againPass == "")
                {
                    MessageBox.Show("Vui lòng điền đẩy đủ mật khẩu!");
                }
                else
                {
                    if (newPass.Equals(againPass) == false)
                    {
                        MessageBox.Show("Mật khẩu nhập lại không khớp!");
                    }
                    else
                    {
                        if (MessageBox.Show("Bạn chắc chắn sẽ đổi mật khẩu ??", "Thông báo", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                        {
                            pass = newPass;
                            BUS_KhachHang.Instance.ThayDoiUserNamePassWord(newPass, ten, this.pass);
                            DTO_TaiKhoan tk = new DTO_TaiKhoan(newPass, ten, quyen, Flg, insetFlag);
                            BUS_TaiKhoan.Instance.Update(tk,id);
                            this.pass = pass;
                            DataInitThongTinKhachHang(this.user, this.pass);
                            MessageBox.Show("Đổi mật khẩu thành công");
                        }
                    }

                }
            }
            

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            DataInitThongTinKhachHang(this.user, this.pass);
        }
        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn đăng xuất không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                this.Hide();
                Login f = new Login();
                f.Show();
            }
        }
    }
}
