using ArtBase.Contracts.DTOs;
using ArtBase.Contracts.Managers;
using System.Collections.Generic;

namespace ArtBase.Interfaces
{
    public interface IClapsManager : IEntityManager<ClapsDTO>
    {
        IEnumerable<ClapsDTO> GetByUser(string userId);
        IEnumerable<ClapsDTO> GetByBookmark(int bookmarkId);
    }
}