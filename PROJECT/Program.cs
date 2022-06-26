using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

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
    }
}
