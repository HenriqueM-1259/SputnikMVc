using SputnikMVc.Models.ViewModel;

namespace SputnikMVc.Models
{
    public class Artista
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public List<Album> MusicaLista { get; set; }

    }
}
