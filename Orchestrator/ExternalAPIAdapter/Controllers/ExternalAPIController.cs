using ExternalAPIAdapter.Logic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SharedComms;

namespace ExternalAPIAdapter.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExternalAPIController : ControllerBase
    {
        private readonly ILogger<ExternalAPIController> _logger;
        private AdapterHandler adapterhandler;
        public ExternalAPIController(ILogger<ExternalAPIController> logger)
        {
            _logger = logger;
            adapterhandler = new AdapterHandler();
        }
         
        [HttpPost]
        public async Task<Response> Post_SearchBooks(Request request)
        {
            Response response = adapterhandler.GetData(request);

            return response;

            //var manga = await _context.Manga.FindAsync(id);

            //if (manga == null)
            //{
            //    return NotFound();
            //}

            //return manga;
        }


    }
}
