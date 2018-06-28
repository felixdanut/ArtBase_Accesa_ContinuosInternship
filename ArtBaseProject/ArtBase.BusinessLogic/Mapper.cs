using ArtBase.Contracts.DTOs;
using ArtBase.Models;
using System.Linq;

namespace ArtBase.BusinessLogic
{
    public static class Mapper
    {
        public static BookmarkDTO GetBookmarkDTO(Bookmark bookmark)
        {
            return new BookmarkDTO
            {
                Id = bookmark.Id,
                Title = bookmark.Title,
                URL = bookmark.URL,
                DateSaved = bookmark.DateSaved,
                User = (bookmark.User != null) ? GetUserDTO(bookmark.User) : null,
                Category = (bookmark.Category != null) ? GetCategoryDTO(bookmark.Category) : null,
                Tags = (bookmark.Tags != null) ? bookmark.Tags.Select(t => GetTagDTO(t)) : null,
                Views = (bookmark.Views != null) ? bookmark.Views.Select(v => GetViewDTO(v)) : null,
                Claps = (bookmark.Claps != null) ? bookmark.Claps.Select(c => GetClapDTO(c)) : null
            };
        }

        public static CategoryDTO GetCategoryDTO(Category category)
        {
            return new CategoryDTO
            {
                Id = category.Id,
                Name = category.Name
            };
        }

        public static ClapsDTO GetClapDTO(Claps clap)
        {
            return new ClapsDTO
            {
                Id = clap.Id,
                Number = clap.ClapsNumber
            };
        }

        public static TagDTO GetTagDTO(Tag tag)
        {
            return new TagDTO
            {
                Id = tag.Id,
                Name = tag.Name
            };
        }

        public static UserDTO GetUserDTO(User user)
        {
            return new UserDTO
            {
                Id = user.Id,
                Name = user.UserName
            };
        }

        public static ViewsDTO GetViewDTO(Views view)
        {
            return new ViewsDTO
            {
                Id = view.Id
            };
        }

        public static BaseEntityDTO GetEntityDTO<TEntityDTO>(BaseEntity<TEntityDTO> entity) where TEntityDTO : BaseEntityDTO
        {
            switch (entity.GetType().Name)
            {
                case "Bookmark":
                    return GetBookmarkDTO(entity as Bookmark);
                case "Tag":
                    return GetTagDTO(entity as Tag);
                case "Views":
                    return GetViewDTO(entity as Views);
                case "Category":
                    return GetCategoryDTO(entity as Category);
                case "Claps":
                    return GetClapDTO(entity as Claps);
            }

            return null;
        }
    }
}
