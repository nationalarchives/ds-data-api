using AutoMapper;
using sar_data_api.Models;
using TNA.DataDefinitionObjects;

namespace sar_data_api;

public class Mapping : Profile
{
    public Mapping()
    {
        CreateMap<ClosureCriterionModel, ClosureCriterion>()
             .ForMember(dest => dest.ExemptionCodeId, opt => opt.MapFrom(src => src.ExemptionCodeId)).ReverseMap();

        CreateMap<SarInfoModel, Sar>()
             .ForMember(dest => dest.RelatedToIA, opt => opt.MapFrom(src => src.Iaid))
             .ForMember(dest => dest.SignedDate, opt => opt.MapFrom(src => src.SignedDate))
             .ForMember(dest => dest.ReviewDate, opt => opt.MapFrom(src => src.ReviewDate))
             .ForMember(dest => dest.ReconsiderDueInDate, opt => opt.MapFrom(src => src.ReconsiderDueInDate))
             .ForMember(dest => dest.Explanation, opt => opt.MapFrom(src => src.Explanation))
             .ForMember(dest => dest.ProcatTitle, opt => opt.MapFrom(src => src.ProcatTitle)).ReverseMap();

        CreateMap<ClosureCriterionDisplayModel, ClosureCriterion>()
             .ForMember(dest => dest.ExemptionCodeId, opt => opt.MapFrom(src => src.ExemptionCodeId)).ReverseMap();

        CreateMap<SarInfoDisplayModel, Sar>()
             .ForMember(dest => dest.RelatedToIA, opt => opt.MapFrom(src => src.Iaid))
             .ForMember(dest => dest.SignedDate, opt => opt.MapFrom(src => src.SignedDate))
             .ForMember(dest => dest.ReviewDate, opt => opt.MapFrom(src => src.ReviewDate))
             .ForMember(dest => dest.ReconsiderDueInDate, opt => opt.MapFrom(src => src.ReconsiderDueInDate))
             .ForMember(dest => dest.Explanation, opt => opt.MapFrom(src => src.Explanation))
             .ForMember(dest => dest.ProcatTitle, opt => opt.MapFrom(src => src.ProcatTitle)).ReverseMap();

        CreateMap<ClosureCriterionDisplayModel, ClosureCriterions>()
             .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.ExemptionCodeId))
             .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.ExemptionCodeDescription)).ReverseMap();
    }
}