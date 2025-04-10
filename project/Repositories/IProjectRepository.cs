using project.Models;

namespace project.Repositories
{
    public interface IProjectRepository
    {
        Contact Create(Contact contact);
        void UpdateEntity(Contact updatedEntity);
        List<Contact> GetEntitiesByOffset(int offset, int limit);
        Contact GetEntityById(int id);
        void DeleteEntity(int id);
    }
}
