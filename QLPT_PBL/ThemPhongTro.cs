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
    public partial class ThemPhongTro : Form
    {
        public ThemPhongTro()
        {
            InitializeComponent();
            AddItemCommbox();
            textBoxGia.Text = "1000000";
        }
        private void AddItemCommbox()
        {
            DataTable dt = new DataTable();
            dt = BUS_LoaiPhong.Instance.GetLoaiPhong();
            var trangThaiPhi = new BindingList<KeyValuePair<string, string>>();

            foreach (DataRow dr in dt.Rows)
            {
                trangThaiPhi.Add(new KeyValuePair<string, string>(dr["ID_LoaiPhong"].ToString(), dr["TenLoaiPhong"].ToString()));
            }
            this.comboBoxLoaiPhong.DataSource = trangThaiPhi;
            this.comboBoxLoaiPhong.ValueMember = "Key";
            this.comboBoxLoaiPhong.DisplayMember = "Value";
            this.comboBoxLoaiPhong.SelectedIndex = 0;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
                 string idPhong = textBoxIdPhong.Text;
                string batdau = dateTimePickerBatDau.Text;
                string ketthuc = dateTimePickerKetThuc.Text;
                int tiendien = Convert.ToInt32(txtTienDien.Text);
                int tienuoc = Convert.ToInt32(txtTienNuoc.Text);
                string loaiphong = comboBoxLoaiPhong.SelectedValue.ToString();
                int gia = BUS_LoaiPhong.Instance.GetGia(comboBoxLoaiPhong.SelectedValue.ToString());
                DTO_Phong phong = new DTO_Phong(idPhong, batdau, ketthuc, gia, loaiphong, 0, 0);
                BUS_Phong.Instance.Insert(phong);
                BUS_TongTien.Instance.InsertTongTien(idPhong, 0, 0, 0);
                BUS_DienNuoc.Instance.InsertDienNuoc(idPhong, 0, 0, tiendien, tienuoc);

                MessageBox.Show("Thêm phòng trọ thành công!");
                this.Close();
            
        }

        private void comboBoxLoaiPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxGia.Text = BUS_LoaiPhong.Instance.GetGia(comboBoxLoaiPhong.SelectedValue.ToString()).ToString();
        }
    }
}
