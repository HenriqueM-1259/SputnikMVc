﻿using SputnikMVc.Models.ViewModel;

namespace SputnikMVc.Models
{
    public class Playlist
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<PlaylistMusica> PlaylistMusica { get; set; }
    }
}
