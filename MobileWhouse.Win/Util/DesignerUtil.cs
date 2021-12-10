using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace MobileWhouse.Util
{
    public class DesignerUtil
    {
        public static bool IsDesignTime()
        {
            Assembly objA = typeof(int).Assembly;
            Screens.Info(objA.FullName);
            return (!ReferenceEquals(objA, null) && objA.FullName.ToUpper().EndsWith("B77A5C561934E089"));
        }

        public static bool IsRunTime()
        {
            Assembly objA = typeof(int).Assembly;
            Screens.Info(objA.FullName);
            return (!ReferenceEquals(objA, null) && objA.FullName.ToUpper().EndsWith("969DB8053D3322AC"));
        }
    }
}
