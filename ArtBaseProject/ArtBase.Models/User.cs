using ArtBase.Contracts.DTOs;
using System;
using System.Collections.Generic;

namespace ArtBase.Models
{
    public class User
    {
        public User(UserDTO userDTO)
        {
            Id = userDTO.Id;
            UserName = userDTO.Name;
        }
        public User() { }
        public string Id { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public DateTime? LockoutEndDateUtc { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        public string UserName { get; set; }

        public virtual List<Bookmark> Bookmark { get; set; }
        public virtual ICollection<Claps> Claps { get; set; }
        public virtual ICollection<Views> Views { get; set; }
    }
}
