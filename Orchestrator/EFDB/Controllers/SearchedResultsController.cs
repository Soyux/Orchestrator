using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EFDB.Data;
using EFDB.Model;
using EFDB.Logic;
using SharedComms;
using System.Text.Json;
using Toolbox;
using System.Net.Http;

namespace EFDB.Controllers
{
    //[Route("api/[controller]")]
    [Route("[controller]")]
    [ApiController]
    public class SearchedResultsController : ControllerBase
    {
        private readonly EFDBContext _context;
        private MasterJSON mjson;
        public SearchedResultsController(EFDBContext context)
        {
            _context = context;
            mjson = new MasterJSON();
        }

        //// GET: api/SearchedResults
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<SearchedResult>>> GetSearchedResult()
        //{
        //    return await _context.SearchedResult.ToListAsync();
        //}

        //// GET: api/SearchedResults/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<SearchedResult>> GetSearchedResult(int id)
        //{
        //    var searchedResult = await _context.SearchedResult.FindAsync(id);

        //    if (searchedResult == null)
        //    {
        //        return NotFound();
        //    }

        //    return searchedResult;
        //}
        [Route("Find")]
        [HttpPost]
        public async Task<IActionResult> GetSearchedResult([FromBody] Request request)
        {   
            Response response = await new Filter().Apply(request, _context.SearchedResult);
            return Ok(mjson.ConvertResponseToJson(response));
        }

        [Route("Post")]
        [HttpPost]
        public async Task<IActionResult> PostSearchedResult([FromBody] Response response)
            //public async Task<IActionResult> PostSearchedResult([FromBody] Response response)
        {
            var searchedResult = new AdapterResponseSearchedResult().Apply(response);
            _context.SearchedResult.Add(searchedResult);
            await _context.SaveChangesAsync();

             CreatedAtAction("GetSearchedResult", new { id = searchedResult.Id }, searchedResult);

            return Ok();
        }

        //// DELETE: api/SearchedResults/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<SearchedResult>> DeleteSearchedResult(int id)
        //{
        //    var searchedResult = await _context.SearchedResult.FindAsync(id);
        //    if (searchedResult == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.SearchedResult.Remove(searchedResult);
        //    await _context.SaveChangesAsync();

        //    return searchedResult;
        //}

        //private bool SearchedResultExists(int id)
        //{
        //    return _context.SearchedResult.Any(e => e.Id == id);
        //}
    }
}
