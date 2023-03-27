using SputnikMVc.Context;
using System.Text.RegularExpressions;
using YoutubeExplode;

namespace SputnikMVc.Services
{
    public class YoutubeService
    {
        private readonly MySQLContext _context;

        public YoutubeService(MySQLContext context)
        {
            _context = context;
        }


        public async Task DownloadMusicaYoutube(string url)
        {
            //string diretorioUpload = "C:/Git/Project/StreamSpuNick/Artistas/";
            //string diretorioUpload = "./Upload/";
            var client = new YoutubeClient();

            // Obtém informações sobre o vídeo
            var video = await client.Videos.GetAsync(url);
            var playlist = await client.Playlists.GetAsync(url);
            if (playlist == null)
            {
              
            }
           
            
        }

    }
}
