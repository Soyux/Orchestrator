using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SharedComms;
using SharedComms.Model;

namespace ExternalAPIAdapter.Logic
{
    public interface IAdapter
    {
        public string _authorname { get; set; }
        public string _bookname { get; set; }
        public string serviceURL { get; }
        public  Task<APIResult> GetData(List<ParameterMap> parameters);

        public string ConvertParameterToHTTPParameter(List<ParameterMap> parameters);

    }//end of interface IAdapter

    public class APIResult
    {
        public List<Book> books { get; set; }
        public int count { get; set; }
        public APIResult() {
            books = new List<Book>();
            count = 0;
        }

    }

}//end of namespace
