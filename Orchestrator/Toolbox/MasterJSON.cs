using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json.Serialization;
using SharedComms;
using Newtonsoft.Json;
using System.Threading.Tasks;
using SharedComms.Model;

namespace Toolbox
{
    public class MasterJSON
    {
        public string PostJSON(string url, dynamic requestItem)
        {
            string request = JsonConvert.SerializeObject(requestItem);
            var webhelper = new MasterHTTP(url, "POST", request, true);
            string response = webhelper.GetResponse();

            return response;
        }

        public async Task<string> PostJSONAsync(string url, dynamic requestItem)
        {
            string request = JsonConvert.SerializeObject(requestItem);
            var webhelper = new MasterHTTP(url, "POST", request, true);
            string response = await webhelper.GetResponseAsync();

            return response;
        }

        private JsonTextReader reader;
        public void LoadJSON(string originalJSON)
        {

            reader = new JsonTextReader(new StringReader(originalJSON));

        }

        public string LookupItem(string searchParam)
        {

            var lastitem = "";
            var resultado = "";
            while (reader.Read())
            {
                if (reader.Value != null)
                {
                    var valor = reader.Value.ToString();

                    if (reader.TokenType.ToString() == "PropertyName")
                    {
                        lastitem = valor;
                    }
                    else
                    {
                        if (lastitem.Equals(searchParam))
                        {
                            resultado = valor;
                            break;
                        }
                    }//fin de if
                }//fin de while
            }
            return resultado;

        }//end of LookupItem
        public object DeconvertJSONToObject(string jsonresponse)
        {
            var request = (Newtonsoft.Json.Linq.JObject)JsonConvert.DeserializeObject(jsonresponse);
            return request;
            //var webhelper = new MasterHTTP(url, "POST", request, true);
            //string response = webhelper.GetResponse();

            //return response;
        }

        public List<Book> DeconvertJSONToListBook(string jsonresponse)
        {
            var request =  (List<Book>)JsonConvert.DeserializeObject(jsonresponse,typeof(List<Book>));
            return request;
            //var webhelper = new MasterHTTP(url, "POST", request, true);
            //string response = webhelper.GetResponse();

            //return response;
        }


        public dynamic DeconvertJSONToDynamic(string jsonresponse)
        {
            return  JsonConvert.DeserializeObject(jsonresponse);
            //var webhelper = new MasterHTTP(url, "POST", request, true);
            //string response = webhelper.GetResponse();

            //return response;
        }

        public Response DeconvertJSONToResponse(string jsonresponse)
        {
            var request = JsonConvert.DeserializeObject<Response>(jsonresponse);
            return request;
            //var webhelper = new MasterHTTP(url, "POST", request, true);
            //string response = webhelper.GetResponse();

            //return response;
        }

        public Request DeconvertJSONToRequest(string jsonresponse)
        {
            var request = JsonConvert.DeserializeObject<Request>(jsonresponse);
            return request;
            //var webhelper = new MasterHTTP(url, "POST", request, true);
            //string response = webhelper.GetResponse();

            //return response;
        }
        public string ConvertRequestToJson(Request data )
        {
            var request = JsonConvert.SerializeObject(data);
            return request;
            //var webhelper = new MasterHTTP(url, "POST", request, true);
            //string response = webhelper.GetResponse();

            //return response;
        }

        public string ConvertResponseToJson(Response data)
        {
            var request = JsonConvert.SerializeObject(data);
            return request;
            //var webhelper = new MasterHTTP(url, "POST", request, true);
            //string response = webhelper.GetResponse();

            //return response;
        }

        public string ConvertObjectoToJSON(dynamic input) {

            var responseJson = JsonConvert.SerializeObject(input, Newtonsoft.Json.Formatting.Indented, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            return responseJson;
        }

        public string ConvertListBookToJSON(List<Book> input)
        {
            var responseJson = JsonConvert.SerializeObject(input);
            return responseJson;
        }

        public string GetValueJSON(string jsonresponse, string titulo)
        {
            try
            {
                var request = (Newtonsoft.Json.Linq.JObject)JsonConvert.DeserializeObject(jsonresponse);

                return request.GetValue(titulo).ToString();
            }
            catch (Exception e)
            {
              //  ApplicationLogger.LogError("GetValueJSON: " + jsonresponse, e);
                return "";
            }
            //var webhelper = new MasterHTTP(url, "POST", request, true);
            //string response = webhelper.GetResponse();

            //return response;
        }

    }
}
