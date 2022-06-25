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
        public MH_Admin_NV()
        {
            InitializeComponent();
        }

        private void ngườiDùngTSMI_Click(object sender, EventArgs e)
        {
            Program.loadForm(new MH_Admin_User(), this);
        }

        private void vaiTròTSMI_Click(object sender, EventArgs e)
        {
            Program.loadForm(new MH_Admin_Role(), this);
        }

        private void CSYTTSMI_Click(object sender, EventArgs e)
        {
            Program.loadForm(new MH_Admin_CSYT(), this);
        }

        private void ThoátTSMI_Click(object sender, EventArgs e)
        {
            Program.loadForm(new MH_Login(), this);
        }
    }
}
