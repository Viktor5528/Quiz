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

            CreateMap<User, ShortInfoUserResponse>()
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Login));
            CreateMap<UpdateUserRequestModel, User>()
                .ForMember(x => x.Login, opt => opt.MapFrom(x => x.Name));
        }


    }
}
