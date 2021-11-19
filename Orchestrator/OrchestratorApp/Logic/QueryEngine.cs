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
         
        const string URLApiAdapter = "https://localhost:44308/ExternalAPI/SearchBook";

        private MasterJSON mjson;

        public QueryEngine(){
            mjson = new MasterJSON();
           
        }

        async Task<Response> InvokeGetAPI_Request(Request request,string serviceURL) {

            //Send data to API
            string jsonresponse = await mjson.PostJSONAsync(serviceURL, request);
            
            //Converts result to Response type
            Response response =  mjson.DeconvertJSONToResponse(jsonresponse);

            return response;
             

        }//end of InvokeAPI

        async Task<Response> InvokeGetAPI_Response(Response response_input, string serviceURL)
        {

            //Send data to API
            string jsonresponse = await mjson.PostJSONAsync(serviceURL, response_input);

            //Converts result to Response type
            var response = mjson.DeconvertJSONToResponse(jsonresponse);

            return response;


        }//end of InvokeAPI

        public async Task<Response> SearchDBFirst(Request request) {

            Response response;
            //Looks for similar information on the Database already searched
            response = await InvokeGetAPI_Request(request, URLEFDB_GetSearchedResult);
            if (response.Books.Count()==0) {

                response = await SearchCloudFirst(request);

            }//not found on databases

            //returns response in plain text
            return response;
            
        }//end of SearchDBFirst

       
        public async Task<Response> SearchCloudFirst(Request request) {
            Response response;
            //IF there isnt info then it will query the external APIs for it
            response = await InvokeGetAPI_Request(request, URLApiAdapter);

            if (response.Books.Count()==0)
            {
                //TODO
                //Information not found anywhere

            }//not found on cloud apis
            else
            {
                //Once information is found, the DB is updated with the new search 
                //Post found info on DB
               await  InvokeGetAPI_Response(response, URLEFDB_PostSearchedResults);

            }//end of else if response was found on externaAPIs
            return response;
        }//end of SearchCloudFirst
        
    }//end of class

}//end of namespace
