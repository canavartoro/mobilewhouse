using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Reflection;
using System.IO;
using System.Xml.Serialization;
using MobileWhouse.Models;

namespace MobileWhouse
{
    static class Program
    {


        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [MTAThread]
        static void Main()
        {
            ClientApplication application = new ClientApplication();
            application.Run();
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

            var stream = assembly.GetManifestResourceStream("MobileWhouse.build.txt");

            using (var reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }
    }
}