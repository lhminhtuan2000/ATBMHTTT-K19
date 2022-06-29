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
    static class Program
    {
        public static string[] tHSBA = { "MAHSBA", "MABN", "NGAY", "CHANĐOAN", "MABS", "MAKHOA", "MACSYT", "KETLUAN" };
        public static string[] tHSBA_DV = { "MAHSBA", "MADV", "NGAY", "MAKTV", "KETQUA" };
        public static string[] tBENHNHAN = { "MABN", "MACSYT", "TENBN", "CMND", "NGAYSINH", "SONHA", "TENĐUONG", "QUANHUYEN", "TINHTP", "TIENSUBENH", "TIENSUBENHGĐ", "DIUNGTHUOC" };
        public static string[] tCSYT = { "MACSYT", "TENCSYT", "ĐCCSYT", "SĐTCSYT" };
        public static string[] tNHANVIEN = { "MANV", "HOTEN", "PHAI", "NGAYSINH", "CMND", "QUEQUAN", "SOĐT", "CSYT", "VAITRO", "CHUYENKHOA" };
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MH_Login());
        }
        public static void loadForm(object formOpen, Form formClose)
        {
            Form f = formOpen as Form;
            f.Show();
            formClose.Hide();
        }
        // connection truyen vao phai dang mo, ham ben duoi return xong dispose connection
        public static DataTable loadDT(string procname, string username, string password, List<string> var, List<string> input)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            String conString = connectionString.Replace("@@@", username).Replace("###", password);
            using (OracleConnection con = new OracleConnection(conString))
            {
                OracleCommand cmd = new OracleCommand(procname, con);
                cmd.CommandType = CommandType.StoredProcedure;
                int size = var.Count;
                for (int i = 0; i < var.Count(); i++)
                {
                    cmd.Parameters.Add(var[i].ToString(), OracleDbType.Varchar2, input[i].ToString(), ParameterDirection.Input);
                }

                DataTable dt = new DataTable();
                dt.Clear();
                try
                {
                    OracleDataAdapter oda = new OracleDataAdapter(cmd);
                    oda.Fill(dt);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Exception: {0}");
                }
                return dt;
            }
        }
        public static DataTable loadDTFromQuery(string query, string username, string password)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            String conString = connectionString.Replace("@@@", username).Replace("###", password);
            using (OracleConnection con = new OracleConnection(conString))
            {
                con.Open();
                OracleCommand cmd = new OracleCommand(query, con);
                cmd.CommandType = CommandType.Text;

                DataTable dt = new DataTable();
                dt.Clear();
                try
                {
                    OracleDataReader reader = cmd.ExecuteReader();
                    reader.Read(); 
                    dt.Load(reader);
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Exception: {0}");
                }
                return dt;
            }
        }
    }
}
