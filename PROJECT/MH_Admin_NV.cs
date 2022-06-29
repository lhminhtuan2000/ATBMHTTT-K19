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
        OracleConnection connect;
        public MH_Admin_NV()
        {
            InitializeComponent();
        }
        public MH_Admin_NV(OracleConnection con)
        {
            InitializeComponent();
            connect = con;
        }
        private void ngườiDùngTSMI_Click(object sender, EventArgs e)
        {
            //Program.loadForm(new MH_Admin_User(connect), this);
        }

        private void vaiTròTSMI_Click(object sender, EventArgs e)
        {
            Program.loadForm(new MH_Admin_Role(connect), this);
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
    }
}
