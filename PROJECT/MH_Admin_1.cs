using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.OracleClient;

namespace PROJECT
{
    public partial class MH_Admin_1 : Form
    {
        string oradb = "Data Source=XEPDB1;User Id=system;Password=sys;";
        DataTable dt = new DataTable();
        public MH_Admin_1()
        {
            InitializeComponent();
            dgv1_loaddata();
        }
        public void dgv1_loaddata()
        {
            try
            {
                using (OracleConnection con = new OracleConnection(oradb))
                {
                    //OracleCommand cmd = new OracleCommand("exec sp_list_all_user", con);
                    OracleCommand cmd = new OracleCommand("SELECT username,password,default_tablespace FROM dba_users WHERE account_status = 'OPEN'", con);
                    OracleDataAdapter oda = new OracleDataAdapter(cmd);
                    dt.Clear();
                    oda.Fill(dt);
                    dgv1.DataSource = dt;
                    dgv1.AutoResizeColumnHeadersHeight();
                }
            }
            catch (OracleException ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void dgv2_loaddata(string username)
        {
            try
            {
                using (OracleConnection con = new OracleConnection(oradb))
                {
                    //OracleCommand cmd = new OracleCommand("exec sp_show_user_privilges('" + username + "')", con);
                    OracleCommand cmd = new OracleCommand("SELECT privilege,ADMIN_OPTION FROM DBA_SYS_PRIVS where grantee = UPPER(" + username + "')", con);
                    OracleDataAdapter oda = new OracleDataAdapter(cmd);
                    //dt.Clear();
                    oda.Fill(dt);
                    dgv2.DataSource = dt;
                    dgv2.AutoResizeColumnHeadersHeight();
                }
            }
            catch (OracleException ex)
            {
                //MessageBox.Show(ex.ToString());
            }
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
            catch (OracleException ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void bt_them_Click(object sender, EventArgs e)
        {
            string username = tb1.ToString();
            string password = tb2.ToString();
            try
            {
                using (OracleConnection con = new OracleConnection(oradb))
                {
                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = con;
                    cmd.CommandText = System.String.Concat("exec sp_create_user('" + username+ "', "  +password+ ")");
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    dgv1_loaddata();
                }
            }
            catch (OracleException ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void bt_xoa_Click(object sender, EventArgs e)
        {
            string username = tb1.ToString();
            string password = tb2.ToString();
            try
            {
                using (OracleConnection con = new OracleConnection(oradb))
                {
                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = con;
                    cmd.CommandText = System.String.Concat("exec sp_delete_user('" +username+ ")");
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    dgv1_loaddata();
                }
            }
            catch (OracleException ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void bt_sua_Click(object sender, EventArgs e)
        {
            string username = tb1.ToString();
            string password = tb2.ToString();
            try
            {
                using (OracleConnection con = new OracleConnection(oradb))
                {
                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = con;
                    cmd.CommandText = System.String.Concat("exec sp_change_user_password('" + username + "', " + password + ")");
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    dgv1_loaddata();
                }
            }
            catch (OracleException ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void bt_khoa_Click(object sender, EventArgs e)
        {
            string username = tb1.ToString();
            string password = tb2.ToString();
            try
            {
                using (OracleConnection con = new OracleConnection(oradb))
                {
                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = con;
                    cmd.CommandText = System.String.Concat("exec sp_lock_user('" + username+ ")");
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    dgv1_loaddata();
                }
            }
            catch (OracleException ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

    }
}
