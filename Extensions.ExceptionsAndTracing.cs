using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace SharpExtensions
{
    public static partial class Extensions
    {
        /// <summary>
        /// returns a list of all inner exceptions of the given exception
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        public static List<Exception> GetAllInners(this Exception ex)
        {
            List<Exception> exceptions = new List<Exception>();
            Exception inner = ex;
            while (inner != null)
            {
                exceptions.Add(inner.InnerException);
                inner = inner.InnerException;
            }
            return exceptions;
        }

        /// <summary>
        /// gets ths deepest inner exception
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        public static Exception GetMostInner(this Exception ex)
        {
            Exception inner = ex;

            while (inner != null)
            {
                inner = inner.InnerException;
                if (inner != null)
                    ex = inner;
            }
            return ex;
        }

        /// <summary>
        /// returns a string to log
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        public static string ToLoggableString(this Exception ex, string extraMessage = "")
        {
            StringBuilder log = new StringBuilder(DateTime.Now.ToString($"yyyy-MM-dd HH:mm:ss.fff : "));

            if (ex.Source != null) log.Append($"at {ex.Source} ");

            if (!string.IsNullOrEmpty(extraMessage)) log.Append($"{extraMessage} ");

            log.Append("Exception Messages= ");
            Exception newEx = ex;
            int i = 1;
            while (newEx != null)
            {
                log.Append($"#{i}: {ex.Message} ");
                i++;
                newEx = newEx.InnerException;
            }

            log.Append($"Exception Stacktrace = {ex.StackTrace} ");

            Exception exBase = ex.GetBaseException();
            if (exBase != null) log.Append($"Base Exception= {exBase}");

            return log.ToString();
        }

        ///requires <see cref="Newtonsoft.Json"/> nuget
        public static string ToJson(this Exception ex)
        {
            Newtonsoft.Json.JsonSerializerSettings settings = new Newtonsoft.Json.JsonSerializerSettings();
            settings.Formatting = Newtonsoft.Json.Formatting.Indented;
            string serialized = Newtonsoft.Json.JsonConvert.SerializeObject(ex, settings);
            return serialized;
        }

        /// <summary>
        /// writes the exception to eventlog
        /// </summary>       
        public static void ToEventLog(this Exception ex, string eventSource, EventLogEntryType logType = EventLogEntryType.Error)
        {
            try
            {                 
                EventLog.WriteEntry(eventSource, ex.Message, logType);
            }
            catch
            {                
                throw new Exception("Error Logging Exception", ex);
            }
        }
        
        /// <summary>
        /// writes the exception message and stacktrace with datetime.Now prefixed
        /// </summary>   
        public static void TraceWriteLine(this Exception ex)
        {
            Trace.WriteLine($"{DateTime.Now.ToString($"yyyy - MM - dd HH: mm:ss.fff : ")} {ex.Message} : {ex.StackTrace}");
        }
    }
}
