using ArtBase.Contracts.DTOs;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace ArtBase.Models
{
    [DataContract(IsReference = true)]
    public class Views : BaseEntity<ViewsDTO>
    {
        public Views(ViewsDTO viewDTO) : base(viewDTO)
        {
            Id = viewDTO.Id;
            User_Id = viewDTO.User.Id;
            Bookmark_Id = viewDTO.Bookmark.Id;
        }

        public Views() { }

        [Key, Column(Order = 0)]
        [DataMember]
        public override int Id { get; set; }

        [DataMember]
        public string User_Id { get; set; }

        [DataMember]
        public int Bookmark_Id { get; set; }

        public virtual User User { get; set; }

        public Bookmark Bookmark { get; set; }

        public override void Update(ViewsDTO viewsDTO)
        {
            throw new System.NotImplementedException();
        }
    }
}