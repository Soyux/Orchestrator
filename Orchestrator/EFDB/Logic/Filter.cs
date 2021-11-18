using EFDB.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SharedComms;

namespace EFDB.Logic
{
    public class Filter
    {
        public async Task<Response> Apply(Request request, DbSet<SearchedResult> context)
        {
            var response = new Response();
            var result = await FindWhereContains(request, context);
            response.autorname = result.Autorname;
            response.bookname = result.Bookname;
            response.jsonresponse = result.Jsonresponse;
            response.foundOn = result.FoundOn;
            return response;

        }//end ApplyFilter

        async Task<SearchedResult> FindWhereContains(Request request,DbSet<SearchedResult> context) {

            var data = context.First(
               P => P.Autorname.Contains(request.autorname) ||
               P.Bookname.Contains(request.bookname) ||
               P.Jsonresponse.Contains(request.autorname) ||
               P.Jsonresponse.Contains(request.bookname)
               );

            return data;

        }//FindWhereContains

    }//end of class

}//end of namespace
