using System;
using System.Net;
using Newtonsoft.Json.Linq;
using System.Text;

namespace RallyRestApiCore
{
	internal class CookieAwareWebClient : WebClient
	{
		protected CookieContainer Cookies { get; private set; }

        public CookieAwareWebClient(ICredentials credentials, CookieContainer cookies = null)
			: base()
		{
			this.Cookies = cookies ?? new CookieContainer();
            this.Encoding = new UTF8Encoding();
            this.Credentials = credentials;
		}


        protected override WebRequest GetWebRequest(Uri address)
        {
            WebRequest request = base.GetWebRequest(address);

            HttpWebRequest webRequest = request as HttpWebRequest;
            if (webRequest != null)
            {
                webRequest.CookieContainer = Cookies;
            }
            webRequest.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;
            request.Timeout = 300000;

            return request;
        }

        public JObject Get(string uri) {
            return JObject.Parse(System.Text.Encoding.UTF8.GetString(this.DownloadData(uri)));
        }
	}
}