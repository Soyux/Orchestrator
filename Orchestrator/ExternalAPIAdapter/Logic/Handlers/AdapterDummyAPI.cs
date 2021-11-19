using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExternalAPIAdapter.Logic.Handlers
{
    public class AdapterDummyAPI : IAdapter
    {
        public string _authorname { get; set; }
        public string _bookname { get; set; }
        public List<ParameterMap> parammap { get; set; }
        public string serviceURL { get => "nowhere"; }
        public string ConvertParameterToHTTPParameter(List<ParameterMap> parameters)
        {
            return "";
        }

        public async Task<APIResult> GetData(List<ParameterMap> parameters )
        {
            return new APIResult();
        }
    }//end of class

}//end of namespace
