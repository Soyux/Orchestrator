using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFDB.Model;
using SharedComms;

namespace EFDB.Logic
{
    public class AdapterResponseSearchedResult
    {

        public SearchedResult Apply(Response response) {

            var searchedresult = new SearchedResult()
            {
                Autorname = response.autorname,
                Bookname = response.bookname,
                FoundOn = response.foundOn,
                Jsonresponse = response.jsonresponse

            };

            return searchedresult;

        }

    }//end of class

}//end of namespace
