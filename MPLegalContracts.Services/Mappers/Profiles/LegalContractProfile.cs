using AutoMapper;
using MPLegalContracts.Data.LegalContracts;
using MPLegalContracts.Services.LegalContracts;

namespace MPLegalContracts.Services.Mappers.Profiles
{
    public class LegalContractProfile : Profile
    {
        public LegalContractProfile()
        {
            CreateMap<CreateLegalContractDto, LegalContractEntity>();

            CreateMap<LegalContractEntity, LegalContractDto>()
                .ForMember(x => x.DatePart, opt => opt.MapFrom(src => new DateDto(src.CreatedAt, src.UpdatedAt)));
        }
    }
}
