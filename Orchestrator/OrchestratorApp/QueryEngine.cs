using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using SharedComms;
using Toolbox;

namespace OrchestratorApp
{
    public class QueryEngine
    {
        const string URLEFDB = "https://localhost:44375/api/SearchedResults/";
        const string URLApiAdapter = "https://localhost:44308/api/ExternalAPI/GetBooks";

        Response InvokeGetAPI(Request request,string serviceURL) {



            var http = new MasterHTTP();
            HttpResponseMessage response;

            var httpparameter = ConvertParameterToHTTPParameter(parameters);
            response = http.GEtJSONAsync(googleapi + httpparameter, "").GetAwaiter().GetResult();
            string res = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            json = res; 

        }//end of InvokeAPI



        public Response SearchDBFirst(Request request) {

            //Looks for similar information on the Database already searched

                //IF there isnt info then it will query the external APIs for it

                //Once information is found, the DB is updated with the new search 

            //returns response back

        }//end of SearchDBFirst

        public void SearchCloudFirst() {
            //invokes the externalAPIAdapter for the query 

            //updates the DB with the search result

        }//end of SearchCloudFirst
        
    }//end of class

}//end of namespace
