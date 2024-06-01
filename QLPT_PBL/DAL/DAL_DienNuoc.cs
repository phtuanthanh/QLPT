﻿using DAL;
using DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_DienNuoc
    {
        private static DAL_DienNuoc _instance;
        public static DAL_DienNuoc Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new DAL_DienNuoc();
                return _instance;
            }
            private set { _instance = value; }
        }
        public DAL_DienNuoc() { }
        #region Get danh sach dien nuoc

        /// <summary>
        /// Get danh sách khách hàng
        /// </summary>
        /// <returns></returns>
        public DataTable GetDienNuoc()
        {
            string query = "(SELECT * FROM DienNuoc)";
            DataTable dtKhachHang = new DataTable();
            dtKhachHang = DAL_DBHelper.Instance.GetRecords(query);
            return dtKhachHang;
        }

        #endregion

        #region Get điện nước theo ID Phòng


        /// <summary>
        /// Get danh sách khách hàng theo ID khách hang
        /// </summary>
        /// <returns></returns>
        public DataTable GetDienNuocByIDPhong(string Id)
        {
            string query = string.Format("SELECT * FROM DienNuoc WHERE ID_Phong = '{0}'", Id);
            DataTable dtKhachHang = new DataTable();
            dtKhachHang = DAL_DBHelper.Instance.GetRecords(query);
            return dtKhachHang;
        }

        #endregion
        #region insert thông tin khách hàng

        /// <summary>
        /// insert thông tin khách hàng
        /// </summary>
        /// <returns></returns>
        public bool Update(string id,int sodien,int sonuoc, int dongiadien,int dongianuoc,int tongtien)
        {
            try
            {
                string query = string.Empty;
                
                    query = string.Format("UPDATE DienNuoc SET SoDienHienTai = '{0}',SoNuocHienTai = '{1}',DonGiaDien ='{2}',DonGiaNuoc = '{3}',TongTien='{4}' WHERE ID_Phong ='{4}'",sodien,sonuoc,dongiadien,dongianuoc,tongtien);
                DataTable dtKhachHang = new DataTable();
                dtKhachHang = DAL_DBHelper.Instance.GetRecords(query);
            }
            catch (Exception ẽ)
            {
                return false;
            }

            return true;
        }

        #endregion

        public bool Delete(string id)
        {
            string query = string.Format("delete DienNuoc where ID_Phong = {0}", id);
            DataTable dtKhachHang = new DataTable();
            dtKhachHang = DAL_DBHelper.Instance.GetRecords(query);
            return true;
        }
        public DataTable GetDienNuocAll()
        {
            string query = string.Format("select Phong.ID_Phong,SoNuocHienTai,SoDienHienTai,DonGiaDien,DonGiaNuoc,TrangThai,Gia from Phong full join DienNuoc on DienNuoc.ID_Phong=Phong.ID_Phong join LoaiPhong on LoaiPhong.ID_LoaiPhong = Phong.ID_LoaiPhong\r\n");
            DataTable dn = new DataTable();
            dn = DAL_DBHelper.Instance.GetRecords(query);
            return dn;
        }
        public DataTable GetDienNuocAllById(string id)
        {
            string query = string.Format("select Phong.ID_Phong,SoNuocHienTai,SoDienHienTai,DonGiaDien,DonGiaNuoc,TrangThai from Phong full join DienNuoc on DienNuoc.ID_Phong=Phong.ID_Phong Where Phong.ID_Phong='{0}'",id);
            DataTable dn = new DataTable();
            dn = DAL_DBHelper.Instance.GetRecords(query);
            return dn;
        }
        public DataTable GetDienNuocAllByIdAndTinhTrang(string id,int tt)
        {
            string query = string.Format("select Phong.ID_Phong,SoNuocHienTai,SoDienHienTai,DonGiaDien,DonGiaNuoc,TrangThai from Phong full join DienNuoc on DienNuoc.ID_Phong=Phong.ID_Phong Where Phong.ID_Phong='{0}' and TrangThai='{1}'", id,tt);
            DataTable dn = new DataTable();
            dn = DAL_DBHelper.Instance.GetRecords(query);
            return dn;
        }
        public DataTable GetDienNuocAllByTrangThai(int tt)
        {
            string query = string.Format("select Phong.ID_Phong,SoNuocHienTai,SoDienHienTai,DonGiaDien,DonGiaNuoc,TrangThai,Gia from Phong full join DienNuoc on DienNuoc.ID_Phong=Phong.ID_Phong join LoaiPhong on LoaiPhong.ID_LoaiPhong = Phong.ID_LoaiPhong Where Phong.TrangThai='{0}'", tt);
            DataTable dn = new DataTable();
            dn = DAL_DBHelper.Instance.GetRecords(query);
            return dn;
        }
        public void UpdateDienNuoc(int sodien,int sonuoc,string id)
        {
            string query = string.Format("update DienNuoc set SoDienHienTai = '{0}', SoNuocHienTai='{1}' where ID_Phong='{2}'", sodien, sonuoc, id);
            DAL_DBHelper.Instance.ExecuteDB(query);
        }
        public void InsertDienNuoc(string id,int sodien,int sonuoc,int dongiadien,int dongianuoc)
        {
            string query = string.Format("insert into DienNuoc values('{0}','{1}','{2}','{3}','{4}')",id, sodien, sonuoc, dongiadien,dongianuoc);
            DAL_DBHelper.Instance.ExecuteDB(query);
        }
    }
}
