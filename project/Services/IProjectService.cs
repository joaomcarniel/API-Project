using project.Models;

namespace project.Services
{
    public interface IProjectService
    {
        ContactDto CreateContact(ContactDto contact);
        ContactResponseDto UpdateContact(ContactDto contact, int id);
        ContactResponseDtoList GetAllContacts(int offset, int limit);
        ContactResponseDto GetContactById(int idContact);
        void DeleteContactById(int id);
    }
}
