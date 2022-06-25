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
        public MH_NghienCuu_HSBA()
        {
            InitializeComponent();
        }

        private void ThoátTSMI_Click(object sender, EventArgs e)
        {
            Program.loadForm(new MH_Login(), this);
        }

        private void infoTSMI_Click(object sender, EventArgs e)
        {
            Program.loadForm(new MH_NhanVien(), this);
        }
    }
}
