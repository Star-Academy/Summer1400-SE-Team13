using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Search.Interface;

namespace Search.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class SearchController : Controller
    {
        private readonly IFullTextSearch _fullTextSearch;

        public SearchController(IFullTextSearch fullTextSearch)
        {
            _fullTextSearch = fullTextSearch;
        }
        
        [HttpGet]
        public IActionResult SearchQuery([FromQuery] string query)
        {
            var result = _fullTextSearch.FindCommandResult(query);
            return !result.Any() ? Ok("No doc found!") : Ok(result);
        }
    }
}