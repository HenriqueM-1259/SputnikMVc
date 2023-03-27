﻿using SputnikMVc.Models;
using SputnikMVc.Services;
using YoutubeExplode;
using YoutubeExplode.Common;
using YoutubeExplode.Videos.Streams;


namespace SputnikMVc.Helpers
{
    public class YoutubeMusicaHelper
    {
        private readonly ArtistaService _service;
        private readonly AlbumService _albumService;

        public YoutubeMusicaHelper(ArtistaService service, AlbumService albumService)
        {
            _service = service;
            _albumService = albumService;
        }

        public async Task<Artista> CriaArtista(YoutubeExplode.Videos.Video video)
        {
            try
            {              
                string Path = "./Artista/";
                Artista artista = new Artista();
                artista.Nome = video.Author.Title;
                //verifica se ha artista registrado no sql
                artista = await _service.GetByName(artista);
                if (artista == null)
                {
                    artista = new Artista();
                    artista.Nome = video.Author.Title;
                    artista.Path = $"/{video.Author.Title}/";
                    artista = await _service.Create(artista);
                }

                string resultPath = $"{Path}/{artista.Path}";
                // verifica se ha pasta do artista 
                if (!Directory.Exists(resultPath))
                {
                    var canalIcon = video.Thumbnails.FirstOrDefault();
                    var IconUrl = canalIcon.Url;

                    //caso nao exista ele vai registrar no sql e criar a pasta
                    Directory.CreateDirectory(resultPath);

                    if (!string.IsNullOrEmpty(IconUrl))
                    {
                        var client = new HttpClient();
                        var imageBytes = await client.GetByteArrayAsync(IconUrl);

                        // Use os bytes da imagem como desejar

                        // Salva a imagem na pasta "Artista/Froid"
                           
                        File.WriteAllBytes($"{resultPath}/{video.Title}.jpg", imageBytes);
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
                string resultPath = $"{Path}/{artista.Path}/${playlist.Title}";
                if (album == null)
                {
                    DateTime data = new DateTime();
                    album = new Album();
                    album.Title = playlist.Title;
                    album.ArtistaId = artista.Id;
                    album.Artista = artista;
                    album.DataCriacao = data;
                    album.Path = resultPath;
                    album = await _albumService.Create(album);
                }


                if (!Directory.Exists(resultPath))
                {
                    Directory.CreateDirectory(resultPath);
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
                var client = new YoutubeClient();
                var manifest = await client.Videos.Streams.GetManifestAsync(video.Id);
                var formato = manifest.GetAudioOnlyStreams().TryGetWithHighestBitrate();
                string path = $"{album.Path}/{video.Title}";
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
