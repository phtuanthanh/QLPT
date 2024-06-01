using DAL;
using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class BUS_Phong
    {
        private static BUS_Phong _instance;
        public static BUS_Phong Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new BUS_Phong();
                return _instance;
            }
            private set { _instance = value; }
        }
        public BUS_Phong() { }
        #region Get danh sách phòng

        /// <summary>
        /// Get danh sách phòng
        /// </summary>
        /// <returns></returns>
        public DataTable GetPhong()
        {
            return DAL_Phong.Instance.GetPhong();
        }

        #endregion

        #region Get danh sách phong theo ma phong

        /// <summary>
        /// Get danh sách phong theo ma phong
        /// </summary>
        /// <returns></returns>
        public DataTable GetPhongByID(string Id)
        {
            return DAL_Phong.Instance.GetPhongByID(Id);
        }

        #endregion

        #region Update trạng thái

        /// <summary>
        /// Update trạng thái
        /// </summary>
        /// <returns></returns>
        public bool UpdateTrangThai(string Id, int tt)
        {
            return DAL_Phong.Instance.UpdateTrangThai(Id, tt);
        }

        #endregion

        //public string GetMaxIDPhong()
        //{
        //	return PhongDao.GetMaxIDPhong();
        //}

        public bool InsertDefault(string Id)
        {
            return DAL_Phong.Instance.InsertDefault(Id);
        }
        public bool Insert(DTO_Phong phong)
        {
            return DAL_Phong.Instance.Insert(phong);
        }

        public void Update(string Id, string gia, string LoaiPhong)
        {
            DAL_Phong.Instance.Update(Id, gia, LoaiPhong);
        }

        public void Delete(string Id)
        {
            DAL_Phong.Instance.Delete(Id);
        }
        public DataTable GetPhongMaPhong()
        {
            return DAL_Phong.Instance.GetPhongMaPhong();
        }
        public DataTable GetPhongMaPhongByTinhTrang(string tt)
        {
            return DAL_Phong.Instance.GetPhongMaPhongByTinhTrang(tt);
        }
        public DataTable GetPhongMaPhongByTinhTrangAndID(string tt, string id)
        {
            return DAL_Phong.Instance.GetPhongMaPhongByTinhTrangAndID(tt,id);
         }
        public DataTable GetPhongMaPhongByID(string id)
        {
            return DAL_Phong.Instance.GetPhongMaPhongByID(id);
        }
        public DataTable GetThongTinKhachHang()
        {
            return DAL_Phong.Instance.GetThongTinKhachHang();
        }
        public DataTable GetThongTinKhachHangByID(string id)
        {
            return DAL_Phong.Instance.GetThongTinKhachHangByID((string)id);
        }
        public DataTable GetPhongByTinhTrangAndLoaiPhong(string trangThaiPhong, string loaiPhong)
        {
            return DAL_Phong.Instance.GetPhongByTinhTrangAndLoaiPhong(trangThaiPhong,loaiPhong);
        }
        public DataTable GetPhongByLoaiPhong(string loaiPhong)
        {
            return DAL_Phong.Instance.GetPhongByLoaiPhong((string)loaiPhong);
        }


    }
}
