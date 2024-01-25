using AutoMapper;
using SnippersAPI.DTOS;

namespace SnippersAPI
{
    public class AutoMapperProfile : Profile
    {

        public AutoMapperProfile()
        {
            CreateMap<Snippet, GetSnippetDto>();

            CreateMap<AddSnippetDto, Snippet>();
        }
        
    }
}
