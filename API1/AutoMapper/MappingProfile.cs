using AutoMapper;
using API.core.DTO_s;
using API1;
using API.core.DbModels;
using API.core;
using Api.Services;


namespace API1.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<PurchaseRequest, PurchaseRequestsDTO>()
                .ForMember(dest => dest.PritemDetails, opt => opt.MapFrom(src => src.PritemDetails))
                //.ForMember(dest => dest.PrtypeNavigation, opt=> opt.MapFrom(src => src.PrtypeNavigation))
                .ReverseMap();
            CreateMap<PurchaseType, PurchaseTypeDTO>()
                .ReverseMap();
            CreateMap<PritemDetail, PritemDetailsDTO>()
                .ForMember(dest => dest.MaterialMaster, opt => opt.MapFrom(src => src.MatCodeNavigation));
                //.ReverseMap();
            CreateMap<PritemDetailsDTO, PritemDetail>();
            //    .ForMember(dest => dest.MatCodeNavigation, opt => opt.MapFrom(src => src.MaterialMaster))
            //    .ForMember(dest => dest.Id, opt => opt.Ignore())
            //    .ReverseMap();
            CreateMap<MaterialMaster, MaterialMasterDTO>()
                .ReverseMap();
            // Add more mappings as needed
        }
    }
    
}
