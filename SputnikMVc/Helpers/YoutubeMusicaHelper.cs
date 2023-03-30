using SputnikMVc.Models;
using SputnikMVc.Models.ViewModel;
using SputnikMVc.Services;
using System.Text.RegularExpressions;
using YoutubeExplode;
using YoutubeExplode.Common;
using YoutubeExplode.Videos.Streams;


namespace SputnikMVc.Helpers
{
    public class YoutubeMusicaHelper
    {
        private readonly ArtistaService _service;
        private readonly AlbumService _albumService;
        private readonly MusicaService _musicaService;
        public YoutubeMusicaHelper(ArtistaService service, AlbumService albumService, MusicaService musica)
        {
            _service = service;
            _albumService = albumService;
            _musicaService = musica;
        }

        public async Task<Artista> CriaArtista(YoutubeExplode.Videos.Video video)
        {
            try
            {
                var client = new YoutubeClient();
                var Canal = await client.Channels.GetAsync(video.Author.ChannelId);
                string Path = "./Artista/";
                Artista artista = new Artista();
                artista.Nome = video.Author.Title;
                var pathArtistaImg = $"~/ArtistaImg/{Canal.Title}.jpg";
                //verifica se ha artista registrado no sql
                artista = await _service.GetByName(artista);
                if (artista == null)
                {
                    artista = new Artista();
                    artista.Nome = video.Author.Title;
                    artista.Path = $"/{Regex.Replace(video.Author.Title, @"[^a-zA-Z0-9]+", "")}/";
                    artista.PathImg = pathArtistaImg;
                    artista = await _service.Create(artista);
                }

                string resultPath = $"{Path}/{artista.Path}";
                // verifica se ha pasta do artista 
                if (!Directory.Exists(resultPath))
                {
                    var canalIcon = Canal.Thumbnails.FirstOrDefault();
                    var IconUrl = canalIcon.Url;

                    //caso nao exista ele vai registrar no sql e criar a pasta
                    Directory.CreateDirectory(resultPath);

                    if (!string.IsNullOrEmpty(IconUrl))
                    {
                        var clientHttp = new HttpClient();
                        var imageBytes = await clientHttp.GetByteArrayAsync(IconUrl);

                        // Use os bytes da imagem como desejar

                        // Salva a imagem na pasta "Artista/Froid"
                           
                        File.WriteAllBytes($"./wwwroot/ArtistaImg/{Canal.Title}.jpg", imageBytes);
                    }
                    else
                    {
                        // O canal não tem um ícone definido
                    }

                    
                }

                // retornar o artista criado ou artista que ja existe
                return artista;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<Album> CriarAlbum(YoutubeExplode.Videos.Video video, YoutubeExplode.Playlists.Playlist playlist)
        {
            try
            {
                Album album = new Album();           
                string Path = "./Artista/";
                Artista artista = new Artista();
                artista.Nome = video.Author.Title;
                artista = await _service.GetByName(artista);
                album.Title = playlist.Title;
                album = await _albumService.GetByName(album);
                
                if (album == null)
                {
                    DateTime data = new DateTime();
                    album = new Album();
                    album.Title = playlist.Title;
                    album.ArtistaId = artista.Id;
                    album.Artista = artista;
                    album.DataCriacao = data;
                    album.Path = $"/Artista/{artista.Path}/{Regex.Replace(playlist.Title, @"[^a-zA-Z0-9]+", "")}";
                    album.PathUrlImg = $"~/ArtistaImg/{playlist.Title}.jpg";
                    album = await _albumService.Create(album);
                }

                
                if (!Directory.Exists($"./{album.Path}"))
                {              
                    var canalIcon = playlist.Thumbnails.FirstOrDefault();
                    var IconUrl = canalIcon.Url;

                    //caso nao exista ele vai registrar no sql e criar a pasta
                    Directory.CreateDirectory($"./{album.Path}");

                    if (!string.IsNullOrEmpty(IconUrl))
                    {
                        var clientHttp = new HttpClient();
                        var imageBytes = await clientHttp.GetByteArrayAsync(IconUrl);

                        // Use os bytes da imagem como desejar

                        // Salva a imagem na pasta "Artista/Froid"

                        File.WriteAllBytes($"./wwwroot/ArtistaImg/{playlist.Title}.jpg", imageBytes);
                    }
                    else
                    {
                        // O canal não tem um ícone definido
                    }


                }
                return album;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task FinazalizaDownload(YoutubeExplode.Videos.Video video, Album album)
        {
            try
            {
                string newTitle = Regex.Replace(video.Title, @"[^a-zA-Z0-9]+", "");
                Musica musica = new Musica
                {
                    Name = video.Title,
                    PathMusica = $"{album.Path}/{newTitle}",
                    Description = video.Description,
                    PathImage = ""

                };

               
                Musica musicaSQL = await _musicaService.Create(musica);
                AlbumMusica albumMusica = new AlbumMusica()
                {
                   
                    AlbumId = album.Id,
                    
                    MusicaId = musicaSQL.Id
                };
                albumMusica = await _musicaService.CreateAlbumAndMusica(albumMusica);
                var client = new YoutubeClient();
                var manifest = await client.Videos.Streams.GetManifestAsync(video.Id);
                var formato = manifest.GetAudioOnlyStreams().TryGetWithHighestBitrate();
                string path = $".{album.Path}/{newTitle}";
                if (formato != null)
                {
                    var outputFilePath = Path.ChangeExtension(path, "m4a");
                    await client.Videos.Streams.DownloadAsync(formato, outputFilePath);

                }
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
