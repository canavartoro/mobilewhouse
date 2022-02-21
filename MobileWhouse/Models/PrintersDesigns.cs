using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace MobileWhouse.Models
{
    public class PrintersDesigns
    {
        public PrintersDesigns()
        {
            result = false;
            message = "";
            printers = new List<string>();
            designs = new List<string>();
        }
        public PrintersDesigns(bool res, string msg)
        {
            result = res;
            message = msg;
            printers = new List<string>();
            designs = new List<string>();
        }

        private List<string> printers = null;
        public List<string> Printers
        {
            get { return printers; }
            set { printers = value; }
        }

        private List<string> designs = null;
        public List<string> Designs
        {
            get { return designs; }
            set { designs = value; }
        }

        private bool result = false;
        public bool Result
        {
            get { return result; }
            set { result = value; }
        }

        private string message = "";
        public string Massage
        {
            get { return message; }
            set { message = value; }
        }
    }

}
