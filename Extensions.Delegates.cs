using System;

namespace SharpExtensions
{
    public static partial class Extensions
    {
        /// <summary>
        /// Try execute an action. Swallow all exceptions
        /// </summary>
        public static void TryExecute(this Action action)
        {
            if (action == null) throw new ArgumentNullException(nameof(action), "An action must be provided");
            try
            {
                action();
            }
            catch (Exception)
            {
                // don't care
            }
        }

        /// <summary>
        /// Try execute an action. Return the exception (if any)
        /// </summary>
        public static Exception TryExecuteWithException(this Action action)
        {
            if (action == null) throw new ArgumentNullException(nameof(action), "An action must be provided");
            Exception ex = null;
            try
            {
                action();
            }
            catch (Exception e)
            {
                ex = e;
            }

            return ex;
        }
    }
}
