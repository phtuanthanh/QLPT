using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLPT_PBL
{
    public partial class DangKy : Form
    {
        public DangKy()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            BUS_ChuTro.Instance.DangKyTro(txtTen.Text,txtEmail.Text,txtSoDienThoa.Text,txtPassWord.Text,txtUserName.Text);
            DTO_TaiKhoan dt = new DTO_TaiKhoan(txtPassWord.Text, txtUserName.Text,"9999",0, true);
            BUS_TaiKhoan.Instance.Update(dt, "");
        }
    }
}
