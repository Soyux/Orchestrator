using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExternalAPIAdapter.Logic.Handlers;
using SharedComms;

namespace ExternalAPIAdapter.Logic
{
    public class AdapterHandler
    {
        const string _autorname = "Author";
        const string _bookname = "Book";
        public Response GetData(Request request)
        {  
            string json = "";
            IAdapter adapter;
            //Build response header
            var response = new Response();
            response.autorname = request.autorname;
            response.bookname = request.bookname;

            //Fetch data from Google API First
            adapter = new AdapterGoogleAPI();
            if (GetDataFromAPI(adapter, request, out json) ==0)
            {
                adapter = new AdapterDummyAPI();
                if (GetDataFromAPI(adapter,  request, out json) == 0)
                {
                   //Across all available APIS, info not found
                }

            }
            response.jsonresponse = json;
            return response;
        }//end of GetData

        int GetDataFromAPI(IAdapter adapter, Request request, out string json)
        {   
            var parameters = new List<ParameterMap>();
            parameters.Add(new ParameterMap() { mappedTo = adapter._authorname, input = _autorname, value = request.autorname});
            parameters.Add(new ParameterMap() { mappedTo = adapter._bookname, input = _bookname, value = request.bookname});

            //Fetch data from API
            return adapter.GetData(parameters, out json);

        }//end of GetDataFromGoogleAPI

    }//end of class
}//end of namespace
