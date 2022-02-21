using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace MobileWhouse.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
    class UyumModuleAttribute : Attribute
    {
        private string _moduleName;
        private string _moduleSource;
        private string _moduleCaption;

        public string ModuleName
        {
            get { return _moduleName; }
            set { _moduleName = value; }
        }
        public string ModuleSource
        {
            get { return _moduleSource; }
            set { _moduleSource = value; }
        }
        public string ModuleCaption
        {
            get { return _moduleCaption; }
            set { _moduleCaption = value; }
        }

        public UyumModuleAttribute(string name, string source,string caption)
        {
            _moduleName = name;
            _moduleSource = source;
            _moduleCaption = caption;
        }
        public UyumModuleAttribute(string name, string source)
            : this(name, "", "")
        {
           
        }
        public UyumModuleAttribute(string name)
            : this(name, "","")
        {
        }
        public UyumModuleAttribute()
        {
        }
    }
}
