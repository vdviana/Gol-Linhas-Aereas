using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace Gol.Test.Helpers
{


    public class HttpHelperConfig
    {



        public string _urlapi { get; set; }
        public int _timeoutConnection { get; set; }
        public string _method { get; set; }
        public string _action { get; set; }
        public string _parameters { get; set; }
        public string _body { get; set; }
        public WebHeaderCollection _headerCollection { get; set; }

    }

    public class HttpRequestHelper
    {
        public string urlapi;
        public int timeoutConnection = 6000;
        public string method;
        public string action;
        public string parameters = "";
        public string body = "";
        public WebHeaderCollection headerCollection = null;

        public void Configure(HttpHelperConfig config)
        {


            urlapi = config._urlapi;
            timeoutConnection = config._timeoutConnection == 0 ? timeoutConnection : config._timeoutConnection;
            method = config._method;
            action = config._action;
            parameters = config._parameters;
            body = config._body;
            headerCollection = config._headerCollection;
        }

        private void Validate()
        {
            if (string.IsNullOrWhiteSpace(urlapi) || string.IsNullOrWhiteSpace(method) || string.IsNullOrWhiteSpace(action))
            {
                throw new Exception("please Register the \"urlapi\", \"method\" and \"action\" params for properly use of this Helper");
            }
        }

        private void CreateRequest(string method, string url, int? timeout, WebHeaderCollection headers, string parameters, out UTF8Encoding enc, out HttpWebRequest request)
        {
            enc = new UTF8Encoding();

            if (!string.IsNullOrEmpty(parameters))
            {
                url += $"{parameters}";
            }

            request = WebRequest.Create(url) as HttpWebRequest;

            if (timeout.HasValue && timeout.Value > 0)
            {
                request.Timeout = timeout.Value;
            }

            request.Method = method;
            request.Headers = headers;

            if (request.Headers == null)
            {
                request.Headers = new WebHeaderCollection();
            }
            //request.ContentType = "application/json";
            //request.Accept = "application/json";

            if (!request.Headers.AllKeys.Any(x => x == "Content-Type"))
            {
                request.Headers.Add("Content-Type", "application/json");
            }

            if (!request.Headers.AllKeys.Any(x => x == "Accept"))
            {
                request.Headers.Add("Accept", "application/json");
            }
        }

        private string MakeRequest(string method, string url, int? timeout, WebHeaderCollection headers, string parameters = "", string body = "")
        {

            HttpWebRequest request;
            CreateRequest(method, url, timeout, headers, parameters, out UTF8Encoding enc, out request);

            if (!method.Equals("GET"))
            {
                request.ContentLength = enc.GetBytes(body).Length;

                using (var dataStream = request.GetRequestStream())
                {
                    dataStream.Write(enc.GetBytes(body), 0, enc.GetBytes(body).Length);
                    dataStream.Flush();
                }
            }

            var response = string.Empty;
            using (WebResponse wr = request.GetResponse())
            {
                using (Stream receiveStream = wr.GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(receiveStream, Encoding.UTF8))
                    {
                        response = reader.ReadToEnd();
                    }
                }
            }

            return response;
        }

        private string request()
        {
            try
            {
                var header = headerCollection ?? new WebHeaderCollection();
                return MakeRequest(method, urlapi + "/" + action, timeoutConnection, header, parameters, body);
            }
            catch (Exception ex) { throw ex; }
        }

        public T ExecuteRequest<T>() where T : class
        {
            Validate();
            return new JsonObject<T>(request()).Object;
        }
        public int ExecuteRequest()
        {
            Validate();
            return int.Parse(request());
        }


        public string ExecuteRequestString()
        {
            Validate();
            return request();
        }

    }
}
