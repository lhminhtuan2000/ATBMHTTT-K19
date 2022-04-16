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
    public partial class MH_Admin_1 : Form
    {
        OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        public MH_Admin_1()
        {
            InitializeComponent();
            dgv1_loaddata();
        }
        public void dgv1_loaddata()
        {
            OracleCommand cmd = new OracleCommand("sp_list_all_user", con);
            //OracleCommand cmd = new OracleCommand("SELECT username,password,default_tablespace FROM dba_users WHERE account_status = 'OPEN'", con);
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

        public void dgv2_loaddata(string username)
        {
            try
            {
                //OracleCommand cmd = new OracleCommand("exec sp_show_user_privilges('" + username + "')", con);
                OracleCommand cmd = new OracleCommand("SELECT privilege,ADMIN_OPTION FROM DBA_SYS_PRIVS where grantee = UPPER('" + username + "')", con);
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

        private void dgv1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int rowIndex = dgv1.CurrentCell.RowIndex;
                string username = dgv1.Rows[rowIndex].Cells[0].Value.ToString();
                string password = dgv1.Rows[rowIndex].Cells[1].Value.ToString();
                tb1.Text = username;
                tb2.Text = password;
                dgv2_loaddata(username);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Exception: {0}", ex.ToString());
            }
        }

        private void bt_them_Click(object sender, EventArgs e)
        {
            string username = tb1.Text.ToString();
            string password = tb2.Text.ToString();

            OracleCommand cmd = new OracleCommand("sp_create_user", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("username", OracleDbType.Varchar2).Value = username;
            cmd.Parameters.Add("password", OracleDbType.Varchar2).Value = password;
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
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
            string username = tb1.Text.ToString();
            OracleCommand cmd = new OracleCommand("sp_delete_user", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("username", OracleDbType.Varchar2).Value = username;

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

        private void bt_sua_Click(object sender, EventArgs e)
        {
            string username = tb1.Text.ToString();
            string password = tb2.Text.ToString();
            OracleCommand cmd = new OracleCommand("sp_change_user_password", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("username", OracleDbType.Varchar2).Value = username;
            cmd.Parameters.Add("password", OracleDbType.Varchar2).Value = password;
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();                
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Exception: {0}", ex.ToString());
            }
            con.Close();
            dgv1_loaddata();
        }

        private void bt_khoa_Click(object sender, EventArgs e)
        {
            string username = tb1.Text.ToString();
            OracleCommand cmd = new OracleCommand("sp_lock_user", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("username", OracleDbType.Varchar2).Value = username;
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Exception: {0}", ex.ToString());
            }
            con.Close();
            dgv1_loaddata();
        }

    }
}
