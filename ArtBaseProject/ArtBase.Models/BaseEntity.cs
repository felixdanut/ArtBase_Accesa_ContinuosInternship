using ArtBase.Contracts.DTOs;

namespace ArtBase.Models
{
    public abstract class BaseEntity<T> where T : BaseEntityDTO
    {
        public BaseEntity(T dto) { }

        public BaseEntity() { }

        public virtual int Id { get; set; }

        public abstract void Update(T dto);
    }
}
