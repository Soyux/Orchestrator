using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrchestratorApp.Logic;
using SharedComms;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OrchestratorApp
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
         
         

        //// POST api/<BooksController>
        //[Route("api/SearchCloud")]
        //[HttpPost]
        //public void Post([FromBody] )
        //{
        //}
        [Route("api/SearchCloud")]
        [HttpPost]
        public async Task<Response> SearchCloud(Request request )
        {
            return await new QueryEngine().SearchCloudFirst(request);
        }

        // POST api/<BooksController>
        [Route("api/SearchDB")]
        [HttpPost]
        public async Task<Response> SearchDB(Request request)
        {
            return await new QueryEngine().SearchDBFirst(request);
        }
    }
}
