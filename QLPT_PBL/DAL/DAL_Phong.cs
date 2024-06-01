using DAL;
using DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_Phong
    {
        private static DAL_Phong _instance;
        public static DAL_Phong Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new DAL_Phong();
                return _instance;
            }
            private set { _instance = value; }
        }
        public DAL_Phong() { }
        #region Get danh sách phòng

        /// <summary>
        /// Get danh sách phòng
        /// </summary>
        /// <returns></returns>
        public DataTable GetPhong()
		{
            string query = string.Format("SELECT * FROM Phong WHERE DelFlag = 0");
            DataTable dtPhong = new DataTable();
            dtPhong = DAL_DBHelper.Instance.GetRecords(query);
            return dtPhong;
        }
        #endregion

        #region Get danh sách phong theo ma phong

        /// <summary>
        /// Get danh sách phong theo ma phong
        /// </summary>
        /// <returns></returns>
        public DataTable GetPhongByID(string Id)
		{
            string query = string.Format("SELECT * FROM Phong WHERE ID_Phong ={0} AND DelFlag = 0",Id);
            DataTable dtPhong = new DataTable();
            dtPhong = DAL_DBHelper.Instance.GetRecords(query);
            return dtPhong;
        }

		#endregion

		#region Update trạng thái

		/// <summary>
		/// Update trạng thái
		/// </summary>
		/// <param name="Id"></param>
		/// <returns></returns>
		public bool UpdateTrangThai(string Id, int tt)
		{
			string query = string.Format("UPDATE Phong SET TrangThai ='{0}' WHERE ID_Phong = '{1}'", tt, Id);
            DataTable dtPhong = new DataTable();
            dtPhong = DAL_DBHelper.Instance.GetRecords(query);
            return true;
		}

		#endregion

		#region

		/// <summary>
		/// 
		/// </summary>
		/// <param name="Id"></param>
		/// <returns></returns>
		public bool InsertDefault(string id)
		{
			string query = "INSERT INTO Phong (ID_Phong,ID_LoaiPhong,Gia,TrangThai,DelFlag) VALUES( '" + id + "','00','1000000','0',0);";
            DataTable dtPhong = new DataTable();
            dtPhong = DAL_DBHelper.Instance.GetRecords(query);
            return true;
		}
        public bool Insert(DTO_Phong phong)
        {
            string query = string.Format("INSERT INTO Phong (ID_Phong,ID_LoaiPhong,TrangThai,DelFlag) VALUES('{0}','{1}','{2}','{3}')",phong.IdPhong,phong.LoaiPhong,phong.TrangThai,phong.DelFlag);
            DataTable dtPhong = new DataTable();
            dtPhong = DAL_DBHelper.Instance.GetRecords(query);
            return true;
        }

        #endregion

        //public string GetMaxIDPhong()
        //{
        //	string idPhong = string.Empty;

        //	_conn.Open();
        //	SqlCommand command = new SqlCommand("SELECT TOP 1 ID_Phong FROM Phong order by ID_Phong DESC", _conn);
        //	using (SqlDataReader reader = command.ExecuteReader())
        //	{
        //		if (reader.Read())
        //		{
        //			idPhong = reader["ID_Phong"].ToString();
        //		}
        //	}
        //	_conn.Close();

        //	return idPhong;
        //}

        public void Update(string Id, string gia, string LoaiPhong)
		{
			string query = "UPDATE Phong SET ID_LoaiPhong = '" + LoaiPhong + "', Gia ='" + gia + "' WHERE ID_Phong = '" + Id + "';";
            DataTable dtPhong = new DataTable();
            dtPhong = DAL_DBHelper.Instance.GetRecords(query);
        }
        //1000000280000
		public void Delete(string Id)
		{
			string query = "Delete from Phong WHERE ID_Phong = '" + Id + "';";
            DAL_DBHelper.Instance.ExecuteDB(query); 
		}
		public DataTable GetPhongMaPhong() {
            string query = string.Format("SELECT  ID_Phong,LoaiPhong.ID_LoaiPhong,TenLoaiPhong,Gia,TrangThai from Phong join LoaiPhong on Phong.ID_LoaiPhong = LoaiPhong.ID_LoaiPhong");
            DataTable dtPhong = new DataTable();
            dtPhong = DAL_DBHelper.Instance.GetRecords(query);
            return dtPhong;
        }
        public DataTable GetPhongMaPhongByID(string id)
        {
            string query = string.Format("Select * from Phong join LoaiPhong on Phong.ID_LoaiPhong = LoaiPhong.ID_LoaiPhong Where ID_Phong='{0}' ",id);
            DataTable dtPhong = new DataTable();
            dtPhong = DAL_DBHelper.Instance.GetRecords(query);
            return dtPhong;
        }
        public DataTable GetPhongMaPhongByTinhTrang(string tt)
        {
            string query = string.Format("Select * from Phong join LoaiPhong on Phong.ID_LoaiPhong = LoaiPhong.ID_LoaiPhong where TrangThai='{0}' ",tt);
            DataTable dtPhong = new DataTable();
            dtPhong = DAL_DBHelper.Instance.GetRecords(query);
            return dtPhong;
        }
        public DataTable GetPhongMaPhongByTinhTrangAndID(string tt,string id)
        {
            string query = string.Format("Select * from Phong join LoaiPhong on Phong.ID_LoaiPhong = LoaiPhong.ID_LoaiPhong where TrangThai='{0}' AND ID_Phong='{1}' ", tt,id);
            DataTable dtPhong = new DataTable();
            dtPhong = DAL_DBHelper.Instance.GetRecords(query);
            return dtPhong;
        }
        public DataTable GetPhongByTinhTrangAndLoaiPhong(string trangThaiPhong, string loaiPhong)
        {
            string query = string.Format("Select * from Phong join LoaiPhong on Phong.ID_LoaiPhong = LoaiPhong.ID_LoaiPhong where TrangThai='{0}' AND LoaiPhong.ID_LoaiPhong='{1}' ", trangThaiPhong,loaiPhong);
            DataTable dtPhong = new DataTable();
            dtPhong = DAL_DBHelper.Instance.GetRecords(query);
            return dtPhong;
        }
        public DataTable GetPhongByLoaiPhong(string loaiPhong)
        {
            string query = string.Format("Select * from Phong join LoaiPhong on Phong.ID_LoaiPhong = LoaiPhong.ID_LoaiPhong where LoaiPhong.ID_LoaiPhong='{0}' ",loaiPhong);
            DataTable dtPhong = new DataTable();
            dtPhong = DAL_DBHelper.Instance.GetRecords(query);
            return dtPhong;
        }
        public DataTable GetThongTinKhachHang()
        {
            string query = string.Format("SELECT DISTINCT  ID_KhachHang as ID,TenKhachHang as [Tên khách hàng],TenTaiKhoan as [Tài khoản],Password as [Mật khẩu],CCCD,SoDienThoai as [Số điện thoại],DiaChi as [Địa chỉ],MaPhong as [Phòng],Gia as [Giá] from Phong join LoaiPhong on Phong.ID_LoaiPhong = LoaiPhong.ID_LoaiPhong join KhachHang on KhachHang.[MaPhong] = Phong.ID_Phong");
            DataTable dtPhong = new DataTable();
            dtPhong = DAL_DBHelper.Instance.GetRecords(query);
            return dtPhong;
        }
        public DataTable GetThongTinKhachHangByID(string id)
        {
            string query = string.Format("SELECT DISTINCT  ID_KhachHang,TenKhachHang,TenTaiKhoan,Password,CCCD,SoDienThoai,DiaChi,MaPhong,TenLoaiPhong,Gia,TrangThai from Phong join LoaiPhong on Phong.ID_LoaiPhong = LoaiPhong.ID_LoaiPhong join KhachHang on KhachHang.[MaPhong] = Phong.ID_Phong where KhachHang.ID_KhachHang='{0}'",id);
            DataTable dtPhong = new DataTable();
            dtPhong = DAL_DBHelper.Instance.GetRecords(query);
            return dtPhong;
        }
  
    }
}
