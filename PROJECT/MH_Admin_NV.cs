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
    public partial class MH_Admin_NV : Form
    {
        string username;
        string password;
        public MH_Admin_NV()
        {
            InitializeComponent();
            dgv1_loaddata();
        }
        public MH_Admin_NV(string user_name, string pass_word)
        {
            InitializeComponent();
            username = user_name;
            password = pass_word;
            dgv1_loaddata();
        }
        public void dgv1_loaddata()
        {
            string query = "select * from NHANVIEN";
            DataTable dt = new DataTable();

            dt = Program.loadDTWithQuery(query, username, password);
            dgv1.DataSource = dt;
            dgv1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        private void bt_them_Click(object sender, EventArgs e)
        {
            string manv = tb1.Text.ToString();
            string hoten = tb2.Text.ToString();
            string phai = cb1.SelectedItem.ToString();
            string ngaysinh = tb3.Text.ToString();
            string cmnd = tb4.Text.ToString();
            string quequan = tb5.Text.ToString();
            string sodt = tb6.Text.ToString();
            string csyt = tb7.Text.ToString();
            string vaitro = cb2.SelectedItem.ToString();
            string chuyenkhoa = tb8.Text.ToString();

            string connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            String conString = connectionString.Replace("@@@", username).Replace("###", password);
            using (OracleConnection con = new OracleConnection(conString))
            {
                con.Open();
                OracleCommand cmd = new OracleCommand("sp_themNhanVien", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("p_manv", OracleDbType.Int64, manv, ParameterDirection.Input);
                cmd.Parameters.Add("p_hoten", OracleDbType.NVarchar2, hoten, ParameterDirection.Input);
                cmd.Parameters.Add("p_phai", OracleDbType.NVarchar2, phai, ParameterDirection.Input);
                cmd.Parameters.Add("p_ngaysinh", OracleDbType.Date, ngaysinh, ParameterDirection.Input);
                cmd.Parameters.Add("p_cmnd", OracleDbType.Varchar2, cmnd, ParameterDirection.Input);
                cmd.Parameters.Add("p_quequan", OracleDbType.NVarchar2, quequan, ParameterDirection.Input);
                cmd.Parameters.Add("p_sodt", OracleDbType.Char, sodt, ParameterDirection.Input);
                cmd.Parameters.Add("p_csyt", OracleDbType.Int64, csyt, ParameterDirection.Input);
                cmd.Parameters.Add("p_vaitro", OracleDbType.NVarchar2, vaitro, ParameterDirection.Input);
                cmd.Parameters.Add("p_chuyenkhoa", OracleDbType.Int64, chuyenkhoa, ParameterDirection.Input);
                cmd.Parameters.Add("p_tenDangNhap", OracleDbType.Varchar2, "UN"+ manv.ToString(), ParameterDirection.Input);

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
        private void bt_tracuuCSYT_Click(object sender, EventArgs e)
        {
            using (var form = new MH_TraCuu(username, password, "CSYT"))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string val = form.ReturnValue1;
                    tb7.Text = val;
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
                    tb8.Text = val;
                }
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

        private void CSYTTSMI_Click(object sender, EventArgs e)
        {
            Program.loadForm(new MH_Admin_CSYT(username, password), this);
        }

        private void ThoátTSMI_Click(object sender, EventArgs e)
        {
            Program.loadForm(new MH_Login(), this);
        }

    }
}
