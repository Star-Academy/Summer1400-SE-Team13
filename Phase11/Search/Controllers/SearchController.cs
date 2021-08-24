using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Search.Interface;

namespace Search.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class SearchController : Controller
    {
        private const string FolderPath = "SampleFiles";
        private readonly IFullTextSearch _fullTextSearch;
        
        public SearchController(IFullTextSearch fullTextSearch)
        {
            _fullTextSearch = fullTextSearch;
        }
        
        [HttpGet]
        public IActionResult SearchQuery([FromQuery] string query)
        {
            var result = _fullTextSearch.FindCommandResult(query, FolderPath);
            return !result.Any() ? Ok("No doc found!") : Ok(result);
        }
    }
}