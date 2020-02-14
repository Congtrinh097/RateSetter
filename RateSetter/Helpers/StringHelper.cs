using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace RateSetter.Helpers
{
    public class StringHelper
    {
        /// <summary>
        /// Remove special characters
        /// </summary>
        /// <param name="str"></param>
        /// <returns>Return string after removed special characters</returns>
        public static string RemoveSpecialCharacters(string str)
        {
            return Regex.Replace(str, @"[^0-9a-zA-Z]+", "");
        }
        
        /// <summary>
        /// sort characters in string
        /// </summary>
        /// <param name="str"></param>
        /// <returns>Return string after sorted by accending</returns>
        public static string SortCharacters(string str)
        {
            return String.Concat(str.OrderBy(c => c));
        }
    }
}
