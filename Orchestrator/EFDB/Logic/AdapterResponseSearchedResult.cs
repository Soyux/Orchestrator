using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using EFDB.Model;
using SharedComms;
using Toolbox;

namespace EFDB.Logic
{
    public class AdapterResponseSearchedResult
    {

        public SearchedResult Apply(Response response) {
            var mjson = new MasterJSON();

            var searchedresult = new SearchedResult()
            {
                Searched_authorname = response.searched_authorname,
                Searched_bookname = response.searched_bookname,
                Bookobject =  Regex.Unescape(mjson.ConvertListBookToJSON(response.Books))
            };

            return searchedresult;

        }

    }//end of class

}//end of namespace
