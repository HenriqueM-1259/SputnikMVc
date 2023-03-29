using SputnikMVc.Models.ViewModel;

namespace SputnikMVc.Models
{
    public class Album
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime DataCriacao { get; set; }
        public int ArtistaId { get; set; }
        public Artista Artista { get; set; }
        public string Path { get; set; }
        public List<AlbumMusica> AlbumMusica { get; set; }
    }
}
