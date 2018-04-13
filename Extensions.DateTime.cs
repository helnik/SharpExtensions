using System;

namespace SharpExtensions
{
    public static partial class Extensions
    {
        public static bool Between(this DateTime dt, DateTime minValue, DateTime maxValue)
        {
            return minValue.CompareTo(dt) == -1 && dt.CompareTo(maxValue) == -1;
        }
    }
}
