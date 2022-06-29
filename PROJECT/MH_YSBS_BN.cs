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
