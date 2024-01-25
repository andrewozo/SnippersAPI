using AutoMapper;
using SnippersAPI.DTOS.User;



namespace SnippersAPI.Data
{
    public interface IAuthRepository
    {

        Task<ServiceResponse<int>> Register(User user, string password);

        Task<ServiceResponse<string>> Login(string email,string password);

        Task<bool> UserExists(string email);



    }
}
