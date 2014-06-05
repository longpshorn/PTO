using System;
using System.Text;

namespace PTO.Core.Extensions
{
    public static class StringBuilderExtensions
    {
        /// <summary>
        /// Appends the specified string in a new line or the first line when the <see cref="StringBuilder"/> was empty.
        /// </summary>
        /// <param name="sb">The string builder.</param>
        /// <param name="value">The string to append.</param>
        /// <returns>A reference to the string builder instance after the append operation has completed.</returns>
        /// <exception cref="ArgumentNullException">The argument sb must not be null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Enlarging the value of this instance would exceed System.Text.StringBuilder.MaxCapacity.</exception>
        public static StringBuilder AppendInNewLine(this StringBuilder sb, string value)
        {
            if (sb == null)
                throw new ArgumentNullException("The string builder was null.");

            if (sb.Length == 0)
                sb.Append(value);
            else
                sb.Append(Environment.NewLine + value);

            return sb;
        }

        /// <summary>
        /// Appends the value to the string builder object in the case that the 
        /// </summary>
        /// <param name="sb">The string builder.</param>
        /// <param name="value">The string to append if it is not null, empty, or whitespace.</param>
        /// <returns>A reference to the string builder instance after the append operation has completed.</returns>
        /// <exception cref="ArgumentNullException">The argument sb must not be null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Enlarging the value of this instance would exceed System.Text.StringBuilder.MaxCapacity.</exception>
        public static StringBuilder AppendIfNotBlank(this StringBuilder sb, string value)
        {
            if (sb == null)
                throw new ArgumentNullException("The string builder was null.");

            if (value.HasValue())
                sb.Append(value);

            return sb;
        }
    }
}
