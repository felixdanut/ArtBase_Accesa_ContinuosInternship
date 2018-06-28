using ArtBase.Contracts.DTOs;
using ArtBase.Contracts.Managers;
using System.Collections.Generic;

namespace ArtBase.Interfaces
{
    public interface IViewsManager : IEntityManager<ViewsDTO>
    {
        IEnumerable<ViewsDTO> GetByUser(string userId);
        IEnumerable<ViewsDTO> GetByBookmark(int bookmarkId);
    }
}