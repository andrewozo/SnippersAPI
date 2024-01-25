using AutoMapper;
using SnippersAPI.Data;
using SnippersAPI.DTOS.Snippet;

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

            serviceResponse.Data = dbSnippets.Select(snip =>
            {
                var getSnippet = _mapper.Map<GetSnippetDto>(snip);

                if (!string.IsNullOrEmpty(snip.Code))
                {
                    getSnippet.Code = EncryptionHelper.Decrypt(snip.Code);
                }

                if (!string.IsNullOrEmpty(snip.Language))
                {
                    getSnippet.Language = EncryptionHelper.Decrypt(snip.Language);
                }

                return getSnippet;
            }).ToList();

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

            string encryptedCode = EncryptionHelper.Encrypt(newSnippet.Code);
            string encryptedLanguage = EncryptionHelper.Encrypt(newSnippet.Language);
            var snippet = _mapper.Map<Snippet>(newSnippet);
            snippet.Code = encryptedCode;
            snippet.Language = encryptedLanguage;
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
