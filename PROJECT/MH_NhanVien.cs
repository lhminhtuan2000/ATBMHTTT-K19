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
    public partial class MH_NhanVien : Form
    {
        string username;
        string password;
        string roleName;
        public MH_NhanVien()
        {
            InitializeComponent();
        }
        public MH_NhanVien(string user_name, string pass_word, string role)
        {
            InitializeComponent();
            username = user_name;
            password = pass_word;
            roleName = role;
            if (roleName == "THANHTRA")
            {
                đọcDữLiệuTSMI.Visible = true;
            }
            if (roleName == "CSYT")
            {
                quảnLýTSMI.Visible = true;
            }
            if (roleName == "NGHIENCUU" || roleName == "YSBS")
            {
                HSBATSMI.Visible = true;
            }
            if (roleName == "YSBS")
            {
                bệnhNhânTSMI.Visible = true;
            }
            if (roleName == "GIAMDOC") // fix khi co' solution OLS
            {
                thôngBáoTSMT.Visible = true;
            }
            dgv1_loaddata();
        }
        public void dgv1_loaddata()
        {
            List<string> varList = new List<string>();
            DataTable dt = new DataTable();

            dt = Program.loadDT("qlbv_dba.SP_XEMTHONGTINCANHAN", username, password, varList, varList);
            tb1.Text = dt.Rows[0]["hoten"].ToString();
            cb1.Text = dt.Rows[0]["phai"].ToString();
            tb3.Text = dt.Rows[0]["ngaysinh"].ToString();
            tb4.Text = dt.Rows[0]["cmnd"].ToString();
            tb5.Text = dt.Rows[0]["quequan"].ToString();
            tb6.Text = dt.Rows[0]["sodt"].ToString();
            tb7.Text = dt.Rows[0]["csyt"].ToString();
            cb2.Text = dt.Rows[0]["vaitro"].ToString();
            tb9.Text = dt.Rows[0]["chuyenkhoa"].ToString();
        }
        private void bt_capnhat_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            String conString = connectionString.Replace("@@@", username).Replace("###", password);
            using (OracleConnection con = new OracleConnection(conString))
            {
                con.Open();
                OracleCommand cmd = new OracleCommand("qlbv_dba.SP_CAPNHATTTNHANVIEN", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("P_HOTEN", OracleDbType.Int64, tb1.Text.ToString(), ParameterDirection.Input);
                cmd.Parameters.Add("P_PHAI", OracleDbType.NVarchar2, cb1.SelectedItem.ToString(), ParameterDirection.Input);
                cmd.Parameters.Add("P_NGAYSINH", OracleDbType.Varchar2, tb3.Text.ToString(), ParameterDirection.Input);
                cmd.Parameters.Add("P_CMND", OracleDbType.Date, tb4.Text.ToString(), ParameterDirection.Input);
                cmd.Parameters.Add("P_QUEQUAN", OracleDbType.Varchar2, tb5.Text.ToString(), ParameterDirection.Input);
                cmd.Parameters.Add("P_SODT", OracleDbType.NVarchar2, tb6.Text.ToString(), ParameterDirection.Input);
                cmd.Parameters.Add("P_CSYT", OracleDbType.NVarchar2, tb7.Text.ToString(), ParameterDirection.Input);
                cmd.Parameters.Add("P_VAITRO", OracleDbType.NVarchar2, cb2.SelectedItem.ToString(), ParameterDirection.Input);
                cmd.Parameters.Add("P_CHUYENKHOA", OracleDbType.NVarchar2, tb9.Text.ToString(), ParameterDirection.Input);

                DataTable dt = new DataTable();
                dt.Clear();
                try
                {
                    OracleDataAdapter oda = new OracleDataAdapter(cmd);
                    oda.Fill(dt);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Exception: {0}");
                }
                dgv1_loaddata();
            }
        }
        private void HSBATSMI_Click(object sender, EventArgs e)
        {
            if (roleName == "NGHIENCUU")
            {
                Program.loadForm(new MH_NghienCuu_HSBA(username, password, roleName), this);
            }
            if (roleName == "YSBS")
            {
                Program.loadForm(new MH_YSBS_HSBA(username, password, roleName), this);
            }
        }
        private void bệnhNhânTSMI_Click(object sender, EventArgs e)
        {
            Program.loadForm(new MH_YSBS_BN(username, password, roleName), this);
        }
        private void thôngBáoTSMT_Click(object sender, EventArgs e)
        {
            Program.loadForm(new MH_GiamDoc(username, password, roleName), this);
        }
        private void quảnLýTSMI_Click(object sender, EventArgs e)
        {
            Program.loadForm(new MH_CSYT(username, password, roleName), this);
        }
        private void đọcDữLiệuTSMI_Click(object sender, EventArgs e)
        {
            Program.loadForm(new MH_ThanhTra(username, password, roleName), this);
        }
        private void ThoátTSMI_Click(object sender, EventArgs e)
        {
            Program.loadForm(new MH_Login(), this);
        }

    }
}
