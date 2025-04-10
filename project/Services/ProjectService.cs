using AutoMapper;
using project.Models;
using project.Repositories;

namespace project.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<ProjectService> _logger;

        public ProjectService(IProjectRepository projectRepository, IMapper mapper, ILogger<ProjectService> logger)
        {
            _projectRepository = projectRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public ContactDto CreateContact(ContactDto contact)
        {
            try
            {
                var contactModel = _mapper.Map<Contact>(contact);
                var createdContact = _projectRepository.Create(contactModel);
                return _mapper.Map<ContactDto>(createdContact);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw new Exception(e.Message);
            }
        }

        public ContactResponseDto UpdateContact(ContactDto contact, int id)
        {
            try
            {
                var contactEntity = _projectRepository.GetEntityById(id);
                if(contactEntity is null)
                {
                    throw new Exception("Contact not found");
                }
                var contactModel = _mapper.Map<Contact>(contact);
                contactModel.ContactId = id;
                _projectRepository.UpdateEntity(contactModel);
                return _mapper.Map<ContactResponseDto>(contactModel);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw new Exception(e.Message);
            }
        }

        public ContactResponseDtoList GetAllContacts(int offset, int limit)
        {
            try
            {
                var response = new ContactResponseDtoList();
                var contacts = _projectRepository.GetEntitiesByOffset(offset, limit);
                response.Contacts = _mapper.Map<List<ContactResponseDto>>(contacts);
                response.TotalCount = response.Contacts.Count;
                response.Offset = offset;
                return response;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw new Exception(e.Message);
            }
        }

        public ContactResponseDto GetContactById(int idContact)
        {
            try
            {
                var contact = _projectRepository.GetEntityById(idContact);
                return _mapper.Map<ContactResponseDto>(contact);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw new Exception(e.Message);
            }
        }

        public void DeleteContactById(int id)
        {
            try
            {
                _projectRepository.DeleteEntity(id);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw new Exception(e.Message);
            }
        }
    }
}
