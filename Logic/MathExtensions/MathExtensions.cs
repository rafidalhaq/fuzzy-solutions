namespace IGS.MathExtensions
{
    public static class MathExtensions
    {
        /// <summary>
        /// Returns 1 if first less or equal than second, or returns second
        /// </summary>
        public static double Truncation(double first, double second)
        {
           return first <= second ?  1 : second;
        }

        /// <summary>
        /// Returns 1 if first less than second, or returns second
        /// </summary>
        public static int LaxTruncation(int first, int second)
        {
            return first < second ? 1 : second;
        }
    }
}
