using System;
using System.Collections.Generic;
using System.Linq;

namespace lib.ndk.Extension
{
    public static class ListExtension
    {
        public static List<T> GetRandomElements<T>(this IEnumerable<T> list, int elementsCount)
        {
            return list.OrderBy(arg => Guid.NewGuid()).Take(elementsCount).ToList();
        }
    }
}