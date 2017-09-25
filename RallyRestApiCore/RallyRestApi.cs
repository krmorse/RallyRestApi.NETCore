using System;
using System.Net;
using Newtonsoft.Json.Linq;

namespace RallyRestApiCore
{
    public class RallyRestApi : IDisposable
    {
        private CookieAwareWebClient client;

        public RallyRestApi(string server, string userName, string password) {
            Client = new CookieAwareWebClient(new CredentialCache() { { new Uri(server), "Basic", new NetworkCredential(userName, password) } });
        }

        private CookieAwareWebClient Client {
            get {
                if (client == null) {
                    throw new ObjectDisposedException("RallyRestApi");
                }
                return client;
            }
            set {
                client = value;
            }
        }


        public JObject Get(string uri) {
            return Client.Get(uri);
        }

        public void Dispose() {
            Client.Dispose();
            Client = null;
        }
    }
}
