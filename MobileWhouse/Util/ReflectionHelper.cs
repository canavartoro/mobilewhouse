using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Collections;

namespace MobileWhouse.Util
{
    public class ReflectionHelper
    {
        [DebuggerStepThrough()]
        public static bool IsSimpleType(Type type)
        {
            return
                type.IsPrimitive ||
                ((IList)new[]
                {
                    typeof(string),
                    typeof(decimal),
                    typeof(DateTime),
                    typeof(TimeSpan),
                    typeof(Guid)
                }).Contains(type) ||
                type.IsEnum ||
                Convert.GetTypeCode(type) != TypeCode.Object ||
                (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>) && IsSimpleType(type.GetGenericArguments()[0]))
                ;
        }
    }
}
