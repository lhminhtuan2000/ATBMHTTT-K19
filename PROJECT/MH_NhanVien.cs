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
        OracleConnection connect;
        string roleName;
        public MH_NhanVien()
        {
            InitializeComponent();
        }

        public MH_NhanVien(OracleConnection con, string role)
        {
            InitializeComponent();
            connect = con;
            roleName = role;
            if (roleName == "CSYT")
            {
                quảnLýTSMI.Visible = true;
            }
            if (roleName == "NGHIENCUU" || roleName == "YSBS")
            {
                HSBATSMI.Visible = true;
            }
            if (roleName == "YSBS")
            {
                bệnhNhânTSMI.Visible = true;
            }
            if (roleName == "GIAMDOC") // fix khi co' solution OLS
            {
                thôngBáoTSMT.Visible = true;
            }
        }

        private void ThoátTSMI_Click(object sender, EventArgs e)
        {
            connect.Dispose();
            Program.loadForm(new MH_Login(), this);
        }

        private void HSBATSMI_Click(object sender, EventArgs e)
        {
            if (roleName == "NGHIENCUU")
            {
                Program.loadForm(new MH_NghienCuu_HSBA(connect, roleName), this);
            }
            if (roleName == "YSBS")
            {
                Program.loadForm(new MH_YSBS_HSBA(connect, roleName), this);
            }
        }

        private void bệnhNhânTSMI_Click(object sender, EventArgs e)
        {
            Program.loadForm(new MH_YSBS_BN(connect, roleName), this);
        }
        private void thôngBáoTSMT_Click(object sender, EventArgs e)
        {
            Program.loadForm(new MH_GiamDoc(connect, roleName), this);
        }
        private void quảnLýTSMI_Click(object sender, EventArgs e)
        {
            Program.loadForm(new MH_NVQL(connect, roleName), this);
        }
    }
}
