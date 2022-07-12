﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zilliqa.DesktopWallet.Core.Extensions
{
    /// <summary>
    /// Provides extensions for <see cref="IEnumerable{T}"/> and <see cref="IEnumerable"/>
    /// </summary>
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Performs the specified <paramref name="action"/> on each element of the <see cref="IEnumerable{T}"/>.
        /// </summary>
        /// <typeparam name="T"> 
        /// The element type.
        /// </typeparam>
        /// <param name="enumerable">
        /// The <see cref="IEnumerable{T}"/> that provides the elements on which the <paramref name="action"/> shall be performed.
        /// </param>
        /// <param name="action">
        /// The <see cref="Action{T}"/> delegate to perform on each element of the <see cref="IEnumerable{T}"/>.
        /// </param>
        public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T> action)
        {
            if (enumerable == null)
            {
                throw new ArgumentNullException("enumerable");
            }

            if (action == null)
            {
                throw new ArgumentNullException("enumerable");
            }


            foreach (T element in enumerable)
            {
                action(element);
            }
        }

        /// <summary>
        /// Casts the elements of <see cref="IEnumerable"/> to <typeparamref name="T"/> and performs the specified 
        /// <paramref name="action"/> on each element of the <see cref="IEnumerable"/>.
        /// </summary>
        /// <typeparam name="T">
        /// The element type.
        /// </typeparam>
        /// <param name="enumerable">
        /// The <see cref="IEnumerable"/> that provides the elements on which the <paramref name="action"/> shall be performed.
        /// </param>
        /// <param name="action">
        /// The <see cref="Action{T}"/> delegate to perform on each element of the <paramref name="enumerable"/>.
        /// </param>
        public static void ForEach<T>(this IEnumerable enumerable, Action<T> action)
        {
            if (enumerable == null)
            {
                throw new ArgumentNullException("enumerable");
            }

            if (action == null)
            {
                throw new ArgumentNullException("enumerable");
            }

            foreach (T element in enumerable.Cast<T>())
            {
                action(element);
            }
        }
    }
}
