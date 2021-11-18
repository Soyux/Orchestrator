using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Toolbox;

namespace ExternalAPIAdapter.Logic.Handlers
{
    public class AdapterGoogleAPI : IAdapter
    {
        public string _authorname { get; set; }
        public string _bookname { get; set; }

        const string googleapi = "https://www.googleapis.com/books/v1/volumes?q=";
        public string serviceURL { get => googleapi; }

        public AdapterGoogleAPI()
        {
            _authorname = "inauthor";
            _bookname = "intitle";

        }//end of constructor

        /// <summary>
        /// Converts the object parameter to the specific HTTP Parameter
        /// for Google API 
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public string ConvertParameterToHTTPParameter(List<ParameterMap> parameters)
        {
            string returnvalue = "";
            foreach (var param in parameters)
            {
                returnvalue += param.mappedTo + ":" + param.value;
                if (parameters.IndexOf(param) != (parameters.Count - 1))
                {
                    returnvalue += "+";
                }
            }//end of foreach
            return returnvalue;
        }//end of ConvertParameter

        /// <summary>
        /// Invokes the API from Google API Books and returns the JSON and the total of values found
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns>The total of records found</returns>
        public APIResult  GetData(List<ParameterMap> parameters )
        {
            var http = new MasterHTTP();
            HttpResponseMessage response;

            var httpparameter = ConvertParameterToHTTPParameter(parameters);
            response = http.GEtJSONAsync(googleapi + httpparameter, "").GetAwaiter().GetResult();
            string res = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();

            return new APIResult()
            {
                count = extractTotalFound(res),
                json = res
            };
        
        }//end of GetData

        public int extractTotalFound(string json) {
            var masterjson = new MasterJSON();
            var totalregisters = masterjson.GetValueJSON(json, "totalItems");
            return int.Parse(totalregisters);
        }


    }//end of class
}//end of namespace
