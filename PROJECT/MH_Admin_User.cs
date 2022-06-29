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
    public partial class MH_Admin_User : Form
    {
        string username;
        string password;
        public MH_Admin_User()
        {
            InitializeComponent();
            dgv1_loaddata();
        }
        public MH_Admin_User(string user_name, string pass_word)
        {
            InitializeComponent();
            username = user_name;
            password = pass_word;
            dgv1_loaddata();
        }
        public void dgv1_loaddata()
        {
            List<string> varList = new List<string>();
            DataTable dt = new DataTable();

            dt = Program.loadDT("sp_list_all_user", username, password, varList, varList);
            dgv1.DataSource = dt;
            dgv1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        public void dgv2_loaddata(string user)
        {
            List<string> varList = new List<string>{ "user" };
            List<string> inputList = new List<string> { user };
            DataTable dt = new DataTable();

            dt = Program.loadDT("sp_show_user_sys_privs", username, password, varList, inputList);
            dgv2.DataSource = dt;
            dgv2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        public void dgv3_loaddata(string user)
        {
            List<string> varList = new List<string> { "user" };
            List<string> inputList = new List<string> { user };
            DataTable dt = new DataTable();

            dt = Program.loadDT("sp_show_user_obj_privs", username, password, varList, inputList);
            dgv3.DataSource = dt;
            dgv3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        private void dgv1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int rowIndex = dgv1.CurrentCell.RowIndex;
                string user = dgv1.Rows[rowIndex].Cells[0].Value.ToString();
                tb1.Text = user;
                dgv2_loaddata(user);
                dgv3_loaddata(user);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Exception: {0}");
            }
        }

        private void bt_them_Click(object sender, EventArgs e)
        {
            try
            {
                string user = tb1.Text.ToString();
                string pass = tb2.Text.ToString();
                List<string> varList = new List<string> { "username", "password" };
                List<string> inputList = new List<string> { user, pass };

                DataTable dt = new DataTable();
                dt = Program.loadDT("sp_create_user", username, password, varList, inputList);
                dgv1_loaddata();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Exception: {0}");
            }
        }

        private void bt_xoa_Click(object sender, EventArgs e)
        {
            try
            {
                string user = tb1.Text.ToString();
                List<string> varList = new List<string> { "username" };
                List<string> inputList = new List<string> { user };

                DataTable dt = new DataTable();
                dt = Program.loadDT("sp_delete_user", username, password, varList, inputList);
                tb1.Clear();
                dgv1_loaddata();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Exception: {0}");
            }
        }

        private void bt_sua_Click(object sender, EventArgs e)
        {
            try
            {
                string user = tb1.Text.ToString();
                string pass = tb2.Text.ToString();
                List<string> varList = new List<string> { "username", "new_password" };
                List<string> inputList = new List<string> { user, pass };

                DataTable dt = new DataTable();
                dt = Program.loadDT("sp_change_user_password", username, password, varList, inputList);
                dgv1_loaddata();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Exception: {0}");
            }
        }

        private void bt_khoa_Click(object sender, EventArgs e)
        {
            int rowIndex = dgv1.CurrentCell.RowIndex;
            string status = dgv1.Rows[rowIndex].Cells[1].Value.ToString();
            try
            {
                string user = tb1.Text.ToString();
                List<string> varList = new List<string> { "username" };
                List<string> inputList = new List<string> { user };

                DataTable dt = new DataTable();
                if (status == "OPEN")
                {
                    dt = Program.loadDT("sp_lock_user", username, password, varList, inputList);
                }
                else if (status == "LOCKED")
                {
                    dt = Program.loadDT("sp_unlock_user", username, password, varList, inputList);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Exception: {0}");
            }
            dgv1_loaddata();
        }

        public void cb_cot_loaddata(string table)
        {
            cb_cot.Items.Clear();
            cb_cot.ResetText();
            cb_cot.Enabled = true; // default: initial false
            if (table == "HSBA")
            {
                cb_cot.Items.AddRange(Program.tHSBA);
            }
            else if(table == "HSBA_DV")
            {
                cb_cot.Items.AddRange(Program.tHSBA_DV);
            }
            else if (table == "BENHNHAN")
            {
                cb_cot.Items.AddRange(Program.tBENHNHAN);
            }
            else if (table == "CSYT")
            {
                cb_cot.Items.AddRange(Program.tCSYT);
            }
            else if (table == "NHANVIEN")
            {
                cb_cot.Items.AddRange(Program.tNHANVIEN);
            }
        }
        private void cb_bang_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cb_bang.SelectedIndex != -1)
            {
                cb_cot_loaddata(cb_bang.SelectedItem.ToString());
            }
        }

        private void bt_grant_table_Click(object sender, EventArgs e)
        {
            string user = tb1.Text.ToString();
            string privilege = cb_quyen.SelectedItem.ToString();
            string table = cb_bang.SelectedItem.ToString();
            string column = cb_cot.SelectedItem.ToString();
            string schema_name = "qlbv_dba";
            string wgo = "0";
            if (checkBox.Checked) // default: initial false
            {
                wgo = "1";
            }

            if (privilege == "SELECT")
            {
                List<string> varList = new List<string> { "user_or_role", "schema_name", "table_name", "col_name", "with_grant_option" };
                List<string> inputList = new List<string> { user, schema_name, table, column, wgo };

                DataTable dt = new DataTable();
                dt = Program.loadDT("sp_grant_select_table", username, password, varList, inputList);
            }
            else if (privilege == "UPDATE")
            {
                List<string> varList = new List<string> { "user_or_role", "schema_name", "table_name", "col_name", "with_grant_option" };
                List<string> inputList = new List<string> { user, schema_name, table, column, wgo };

                DataTable dt = new DataTable();
                dt = Program.loadDT("sp_grant_update_on_table", username, password, varList, inputList);
            }
            else if (privilege == "INSERT") // NO COLUMN
            {
                List<string> varList = new List<string> { "user_or_role", "schema_name", "table_name", "with_grant_option" };
                List<string> inputList = new List<string> { user, schema_name, table, wgo };

                DataTable dt = new DataTable();
                dt = Program.loadDT("sp_grant_insert_table", username, password, varList, inputList);
            }
            else if (privilege == "DELETE") // NO COLUMN
            {
                List<string> varList = new List<string> { "user_or_role", "schema_name", "table_name", "with_grant_option" };
                List<string> inputList = new List<string> { user, schema_name, table, wgo };

                DataTable dt = new DataTable();
                dt = Program.loadDT("sp_grant_delete_table", username, password, varList, inputList);
            }
            dgv2_loaddata(user);
            dgv3_loaddata(user);
        }
        private void bt_revoke_table_Click(object sender, EventArgs e)
        {
            string user = tb1.Text.ToString();
            string privilege = cb_quyen.SelectedItem.ToString();
            string table = cb_bang.SelectedItem.ToString();
            string schema_name = "qlbv_dba";

            if (privilege == "SELECT")
            {
                List<string> varList = new List<string> { "user_or_role", "table_name" };
                List<string> inputList = new List<string> { user, table };

                DataTable dt = new DataTable();
                dt = Program.loadDT("sp_revoke_select_table", username, password, varList, inputList);
            }
            else if (privilege == "UPDATE")
            {
                List<string> varList = new List<string> { "user_or_role", "table_name" };
                List<string> inputList = new List<string> { user, table };

                DataTable dt = new DataTable();
                dt = Program.loadDT("sp_revoke_update_table", username, password, varList, inputList);
            }
            else if (privilege == "INSERT")
            {
                List<string> varList = new List<string> { "user_or_role", "schema_name", "table_name" };
                List<string> inputList = new List<string> { user, schema_name, table };

                DataTable dt = new DataTable();
                dt = Program.loadDT("sp_revoke_insert_table", username, password, varList, inputList);
            }
            else if (privilege == "DELETE")
            {
                List<string> varList = new List<string> { "user_or_role", "schema_name", "table_name" };
                List<string> inputList = new List<string> { user, schema_name, table };

                DataTable dt = new DataTable();
                dt = Program.loadDT("sp_revoke_delete_table", username, password, varList, inputList);
            }
            dgv2_loaddata(user);
            dgv3_loaddata(user);
        }
        private void bt_grant_obj_Click(object sender, EventArgs e)
        {
            string user = tb1.Text.ToString();
            string privilege = tb3.Text.ToString();
            string obj = tb4.Text.ToString();
            string schema_name = "qlbv_dba";
            string wgo = "0";
            if (checkBox.Checked) // default: initial false
            {
                wgo = "1";
            }
            List<string> varList = new List<string> { "user_or_role", "privilege", "schema_name", "obj_name", "with_grant_option" };
            List<string> inputList = new List<string> { user, privilege, schema_name, obj, wgo };

            DataTable dt = new DataTable();
            dt = Program.loadDT("sp_grant_obj_priv", username, password, varList, inputList);
            dgv2_loaddata(user);
            dgv3_loaddata(user);
        }
        private void bt_revoke_obj_Click(object sender, EventArgs e)
        {
            string user = tb1.Text.ToString();
            string privilege = tb3.Text.ToString();
            string obj = tb4.Text.ToString();
            string schema_name = "qlbv_dba";
            List<string> varList = new List<string> { "user_or_role", "privilege", "schema_name", "obj_name" };
            List<string> inputList = new List<string> { user, privilege, schema_name, obj };

            DataTable dt = new DataTable();
            dt = Program.loadDT("sp_revoke_obj_priv", username, password, varList, inputList);
            dgv2_loaddata(user);
            dgv3_loaddata(user);
        }
        private void bt_grant_sys_Click(object sender, EventArgs e)
        {
            string user = tb1.Text.ToString();
            string privilege = tb5.Text.ToString();
            string wgo = "0";
            if (checkBox.Checked) // default: initial false
            {
                wgo = "1";
            }
            List<string> varList = new List<string> { "user_or_role", "privilege", "with_grant_option" };
            List<string> inputList = new List<string> { user, privilege, wgo };

            DataTable dt = new DataTable();
            dt = Program.loadDT("sp_grant_sys_priv", username, password, varList, inputList);
            dgv2_loaddata(user);
            dgv3_loaddata(user);
        }
        private void bt_revoke_sys_Click(object sender, EventArgs e)
        {
            string user = tb1.Text.ToString();
            string privilege = tb5.Text.ToString();
            List<string> varList = new List<string> { "user_or_role", "privilege" };
            List<string> inputList = new List<string> { user, privilege };

            DataTable dt = new DataTable();
            dt = Program.loadDT("sp_revoke_sys_priv", username, password, varList, inputList);
            dgv2_loaddata(user);
            dgv3_loaddata(user);
        }
        private void vaiTròTSMI_Click(object sender, EventArgs e)
        {
            Program.loadForm(new MH_Admin_Role(username, password), this);
        }

        private void CSYTTSMI_Click(object sender, EventArgs e)
        {
            Program.loadForm(new MH_Admin_CSYT(username, password), this);
        }

        private void nhânViênTSMI_Click(object sender, EventArgs e)
        {
            Program.loadForm(new MH_Admin_NV(username, password), this);
        }

        private void ThoátTSMI_Click(object sender, EventArgs e)
        {
            Program.loadForm(new MH_Login(), this);
        }

    }
}
