using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SharedComms;
using EFDB.Model;
namespace EFDB.Logic
{
    public class AdapterSearchResultResponse
    {
        public Response Apply(SearchedResult result)
        {

            var response = new Response()
            {
                autorname = result.Autorname,
                bookname=result.Bookname,
                foundOn=result.FoundOn,
                jsonresponse=result.Jsonresponse
            };

            return response;

        }//end of Apply

    }
}
