using AdminModel.AdminSection;
using AutoMapper;
using Entity.AdminSection;

namespace AdminServer.Middlewares
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region AdminSection
            CreateMap<AdminRefreshToken, AdminRefreshTokenViewModel>().ReverseMap();
            CreateMap<Admin, AdminViewModel>().ReverseMap();
            #endregion
        }
    }
}
