using ArtBase.Contracts.DTOs;
using ArtBase.Interfaces;
using ArtBase.Models;

namespace ArtBase.BusinessLogic
{
    public class CategoryManager : BaseEntityManager<Category, CategoryDTO>, ICategoryManager
    {
        public CategoryManager() : base() { }
    }
}