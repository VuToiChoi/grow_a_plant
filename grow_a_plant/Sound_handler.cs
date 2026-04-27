    using System;
    using System.IO;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;

namespace grow_a_plant
{
    internal class Sound_handler
    {
        private Song _song;
        private ContentManager _content;

        public Sound_handler(ContentManager content)
        {
            _content = content;
            try
            {
                var audioPath = Path.Combine(content.RootDirectory, "music", "Musicforplant.mp3");
                var fullPath = Path.GetFullPath(audioPath);
                _song = Song.FromUri("main_menu", new Uri(fullPath));
                MediaPlayer.Play(_song);
                MediaPlayer.IsRepeating = true;
                MediaPlayer.Volume = 0.5f;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Failed to load song: " + ex);
                // continue without crashing
            }
        }

        public void Water_Sound(ContentManager content) {

            try
            {
                var audioPath = Path.Combine(content.RootDirectory, "music", "water.mp3");
                var fullPath = Path.GetFullPath(audioPath);
                _song = Song.FromUri("water", new Uri(fullPath));
                MediaPlayer.Play(_song);
                MediaPlayer.IsRepeating = true;
                MediaPlayer.Volume = 1.0f;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Failed to load song: " + ex);
                // continue without crashing
        }
        }
    }
}
