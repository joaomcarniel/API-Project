using AutoMapper;
using project.Models;

namespace project.Mappers
{
    public class ContactProfile : Profile
    {
        public ContactProfile()
        {
            CreateMap<Contact, ContactDto>();
            CreateMap<ContactDto, Contact>()
                .ForMember(dest => dest.ContactId, opt => opt.Ignore())  
                .ForMember(dest => dest.CreationDate, opt => opt.Ignore());

            CreateMap<Contact, ContactResponseDto>();
            CreateMap<ContactResponseDto, Contact>()
                .ForMember(dest => dest.CreationDate, opt => opt.Ignore());
        }
    }
}
