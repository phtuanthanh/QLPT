//using BUS;
//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;

//namespace QLPT_PBL
//{
//    public partial class ChiTiet : Form
//    {
//        string id;
//        public ChiTiet()
//        {
//            InitializeComponent();
//        }
//        public ChiTiet(string id)
//        {
//            this.id = id;
//            var kh = new BindingList<KeyValuePair<string, string>>();
//            kh.Add(new KeyValuePair<string, string>("", " --- Khách hàng --- "));
//            InitializeComponent();
//            DataTable dataTable = BUS_KhachHang.Instance.GetKhachHangByIdPhong(id);
//            foreach (DataRow row in dataTable.Rows)
//            {
//                kh.Add(new KeyValuePair<string, string>(row["ID_KhachHang"].ToString(), row["TenKhachHang"].ToString()));
//            }
//            this.cbbKhachHang.DataSource = kh;
//            this.cbbKhachHang.ValueMember = "Key";
//            this.cbbKhachHang.DisplayMember = "Value";
//            this.cbbKhachHang.SelectedIndex = 0;
//        }

//        private void btnXem_Click(object sender, EventArgs e)
//        {
//            DataTable dt = BUS_KhachHang.Instance.GetKhachHangByID(cbbKhachHang.SelectedValue.ToString());
//            foreach (DataRow row in dt.Rows)
//            {
//                txtMaKhachhang.Text = row["ID_KhachHang"].ToString();
//                txtTenKhachHang.Text = row["TenKhachHang"].ToString();
//                txtDiaChi.Text = row["DiaChi"].ToString();
//                txtSoDienThoai.Text = row["SoDienThoai"].ToString();
//                txtCMND.Text = row["CCCD"].ToString();
//            }
//        }

//        private void btnHuy_Click(object sender, EventArgs e)
//        {
//            if (MessageBox.Show("Thoát chương trình ??", "Thông báo", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
//            {
//               this.Close();
//            }
//        }

//        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
//        {

//        }
//    }
//}
