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
    public partial class MH_NghienCuu_HSBA : Form
    {
        string username;
        string password;
        string roleName;
        public MH_NghienCuu_HSBA()
        {
            InitializeComponent();
        }
        public MH_NghienCuu_HSBA(string user_name, string pass_word, string role)
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
        private void ThoátTSMI_Click(object sender, EventArgs e)
        {
            Program.loadForm(new MH_Login(), this);
        }
    }
}
