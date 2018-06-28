namespace ArtBase.Contracts.DTOs
{
    public class ClapsDTO : BaseEntityDTO
    {
        public int Number { get; set; }
        public UserDTO User { get; set; }
        public BookmarkDTO Bookmark { get; set; }
    }
}
