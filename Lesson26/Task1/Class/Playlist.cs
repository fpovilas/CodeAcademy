namespace Task1.Class
{
    internal class Playlist
    {
        private List<Track> Tracks { get; set; } = new();

        public Playlist(List<Track> tracks) { Tracks = tracks; }

        public void AddTrack(Track track) { Tracks.Add(track); }

        public void RemoveTrack(Track track) { Tracks.Remove(track); }

        public void PrintTracks()
        {
            foreach (Track track in Tracks)
            {
                Console.WriteLine(track.GetTitle());
            }
        }
    }
}
