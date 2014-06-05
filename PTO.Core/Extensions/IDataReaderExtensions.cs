using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Reflection;

namespace PTO.Core.Extensions
{
    public static class IDataReaderExtensions
    {
        public static List<T> DataReaderMapToList<T>(this IDataReader dr)
        {
            List<T> list = new List<T>();
            T obj = default(T);
            while (dr.Read())
            {
                obj = Activator.CreateInstance<T>();
                foreach (PropertyInfo prop in obj.GetType().GetProperties())
                {
                    // try to set the values in the destination object to values from the
                    // data reader source.
                    // ignore fields in destination that do not have corresponding field
                    // in the data reader source.
                    try
                    {
                        if (!object.Equals(dr[prop.Name], DBNull.Value))
                        {
                            prop.SetValue(obj, dr[prop.Name], null);
                        }
                    }
                    catch (Exception e)
                    {
                        Debug.Print(e.Message);
                    }
                }
                list.Add(obj);
            }
            return list;
        }
    }
}