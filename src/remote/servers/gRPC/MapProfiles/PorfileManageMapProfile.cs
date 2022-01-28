using AutoMapper;

namespace gRPC.MapProfiles
{
    public class ProfileManageMapProfile : AutoMapper.Profile
    {
        public ProfileManageMapProfile()
        {
            //null string --> ""
            CreateMap<string?, string>().ConvertUsing<NullStringConverter>();

            //DTOs -> gRPC
            CreateMap<Application.DTOs.Status, gRPC.Status>();
            CreateMap<Application.DTOs.Profile, gRPC.Profile>();
            CreateMap<Application.DTOs.Technology, gRPC.Technology>();
            CreateMap<Application.DTOs.Position, gRPC.JobPosition>();
            CreateMap<Application.DTOs.Level, gRPC.Level>();
        }
    }

    public class NullStringConverter : ITypeConverter<string?, string>
    {
        public string Convert(string? source, string destination, ResolutionContext context)
        {
            return source ?? string.Empty;
        }
    }
}