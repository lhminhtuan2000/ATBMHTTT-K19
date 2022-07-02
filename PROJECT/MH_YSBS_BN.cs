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
    public partial class MH_YSBS_BN : Form
    {
        string username;
        string password;
        string roleName;
        public MH_YSBS_BN()
        {
            InitializeComponent();
        }
        public MH_YSBS_BN(string user_name, string pass_word, string role)
        {
            InitializeComponent();
            username = user_name;
            password = pass_word;
            roleName = role;
        }
        private void bt_tracuu_Click(object sender, EventArgs e)
        {
            List<string> varList = new List<string> { "p_key" };
            List<string> inputList = new List<string> { };
            DataTable dt = new DataTable();
            if (tb1.Text.Length != 0) //String.IsNullOrEmpty(textBox1.Text)
            {
                inputList.Add(tb1.Text.ToString());
            }
            else if (tb2.Text.Length != 0) //String.IsNullOrWhitespace(textBox1.Text)
            {
                inputList.Add(tb2.Text.ToString());
            }

            dt = Program.loadDT("qlbv_dba.sp_ybs_xemThongTinBenhNhan", username, password, varList, inputList);
            dgv1.DataSource = dt;
            dgv1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        private void infoTSMI_Click(object sender, EventArgs e)
        {
            Program.loadForm(new MH_NhanVien(username, password, roleName), this);
        }
        private void HSBATSMI_Click(object sender, EventArgs e)
        {
            Program.loadForm(new MH_YSBS_BN(username, password, roleName), this);
        }
        private void ThoátTSMI_Click(object sender, EventArgs e)
        {
            Program.loadForm(new MH_Login(), this);
        }

    }
}
