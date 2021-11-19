using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SharedComms;
using EFDB.Model;
using Toolbox;
using System.Text.RegularExpressions;

namespace EFDB.Logic
{
    public class AdapterSearchResultResponse
    {
        public Response Apply(SearchedResult result)
        {
            var mjson = new MasterJSON();
            var response = new Response()
            {
                searched_authorname = result.Searched_authorname,
                searched_bookname = result.Searched_bookname,
                Books = mjson.DeconvertJSONToListBook(Regex.Unescape (result.Bookobject))
                
            };

            return response;

        }//end of Apply

    }
}
