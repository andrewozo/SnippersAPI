using AutoMapper;
using SnippersAPI.DTOS.Snippet;

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
