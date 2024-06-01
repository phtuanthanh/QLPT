using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_ThongKe
    {
        private static DAL_ThongKe _instance;
        public static DAL_ThongKe Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new DAL_ThongKe();
                return _instance;
            }
            private set { _instance = value; }
        }
        public DAL_ThongKe() { }
        #region Get danh sach dien nuoc

        /// <summary>
        /// Get danh sách khách hàng
        /// </summary>
        /// <returns></returns>
        public DataTable GetThongKebyID(string id)
        { 
            string query = string.Format("SELECT ThoiGian as [Thời gian],SoDienTieuThu as [Số điện tiêu thụ],SoNuocTieuThu as [Số nước tiêu thụ],DonGiaDien as [Đơn giá điện],DonGiaNuoc as [Đơn giá nước], TienPhong as [Tiền phòng],ThongKe.TongTien as [Thống kê] FROM ThongKe join DienNuoc on ThongKe.ID_Phong= DienNuoc.ID_Phong WHERE ThongKe.ID_Phong = '{0}'", id);
            DataTable dtKhachHang = new DataTable();
            dtKhachHang = DAL_DBHelper.Instance.GetRecords(query);
            return dtKhachHang;
        }
        public string InsertDienNuoc(string time,int sodien,int sonuoc,int tienphong,int tongtien,string id)
        {
            string query = string.Format("Insert into ThongKe values ('{0}','{1}','{2}','{3}','{4}','{5}')", time, sodien, sonuoc, tienphong, tongtien,id);
            DAL_DBHelper.Instance.ExecuteDB(query);
            return query;
        }
        public void Delete(string id) {
            string query = string.Format("Delete ThongKe Where ID_Phong='{0}'", id);
            DAL_DBHelper.Instance.ExecuteDB(query);
        }
        #endregion
    }
}

