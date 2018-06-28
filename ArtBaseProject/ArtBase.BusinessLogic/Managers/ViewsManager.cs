using ArtBase.Contracts.DTOs;
using ArtBase.Interfaces;
using ArtBase.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ArtBase.BusinessLogic
{
    public class ViewsManager : BaseEntityManager<Views, ViewsDTO>, IViewsManager
    {
        public ViewsManager() : base() { }

        private IQueryable<Views> GetQueryViews()
        {
            return dbContext.Views
                .Include(v => v.Bookmark)
                .Include(v => v.Bookmark.Category)
                .Include(v => v.Bookmark.Tags)
                .Include(v => v.Bookmark.Claps)
                .Include(v => v.Bookmark.Views)
                .Include(v => v.Bookmark.User)
                .Include(v => v.User);
        }

        public override IEnumerable<ViewsDTO> GetAll()
        {
            List<ViewsDTO> viewsDTO = new List<ViewsDTO>();

            GetQueryViews().ToList().ForEach(v =>
            {
                ViewsDTO viewDTO = Mapper.GetViewDTO(v);
                viewDTO.Bookmark = Mapper.GetBookmarkDTO(v.Bookmark);
                viewDTO.User = Mapper.GetUserDTO(v.User);
                viewsDTO.Add(viewDTO);
            });

            return viewsDTO;
        }

        public override ViewsDTO GetById(int Id)
        {
            Views view = GetQueryViews().FirstOrDefault(v => v.Id == Id);

            if (view != null)
            {
                ViewsDTO viewDTO = Mapper.GetViewDTO(view);
                viewDTO.Bookmark = Mapper.GetBookmarkDTO(view.Bookmark);
                viewDTO.User = Mapper.GetUserDTO(view.User);

                return viewDTO;
            }

            return new ViewsDTO();
        }

        public IEnumerable<ViewsDTO> GetByUser(string userId)
        {
            List<ViewsDTO> viewsDTO = new List<ViewsDTO>();

            GetQueryViews().Where(c => c.User_Id == userId).ToList().ForEach(v =>
            {
                ViewsDTO viewDTO = Mapper.GetViewDTO(v);
                viewDTO.Bookmark = Mapper.GetBookmarkDTO(v.Bookmark);
                viewDTO.User = Mapper.GetUserDTO(v.User);
                viewsDTO.Add(viewDTO);
            });

            return viewsDTO;
        }

        public IEnumerable<ViewsDTO> GetByBookmark(int bookmarkId)
        {
            List<ViewsDTO> viewsDTO = new List<ViewsDTO>();

            GetQueryViews().Where(c => c.Bookmark_Id == bookmarkId).ToList().ForEach(v =>
            {
                ViewsDTO viewDTO = Mapper.GetViewDTO(v);
                viewDTO.Bookmark = Mapper.GetBookmarkDTO(v.Bookmark);
                viewDTO.User = Mapper.GetUserDTO(v.User);
                viewsDTO.Add(viewDTO);
            });

            return viewsDTO;
        }
    }
}