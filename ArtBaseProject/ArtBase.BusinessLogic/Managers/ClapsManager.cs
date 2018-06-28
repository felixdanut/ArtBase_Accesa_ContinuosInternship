using ArtBase.Contracts.DTOs;
using ArtBase.Interfaces;
using ArtBase.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ArtBase.BusinessLogic
{
    public class ClapsManager : BaseEntityManager<Claps, ClapsDTO>, IClapsManager
    {
        public ClapsManager() : base() { }

        private IQueryable<Claps> GetQueryClaps()
        {
            return dbContext.Claps
                .Include(c => c.Bookmark)
                .Include(c => c.Bookmark.Category)
                .Include(c => c.Bookmark.Tags)
                .Include(c => c.Bookmark.Claps)
                .Include(c => c.Bookmark.Views)
                .Include(c => c.Bookmark.User)
                .Include(c => c.User);
        }

        public override IEnumerable<ClapsDTO> GetAll()
        {
            List<ClapsDTO> clapsDTO = new List<ClapsDTO>();

            GetQueryClaps().ToList().ForEach(c =>
            {
                ClapsDTO clapDTO = Mapper.GetClapDTO(c);
                clapDTO.Bookmark = Mapper.GetBookmarkDTO(c.Bookmark);
                clapDTO.User = Mapper.GetUserDTO(c.User);
                clapsDTO.Add(clapDTO);
            });

            return clapsDTO;
        }

        public override ClapsDTO GetById(int Id)
        {
            Claps clap = GetQueryClaps().FirstOrDefault(c => c.Id == Id);

            if (clap != null)
            {
                ClapsDTO clapDTO = Mapper.GetClapDTO(clap);
                clapDTO.Bookmark = Mapper.GetBookmarkDTO(clap.Bookmark);
                clapDTO.User = Mapper.GetUserDTO(clap.User);

                return clapDTO;
            }

            return new ClapsDTO();
        }
        public IEnumerable<ClapsDTO> GetByBookmark(int bookmarkId)
        {
            List<ClapsDTO> clapsDTO = new List<ClapsDTO>();

            GetQueryClaps().Where(c => c.Bookmark_Id == bookmarkId).ToList().ForEach(c =>
            {
                ClapsDTO clapDTO = Mapper.GetClapDTO(c);
                clapDTO.Bookmark = Mapper.GetBookmarkDTO(c.Bookmark);
                clapDTO.User = Mapper.GetUserDTO(c.User);
                clapsDTO.Add(clapDTO);
            });

            return clapsDTO;
        }

        public IEnumerable<ClapsDTO> GetByUser(string userId)
        {
            List<ClapsDTO> clapsDTO = new List<ClapsDTO>();

            GetQueryClaps().Where(c => c.User_Id == userId).ToList().ForEach(c =>
            {
                ClapsDTO clapDTO = Mapper.GetClapDTO(c);
                clapDTO.Bookmark = Mapper.GetBookmarkDTO(c.Bookmark);
                clapDTO.User = Mapper.GetUserDTO(c.User);
                clapsDTO.Add(clapDTO);
            });

            return clapsDTO;
        }
    }
}