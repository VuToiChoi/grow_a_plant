
    using System;
    using System.IO;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Media;

    namespace grow_a_plant
    {
        internal class Sound_handler
        {
            private Song song;

            public void PlayMusic(ContentManager content)
            {
                try
                {
                    var audioPath = Path.Combine(content.RootDirectory, "music", "Musicforplant.mp3");
                    var fullPath = Path.GetFullPath(audioPath);

                    song = Song.FromUri("Musicforplant", new Uri(fullPath, UriKind.Absolute));

                    MediaPlayer.Play(song);
                    MediaPlayer.IsRepeating = true;
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Failed to load song: " + ex);
                }
            }
        }
    }
