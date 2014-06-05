using System;
using System.Text.RegularExpressions;
using System.Linq;

namespace PTO.Core.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Returns the first n characters or the full length of the string, whichever is smaller.
        /// </summary>
        /// <param name="source">The source string to take the first n characters from.</param>
        /// <param name="n">The desired number of characters to take.</param>
        /// <returns>
        /// A shortened version of the string, unless n is greater than the length of the string,
        /// in which case the entire string will be returned.
        /// </returns>
        public static string Left(this string source, int n)
        {
            return source.Substring(0, Math.Max(0, Math.Min(n, source.Length)));
        }

        /// <summary>
        /// Get substring of specified number of characters on the right.
        /// </summary>
        /// <param name="source">The source string to take the last n characters from.</param>
        /// <param name="n">The desired number of characters to take.</param>
        /// <returns>The last n characters of the source string.</returns>
        public static string Right(this string source, int n)
        {
            return source.Substring(source.Length - n);
        }

        /// <summary>
        /// Trims characters of specfied length from the front of a string.
        /// </summary>
        /// <param name="source">The string from which the characters should be trimmed.</param>
        /// <param name="length">The number of characters that should be trimmed from the front of the string.</param>
        /// <returns>An empty string or the string with the number of characters specified trimmed from the beginning of the string.</returns>
        public static string TrimStartLength(this string source, int length)
        {
            return string.Join(string.Empty, source.Skip(length));
        }

        /// <summary>
        /// Converts the string to a the lower-case version of the string, unless the string is null,
        /// in which case the empty string will be returned.
        /// </summary>
        /// <param name="source">The string that should be converted to lower-case or the empty string.</param>
        /// <returns>A lower-case version of the string or the empty string.</returns>
        public static string ToLowerOrBlank(this string source)
        {
            return string.IsNullOrEmpty(source) ? "" : source.ToLower();
        }

        /// <summary>
        /// Shortcut method to determine if a string has a value.
        /// </summary>
        /// <param name="value">The string to be evaluated.</param>
        /// <param name="strict">Whether or not white space should be checked when determining if the string has a value.</param>
        /// <returns>A boolean indication of whether or not the string has a value.</returns>
        public static bool HasValue(this string value, bool strict = true)
        {
            return strict ? !string.IsNullOrWhiteSpace(value) : !string.IsNullOrEmpty(value);
        }

        /// <summary>
        /// Extracts characters (a-zA-Z, ) from the string.
        /// </summary>
        /// <param name="value">The string from which to extract the characters.</param>
        /// <param name="pattern">The pattern to be used to extract the characters.</param>
        /// <returns>The string with the non-pattern matched characters removed.</returns>
        public static string ExtractCharacters(this string value, string pattern = @"[^a-zA-Z, ]+")
        {
            return Regex.Replace(value, pattern, string.Empty);
        }

        /// <summary>
        /// Extracts the numbers from the string.
        /// </summary>
        /// <param name="value">The string from which the numbers should be extracted.</param>
        /// <param name="pattern">The pattern to be used to extract the characters.</param>
        /// <returns>The string with the non-pattern matched characters removed.</returns>
        public static string ExtractNumbers(this string value, string pattern = @"[^\d+]")
        {
            return Regex.Replace(value, pattern, string.Empty);
        }

        /// <summary>
        /// Remove HTML tags from string using char array.
        /// </summary>
        public static string StripTags(this string source)
        {
            // @"(?></?\w+)(?>(?:[^>'""]+|'[^']*'|""[^""]*"")*)>"
            char[] array = new char[source.Length];
            int arrayIndex = 0;
            bool inside = false;

            foreach (char let in source)
            {
                if (let == '<')
                {
                    inside = true;
                    continue;
                }
                if (let == '>')
                {
                    inside = false;
                    continue;
                }
                if (inside)
                {
                    continue;
                }
                array[arrayIndex] = @let;
                arrayIndex++;
            }

            return new string(array, 0, arrayIndex);
        }

        private const int VeryLongWordLength = 18;

        /// <summary>
        /// Gets a snippet of the string making sure to break on full words.
        /// </summary>
        /// <param name="source">The source string for which to retrieve the teaser snippet.</param>
        /// <param name="maxLength">The maximum number of characters to return from the string (default: 100).</param>
        /// <param name="ender">The string used to end the teaser if the string exceeds the max length value (default: "...").</param>
        /// <returns></returns>
        public static string GetTeaserSnippet(this string source, int maxLength = 100, string ender = "...")
        {
            string temp = " ";
            if (source != null)
            {
                temp = source.StripTags();

                string ending = temp.Length > maxLength ? ender : string.Empty;

                temp = temp.Length >= maxLength ? temp.Left(maxLength) : temp;

                int n = Math.Max(temp.Length < maxLength ? maxLength : temp.LastIndexOf(" ", StringComparison.CurrentCulture), maxLength - VeryLongWordLength);

                temp = temp.Left(n) + ending;
            }
            return temp;
        }

        public static string ToSeparatedWords(this string value)
        {
            if (value != null && value.Length > 3)
                return Regex.Replace(value, "([A-Z][a-z]?)", " $1").Trim();
            return value;
        }
    }
}
