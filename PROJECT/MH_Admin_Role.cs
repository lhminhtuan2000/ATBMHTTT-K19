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
using System.Configuration; // To Access App Config Attributes
namespace PROJECT
{
    public partial class MH_Admin_Role : Form
    {
        OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        public MH_Admin_Role()
        {
            InitializeComponent();
            dgv1_loaddata();
            dgv3_loaddata();
        }
        public void dgv1_loaddata()
        {
            OracleCommand cmd = new OracleCommand("sp_list_all_role", con);
            cmd.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            dt.Clear();
            try
            {
                con.Open();
                OracleDataAdapter oda = new OracleDataAdapter(cmd);
                oda.Fill(dt);
                dgv1.DataSource = dt;
                dgv1.AutoResizeColumnHeadersHeight();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Exception: {0}", ex.ToString());
            }
            con.Close();
        }
        public void dgv2_loaddata(string role_name)
        {
            OracleCommand cmd = new OracleCommand("sp_show_role_privileges", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("role_name", OracleDbType.Varchar2).Value = role_name;
            try
            {
                OracleDataAdapter oda = new OracleDataAdapter(cmd);
                con.Open();
                DataTable dt = new DataTable();
                dt.Clear();
                oda.Fill(dt);
                dgv2.DataSource = dt;
                dgv2.AutoResizeColumnHeadersHeight();

            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Exception: {0}", ex.ToString());
            }
            con.Close();
        }
        public void dgv3_loaddata()
        {
            OracleCommand cmd = new OracleCommand("sp_list_all_user", con);
            cmd.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            dt.Clear();
            try
            {
                con.Open();
                OracleDataAdapter oda = new OracleDataAdapter(cmd);
                oda.Fill(dt);
                dgv3.DataSource = dt;
                dgv3.AutoResizeColumnHeadersHeight();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Exception: {0}", ex.ToString());
            }
            con.Close();
        }

        private void dgv1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int rowIndex = dgv1.CurrentCell.RowIndex;
                string role_name = dgv1.Rows[rowIndex].Cells[0].Value.ToString();
                tb1.Text = role_name;
                dgv2_loaddata(role_name);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Exception: {0}", ex.ToString());
            }
        }

        private void bt_them_Click(object sender, EventArgs e)
        {
            string role_name = tb1.Text.ToString();

            OracleCommand cmd = new OracleCommand("sp_create_role", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("role_name", OracleDbType.Varchar2).Value = role_name;
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                tb1.Clear();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Exception: {0}", ex.ToString());
            }
            con.Close();
            dgv1_loaddata();
        }
        private void bt_xoa_Click(object sender, EventArgs e)
        {
            string role_name = tb1.Text.ToString();
            OracleCommand cmd = new OracleCommand("sp_delete_role", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("role_name", OracleDbType.Varchar2).Value = role_name;

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                tb1.Clear();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Exception: {0}", ex.ToString());
            }
            con.Close();
            dgv1_loaddata();
        }
        private void cb_cot_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dgv3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int rowIndex = dgv3.CurrentCell.RowIndex;
                string username = dgv3.Rows[rowIndex].Cells[0].Value.ToString();
                tb2.Text = username;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Exception: {0}", ex.ToString());
            }
        }

        private void ngườiDùngTSMI_Click(object sender, EventArgs e)
        {
            Program.loadForm(new MH_Admin_User(), this);
        }

        private void CSYTTSMI_Click(object sender, EventArgs e)
        {
            Program.loadForm(new MH_Admin_CSYT(), this);
        }
    }
}
