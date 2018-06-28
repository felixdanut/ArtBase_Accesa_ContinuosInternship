using ArtBase.Contracts.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace ArtBase.Models
{
    [DataContract(IsReference = true)]
    public class Bookmark : BaseEntity<BookmarkDTO>
    {
        public Bookmark(BookmarkDTO bookmarkDTO) : base(bookmarkDTO)
        {
            base.Id = bookmarkDTO.Id;
            Title = bookmarkDTO.Title;
            URL = bookmarkDTO.URL;
            DateSaved = bookmarkDTO.DateSaved;
            Category_Id = bookmarkDTO.Category.Id;
            User_Id = bookmarkDTO.User.Id;
        }

        public Bookmark() { }

        [Key, Column(Order = 0)]
        [DataMember]
        public override int Id { get; set; }

        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public string URL { get; set; }
        [DataMember]
        public DateTime DateSaved { get; set; }

        [DataMember]
        public int Category_Id { get; set; }

        [DataMember]
        public string User_Id { get; set; }

        public virtual User User { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<Claps> Claps { get; set; }
        public virtual ICollection<Views> Views { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }

        public override void Update(BookmarkDTO bookmarkDTO)
        {
            Title = bookmarkDTO.Title;
            URL = bookmarkDTO.URL;
            DateSaved = bookmarkDTO.DateSaved;
            Category_Id = bookmarkDTO.Category.Id;
        }
    }
}
