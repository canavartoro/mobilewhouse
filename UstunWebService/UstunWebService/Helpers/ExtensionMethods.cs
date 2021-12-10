using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace UstunWebService.Helpers
{
    public static class ExtensionMethods
    {
        public static IDbDataParameter NewParameter(this IDbCommand command, string name, DbType dbType, object value)
        {
            IDbDataParameter iParameter = command.CreateParameter();
            iParameter.ParameterName = name;
            iParameter.Value = value;
            iParameter.DbType = dbType;
            return iParameter;
        }

        public static object toParameterValue(this string stringvalue)
        {
            if(string.IsNullOrWhiteSpace(stringvalue))
            {
                return DBNull.Value;
            }
            else
            {
                return stringvalue;
            }
        }
    }
}