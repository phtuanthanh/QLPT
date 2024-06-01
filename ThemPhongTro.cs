﻿using BUS;
using DTO;
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
    public partial class ThemPhongTro : Form
    {
        string IDtro= string.Empty;
        bool DelFlag;
        string IDPhong =string.Empty;
        public ThemPhongTro(string idTro, bool delFlag)
        {
            InitializeComponent();
            IDtro = idTro;
            AddItemCommbox();
            textBoxGia.Text = "1000000";
            DelFlag = delFlag;
            DataTable dt = BUS_Tro.Instance.GetTienDienNuoc(IDtro);
            foreach (DataRow dr in dt.Rows)
            {
                txtTienDien.Text = dr["DonGiaDien"].ToString();
                txtTienNuoc.Text = dr["DonGiaNuoc"].ToString();
            }
        }
        public ThemPhongTro(string idTro, bool delFlag,string Idphong)
        {
            InitializeComponent();
            IDtro = idTro;
            AddItemCommbox();
            textBoxGia.Text = "1000000";
            DelFlag = delFlag;
            IDPhong = Idphong;
            DataTable dt = BUS_Tro.Instance.GetTienDienNuoc(IDtro);
            foreach (DataRow dr in dt.Rows)
            {
                txtTienDien.Text = dr["DonGiaDien"].ToString();
                txtTienNuoc.Text = dr["DonGiaNuoc"].ToString();
            }
            dt = BUS_KhachHang.Instance.GetKhachHangByIdPhong(Idphong);
            dataGridViewKhachHang.DataSource = dt;
            textBoxIdPhong.Text = Idphong;
        }
        private void AddItemCommbox()
        {
            DataTable dt = new DataTable();
            dt = BUS_LoaiPhong.Instance.GetLoaiPhong();
            var trangThaiPhi = new BindingList<KeyValuePair<string, string>>();
            trangThaiPhi.Add(new KeyValuePair<string, string>("", " --- Loại phòng --- "));

            foreach (DataRow dr in dt.Rows)
            {
                trangThaiPhi.Add(new KeyValuePair<string, string>(dr["ID_LoaiPhong"].ToString(), dr["TenLoaiPhong"].ToString()));
            }
            this.comboBox1.DataSource = trangThaiPhi;
            this.comboBox1.ValueMember = "Key";
            this.comboBox1.DisplayMember = "Value";
            this.comboBox1.SelectedIndex = 1;

            
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
                string batdau = dateTimePickerBatDau.Text;
                string ketthuc = dateTimePickerKetThuc.Text;
                int tiendien = Convert.ToInt32(txtTienDien.Text);
                int tienuoc = Convert.ToInt32(txtTienNuoc.Text);
                string tenphong = textBoxIdPhong.Text;
                string loaiphong = comboBox1.SelectedValue.ToString();
                int gia = BUS_LoaiPhong.Instance.GetGia(comboBox1.SelectedValue.ToString());
            try
            {
                if(DelFlag)
                {
                    DTO_Phong phong = new DTO_Phong(tenphong, IDtro, batdau, ketthuc, gia, loaiphong, 0, 0);
                    BUS_Phong.Instance.Insert(phong);
                    BUS_TongTien.Instance.InsertTongTien(0, 0, 0);
                    BUS_DienNuoc.Instance.InsertDienNuoc( 0, 0, tiendien, tienuoc);

                    MessageBox.Show("Thêm phòng trọ thành công!");
                    this.Close();
                }
                else
                {
                    BUS_Phong.Instance.Update(IDPhong, tenphong,loaiphong);
                }
               
            }
            catch(Exception ex)
            {
                MessageBox.Show("Mã phòng bị trùng");
            }                  
        }

        private void comboBoxLoaiPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxGia.Text = BUS_LoaiPhong.Instance.GetGia(comboBox1.SelectedValue.ToString()).ToString();
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int a=-1;
            if(int.TryParse(comboBox1.SelectedValue.ToString(), out a)) {
                textBoxGia.Text= BUS_LoaiPhong.Instance.GetGia(a.ToString()).ToString();
            }
        }
    }
}
