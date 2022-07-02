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
    public partial class MH_CSYT : Form
    {
        string connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        string username;
        string password;
        string roleName;
        public MH_CSYT()
        {
            InitializeComponent();
        }
        public MH_CSYT(string user_name, string pass_word, string role)
        {
            InitializeComponent();
            username = user_name;
            password = pass_word;
            roleName = role;
        }
        public void dgv1_loaddata()
        {
            String conString = connectionString.Replace("@@@", username).Replace("###", password);
            using (OracleConnection con = new OracleConnection(conString))
            {
                con.Open();
                OracleCommand cmd = new OracleCommand("qlbv_dba.sp_csyt_xemhsba", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("p_mahsba", OracleDbType.Int64, tb1.Text.ToString(), ParameterDirection.Input);

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
                tb1.Text = dt.Rows[0]["mahsba"].ToString();
                tb2.Text = dt.Rows[0]["mabn"].ToString();
                tb3.Text = dt.Rows[0]["ngay"].ToString();
                tb4.Text = dt.Rows[0]["chandoan"].ToString();
                tb5.Text = dt.Rows[0]["mabs"].ToString();
                tb6.Text = dt.Rows[0]["makhoa"].ToString();
                tb7.Text = dt.Rows[0]["macsyt"].ToString();
                tb8.Text = dt.Rows[0]["ketluan"].ToString();
            }
        }
        public void dgv2_loaddata(string mahsba)
        {
            String conString = connectionString.Replace("@@@", username).Replace("###", password);
            using (OracleConnection con = new OracleConnection(conString))
            {
                con.Open();
                OracleCommand cmd = new OracleCommand("qlbv_dba.sp_csyt_xemhsba_dv", con);
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
        private void bt_timHSBA_Click(object sender, EventArgs e)
        {
            String conString = connectionString.Replace("@@@", username).Replace("###", password);
            using (OracleConnection con = new OracleConnection(conString))
            {
                con.Open();
                string mahsba = tb1.Text.ToString();
                OracleCommand cmd = new OracleCommand("qlbv_dba.sp_csyt_xemhsba", con);
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
        private void bt_themHSBA_Click(object sender, EventArgs e)
        {
            String conString = connectionString.Replace("@@@", username).Replace("###", password);
            using (OracleConnection con = new OracleConnection(conString))
            {
                con.Open();
                OracleCommand cmd = new OracleCommand("qlbv_dba.sp_csyt_them_HSBA", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("p_mahsba", OracleDbType.Int64, tb1.Text.ToString(), ParameterDirection.Input);
                cmd.Parameters.Add("p_mabn", OracleDbType.Int64, tb2.Text.ToString(), ParameterDirection.Input);
                cmd.Parameters.Add("p_ngay", OracleDbType.Date, tb3.Text.ToString(), ParameterDirection.Input);
                cmd.Parameters.Add("p_chandoan", OracleDbType.NVarchar2, tb4.Text.ToString(), ParameterDirection.Input);
                cmd.Parameters.Add("p_mabs", OracleDbType.Int64, tb5.Text.ToString(), ParameterDirection.Input);
                cmd.Parameters.Add("p_makhoa", OracleDbType.Int64, tb6.Text.ToString(), ParameterDirection.Input);
                cmd.Parameters.Add("p_macsyt", OracleDbType.Int64, tb7.Text.ToString(), ParameterDirection.Input);
                cmd.Parameters.Add("p_ketluan", OracleDbType.NVarchar2, tb8.Text.ToString(), ParameterDirection.Input);

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
        private void bt_xoaHSBA_Click(object sender, EventArgs e)
        {
            String conString = connectionString.Replace("@@@", username).Replace("###", password);
            using (OracleConnection con = new OracleConnection(conString))
            {
                con.Open();
                OracleCommand cmd = new OracleCommand("qlbv_dba.sp_csyt_xoa_HSBA", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("p_mahsba", OracleDbType.Int64, tb1.Text.ToString(), ParameterDirection.Input);

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
        private void bt_themHSBA_DV_Click(object sender, EventArgs e)
        {
            String conString = connectionString.Replace("@@@", username).Replace("###", password);
            using (OracleConnection con = new OracleConnection(conString))
            {
                con.Open();
                OracleCommand cmd = new OracleCommand("qlbv_dba.sp_csyt_them_HSBA_DV", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("p_mahsba", OracleDbType.Int64, tb1.Text.ToString(), ParameterDirection.Input);
                cmd.Parameters.Add("p_madv", OracleDbType.Int64, tb9.Text.ToString(), ParameterDirection.Input);
                cmd.Parameters.Add("p_ngay", OracleDbType.Date, tb10.Text.ToString(), ParameterDirection.Input);
                cmd.Parameters.Add("p_maktv", OracleDbType.Int64, tb11.Text.ToString(), ParameterDirection.Input);
                cmd.Parameters.Add("p_ketqua", OracleDbType.NVarchar2, tb12.Text.ToString(), ParameterDirection.Input);

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
                dgv2_loaddata(tb1.Text.ToString());
            }
        }
        private void bt_xoaHSBA_DV_Click(object sender, EventArgs e)
        {
            String conString = connectionString.Replace("@@@", username).Replace("###", password);
            using (OracleConnection con = new OracleConnection(conString))
            {
                con.Open();
                OracleCommand cmd = new OracleCommand("qlbv_dba.sp_csyt_xoa_HSBA_DV", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("p_mahsba", OracleDbType.Int64, tb1.Text.ToString(), ParameterDirection.Input);
                cmd.Parameters.Add("p_madv", OracleDbType.Int64, tb9.Text.ToString(), ParameterDirection.Input);
                cmd.Parameters.Add("p_ngay", OracleDbType.Date, tb10.Text.ToString(), ParameterDirection.Input);

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
                dgv2_loaddata(tb1.Text.ToString());
            }
        }
        private void bt_tracuuBS_Click(object sender, EventArgs e)
        {
            using (var form = new MH_TraCuu(username, password, "NHANVIEN"))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string val = form.ReturnValue1;
                    tb5.Text = val;
                }
            }
        }
        private void bt_tracuuKhoa_Click(object sender, EventArgs e)
        {
            using (var form = new MH_TraCuu(username, password, "KHOA"))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string val = form.ReturnValue1;
                    tb6.Text = val;
                }
            }
        }
        private void bt_tracuuDV_Click(object sender, EventArgs e)
        {
            using (var form = new MH_TraCuu(username, password, "DICHVU"))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string val = form.ReturnValue1;
                    tb9.Text = val;
                }
            }
        }
        private void bt_tracuuKTV_Click(object sender, EventArgs e)
        {
            using (var form = new MH_TraCuu(username, password, "NHANVIEN"))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string val = form.ReturnValue1;
                    tb11.Text = val;
                }
            }
        }
        private void infoTSMI_Click(object sender, EventArgs e)
        {
            Program.loadForm(new MH_NhanVien(username, password, roleName), this);
        }
        private void ThoátTSMI_Click(object sender, EventArgs e)
        {
            Program.loadForm(new MH_Login(), this);
        }

    }
}
