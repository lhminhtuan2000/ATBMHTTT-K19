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
using System.Configuration; // To Access App Config Attributes

namespace PROJECT
{
    public partial class MH_Login : Form
    {
        string role = null;
        public MH_Login()
        {
            InitializeComponent();
        }

        private void bt_login_Click(object sender, EventArgs e)
        {
            string username = tb1.Text.ToString();
            string password = tb2.Text.ToString();
            using (OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString))
            {
                OracleCommand cmd = new OracleCommand("sp_login", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("user", OracleDbType.Varchar2).Value = username;
                cmd.Parameters.Add("pass", OracleDbType.Varchar2).Value = password;

                con.Open();
                //object temp = cmd.ExecuteScalar();
                OracleDataReader reader = cmd.ExecuteReader();
                try
                {
                    reader.Read();
                    role = reader.GetString(0);
                    //role = temp.ToString();
                    if (role == "THANHTRA")
                    {
                        con.Close();
                        Program.loadForm(new MH_ThanhTra(), this);
                    }
                    else if(role == "CSYT" || role == "YSBS" || role == "NGHIENCUU")
                    {
                        con.Close();
                        Program.loadForm(new MH_NhanVien(username, password, role), this);
                    }
                    else if (role == "NVQL")
                    {
                        con.Close();
                        Program.loadForm(new MH_NVQL(), this);
                    }
                    else if (role == "PDB_DBA")
                    {
                        Program.loadForm(new MH_Admin_User(), this);
                    }
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine("Exception: {0}", ex.ToString());
                }
                reader.Close();
            }
        }
    }
}
