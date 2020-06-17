using TennisConnect.Data;
using TennisConnect.Web.Models;

namespace TennisConnect.Web
{
    public class AutoMapperProfile : AutoMapper.Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserModel>();
            CreateMap<RegisterModel, User>();
            CreateMap<UpdateModel, User>();
            CreateMap<AddressModel, Address>();
            CreateMap<Friend, FriendModel>();
            CreateMap<Profile, CompletedProfileModel>()
                .ForMember(dest => dest.UserModel, opt => opt.MapFrom(src => src.User));   
        }
    }
}
