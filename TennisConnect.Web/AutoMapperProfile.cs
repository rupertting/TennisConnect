using AutoMapper;
using TennisConnect.Data;
using TennisConnect.Web.Models;

namespace TennisConnect.Web
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserModel>();
            CreateMap<RegisterModel, User>();
            CreateMap<UpdateModel, User>();
        }
    }
}
