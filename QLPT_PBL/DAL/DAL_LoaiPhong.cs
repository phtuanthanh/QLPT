using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class DAL_LoaiPhong
    {
        private static DAL_LoaiPhong _instance;
        public static DAL_LoaiPhong Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new DAL_LoaiPhong();
                return _instance;
            }
            private set { _instance = value; }
        }
        public DAL_LoaiPhong() { }
        #region Get danh sách loại phòng

        /// <summary>
        /// Get danh sách loại phòng
        /// </summary>
        /// <returns></returns>
        public DataTable GetLoaiPhong()
		{
            string query = string.Format("SELECT * FROM LoaiPhong");
            DataTable dtLoaiPhong = new DataTable();
            dtLoaiPhong = DAL_DBHelper.Instance.GetRecords(query);
            return dtLoaiPhong;
        }

		#endregion

		#region Get danh sách phong theo ma phong

		/// <summary>
		/// Get danh sách phong theo ma phong
		/// </summary>
		/// <returns></returns>
		public DataTable GetLoaiPhongByID(string Id)
		{
            string query = string.Format("SELECT * FROM LoaiPhong WHERE ID_LoaiPhong = {0} AND DelFlg = 0", Id);
            DataTable dtLoaiPhong = new DataTable();
            dtLoaiPhong = DAL_DBHelper.Instance.GetRecords(query);
            return dtLoaiPhong;
        }
        public DataTable GetThongTinPhong(string Id)
        {
            string query = string.Format("select * from Phong join LoaiPhong on Phong.ID_LoaiPhong = LoaiPhong.ID_LoaiPhong where ID_Phong ='{0}'", Id);
            DataTable dtLoaiPhong = new DataTable();
            dtLoaiPhong = DAL_DBHelper.Instance.GetRecords(query);
            return dtLoaiPhong;
        }
        public int GetGia(string Id)
        {
            string query = string.Format("select Gia from LoaiPhong where ID_LoaiPhong='{0}'",Id);
            int gia = 1;
            DataTable dtLoaiPhong = DAL_DBHelper.Instance.GetRecords(query);
            foreach (DataRow row in dtLoaiPhong.Rows)
            {
                gia = Convert.ToInt32(row["Gia"].ToString());
            }
            return gia;
        }
        #endregion
    }
}
