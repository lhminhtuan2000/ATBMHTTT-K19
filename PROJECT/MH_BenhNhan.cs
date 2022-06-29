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
    public partial class MH_BenhNhan : Form
    {
        string username;
        string password;
        public MH_BenhNhan()
        {
            InitializeComponent();
        }
        public MH_BenhNhan(string user_name, string pass_word)
        {
            InitializeComponent();
            username = user_name;
            password = pass_word;
        }
        private void ThoátTSMI_Click(object sender, EventArgs e)
        {
            Program.loadForm(new MH_Login(), this);
        }
    }
}
