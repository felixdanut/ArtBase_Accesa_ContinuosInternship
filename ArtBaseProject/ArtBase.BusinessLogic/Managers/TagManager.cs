using ArtBase.Contracts.DTOs;
using ArtBase.Interfaces;
using ArtBase.Models;

namespace ArtBase.BusinessLogic
{
    public class TagManager : BaseEntityManager<Tag, TagDTO>, ITagManager
    {
        public TagManager() : base() { }
    }
}