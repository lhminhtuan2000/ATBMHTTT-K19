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
using System.Configuration; // To Access App Config Attributes

namespace PROJECT
{
    public partial class MH_Login : Form
    {
        string connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        public MH_Login()
        {
            InitializeComponent();
        }
        private void bt_login_Click(object sender, EventArgs e)
        {
            string username = tb1.Text.ToString();
            string password = tb2.Text.ToString();
            String conString = connectionString.Replace("@@@", username).Replace("###",password);
            
            using (OracleConnection con = new OracleConnection(conString))
            {
                try
                {
                    OracleCommand cmd = new OracleCommand("SELECT ROLE FROM SESSION_ROLES", con);
                    con.Open();
                    object obj = cmd.ExecuteScalar();
                    //OracleDataReader reader = cmd.ExecuteReader();reader.Read(); reader.Close();
                    string role = obj.ToString();
                    if (role == "PDB_DBA" || role == "DBA")
                    {
                        Program.loadForm(new MH_Admin_User(username, password), this);
                    }
                    else if (role == "THANHTRA")
                    {
                        Program.loadForm(new MH_ThanhTra(con), this);
                    }
                    else if (role == "CSYT" || role == "YSBS" || role == "NGHIENCUU" || role == "GIAMDOC") // fix khi co' solution cho OLS
                    {
                        Program.loadForm(new MH_NhanVien(con, role), this);
                    }
                    else if (role == "BENHNHAN")
                    {
                        Program.loadForm(new MH_BenhNhan(con), this);
                    }
                }
                catch (Exception ex) //OracleException
                {
                    //System.Console.WriteLine(ex.ToString());
                    MessageBox.Show("Phải làm sao! Phải làm sao!", "Đăng nhập thất bại rrr", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            
        }
    }
}
