using ExternalAPIAdapter.Logic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SharedComms;
using Toolbox;

namespace ExternalAPIAdapter.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExternalAPIController : ControllerBase
    {
        private readonly ILogger<ExternalAPIController> _logger;
        private AdapterHandler adapterhandler;
        private MasterJSON mjson;
        public ExternalAPIController(ILogger<ExternalAPIController> logger)
        {
            _logger = logger;
            adapterhandler = new AdapterHandler();
            mjson = new MasterJSON();
        }
        [Route("SearchBook")]
        [HttpPost]
        public async Task<IActionResult> Post_SearchBooks([FromBody] Request request)
        {

            Response response = await adapterhandler.GetData(request);

            return Ok(mjson.ConvertResponseToJson(response));

            //var manga = await _context.Manga.FindAsync(id);

            //if (manga == null)
            //{
            //    return NotFound();
            //}

            //return manga;
        }


    }
}
