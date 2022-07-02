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
    public partial class MH_TraCuu : Form
    {
        string username;
        string password;
        string info;
        public string ReturnValue1 { get; set; }
        public MH_TraCuu()
        {
            InitializeComponent();
            dgv1_loaddata();
        }
        public MH_TraCuu(string user_name, string pass_word, string in_fo)
        {
            InitializeComponent();
            username = user_name;
            password = pass_word;
            info = in_fo;
            dgv1_loaddata();
        }
        public void dgv1_loaddata()
        {
            string query = "select * from " + info;
            DataTable dt = new DataTable();

            dt = Program.loadDTWithQuery(query, username, password);
            dgv1.DataSource = dt;
            dgv1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        private void btnChon_Click(object sender, EventArgs e)
        {
            this.ReturnValue1 = tb1.Text.ToString();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        private void dgv1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int rowIndex = dgv1.CurrentCell.RowIndex;
                string key = dgv1.Rows[rowIndex].Cells[0].Value.ToString();
                tb1.Text = key;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Exception: {0}");
            }
        }
    }
}
