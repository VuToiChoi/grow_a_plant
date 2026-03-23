
    using System;
    using System.IO;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Media;

namespace grow_a_plant
{
    internal class Sound_handler
    {
        private Song _song;

        public Sound_handler(Song song)
        {
            _song = song;
        }
        public void search_for_music(ContentManager content)
        {
            try
            {
                var audioPath = Path.Combine(content.RootDirectory, "music", "Musicforplant.mp3");
                var fullPath = Path.GetFullPath(audioPath);

                _song = Song.FromUri("Musicforplant", new Uri(fullPath, UriKind.Absolute));

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Failed to load song: " + ex);
            }
        }

        public void start_music()
        {
            if (_song != null)
            {
                MediaPlayer.IsRepeating = true;
                MediaPlayer.Play(_song);
            }
        }
        public void StopMusic()
        {
            MediaPlayer.Stop();
        }
    }
}
