using ArtBase.Contracts.DTOs;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ArtBase.Models
{
    [DataContract(IsReference = true)]
    public class Tag : BaseEntity<TagDTO>
    {
        public Tag(TagDTO tagDTO) : base(tagDTO)
        {
            if (tagDTO.Id > 0)
            {
                Id = tagDTO.Id;
            }
            Name = tagDTO.Name;
        }

        public Tag() { }

        [Key]
        [DataMember]
        public override int Id { get; set; }
        [DataMember]
        public string Name { get; set; }

        public virtual ICollection<Bookmark> Bookmarks { get; set; }

        public override void Update(TagDTO tagDTO)
        {
            Name = tagDTO.Name;
        }
    }
}
