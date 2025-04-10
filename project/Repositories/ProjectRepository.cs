using project.Models;

namespace project.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly DbProjectContext _context;

        public ProjectRepository(DbProjectContext context)
        {
            _context = context;
        }

        public Contact Create(Contact contact)
        {
            contact.CreationDate = DateTime.Now;
            _context.Contacts.Add(contact);
            _context.SaveChanges();
            return contact;
        }

        public void DeleteEntity(int id)
        {
            var entity = _context.Contacts.FirstOrDefault(e => e.ContactId == id);
            if (entity != null)
            {
                _context.Contacts.Remove(entity);
                _context.SaveChanges();
            }
        }

        public void UpdateEntity(Contact updatedEntity)
        {
            var entity = _context.Contacts.FirstOrDefault(e => e.ContactId == updatedEntity.ContactId);
            if (entity != null)
            {
                entity.LastName = updatedEntity.LastName;
                entity.FirstName = updatedEntity.FirstName;
                entity.ContactStatus = updatedEntity.ContactStatus;
                entity.Telephone = updatedEntity.Telephone;
                entity.Email = updatedEntity.Email;
                entity.Email = updatedEntity.Email;
                _context.SaveChanges();
            }
        }

        public List<Contact> GetEntitiesByOffset(int offset, int limit)
        {
            return _context.Contacts.Skip(offset).Take(limit).ToList();
        }

        public Contact GetEntityById(int id)
        {
            try
            {
                return _context.Contacts.FirstOrDefault(e => e.ContactId == id);
            }
            catch (Exception)
            {
                throw new Exception("Contact not found");
            }
        }
    }
}
