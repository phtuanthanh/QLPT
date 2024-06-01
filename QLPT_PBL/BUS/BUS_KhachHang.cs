using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class BUS_KhachHang
    {
        private static BUS_KhachHang _instance;
        public static BUS_KhachHang Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new BUS_KhachHang();
                return _instance;
            }
            private set { _instance = value; }
        }
        public BUS_KhachHang() { }
        public DataTable GetKhachHangByID(string id)
        {
            return DAL_KhachHang.Instance.GetKhachHangByID(id);
        }
        public DataTable GetKhachHangByUserNameAndPassWord(string UserName, string PassWord)
        {
            return DAL_KhachHang.Instance.GetKhachHangByUserNameAndPassWord(UserName, PassWord);
        }
        public DataTable GetKhachHangByUserName(string UserName)
        {
            return DAL_KhachHang.Instance.GetKhachHangByUserName(UserName);
        }
        public DataTable GetKhachHangByIdPhong(string Id)
        {
            return DAL_KhachHang.Instance.GetKhachHangByIdPhong(Id);
        }
        public bool Update(DTO_KhachHang tk)
        {
           return DAL_KhachHang.Instance.Update(tk);
        }
        public void Delete(string id)
        {
           DAL_KhachHang.Instance.Delete(id);
        }
        public DataTable GetPhongByUserNamePassWord(string UserName, string PassWord)
        {
            return DAL_KhachHang.Instance.GetPhongByUserNamePassWord(UserName, PassWord);
        }
        public bool ThayDoiUserNamePassWord(string newPass, string userName, string pass)
        {
            return DAL_KhachHang.Instance.ThayDoiUserNamePassWord(newPass,userName,pass);
        }
    }
}

