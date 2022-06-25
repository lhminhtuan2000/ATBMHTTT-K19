using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PROJECT
{
    static class Program
    {
        public static string[] tHSBA = { "MÃHSBA", "MÃBN", "NGÀY", "CHẨNĐOÁN", "MÃBS", "MÃKHOA", "MÃCSYT", "KẾTLUẬN" };
        public static string[] tHSBA_DV = { "MÃHSBA", "MÃDV", "NGÀY", "MÃKTV", "KẾTQUẢ" };
        public static string[] tBENHNHAN = { "MÃBN", "MÃCSYT", "TÊNBN", "CMND", "NGÀYSINH", "SỐNHÀ", "TÊNĐƯỜNG", "QUẬNHUYỆN", "TỈNHTP", "TIỀNSỬBỆNH", "TIỀNSỬBỆNHGĐ", "DỊỨNGTHUỐC" };
        public static string[] tCSYT = { "MÃCSYT", "TÊNCSYT", "ĐCCSYT", "SĐTCSYT" };
        public static string[] tNHANVIEN = { "MÃNV", "HỌTÊN", "PHÁI", "NGÀYSINH", "CMND", "QUÊQUÁN", "SỐĐT", "CSYT", "VAITRÒ", "CHUYÊNKHOA" };
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
