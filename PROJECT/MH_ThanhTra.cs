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
    public partial class MH_ThanhTra : Form
    {
        string username;
        string password;
        string roleName;
        public MH_ThanhTra()
        {
            InitializeComponent();
        }
        public MH_ThanhTra(string user_name, string pass_word, string role)
        {
            InitializeComponent();
            username = user_name;
            password = pass_word;
            roleName = role;
        }
        private void bt_xem_Click(object sender, EventArgs e)
        {
            string table = cb_bang.SelectedItem.ToString();

            string connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            String conString = connectionString.Replace("@@@", username).Replace("###", password);
            using (OracleConnection con = new OracleConnection(conString))
            {
                con.Open();
                OracleCommand cmd = new OracleCommand("qlbv_dba.sp_xemThongTinQuanHe", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("tenBang", OracleDbType.Varchar2, table, ParameterDirection.Input);

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
