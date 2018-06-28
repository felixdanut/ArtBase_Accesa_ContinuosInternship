using ArtBase.Contracts.Managers;
using ArtBase.Contracts.DTOs;
using System.Collections.Generic;

namespace ArtBase.Interfaces
{
    public interface IBookmarkManager : IEntityManager<BookmarkDTO>
    {
        IEnumerable<BookmarkDTO> GetLastBookmarks(int numberOfBookmarks);
        IEnumerable<BookmarkDTO> GetBookmarksBySearchQuery(string searchQuery);
        IEnumerable<BookmarkDTO> GetBookmarksByUser(string userId);
        BookmarkDTO CheckBookmarkExists(string URL, string userId);
    }
}
