using System.Web.Services.Protocols;

namespace CustomExtensions
{
    public static partial class Extensions
    {           
        public static void DisposeClientOnComplete(this SoapHttpClientProtocol client)
        {
            if (client != null)
            {
                client.Dispose();
                client = null;
            }
        }

        public static void DisposeClientOnException(this SoapHttpClientProtocol client)
        {
            if (client != null)
            {
                try { client.Abort(); }
                catch { client = null; }                
            }
        }
    }
}

