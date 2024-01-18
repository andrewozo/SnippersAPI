namespace SnippersAPI.Services
{
    public interface ISnippetService
    {
        Task<ServiceResponse<List<GetSnippetDto>>> GetAllSnippets();

        Task<ServiceResponse<GetSnippetDto>> GetSnippetById(int id);

        Task<ServiceResponse<List<GetSnippetDto>>> AddSnippet(AddSnippetDto newSnippet);
    }
}
