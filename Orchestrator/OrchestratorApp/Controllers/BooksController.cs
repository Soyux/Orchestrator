using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrchestratorApp.Logic;
using SharedComms;
using Toolbox;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OrchestratorApp
{
    [Route("[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private MasterJSON mjson = new MasterJSON();
        //// POST api/<BooksController>
        //[Route("api/SearchCloud")]
        //[HttpPost]
        //public void Post([FromBody] )
        //{
        //}
        [Route("SearchCloud")]
        [HttpPost]
        public async Task<IActionResult> SearchCloud([FromBody]Request request )
        {
            var response = await new QueryEngine().SearchCloudFirst(request);
            return Ok(mjson.ConvertResponseToJson(response));
        }

        //POST localhost/Books/
        [Route("SearchDB")]
        [HttpPost]
        public async Task<IActionResult> SearchDB([FromBody] Request request)
        {
            var response = await new QueryEngine().SearchDBFirst(request);

            return Ok(mjson.ConvertResponseToJson(response));
        }
    }
}
