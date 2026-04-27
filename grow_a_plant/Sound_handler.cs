using System;
using System.IO;
using System.Reflection.Metadata;
using System.Threading;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;
using SharpDX.Direct3D11;

namespace grow_a_plant
{
    internal class Sound_handler
    {
        private Song _song;
        private ContentManager _content;
        SoundEffect _waterSound;

        public Sound_handler(ContentManager content)
        {
            _content = content;
            _waterSound = _content.Load<SoundEffect>("music/water");

            try
            {
                start_background_music(content);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Failed to load song: " + ex);
                // continue without crashing
            }
        }

        public void play_water_sound(ContentManager content)
        {
            _waterSound.Play(0.5f, 0, 0);
        }
        public void start_background_music(ContentManager content) {
            var audioPath = Path.Combine(content.RootDirectory, "music", "Musicforplant.mp3");
            var fullPath = Path.GetFullPath(audioPath);
            _song = Song.FromUri("main_menu", new Uri(fullPath));
            MediaPlayer.Play(_song);
            MediaPlayer.IsRepeating = true;
            MediaPlayer.Volume = 0.5f;
        }
    }
}
