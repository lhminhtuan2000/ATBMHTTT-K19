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
    public partial class MH_YSBS_HSBA : Form
    {
        string username;
        string password;
        string roleName;
        public MH_YSBS_HSBA()
        {
            InitializeComponent();
        }
        public MH_YSBS_HSBA(string user_name, string pass_word, string role)
        {
            InitializeComponent();
            username = user_name;
            password = pass_word;
            roleName = role;
        }
        public void dgv2_loaddata(string mahsba)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            String conString = connectionString.Replace("@@@", username).Replace("###", password);
            using (OracleConnection con = new OracleConnection(conString))
            {
                con.Open();
                OracleCommand cmd = new OracleCommand("qlbv_dba.sp_ybs_xemHSBA_DV", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("p_mahsba", OracleDbType.Int64, mahsba, ParameterDirection.Input);

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
                dgv2.DataSource = dt;
                dgv2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
        }
        private void bt_timHSBA_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            String conString = connectionString.Replace("@@@", username).Replace("###", password);
            using (OracleConnection con = new OracleConnection(conString))
            {
                con.Open();
                string mahsba = tb1.Text.ToString();
                OracleCommand cmd = new OracleCommand("qlbv_dba.sp_ybs_xemHSBA", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("p_mahsba", OracleDbType.Int64, mahsba, ParameterDirection.Input);

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
                dgv1.DataSource = dt;
                dgv1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dgv2_loaddata(mahsba);
            }
        }
        private void dgv1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int rowIndex = dgv1.CurrentCell.RowIndex;
                string mahsba = dgv1.Rows[rowIndex].Cells[0].Value.ToString();
                dgv2_loaddata(mahsba);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Exception: {0}");
            }
        }
        private void infoTSMI_Click(object sender, EventArgs e)
        {
            Program.loadForm(new MH_NhanVien(username, password, roleName), this);
        }
        private void bệnhNhânTSMI_Click(object sender, EventArgs e)
        {
            Program.loadForm(new MH_YSBS_BN(username, password, roleName), this);
        }
        private void ThoátTSMI_Click(object sender, EventArgs e)
        {
            Program.loadForm(new MH_Login(), this);
        }
    }
}
