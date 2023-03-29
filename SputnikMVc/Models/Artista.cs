using SputnikMVc.Models.ViewModel;

namespace SputnikMVc.Models
{
    public class Artista
    {
        public Artista()
        {
            this.Path = $"/{Nome}";
            this.DataCriacao = DateTime.Now;
        }
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataCriacao { get; set; } = new DateTime();
        public string Path { get; set; }
        public string PathImg { get; set; }
        public List<Album> MusicaLista { get; set; }

    }
}
