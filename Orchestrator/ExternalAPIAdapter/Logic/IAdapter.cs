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
        public int GetData(List<ParameterMap> parameters, out string json);

        public string ConvertParameterToHTTPParameter(List<ParameterMap> parameters);

    }//end of interface IAdapter

}//end of namespace
