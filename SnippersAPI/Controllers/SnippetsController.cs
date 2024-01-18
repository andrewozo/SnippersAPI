using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SnippersAPI.Services;

namespace SnippersAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SnippetsController : ControllerBase
    {
        private readonly ISnippetService _snippetService;
        public SnippetsController(ISnippetService snippetService)
        {
            _snippetService = snippetService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<GetSnippetDto>>> GetAllSnippets()
        {
            return Ok(await _snippetService.GetAllSnippets());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetSnippetDto>>> GetSingleSnippet(int id)
        {
            return Ok(await _snippetService.GetSnippetById(id));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetSnippetDto>>>> AddSnippet(AddSnippetDto newSnippet)
        {
            return Ok(await _snippetService.AddSnippet(newSnippet));
        }
    }
}
