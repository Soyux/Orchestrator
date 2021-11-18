using ExternalAPIAdapter.Logic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        [HttpGet]
      
        public async Task<Response> GetBooks(Request request)
        {
            Response response = adapterhandler.GetData(request.autorname, request.bookname);

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
