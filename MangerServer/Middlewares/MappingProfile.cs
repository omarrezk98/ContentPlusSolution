
using AutoMapper;
using Entity.MangerSection;
using MangerModel.MangerSection;

namespace MangerServer.Middlewares
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region MangerSection
            CreateMap<MangerRefreshToken, MangerRefreshTokenViewModel>().ReverseMap();
            #endregion
        }
    }
}
