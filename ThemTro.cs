using BUS;
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
    public partial class ThemTro : Form
    {
        string IDCHUTRO = string.Empty;
        public ThemTro()
        {
            InitializeComponent();
        }
        public ThemTro(string id)
        {
            InitializeComponent();
            IDCHUTRO = id;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string diachi = textBox1.Text;
            //string sophong = textBox2.Text;
            string sonuoc = textBox3.Text;
            string sodien = textBox4.Text;
            BUS_Tro.Instance.ThemDayTroMoi(IDCHUTRO, diachi, sodien, sonuoc);
            MessageBox.Show("Thêm dãy trọ mới thành công");
        }
    }
}
