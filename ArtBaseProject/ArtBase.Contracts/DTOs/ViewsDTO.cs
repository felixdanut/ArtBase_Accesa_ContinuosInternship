namespace ArtBase.Contracts.DTOs
{
    public class ViewsDTO : BaseEntityDTO
    {
        public UserDTO User { get; set; }
        public BookmarkDTO Bookmark { get; set; }
    }
}
