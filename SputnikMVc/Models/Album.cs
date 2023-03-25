namespace SputnikMVc.Models
{
    public class Album
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime DataCriacao { get; set; }
        public int ArtistaId { get; set; }
        public Artista Artista { get; set; }
        public List<Musica> Musicas { get; set; }
    }
}
