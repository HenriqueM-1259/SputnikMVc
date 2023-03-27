using SputnikMVc.Context;
using SputnikMVc.Helpers;
using YoutubeExplode;
using System.IO;
using SputnikMVc.Models;

namespace SputnikMVc.Services
{
    public class YoutubeService
    {
        private readonly ArtistaService _artistaService;
        private readonly AlbumService _albumService;
        private readonly YoutubeMusicaHelper _helper;
        public YoutubeService(ArtistaService artistaService, AlbumService albumService, YoutubeMusicaHelper helper)
        {
            _artistaService = artistaService;
            _albumService = albumService;
            _helper = helper;
        }




        public async Task DownloadMusicaYoutube(string url)
        {
            try
            {
                var client = new YoutubeClient();
                var video = await client.Videos.GetAsync(url);
                //var Canal = await client.Channels.GetAsync(url);
                Artista artista = await _helper.CriaArtista(video);

                var playlist = await client.Playlists.GetAsync(url);

                Album album = await _helper.CriarAlbum(video,playlist);

                await _helper.FinazalizaDownload(video,album);


            }
            catch (Exception)
            {

                throw;
            }
                       
        }

    }
}
