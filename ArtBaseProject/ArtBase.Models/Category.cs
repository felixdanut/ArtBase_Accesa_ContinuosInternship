using ArtBase.Contracts.DTOs;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ArtBase.Models
{
    [DataContract(IsReference = true)]
    public class Category : BaseEntity<CategoryDTO>
    {
        public Category(CategoryDTO categoryDTO) : base(categoryDTO)
        {
            Id = categoryDTO.Id;
            Name = categoryDTO.Name;
        }

        public Category() { }

        [Key]
        [DataMember]
        public override int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        public virtual List<Bookmark> Bookmark { get; set; }

        public override void Update(CategoryDTO categoryDTO)
        {
            Name = categoryDTO.Name;
        }
    }
}