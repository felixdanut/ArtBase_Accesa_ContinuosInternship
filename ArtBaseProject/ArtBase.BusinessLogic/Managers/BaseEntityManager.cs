using ArtBase.Contracts.DTOs;
using ArtBase.Contracts.Managers;
using ArtBase.DataAccess;
using ArtBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ArtBase.BusinessLogic
{
    public abstract class BaseEntityManager<TEntity, TEntityDTO> : IEntityManager<TEntityDTO> where TEntity : BaseEntity<TEntityDTO> where TEntityDTO : BaseEntityDTO
    {

        internal ArtBaseDbContext dbContext = new ArtBaseDbContext();

        public virtual TEntityDTO Add(TEntityDTO entityDTO)
        {
            if (entityDTO != null)
            {
                TEntity entity = (TEntity)Activator.CreateInstance(typeof(TEntity), new { entityDTO });
                dbContext.Set<TEntity>().Add(entity);
                int result = dbContext.SaveChanges();

                return result >= 1 ? Mapper.GetEntityDTO(entity) as TEntityDTO : null;
            }

            return null;
        }

        public virtual TEntityDTO Update(TEntityDTO entityDTO)
        {
            TEntity entity = dbContext.Set<TEntity>().FirstOrDefault(x => x.Id == entityDTO.Id);

            if (entity != null)
            {
                entity.Update(entityDTO);
                int result = dbContext.SaveChanges();

                return result >= 1 ? Mapper.GetCategoryDTO(dbContext.Category.FirstOrDefault(x => x.Id == entity.Id)) as TEntityDTO : null;
            }

            return null;
        }

        public virtual bool Delete(int Id)
        {
            TEntity entity = dbContext.Set<TEntity>().FirstOrDefault(x => x.Id == Id);

            if (entity != null)
            {
                dbContext.Set<TEntity>().Remove(entity);
                int result = dbContext.SaveChanges();

                return result >= 1 ? true : false;
            }

            return false;
        }

        public virtual IEnumerable<TEntityDTO> GetAll()
        {
            return dbContext.Set<TEntity>().ToList().Select(c => Mapper.GetEntityDTO(c) as TEntityDTO);
        }

        public virtual TEntityDTO GetById(int Id)
        {
            TEntity entity = dbContext.Set<TEntity>().FirstOrDefault(x => x.Id == Id);

            if (entity != null)
                return Mapper.GetEntityDTO(entity) as TEntityDTO;

            return null;
        }
    }
}

