using EFDB.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SharedComms;
using SharedComms.Model;
using Toolbox;
using System.Text.RegularExpressions;

namespace EFDB.Logic
{
    public class Filter
    {
        MasterJSON mjson;

        public Filter() {
            mjson = new MasterJSON();
        }

        public async Task<Response> Apply(Request request, DbSet<SearchedResult> context)
        {
            var response = new Response();
            var result = await FindWhereContains(request, context);
            response.searched_authorname = result.Searched_authorname;
            response.searched_bookname= result.Searched_bookname;
            response.Books = mjson.DeconvertJSONToListBook(Regex.Unescape( result.Bookobject))??new List<Book>(); 
            return response;
        }//end ApplyFilter

        async Task<SearchedResult> FindWhereContains(Request request,DbSet<SearchedResult> context) {

            var data = new SearchedResult();
            if (context.Count() > 0)
            {
                  data = await context.FirstOrDefaultAsync(
                   P => P.Searched_authorname.Contains(request.autorname) ||
                   P.Searched_bookname.Contains(request.bookname) ||
                   P.Bookobject.Contains(request.autorname) ||
                   P.Bookobject.Contains(request.bookname)
                   );
            }
            return data??new SearchedResult();

        }//FindWhereContains

    }//end of class

}//end of namespace
