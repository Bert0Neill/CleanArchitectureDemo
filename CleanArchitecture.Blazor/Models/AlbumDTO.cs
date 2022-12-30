namespace CleanArchitecture.Blazor.Models
{
    public class AlbumDTO
    {
        public int AlbumId { get; set; }
        public string AlbumName { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int ArtistId { get; set; }
        public int GenreId { get; set; }
    }
}
