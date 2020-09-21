using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Web;

namespace TPModule5_3.Utils
{
    public static class Hydratator
    {
        public static T Hydrate<T>(this T item) where T : new()
        {
            T result = new T();
            item.GetType().GetMembers();

            PropertyInfo[] properties = typeof(T).GetProperties();
            foreach (PropertyInfo property in properties)
            {
                property.SetValue(result, property.GetValue(item));
            }

            return result;
        }

        private static readonly ConditionalWeakTable<object, RefId> _ids = new ConditionalWeakTable<object, RefId>();

        public static Guid GetRefId<T>(this T obj) where T : class
        {
            if (obj == null)
                return default(Guid);

            return _ids.GetOrCreateValue(obj).Id;
        }

        private class RefId
        {
            public Guid Id { get; } = Guid.NewGuid();
        }

    }
}