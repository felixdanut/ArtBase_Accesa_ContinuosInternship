using ArtBase.Contracts.DTOs;
using ArtBase.Interfaces;
using ArtBase.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ArtBase.BusinessLogic
{
    public class BookmarkManager : BaseEntityManager<Bookmark, BookmarkDTO>, IBookmarkManager
    {
        public BookmarkManager() : base() { }

        private IQueryable<Bookmark> GetQueryBookmarks()
        {
            return dbContext.Bookmark
                .Include(b => b.Tags)
                .Include(b => b.Category)
                .Include(b => b.Views)
                .Include(b => b.Claps)
                .Include(b => b.User);
        }

        public override BookmarkDTO Add(BookmarkDTO bookmarkDTO)
        {
            if (bookmarkDTO == null)
            {
                return null;
            }

            Bookmark bookmark = new Bookmark(bookmarkDTO);
            List<Tag> tagList = new List<Tag>();

            if (bookmarkDTO.Tags != null)
            {
                foreach (TagDTO tagDTO in bookmarkDTO.Tags)
                {
                    Tag tag = new Tag(tagDTO);
                    Tag tagByName = dbContext.Tag.FirstOrDefault(t => t.Name == tag.Name);
                    if (tagDTO.Id > 0)
                    {
                        tag = dbContext.Tag.FirstOrDefault(t => t.Id == tag.Id);
                    }
                    else if (tagByName != null)
                    {
                        tag = tagByName;
                    }

                    tagList.Add(tag);
                }
            }

            bookmark.Tags = tagList;
            bookmark.User_Id = bookmarkDTO.User.Id;
            dbContext.Bookmark.Add(bookmark);
            int result = dbContext.SaveChanges();

            return result >= 1 ? Mapper.GetBookmarkDTO(GetQueryBookmarks().FirstOrDefault(b => b.URL == bookmark.URL)) : null;
        }

        public override BookmarkDTO Update(BookmarkDTO bookmarkDTO)
        {
            Bookmark bookmark = GetQueryBookmarks().FirstOrDefault(b => b.Id == bookmarkDTO.Id);

            if (bookmark == null)
            {
                return null;
            }

            bookmark.Update(bookmarkDTO);

            List<Tag> newTagList = new List<Tag>();
            List<Tag> fullTagList = new List<Tag>();
            foreach (TagDTO tagDTO in bookmarkDTO.Tags)
            {
                Tag tag = new Tag(tagDTO);
                Tag tagByName = dbContext.Tag.FirstOrDefault(t => t.Name == tag.Name);
                if (tagDTO.Id > 0)
                {
                    tag = dbContext.Tag.FirstOrDefault(t => t.Id == tag.Id);

                }
                else if (tagByName != null)
                {
                    tag = tagByName;
                }

                if (!bookmark.Tags.Contains(tag))
                {
                    newTagList.Add(tag);
                }
                fullTagList.Add(tag);
            }

            List<Tag> removedTags = bookmark.Tags.Where(b => !fullTagList.Any(t => t.Id == b.Id)).ToList();
            foreach (Tag tag in removedTags)
            {
                bookmark.Tags.Remove(tag);
            }

            foreach (Tag tag in newTagList)
            {
                bookmark.Tags.Add(tag);
            }

            int result = dbContext.SaveChanges();

            return result >= 1 ? Mapper.GetBookmarkDTO(GetQueryBookmarks().FirstOrDefault(b => b.Id == bookmark.Id)) : null;
        }

        public override IEnumerable<BookmarkDTO> GetAll()
        {
            return GetQueryBookmarks().ToList().Select(b => Mapper.GetBookmarkDTO(b));
        }

        public override BookmarkDTO GetById(int Id)
        {
            Bookmark bookmark = GetQueryBookmarks().FirstOrDefault(x => x.Id == Id);

            if (bookmark != null)
            {
                return Mapper.GetBookmarkDTO(bookmark);
            }

            return null;
        }

        public IEnumerable<BookmarkDTO> GetLastBookmarks(int numberOfBookmarks)
        {
            return GetQueryBookmarks()
                .OrderByDescending(i => i.DateSaved)
                .Take(numberOfBookmarks)
                .ToList()
                .Select(b => Mapper.GetBookmarkDTO(b));
        }

        public IEnumerable<BookmarkDTO> GetBookmarksBySearchQuery(string searchQuery)
        {
            return GetQueryBookmarks()
                .Where(bk => bk.Title.Contains(searchQuery) || bk.Tags.Select(t => t.Name).Where(t => t.Contains(searchQuery)).Any())
                .OrderBy(i => i.Title)
                .ToList()
                .Select(b => Mapper.GetBookmarkDTO(b));
        }

        public IEnumerable<BookmarkDTO> GetBookmarksByUser(string userId)
        {
            return GetQueryBookmarks().Where(b => b.User_Id == userId).ToList().Select(b => Mapper.GetBookmarkDTO(b));
        }

        public BookmarkDTO CheckBookmarkExists(string URL, string userId)
        {
            Bookmark bookmark = GetQueryBookmarks().FirstOrDefault(b => b.URL == URL && b.User_Id == userId);

            if (bookmark != null)
            {
                return Mapper.GetBookmarkDTO(bookmark);
            }

            return null;
        }
    }
}