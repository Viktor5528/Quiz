using AutoMapper;
using DataLayer.Entity;
using Services.Requests;
using Services.Responses;

namespace Services.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<CreateUserRequestModel, User>();

            CreateMap<User, ShortInfoUserResponse>().ForMember(x => x.Name, opt => opt.MapFrom(x => x.Login));
        }


    }
}
