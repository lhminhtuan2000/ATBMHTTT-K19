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
        public static DataTable loadDT(string procname, OracleConnection connect, List<string> var, List<string> input)
        {
            OracleCommand cmd = new OracleCommand(procname, connect);
            cmd.CommandType = CommandType.StoredProcedure;
            int size = var.Count;
            for (int i =0; i<var.Count(); i++)
            {
                cmd.Parameters.Add(var[i].ToString(), OracleDbType.Varchar2).Value = input[i].ToString();
                //MessageBox.Show(procname);
            }
            DataTable dt = new DataTable();
            dt.Clear();
            try
            {
                //connect.Open();
                OracleDataAdapter oda = new OracleDataAdapter(cmd);
                oda.Fill(dt); //fix
                MessageBox.Show(dt.ToString());
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Exception: {0}", ex.ToString());
            }
            return dt;
        }
    }
}
