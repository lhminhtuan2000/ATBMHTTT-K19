using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System.Configuration;

namespace PROJECT
{
    public partial class MH_BenhNhan : Form
    {
        string username;
        string password;
        public MH_BenhNhan()
        {
            InitializeComponent();
        }
        public MH_BenhNhan(string user_name, string pass_word)
        {
            InitializeComponent();
            username = user_name;
            password = pass_word;
            dgv1_loaddata();
        }
        public void dgv1_loaddata()
        {
            List<string> varList = new List<string>();
            DataTable dt = new DataTable();

            dt = Program.loadDT("qlbv_dba.SP_XEMTHONGTINCANHAN", username, password, varList, varList);
            tb1.Text = dt.Rows[0]["macsyt"].ToString();
            tb2.Text = dt.Rows[0]["tenbn"].ToString();
            tb3.Text = dt.Rows[0]["cmnd"].ToString();
            tb4.Text = dt.Rows[0]["ngaysinh"].ToString();
            tb5.Text = dt.Rows[0]["sonha"].ToString();
            tb6.Text = dt.Rows[0]["tenduong"].ToString();
            tb7.Text = dt.Rows[0]["quanhuyen"].ToString();
            tb8.Text = dt.Rows[0]["tinhtp"].ToString();
            tb9.Text = dt.Rows[0]["tiensubenh"].ToString();
            tb10.Text = dt.Rows[0]["tiensubenhgd"].ToString();
            tb11.Text = dt.Rows[0]["diungthuoc"].ToString();
        }
        private void ThoátTSMI_Click(object sender, EventArgs e)
        {
            Program.loadForm(new MH_Login(), this);
        }
    }
}
