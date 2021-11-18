using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Toolbox
{
    public class MasterHTTP
    {
        private WebRequest request;
        private Stream dataStream;

        private string status;

        public String Status
        {
            get
            {
                return status;
            }
            set
            {
                status = value;
            }
        }

        public void DownloadFile(string source, string destination)
        {

            using (var client = new WebClient())
            {
                client.DownloadFile(source, destination);
            }
        }



        public async Task<HttpResponseMessage> POSTJSONAsync(string url, string data, string accessToken)
        {


            HttpClient client = new HttpClient();
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            HttpResponseMessage response = await client.PostAsync(url, new StringContent(data, Encoding.UTF8, "application/json"));
            //if (response.IsSuccessStatusCode)
            //{
            //    resultado = response.ReasonPhrase;
            //}
            //else
            //{
            //    if (response.StatusCode == HttpStatusCode.BadRequest) {//400 error

            //    }

            //                resultado = response.Headers.GetValues("X-Error-Cause").FirstOrDefault();
            //}


            return response;


            //var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            //httpWebRequest.ContentType = "application/json";
            //httpWebRequest.Method = "POST";

            //httpWebRequest.PreAuthenticate = true;
            //httpWebRequest.Headers.Add("Authorization", "Bearer " + accessToken);

            //using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            //{
            //    string json = data;

            //    streamWriter.Write(json);
            //    streamWriter.Flush();
            //    streamWriter.Close();
            //}

            //var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            //using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            //{
            //    var result = streamReader.ReadToEnd();
            //    return result;
            //}

        }


        public async Task<HttpResponseMessage> GEtJSONAsync(string url, string accessToken)
        {


            HttpClient client = new HttpClient();
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            HttpResponseMessage response = await client.GetAsync(url);
            //if (response.IsSuccessStatusCode)
            //{
            //    resultado = response.ReasonPhrase;
            //}
            //else
            //{
            //    if (response.StatusCode == HttpStatusCode.BadRequest) {//400 error

            //    }

            //                resultado = response.Headers.GetValues("X-Error-Cause").FirstOrDefault();
            //}


            return response;




        }//fin de metodo




        public MasterHTTP(string url)
        {
            // Create a request using a URL that can receive a post.

            request = WebRequest.Create(url);
        }

        public MasterHTTP(string url, string method)
            : this(url)
        {

            if (method.Equals("GET") || method.Equals("POST"))
            {
                // Set the Method property of the request to POST.
                request.Method = method;
            }
            else
            {
                throw new Exception("Invalid Method Type");
            }
        }

        public string URLEncode(string valor)
        {

            return System.Net.WebUtility.UrlEncode(valor);
        }

        //https://www.quora.com/How-do-I-post-JSON-data-to-API-using-C




        public MasterHTTP(string url, string method, string data, bool json = false, string token = "")
            : this(url, method)
        {
            var myhttpwebrequest = (HttpWebRequest)request;

            // Create POST data and convert it to a byte array.
            string postData = data;
            byte[] byteArray = json ? Encoding.ASCII.GetBytes(postData) : Encoding.UTF8.GetBytes(postData);

            // Set the ContentType property of the WebRequest.
            request.ContentType = json ? "application/json" : "application/x-www-form-urlencoded;charset=utf-8";

            if (token.Trim().Length>0)
            {

                request.PreAuthenticate = true;
                request.Headers.Add("Authorization", "Bearer " + token);

            }//fin de if

            // Set the ContentLength property of the WebRequest.
            request.ContentLength = byteArray.Length;

            // Get the request stream.
            dataStream = request.GetRequestStream();

            // Write the data to the request stream.
            dataStream.Write(byteArray, 0, byteArray.Length);

            // Close the Stream object.
            dataStream.Close();

        }

        public MasterHTTP()
        {
        }

        public string GetResponse()
        {

            // Get the original response.
            WebResponse response = request.GetResponse();

            this.Status = ((HttpWebResponse)response).StatusDescription;

            // Get the stream containing all content returned by the requested server.
            dataStream = response.GetResponseStream();

            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream);

            // Read the content fully up to the end.
            string responseFromServer = reader.ReadToEnd();

            // Clean up the streams.
            reader.Close();
            dataStream.Close();
            response.Close();

            return responseFromServer;
        }

    }
}
