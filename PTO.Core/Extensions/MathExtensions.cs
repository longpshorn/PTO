namespace PTO.Core.Extensions
{
    public static class MathExtensions
    {
        /// <summary>
        /// Counts the number of bits set for the binary representation of the value passed.
        /// This is known as the "Hamming Weight".
        /// 
        /// Examples:
        ///   - For the number 12 (0x1100), the Hamming Weight is 2.
        ///   - For the number 2 (0x10), the Hamming Weigth is 1.
        /// </summary>
        /// <param name="i">The number for which the number of set bits should be counted.</param>
        /// <returns>The count of the number of set bits.</returns>
        public static int CountSetBits(int i)
        {
            i = i - ((i >> 1) & 0x55555555);
            i = (i & 0x33333333) + ((i >> 2) & 0x33333333);
            return (((i + (i >> 4)) & 0x0F0F0F0F) * 0x01010101) >> 24;
        }

        /// <summary>
        /// Checks if the number passed is a power of 2.
        /// </summary>
        /// <param name="i">The number to be checked.</param>
        /// <returns>A boolean indication of whether or not the number is a power of 2.</returns>
        public static bool IsPowerOfTwo(int i)
        {
            return i > 0 && (i & (i - 1)) == 0;
        }

        /// <summary>
        /// Checks to see if only one bit is set in the binary representation of a number 
        /// (i.e., checks to see if the number is a power of 2).
        /// </summary>
        /// <param name="i">The number to be checked.</param>
        /// <returns>A boolean indication of whether or not the number has only one bit set.</returns>
        public static bool OneBitSet(int i)
        {
            return IsPowerOfTwo(i);
        }
    }
}
