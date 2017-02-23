using System;

namespace CustomExtensions
{
    public partial class Extensions
    {
        public static bool Between(this DateTime dt, DateTime minValue, DateTime maxValue)
        {
            return minValue.CompareTo(dt) == -1 && dt.CompareTo(maxValue) == -1;
        }
    }
}
