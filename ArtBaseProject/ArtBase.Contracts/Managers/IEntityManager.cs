using ArtBase.Contracts.DTOs;
using System.Collections.Generic;

namespace ArtBase.Contracts.Managers
{
    public interface IEntityManager<T> where T : BaseEntityDTO
    {
        IEnumerable<T> GetAll();
        T GetById(int Id);
        T Add(T entityDTO);
        T Update(T entityDTO);
        bool Delete(int Id);
    }
}
