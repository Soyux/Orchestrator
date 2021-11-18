using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExternalAPIAdapter.Logic.Handlers;

namespace ExternalAPIAdapter.Logic
{
    public class AdapterHandler
    {
        const string _autorname = "Author";
        const string _bookname = "Book";
        public Response GetData(string input_author_name, string input_book_name)
        {
           
            string json = "";
            IAdapter adapter;
            //Build response header
            var response = new Response();
            response.autorname = input_author_name;
            response.bookname = input_book_name;

            //Fetch data from Google API First
            adapter = new AdapterGoogleAPI();
            if (GetDataFromAPI(adapter,input_author_name, input_book_name, out json) ==0)
            {
                adapter = new AdapterDummyAPI();
                if (GetDataFromAPI(adapter, input_author_name, input_book_name, out json) == 0)
                {
                   //Across all available APIS, info not found
                }

            }
            response.jsonresponse = json;
            return response;
        }//end of GetData

        int GetDataFromAPI(IAdapter adapter,string input_author_name, string input_book_name, out string json)
        {   
            var parameters = new List<ParameterMap>();
            parameters.Add(new ParameterMap() { mappedTo = adapter._authorname, input = _autorname, value = input_author_name });
            parameters.Add(new ParameterMap() { mappedTo = adapter._bookname, input = _bookname, value = input_book_name });

            //Fetch data from API
            return adapter.GetData(parameters, out json);

        }//end of GetDataFromGoogleAPI

    }//end of class
}//end of namespace
