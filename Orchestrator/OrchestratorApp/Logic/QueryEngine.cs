using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using SharedComms;
using Toolbox;

namespace OrchestratorApp.Logic
{
    public class QueryEngine
    {
        const string URLEFDB = "https://localhost:44375/SearchedResults/";
        const string URLEFDB_GetSearchedResult = URLEFDB+"Find/";

        const string URLEFDB_PostSearchedResults = URLEFDB + "Post/";

        const string URLApiAdapter = "https://localhost:44308/api/ExternalAPI/GetBooks";

        private MasterJSON mjson;

        public QueryEngine(){
            mjson = new MasterJSON();
        }

        Response InvokeGetAPI(Request request,string serviceURL) {

            //Send data to API
            string jsonresponse = mjson.PostJSON(serviceURL, request);
            
            //Converts result to Response type
            Response response =  mjson.DeconvertJSONToResponse(jsonresponse);

            return response;
             

        }//end of InvokeAPI

        public async Task<Response> SearchDBFirst(Request request) {

            Response response;
            //Looks for similar information on the Database already searched
            response = InvokeGetAPI(request, URLEFDB_GetSearchedResult);
            if (response.foundOn == (int)FoundType.NotFound) {

                response = await SearchCloudFirst(request);

            }//not found on databases

            //returns response back
            return response;
        }//end of SearchDBFirst
         

        public async Task<Response> SearchCloudFirst(Request request) {
            Response response;
            //IF there isnt info then it will query the external APIs for it
            response = InvokeGetAPI(request, URLApiAdapter);

            if (response.foundOn == (int)FoundType.NotFound)
            {
                //TODO
                //Information not found anywhere

            }//not found on cloud apis
            else
            {
                //Once information is found, the DB is updated with the new search 
                InvokeGetAPI(request, URLEFDB_PostSearchedResults);

            }//end of else if response was found on externaAPIs
            return response;
        }//end of SearchCloudFirst
        
    }//end of class

}//end of namespace
