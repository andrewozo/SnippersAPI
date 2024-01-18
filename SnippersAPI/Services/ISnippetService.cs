namespace SnippersAPI.Services
{
    public interface ISnippetService
    {
        Task<List<GetSnippetDto>> GetAllSnippets();

        Task<GetSnippetDto> GetSnippetById(int id);

        Task<AddSnippetDto> AddSnippet(AddSnippetDto newSnippet);
    }
}
