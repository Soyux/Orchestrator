using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExternalAPIAdapter.Logic.Handlers;
using SharedComms;
using Toolbox;
namespace ExternalAPIAdapter.Logic
{
   
    public   class AdapterHandler
    {
        const string _autorname = "Author";
        const string _bookname = "Book";
      
        public AdapterHandler() {
            
        }

        public async Task<Response> GetData(Request request)
        {
            APIResult result;
            
            IAdapter adapter;
            //Build response header
            var response = new Response();
            response.searched_authorname = request.autorname;
            response.searched_bookname= request.bookname;

            //Fetch data from Google API First
            adapter = new AdapterGoogleAPI();
            result = await GetDataFromAPI(adapter, request);
            response.Books = result.books;
            if (result.count==0)
            {
                adapter = new AdapterDummyAPI();
                result = await GetDataFromAPI(adapter, request);
                response.Books = result.books;
                if (result.count == 0)
                { 
                    //Across all available APIS, info not found
                }
            } 

            return response;
        }//end of GetData

        async Task<APIResult> GetDataFromAPI(IAdapter adapter, Request request)
        {   
            var parameters = new List<ParameterMap>();
            parameters.Add(new ParameterMap() { mappedTo = adapter._authorname, input = _autorname, value = request.autorname});
            parameters.Add(new ParameterMap() { mappedTo = adapter._bookname, input = _bookname, value = request.bookname});

            //Fetch data from API
            return  await adapter.GetData(parameters);
             

        }//end of GetDataFromGoogleAPI

    }//end of class
}//end of namespace
