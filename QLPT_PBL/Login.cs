using BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLPT_PBL
{
    public partial class Login : Form
    {

        #region FLogin
        /// <summary>
        /// FLogin
        /// </summary>
        public Login()
        {
            InitializeComponent();
            this.txtUserName.Text = "Admin";
            this.txtPassWord.Text = "123";
        }

        #endregion

        #region Event

        #region btDangNhap_Click : Sự kiên đăng nhập

        /// <summary>
        /// Sự kiên đăng nhập
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        #endregion
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string userName = this.txtUserName.Text;
            string passWord = this.txtPassWord.Text;

            DataTable user = lgoin(userName, passWord);
            if (user.Rows.Count > 0)
            {
                if (user.Rows[0]["Quyen"].ToString().Equals("9999"))
                {
                    Main f = new Main();
                    this.Hide();
                    f.ShowDialog();
                }
                if (user.Rows[0]["Quyen"].ToString().Equals("6666"))
                {
                    MainUser f = new MainUser(userName,passWord);
                    this.Hide();
                    f.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Sai tài khoản hoặc mật khẩu", "Thông báo", MessageBoxButtons.YesNo);
            }

        }
        #region btHuy_Click :  Sự kiến thóa chương trình

        /// <summary>
        ///  Sự kiến thóa chương trình
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHuy_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Thoát chương trình ??", "Thông báo", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        #endregion

        #region lgoin : Sự kiến đăng nhập

        /// <summary>
        /// Sự kiến đăng nhập
        /// </summary>
        /// <param name="username"></param>
        /// <param name="pasworrd"></param>
        /// <returns></returns>
        DataTable lgoin(string username, string pasworrd)
        {
            BUS_TaiKhoan tk = new BUS_TaiKhoan();
            DataTable dtTk = tk.GetLogin(username, pasworrd);
            return dtTk;
        }




        #endregion

        #endregion

     
    }
    }
