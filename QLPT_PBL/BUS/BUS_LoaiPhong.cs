using DAL;
using DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class BUS_LoaiPhong
    {
        private static BUS_LoaiPhong _instance;
        public static BUS_LoaiPhong Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new BUS_LoaiPhong();
                return _instance;
            }
            private set { _instance = value; }
        }
        #region Get danh sách loại phòng

        /// <summary>
        /// Get danh sách loại phòng
        /// </summary>
        /// <returns></returns>
        public DataTable GetLoaiPhong()
		{
            return DAL_LoaiPhong.Instance.GetLoaiPhong();
        }

        #endregion

        #region Get danh sách loại phong theo ma phong

        /// <summary>
        /// Get danh sách loại phong theo ma phong
        /// </summary>
        /// <returns></returns>
        public DataTable GetLoaiPhongByID(string Id)
		{
            return DAL_LoaiPhong.Instance.GetLoaiPhongByID(Id);
        }
        public DataTable GetThongTinPhong(string Id)
        {
            return DAL_LoaiPhong.Instance.GetThongTinPhong(Id);
        }
        public int GetGia(string Id)
        {
            return DAL_LoaiPhong.Instance.GetGia(Id);
        }
        #endregion
    }
}
