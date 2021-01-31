using System;
using System.Collections.Generic;
using System.Linq;

namespace Extendy.Collections
{
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Checks whether any of the <paramref name="values"/> exist in the <paramref name="source"/>
        /// </summary>
        /// <typeparam name="TSource">The type of objects in the collection.</typeparam>
        /// <typeparam name="TValues">The type of values to add to the collection.</typeparam>
        /// <param name="values">The elements to check for in the collection
        /// The collection itself cannot be null, but the values can be null, if T is a reference type./></param>.
        /// <exception cref="ArgumentNullException" />
        public static bool ContainsAny<TSource, TValues>(this IEnumerable<TSource> source, params TValues[] values) where TValues : class, TSource where TSource : class
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (values == null)
                throw new ArgumentNullException(nameof(values));

            return source.Any(item => values.Contains(item));
        }

        /// <summary>
        /// Checks whether any of the <paramref name="values"/> exist in the <paramref name="source"/>
        /// </summary>
        /// <typeparam name="T">The type of objects in the collection.</typeparam>
        /// <param name="values">The elements to check for in the collection. 
        /// The collection itself cannot be null, but the values can be null, if T is a reference type./></param>.
        /// <exception cref="ArgumentNullException" />
        public static bool ContainsAny<T>(this IEnumerable<T> source, params T[] values) where T : struct
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (values == null)
                throw new ArgumentNullException(nameof(values));

            return source.Any(item => values.Any(val => val.Equals(item)));
        }

        /// <summary>
        /// Adds the specified values to the <see cref="ICollection{T}"/>
        /// </summary>
        /// <typeparam name="TSource">The type of objects in the collection.</typeparam>
        /// <typeparam name="TValues">The type of values to add to the collection.</typeparam>
        /// <param name="values">The elements who should be added to the collection.
        /// The collection itself cannot be null, but the values can be null, if T is a reference type./></param>.
        /// <exception cref="ArgumentNullException" />
        public static void AddRange<TSource, TValues>(this ICollection<TSource> source, params TValues[] values) where TValues : TSource
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (values == null)
                throw new ArgumentNullException(nameof(values));

            foreach (TValues value in values)
                source.Add(value);
        }

        /// <summary>
        /// Removes duplicate values from the <see cref="ICollection{T}"/>
        /// </summary>
        /// <typeparam name="T">The type of objects in the collection.</typeparam>
        /// <param name="source">The collection to remove duplicates from</param>
        /// <exception cref="ArgumentNullException" />
        public static void RemoveDuplicates<T>(this ICollection<T> source)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            HashSet<T> knownDuplicates = new HashSet<T>();
            List<T> distinctItems = new List<T>();

            for (int i = 0; i < source.Count; i++)
            {
                if (knownDuplicates.Add(source.ElementAt(i)))
                    distinctItems.Add(source.ElementAt(i));
            }

            source.Clear();

            foreach (T item in distinctItems)
            {
                source.Add(item);
            }
        }

        /// <summary>
        /// Returns distinct elements from a sequence based on a function.
        /// </summary>
        /// <typeparam name="TSource">The type of values in the collection.</typeparam>
        /// <typeparam name="TKey">The type of values to select the key from.</typeparam>
        /// <param name="keySelector">A function that defines the conditions of how to select distinct elements</param>
        /// <returns>An <see cref="IEnumerable{T}"/>that represents distinct elements from the source sequence.</returns>
        /// <exception cref="ArgumentNullException" />
        public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            HashSet<TKey> foundKeys = new HashSet<TKey>();
            bool foundNull = false;

            foreach (TSource element in source)
            {
                if (element != null)
                {
                    if (foundKeys.Add(keySelector(element)))
                    {
                        yield return element;
                    }
                }
                else if (!foundNull)
                {
                    foundNull = true;
                    yield return element;
                }
            }
        }
    }
}
