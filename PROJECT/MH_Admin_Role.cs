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
    public partial class MH_Admin_Role : Form
    {
        string username;
        string password;
        public MH_Admin_Role()
        {
            InitializeComponent();
            dgv1_loaddata();
        }
        public MH_Admin_Role(string user_name, string pass_word)
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
            dt = Program.loadDT("sp_show_roles", username, password, varList, varList);
            dgv1.DataSource = dt;
            dgv1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        public void dgv2_loaddata(string role)
        {
            List<string> varList = new List<string> { "role_name" };
            List<string> inputList = new List<string> { role };
            DataTable dt = new DataTable();

            dt = Program.loadDT("sp_role_sys_privs", username, password, varList, inputList);
            dgv2.DataSource = dt;
            dgv2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        public void dgv3_loaddata(string role)
        {
            List<string> varList = new List<string> { "role_name" };
            List<string> inputList = new List<string> { role };
            DataTable dt = new DataTable();

            dt = Program.loadDT("sp_role_obj_privs", username, password, varList, inputList);
            dgv3.DataSource = dt;
            dgv3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void dgv1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int rowIndex = dgv1.CurrentCell.RowIndex;
                string role_name = dgv1.Rows[rowIndex].Cells[0].Value.ToString();
                tb1.Text = role_name;
                dgv2_loaddata(role_name);
                dgv3_loaddata(role_name);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Exception: {0}", ex.ToString());
            }
        }

        private void bt_them_Click(object sender, EventArgs e)
        {
            try
            {
                string role = tb1.Text.ToString();
                string pass = tb2.Text.ToString();
                List<string> varList = new List<string> { "role_name" };
                List<string> inputList = new List<string> { role };

                DataTable dt = new DataTable();
                dt = Program.loadDT("sp_create_role", username, password, varList, inputList);
                dgv1_loaddata();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Exception: {0}");
            }
        }
        private void bt_xoa_Click(object sender, EventArgs e)
        {
            string role_name = tb1.Text.ToString();
            OracleCommand cmd = new OracleCommand("sp_delete_role", connect);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("role_name", OracleDbType.Varchar2).Value = role_name;

            try
            {
                connect.Open();
                cmd.ExecuteNonQuery();
                tb1.Clear();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Exception: {0}", ex.ToString());
            }
            connect.Close();
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
            //Program.loadForm(new MH_Admin_User(connect), this);
        }

        private void CSYTTSMI_Click(object sender, EventArgs e)
        {
            Program.loadForm(new MH_Admin_CSYT(connect), this);
        }

        private void ThoátTSMI_Click(object sender, EventArgs e)
        {
            connect.Dispose();
            Program.loadForm(new MH_Login(), this);
        }

        private void nhânViênTSMI_Click(object sender, EventArgs e)
        {
            Program.loadForm(new MH_Admin_NV(connect), this);
        }
    }
}
