using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExternalAPIAdapter.Logic
{
    public interface IAdapter
    {
        public string _authorname { get; set; }
        public string _bookname { get; set; }
        public string serviceURL { get; }
        public APIResult GetData(List<ParameterMap> parameters);

        public string ConvertParameterToHTTPParameter(List<ParameterMap> parameters);

    }//end of interface IAdapter

    public class APIResult
    {
        public string json { get; set; }
        public int count { get; set; }

    }

}//end of namespace
