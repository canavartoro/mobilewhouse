using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace m2Mobile_c_v4
{
    public class FormParameters
    {
        public string PRM_FORMNAME { set; get; }
        public Boolean PRM_USEBARCODE { set; get; }
        public Boolean PRM_USEPACKAGECODE { set; get; }
        public Boolean PRM_USESERIALCODE { set; get; }
        public Boolean PRM_USESTOCKCODE { set; get; }
        public Boolean PRM_USERACKCODE { set; get; }
        public string PRM_BARCODEPREVALUE { set; get; }
        public string PRM_PACKAGEPREVALUE { set; get; }
        public string PRM_SERIALPREVALUE { set; get; }
        public string PRM_STOCKPREVALUE { set; get; }
        public Boolean PRM_ALLOWMANUELENTRY { set; get; }
        public int PRM_MAXAMOUNT { set; get; }
        public int PRM_DEFAULTAMOUNT { set; get; }
        public string PRM_READSQUENCE1 { set; get; }
        public string PRM_READSQUENCE2 { set; get; }
        public string PRM_READSQUENCE3 { set; get; }
        public string PRM_READSQUENCE4 { set; get; }
        public string PRM_READSQUENCE5 { set; get; }
        public string PRM_PACKAGELABEL { set; get; }
        public string PRM_SERIALLABEL { set; get; }
        public string PRM_STOCKLABEL { set; get; }
        public string PRM_BARCODELABEL { set; get; }
        public string PRM_RACKLABEL { set; get; }


    }
}
