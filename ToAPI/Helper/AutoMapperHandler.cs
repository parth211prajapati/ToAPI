using AutoMapper;
using ToAPI.Modal;
using ToAPI.Repos.Models;

namespace ToAPI.Helper
{
    public class AutoMapperHandler : Profile
    {
        public AutoMapperHandler()
        {
            CreateMap<TblCustomer, CustomerModal>()
                .ForMember(dest => dest.Statusname, opt => opt.MapFrom(src => (src.IsActive.GetValueOrDefault() ? "Active" : "Inactive"))).ReverseMap();
        }
    }
}
