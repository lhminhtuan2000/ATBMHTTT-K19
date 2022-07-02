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
    public partial class MH_Admin_CSYT : Form
    {
        string username;
        string password;
        public MH_Admin_CSYT()
        {
            InitializeComponent();
            dgv1_loaddata();
        }
        public MH_Admin_CSYT(string user_name, string pass_word)
        {
            InitializeComponent();
            username = user_name;
            password = pass_word;
            dgv1_loaddata();
        }
        public void dgv1_loaddata()
        {
            string query = "select * from CSYT";
            DataTable dt = new DataTable();

            dt = Program.loadDTWithQuery(query, username, password);
            dgv1.DataSource = dt;
            dgv1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        private void dgv1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int rowIndex = dgv1.CurrentCell.RowIndex;
                tb1.Text = dgv1.Rows[rowIndex].Cells[0].Value.ToString();
                tb2.Text = dgv1.Rows[rowIndex].Cells[1].Value.ToString();
                tb3.Text = dgv1.Rows[rowIndex].Cells[2].Value.ToString();
                tb4.Text = dgv1.Rows[rowIndex].Cells[3].Value.ToString();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Exception: {0}", ex.ToString());
            }
        }
        private void bt_them_Click(object sender, EventArgs e)
        {
            string macsyt = tb1.Text.ToString();
            string tencsyt = tb2.Text.ToString();
            string dccsyt = tb3.Text.ToString();
            string sdtcsyt = tb4.Text.ToString();

            string connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            String conString = connectionString.Replace("@@@", username).Replace("###", password);
            using (OracleConnection con = new OracleConnection(conString))
            {
                con.Open();
                OracleCommand cmd = new OracleCommand("sp_themCSYT", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("p_macsyt", OracleDbType.Int64, macsyt, ParameterDirection.Input);
                cmd.Parameters.Add("p_tencsyt", OracleDbType.NVarchar2, tencsyt, ParameterDirection.Input);
                cmd.Parameters.Add("p_dccsyt", OracleDbType.NVarchar2, dccsyt, ParameterDirection.Input);
                cmd.Parameters.Add("p_sdtcsyt", OracleDbType.Char, sdtcsyt, ParameterDirection.Input);

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
                dgv1_loaddata();
            }
        }

        private void bt_sua_Click(object sender, EventArgs e)
        {
            string macsyt = tb1.Text.ToString();
            string tencsyt = tb2.Text.ToString();
            string dccsyt = tb3.Text.ToString();
            string sdtcsyt = tb4.Text.ToString();

            string connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            String conString = connectionString.Replace("@@@", username).Replace("###", password);
            using (OracleConnection con = new OracleConnection(conString))
            {
                con.Open();
                OracleCommand cmd = new OracleCommand("sp_capNhatCSYT", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("p_macsyt", OracleDbType.Int64, macsyt, ParameterDirection.Input);
                cmd.Parameters.Add("p_tencsyt", OracleDbType.NVarchar2, tencsyt, ParameterDirection.Input);
                cmd.Parameters.Add("p_dccsyt", OracleDbType.NVarchar2, dccsyt, ParameterDirection.Input);
                cmd.Parameters.Add("p_sdtcsyt", OracleDbType.Char, sdtcsyt, ParameterDirection.Input);

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
                dgv1_loaddata();
            }
        }

        private void ngườiDùngTSMI_Click(object sender, EventArgs e)
        {
            Program.loadForm(new MH_Admin_User(username, password), this);
        }

        private void vaiTròTSMI_Click(object sender, EventArgs e)
        {
            Program.loadForm(new MH_Admin_Role(username, password), this);
        }

        private void nhânViênTSMI_Click(object sender, EventArgs e)
        {
            Program.loadForm(new MH_Admin_NV(username, password), this);
        }

        private void ThoátTSMI_Click(object sender, EventArgs e)
        {
            Program.loadForm(new MH_Login(), this);
        }

    }
}
