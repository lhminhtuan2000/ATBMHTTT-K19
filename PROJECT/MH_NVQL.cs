﻿using System;
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
    public partial class MH_NVQL : Form
    {
        OracleConnection connect;
        public MH_NVQL()
        {
            InitializeComponent();
        }
        public MH_NVQL(OracleConnection con)
        {
            InitializeComponent();
            connect = con;
        }
        private void ThoátTSMI_Click(object sender, EventArgs e)
        {
            connect.Dispose();
            Program.loadForm(new MH_Login(), this);
        }
    }
}
