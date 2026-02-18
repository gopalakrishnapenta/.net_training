using System;
using System.Collections.Generic;
using System.Linq;

namespace MusicStreamingService
{
    // Song class
    class Song
    {
        public string SongId { get; set; }
        public string Title { get; set; }
        public string Artist { get; set; }
        public string Genre { get; set; }
        public string Album { get; set; }
        public TimeSpan Duration { get; set; }
        public int PlayCount { get; set; }
    }

    // Playlist class
    class Playlist
    {
        public string PlaylistId { get; set; }
        public string Name { get; set; }
        public string CreatedBy { get; set; }
        public List<Song> Songs { get; set; }

        public Playlist()
        {
            Songs = new List<Song>();
        }
    }

    // User class
    class User
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public List<string> FavoriteGenres { get; set; }
        public List<Playlist> UserPlaylists { get; set; }

        public User()
        {
            FavoriteGenres = new List<string>();
            UserPlaylists = new List<Playlist>();
        }
    }

    // MusicManager class
    class MusicManager
    {
        private List<Song> songs = new List<Song>();
        private List<User> users = new List<User>();
        private int songCounter = 1;
        private int playlistCounter = 1;

        // Add song
        public void AddSong(string title, string artist, string genre,
                            string album, TimeSpan duration)
        {
            Song song = new Song
            {
                SongId = "S" + songCounter++,
                Title = title,
                Artist = artist,
                Genre = genre,
                Album = album,
                Duration = duration,
                PlayCount = 0
            };

            songs.Add(song);
            Console.WriteLine("Song added successfully");
        }

        // Create playlist
        public void CreatePlaylist(string userId, string playlistName)
        {
            User user = users.FirstOrDefault(u => u.UserId == userId);

            if (user == null)
            {
                user = new User
                {
                    UserId = userId,
                    UserName = userId
                };
                users.Add(user);
            }

            Playlist playlist = new Playlist
            {
                PlaylistId = "P" + playlistCounter++,
                Name = playlistName,
                CreatedBy = userId
            };

            user.UserPlaylists.Add(playlist);
            Console.WriteLine("Playlist created successfully");
        }

        // Add song to playlist
        public bool AddSongToPlaylist(string playlistId, string songId)
        {
            Song song = songs.FirstOrDefault(s => s.SongId == songId);
            if (song == null)
                return false;

            foreach (User user in users)
            {
                Playlist playlist =
                    user.UserPlaylists.FirstOrDefault(p => p.PlaylistId == playlistId);

                if (playlist != null)
                {
                    playlist.Songs.Add(song);
                    song.PlayCount++;
                    return true;
                }
            }
            return false;
        }

        // Group songs by genre
        public Dictionary<string, List<Song>> GroupSongsByGenre()
        {
            return songs
                .GroupBy(s => s.Genre)
                .ToDictionary(g => g.Key, g => g.ToList());
        }

        // Get top played songs
        public List<Song> GetTopPlayedSongs(int count)
        {
            return songs
                .OrderByDescending(s => s.PlayCount)
                .Take(count)
                .ToList();
        }
    }

    // Program class
    class Program
    {
        static void Main()
        {
            MusicManager manager = new MusicManager();

            // Add songs
            manager.AddSong("Believer", "Imagine Dragons", "Rock", "Evolve",
                            TimeSpan.FromMinutes(3.2));
            manager.AddSong("Shape of You", "Ed Sheeran", "Pop", "Divide",
                            TimeSpan.FromMinutes(4));
            manager.AddSong("Perfect", "Ed Sheeran", "Pop", "Divide",
                            TimeSpan.FromMinutes(4.5));

            // Create playlist
            manager.CreatePlaylist("U1", "My Favorites");

            // Add songs to playlist
            manager.AddSongToPlaylist("P1", "S1");
            manager.AddSongToPlaylist("P1", "S2");
            manager.AddSongToPlaylist("P1", "S2");

            // Group songs by genre
            Console.WriteLine("\nSongs Grouped By Genre:");
            var grouped = manager.GroupSongsByGenre();
            foreach (var group in grouped)
            {
                Console.WriteLine(group.Key);
                foreach (var song in group.Value)
                    Console.WriteLine(song.Title);
            }

            // Top played songs
            Console.WriteLine("\nTop Played Songs:");
            var topSongs = manager.GetTopPlayedSongs(2);
            foreach (var song in topSongs)
                Console.WriteLine(song.Title + " - Plays: " + song.PlayCount);
        }
    }
}
