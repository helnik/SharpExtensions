using System.Web.Services.Protocols;

namespace SharpExtensions
{
    public static partial class Extensions
    {           
        public static void DisposeClientOnComplete(this SoapHttpClientProtocol client)
        {
            if (client == null)
                return;
            client.Dispose();
            client = null;
        }

        public static void DisposeClientOnException(this SoapHttpClientProtocol client)
        {
            if (client == null)
                return;
            try
            {
                client.Abort();
            }
            catch
            {
                client = null;
            }
        }
    }
}

