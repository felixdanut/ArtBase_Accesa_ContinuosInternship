using System;
using System.Collections.Generic;

namespace ArtBase.Contracts.DTOs
{
    public class BookmarkDTO : BaseEntityDTO
    {
        public string Title { get; set; }
        public string URL { get; set; }
        public UserDTO User { get; set; }
        public CategoryDTO Category { get; set; }
        public DateTime DateSaved { get; set; }
        public IEnumerable<TagDTO> Tags { get; set; }
        public IEnumerable<ClapsDTO> Claps { get; set; }
        public IEnumerable<ViewsDTO> Views { get; set; }
    }
}