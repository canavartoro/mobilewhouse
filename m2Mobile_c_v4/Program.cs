using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Reflection;
using System.IO;

namespace m2Mobile_c_v4
{
    static class Program
    {
        [MTAThread]
        private static void Main()
        {
            Application.Run(new Frm_Menu());
        }

        public static string Versiyon
        {
            get
            {
                Assembly entryPoint = Assembly.GetExecutingAssembly();
                AssemblyName entryPointName = entryPoint.GetName();
                Version entryPointVersion = entryPointName.Version;
                return string.Format("{0}", entryPointVersion);
            }
        }

        public static string BuildNumber()
        {
            var assembly = Assembly.GetExecutingAssembly();
            //string[] names = assembly.GetManifestResourceNames();

            var stream = assembly.GetManifestResourceStream("m2Mobile_c_v4.build.txt");

            using (var reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }
    }
}

