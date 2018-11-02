using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.OnlineRadioDatabase
{
    public class StartUp
    {
        static void Main()
        {
            int linesCnt = int.Parse(Console.ReadLine());
            var songs = new List<Song>();

            for(int cnt = 1; cnt <= linesCnt; cnt++)
            {
                string input = Console.ReadLine();
                
                try
                {
                    var tokens = input.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

                    if (tokens.Length < 3)
                    {
                        throw new InvalidSongException();
                    }

                    string artist = tokens[0];
                    string title = tokens[1];
                    string length = tokens[2];

                    Song song = new Song(artist, title, length);
                    songs.Add(song);
                    Console.WriteLine("Song added.");
                }
                catch(InvalidSongException ex)
                {
                    Console.WriteLine(ex.CustomMessage);
                }
            }
            
            double totalSeconds = songs.Sum(x =>
            {
                var time = x.Length.Split(':');
                int minutes = int.Parse(time[0]);
                int seconds = int.Parse(time[1]);
                return minutes * 60.0 + seconds;
            });

            var total = TimeSpan.FromSeconds(totalSeconds);
            
            Console.WriteLine($"Songs added: {songs.Count}");
            Console.WriteLine($"Playlist length: {total.Hours}h {total.Minutes}m {total.Seconds}s");
        }
    }
}