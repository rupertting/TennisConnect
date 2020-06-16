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
            CreateMap<ClubModel, Club>();
            CreateMap<AddressModel, Address>();
        }
    }
}
