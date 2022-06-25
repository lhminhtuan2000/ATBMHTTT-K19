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
    public partial class MH_NhanVien : Form
    {
        string roleName;
        public MH_NhanVien()
        {
            InitializeComponent();
        }

        public MH_NhanVien(string user, string pass, string role)
        {
            InitializeComponent();
            roleName = role;
            if (roleName == "NGHIENCUU" || roleName == "YSBS")
            {
                HSBATSMI.Visible = true;
            }
            if (roleName == "YSBS")
            {
                bệnhNhânTSMI.Visible = true;
            }
            if (user == "boss") // fix khi co' solution OLS
            {
                thôngBáoTSMT.Visible = true;
            }
        }

        private void ThoátTSMI_Click(object sender, EventArgs e)
        {
            Program.loadForm(new MH_Login(), this);
        }

        private void HSBATSMI_Click(object sender, EventArgs e)
        {
            if (roleName == "NGHIENCUU")
            {
                Program.loadForm(new MH_NghienCuu_HSBA(), this);
            }
            if (roleName == "YSBS")
            {
                Program.loadForm(new MH_YSBS_HSBA(), this);
            }
        }

        private void bệnhNhânTSMI_Click(object sender, EventArgs e)
        {
            Program.loadForm(new MH_YSBS_BN(), this);
        }

        private void thôngBáoTSMT_Click(object sender, EventArgs e)
        {
            Program.loadForm(new MH_GiamDoc(), this);
        }
    }
}
