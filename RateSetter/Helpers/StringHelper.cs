using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace RateSetter.Helpers
{
    class StringHelper
    {
        /// <summary>
        /// Remove special characters
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string RemoveSpecialCharacters(string str)
        {
            return Regex.Replace(str, @"[^0-9a-zA-Z]+", "");
        }
        
        /// <summary>
        /// sort characters by accending
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string SortCharacters(string str)
        {
            return String.Concat(str.OrderBy(c => c));
        }
    }
}
