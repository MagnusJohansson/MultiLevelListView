using System;
using System.Reflection;

namespace MultiLevelListViewApp
{
    public static class ObjectTypeHelper
    {
        public static T Cast<T>(this Object obj)
        where T : class
        {
            PropertyInfo property = obj.GetType().GetProperty("Instance");
            return (property == null ? default(T) : (T)(property.GetValue(obj, null) as T));
        }

        public static T ToJObject<T>(this object obj)
        where T : class
        {
            return (T)(obj as T);
        }
    }
}