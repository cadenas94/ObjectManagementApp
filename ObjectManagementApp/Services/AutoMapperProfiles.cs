using AutoMapper;
using ObjectManagementApp.DTO;
using ObjectManagementApp.Models;

namespace ObjectManagementApp.Services
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {

            //Definition of the mapping between the entitites and the DTOs
            CreateMap<ObjectM, ObjectMDTO>();
            CreateMap<List<ObjectM>, ObjectMListDTO>()
                .ForMember(dest => dest.ObjectList, opt => opt.MapFrom(src => src));

        }
    }
}
