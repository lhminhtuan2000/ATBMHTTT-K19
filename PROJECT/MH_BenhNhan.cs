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
        private void bt_capnhat_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            String conString = connectionString.Replace("@@@", username).Replace("###", password);
            using (OracleConnection con = new OracleConnection(conString))
            {
                con.Open();
                OracleCommand cmd = new OracleCommand("qlbv_dba.SP_CAPNHATTTBENHNHAN", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("P_MACSYT", OracleDbType.Int64, tb1.Text.ToString(), ParameterDirection.Input);
                cmd.Parameters.Add("P_TENBN", OracleDbType.NVarchar2, tb2.Text.ToString(), ParameterDirection.Input);
                cmd.Parameters.Add("P_CMND", OracleDbType.Varchar2, tb3.Text.ToString(), ParameterDirection.Input);
                cmd.Parameters.Add("P_NGAYSINH", OracleDbType.Date, tb4.Text.ToString(), ParameterDirection.Input);
                cmd.Parameters.Add("P_SONHA", OracleDbType.Varchar2, tb5.Text.ToString(), ParameterDirection.Input);
                cmd.Parameters.Add("P_TENDUONG", OracleDbType.NVarchar2, tb6.Text.ToString(), ParameterDirection.Input);
                cmd.Parameters.Add("P_QUANHUYEN", OracleDbType.NVarchar2, tb7.Text.ToString(), ParameterDirection.Input);
                cmd.Parameters.Add("P_TINHTP", OracleDbType.NVarchar2, tb8.Text.ToString(), ParameterDirection.Input);
                cmd.Parameters.Add("P_TIENSUBENH", OracleDbType.NVarchar2, tb9.Text.ToString(), ParameterDirection.Input);
                cmd.Parameters.Add("P_TIENSUBENHGD", OracleDbType.NVarchar2, tb10.Text.ToString(), ParameterDirection.Input);
                cmd.Parameters.Add("P_DIUNGTHUOC", OracleDbType.NVarchar2, tb11.Text.ToString(), ParameterDirection.Input);

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
        private void ThoátTSMI_Click(object sender, EventArgs e)
        {
            Program.loadForm(new MH_Login(), this);
        }

    }
}
