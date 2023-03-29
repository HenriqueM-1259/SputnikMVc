using SputnikMVc.Models.ViewModel;

namespace SputnikMVc.Models
{
    public class Musica
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public DateTime DataCriacao { get; set; }
        public string? PathImage { get; set; }
        public string? PathMusica { get; set; }
        public List<PlaylistMusica> PlaylistMusica { get; set; }
        public List<AlbumMusica> AlbumMusica { get; set; }
    }
}
