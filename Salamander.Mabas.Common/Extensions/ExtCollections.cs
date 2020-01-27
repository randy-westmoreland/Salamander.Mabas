using System;
using System.Collections.Generic;

namespace Salamander.Mabas.Common.Extensions
{
    /// <summary>
    /// Collections Extension Class.
    /// </summary>
    public static class ExtCollections
    {
        /// <summary>
        /// Extension method to do 'ForEach' on IEnumerable without the need
        /// of doing 'foo.ToList.ForEach' as that is bad practice.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items">The items.</param>
        /// <param name="action">The action.</param>
        public static void ForEach<T>(this IEnumerable<T> items, Action<T> action)
        {
            foreach(var item in items)
            {
                action(item);
            }
        }
    }
}