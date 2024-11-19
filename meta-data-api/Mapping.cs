using AutoMapper;
using meta_data_api.Models;
using TNA.DataDefinitionObjects;

namespace meta_data_api;

public class Mapping : Profile
{
    public Mapping()
    {
        CreateMap<DigitalFileModel, DFile>()
             .ForMember(dest => dest.CSum, opt => opt.MapFrom(src => src.CheckSum))
             .ForMember(dest => dest.Frmt, opt => opt.MapFrom(src => src.Format))
             .ForMember(dest => dest.OrigName, opt => opt.MapFrom(src => src.OriginalName)).ReverseMap();
        CreateMap<ReplicaModel, Repl>()
             .ForMember(dest => dest.RID, opt => opt.MapFrom(src => src.ReplicaId))
             .ForMember(dest => dest.Orig, opt => opt.MapFrom(src => src.Origination))
             .ForMember(dest => dest.TSize, opt => opt.MapFrom(src => src.TotalSize)).ReverseMap();

        CreateMap<FileEditSetModel, FileEditSet>()
             .ForMember(dest => dest.Init, opt => opt.MapFrom(src => src.Initial))
             .ForMember(dest => dest.Curt, opt => opt.MapFrom(src => src.Current))
             .ForMember(dest => dest.Frmt, opt => opt.MapFrom(src => src.Format))
             .ForMember(dest => dest.OrigName, opt => opt.MapFrom(src => src.OriginalName)).ReverseMap();
        CreateMap<ReplicaEditSetModel, ReplEditSet>()
             .ForMember(dest => dest.Usr, opt => opt.MapFrom(src => src.User))
             .ForMember(dest => dest.Req, opt => opt.MapFrom(src => src.Requested))
             .ForMember(dest => dest.Sub, opt => opt.MapFrom(src => src.Submitted)).ReverseMap();

        CreateMap<PreparedFileItemModel, PreparedFileItem>().ReverseMap();
        CreateMap<PreparedFileModel, PrepFile>().ReverseMap();
    }
}