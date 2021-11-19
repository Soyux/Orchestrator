using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Toolbox;
using SharedComms.Model;
using SharedComms;
using Newtonsoft.Json.Linq;

namespace ExternalAPIAdapter.Logic.Handlers
{
    public class AdapterGoogleAPI : IAdapter
    {
        public string _authorname { get; set; }
        public string _bookname { get; set; }

        const string googleapi = "https://www.googleapis.com/books/v1/volumes?q=";
        public string serviceURL { get => googleapi; }
        private MasterJSON mjson;
        public AdapterGoogleAPI()
        {
            mjson = new MasterJSON();
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
        public async Task<APIResult> GetData(List<ParameterMap> parameters )
        {
            var http = new MasterHTTP();
            HttpResponseMessage response;

            var httpparameter = ConvertParameterToHTTPParameter(parameters);
            response = http.GEtJSONAsync(googleapi + httpparameter, "").GetAwaiter().GetResult();
            string res = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();

            return extractInfo(res);
        
        }//end of GetData

        public APIResult extractInfo(string json)
        {
            var result = new APIResult();
             

            dynamic obj =mjson.DeconvertJSONToObject(json);
            var totalitems = (int)obj.totalItems;
            if (obj.items != null) {
                foreach (var book in obj.items) {

                    var new_book = new Book();
                    var volumeInfo = book.volumeInfo;

                    new_book.Title = volumeInfo.title ?? "";
                    new_book.Publisher = volumeInfo.publisher ?? "";
                    if (volumeInfo.authors != null) {
                        foreach (string author in volumeInfo.authors) {
                            new_book.Authors.Add(author);
                        }
                    }
                    result.books.Add(new_book);

                }//end of foreach
            }
            result.count = totalitems;
            return result;
        }


    }//end of class
}//end of namespace
