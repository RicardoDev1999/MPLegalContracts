using AutoMapper;
using MPLegalContracts.Data;

namespace MPLegalContracts.Services.Mappers.Profiles
{
    public class DateProfile : Profile
    {
        public DateProfile()
        {
            CreateMap<DateEntity, DateDto>().ReverseMap();
        }
    }
}
