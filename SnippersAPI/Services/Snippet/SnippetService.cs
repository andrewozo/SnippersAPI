using AutoMapper;
using SnippersAPI.Data;
using SnippersAPI.DTOS;
using SnippersAPI.Services;

namespace SnippersAPI.Services
{
    public class SnippetService : ISnippetService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public SnippetService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<ServiceResponse<List<GetSnippetDto>>> GetAllSnippets()
        {
            var serviceResponse = new ServiceResponse<List<GetSnippetDto>>();
            var dbSnippets = await _context.Snippets.ToListAsync();
           serviceResponse.Data = dbSnippets.Select(snip => _mapper.Map<GetSnippetDto>(snip)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetSnippetDto>> GetSnippetById(int id)
        {
            var serviceResponse = new ServiceResponse<GetSnippetDto>();

            var dbSnippet = await _context.Snippets.FirstOrDefaultAsync(snip => snip.Id == id);

            serviceResponse.Data = _mapper.Map<GetSnippetDto>(dbSnippet);

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetSnippetDto>>> AddSnippet(AddSnippetDto newSnippet)
        {
            var serviceResponse = new ServiceResponse<List<GetSnippetDto>>();
            var snippet = _mapper.Map<Snippet>(newSnippet);
            _context.Snippets.Add(snippet);
            await _context.SaveChangesAsync();
            serviceResponse.Data =
                await _context
                    .Snippets
                    .Select(snip => _mapper.Map<GetSnippetDto>(snip))
                    .ToListAsync();

            return serviceResponse;
        }
    }
}
