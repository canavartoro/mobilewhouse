using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MobileWhouse.Util;
using System.Collections;
using MobileWhouse.Log;
using System.Reflection;
using System.Windows.Forms;

namespace MobileWhouse.Data
{
    public class DataProvider : IDisposable
    {
        public DataProvider() { }

        public static IList TableToList(DataTable tbl, Type type)
        {
            IList list = null;
            if (tbl != null && tbl.Rows.Count > 0)
            {
                Type d1 = typeof(List<>);
                list = (IList)Activator.CreateInstance(d1.MakeGenericType(type));
                var primitive = ReflectionHelper.IsSimpleType(type);

                for (int i = 0; i < tbl.Rows.Count; i++)
                {
                    object newObject = null;
                    if (!primitive)
                    {
                        newObject = Activator.CreateInstance(type);
                    }

                    for (var column = 0; column < tbl.Columns.Count; column++)
                    {
                        if (tbl.Rows[i][column] == DBNull.Value)
                            continue;

                        if (primitive)
                        {
                            if (type.IsAssignableFrom(tbl.Rows[i][column].GetType()))
                            {
                                newObject = Convert.ChangeType(tbl.Rows[i][column], type, null);
                            }
                        }
                        else
                        {
                            var property = type.GetProperty(tbl.Columns[column].ColumnName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
                            if (property != null)
                            {
                                try
                                {
                                    //if (property.PropertyType.IsAssignableFrom(dr.GetValue(Convert.ToInt32(xmlschema.Rows[column]["ColumnOrdinal"])).GetType()))
                                    //{
                                    property.SetValue(newObject, Convert.ChangeType(tbl.Rows[i][column], property.PropertyType, null), null);
                                    //}
                                }
                                catch (Exception e)
                                {
                                    Logger.E(e);
                                }
                                //property.SetValue(newObject, dr.GetValue(Convert.ToInt32(xmlschema.Rows[column]["ColumnOrdinal"])), null);
                            }
                        }
                    }
                    list.Add(newObject);
                }

            }
            return list;
        }

        public static object TableToObject(DataTable tbl, Type type)
        {
            object newObject = null;
            if (tbl != null && tbl.Rows.Count > 0)
            {
                var primitive = ReflectionHelper.IsSimpleType(type);

                if (!primitive)
                {
                    newObject = Activator.CreateInstance(type);
                }

                for (var column = 0; column < tbl.Columns.Count; column++)
                {
                    if (tbl.Rows[0][column] == DBNull.Value)
                        continue;

                    if (primitive)
                    {
                        if (type.IsAssignableFrom(tbl.Rows[0][column].GetType()))
                        {
                            newObject = Convert.ChangeType(tbl.Rows[0][column], type, null);
                        }
                    }
                    else
                    {
                        var property = type.GetProperty(tbl.Columns[column].ColumnName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
                        if (property != null)
                        {
                            try
                            {
                                //if (property.PropertyType.IsAssignableFrom(dr.GetValue(Convert.ToInt32(xmlschema.Rows[column]["ColumnOrdinal"])).GetType()))
                                //{
                                property.SetValue(newObject, Convert.ChangeType(tbl.Rows[0][column], property.PropertyType, null), null);
                                //}
                            }
                            catch (Exception e)
                            {
                                Logger.E(e);
                            }
                            //property.SetValue(newObject, dr.GetValue(Convert.ToInt32(xmlschema.Rows[column]["ColumnOrdinal"])), null);
                        }
                    }
                }
            }
            return newObject;
        }

        #region IDisposable
        ~DataProvider()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private bool disposed = false;

        private void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {

            }

            disposed = true;
        }

        #endregion
    }
}
