using AutoMapper;
using PTO.Entity;
using PTO.Web.Models;
using PTO.Web.Models.Users;

namespace PTO.Web
{
    public static class AutoMapperBootstrapper
    {
        public static void RegisterMappings() {
            //AutoMapperConfiguration.Configure();

            Mapper.CreateMap<UserAddress, AddressViewModel>()
                .ForMember(dest => dest.FamilyMembers, opt => opt.Ignore())
                .ForMember(dest => dest.Formatted, opt => opt.Ignore())
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.User != null ? src.User.Id : 0))
                .ForMember(dest => dest.Latitude, opt => opt.MapFrom(src => src.Location != null ? src.Location.Latitude : null))
                .ForMember(dest => dest.Longitude, opt => opt.MapFrom(src => src.Location != null ? src.Location.Longitude : null));

            Mapper.CreateMap<UserEmail, EmailViewModel>();

            Mapper.CreateMap<User, UserViewModel>();

            Mapper.AssertConfigurationIsValid();
        }
    }
}