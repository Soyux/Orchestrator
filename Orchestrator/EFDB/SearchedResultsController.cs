using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EFDB.Data;
using EFDB.Model;

namespace EFDB
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchedResultsController : ControllerBase
    {
        private readonly EFDBContext _context;

        public SearchedResultsController(EFDBContext context)
        {
            _context = context;
        }

        // GET: api/SearchedResults
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SearchedResult>>> GetSearchedResult()
        {
            return await _context.SearchedResult.ToListAsync();
        }

        // GET: api/SearchedResults/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SearchedResult>> GetSearchedResult(int id)
        {
            var searchedResult = await _context.SearchedResult.FindAsync(id);

            if (searchedResult == null)
            {
                return NotFound();
            }

            return searchedResult;
        }

        // PUT: api/SearchedResults/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSearchedResult(int id, SearchedResult searchedResult)
        {
            if (id != searchedResult.Id)
            {
                return BadRequest();
            }

            _context.Entry(searchedResult).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SearchedResultExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/SearchedResults
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<SearchedResult>> PostSearchedResult(SearchedResult searchedResult)
        {
            _context.SearchedResult.Add(searchedResult);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSearchedResult", new { id = searchedResult.Id }, searchedResult);
        }

        // DELETE: api/SearchedResults/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SearchedResult>> DeleteSearchedResult(int id)
        {
            var searchedResult = await _context.SearchedResult.FindAsync(id);
            if (searchedResult == null)
            {
                return NotFound();
            }

            _context.SearchedResult.Remove(searchedResult);
            await _context.SaveChangesAsync();

            return searchedResult;
        }

        private bool SearchedResultExists(int id)
        {
            return _context.SearchedResult.Any(e => e.Id == id);
        }
    }
}
