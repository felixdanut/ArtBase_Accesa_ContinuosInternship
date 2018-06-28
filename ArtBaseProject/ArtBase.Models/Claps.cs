using ArtBase.Contracts.DTOs;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace ArtBase.Models
{
    [DataContract(IsReference = true)]
    public class Claps : BaseEntity<ClapsDTO>
    {
        public Claps(ClapsDTO clapsDTO) : base(clapsDTO)
        {
            Id = clapsDTO.Id;
            ClapsNumber = clapsDTO.Number;
            User_Id = clapsDTO.User.Id;
            Bookmark_Id = clapsDTO.Bookmark.Id;
        }

        public Claps() { }

        [Key, Column(Order = 0)]
        [DataMember]
        public override int Id { get; set; }
        [DataMember]
        public int ClapsNumber { get; set; }

        [DataMember]
        public string User_Id { get; set; }

        [DataMember]
        public int Bookmark_Id { get; set; }

        public virtual User User { get; set; }

        public Bookmark Bookmark { get; set; }

        public override void Update(ClapsDTO clapsDTO)
        {
            ClapsNumber = clapsDTO.Number;
        }
    }
}
