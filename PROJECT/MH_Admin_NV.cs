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
            /*
            List<string> varList = new List<string>();
            DataTable dt = new DataTable();

            dt = Program.loadDT("sp_list_all_user", username, password, varList, varList);
            dgv1.DataSource = dt;
            dgv1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            */
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
