using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _04.MovieTime
{
    class MovieTime
    {
        static void Main()
        {
            string favouriteGenre = Console.ReadLine();
            string duration = Console.ReadLine();
            var moviesData = new Dictionary<string, Dictionary<string, TimeSpan>>();

            string input = Console.ReadLine();
            double totalTime = 0;

            while (input != "POPCORN!")
            {
                var tokens = Regex.Split(input, @"\s*\|\s*");
                string title = tokens[0];
                string genre = tokens[1];

                var time = Regex.Split(tokens[2], @"\s*\:\s*")
                                .Select(int.Parse).ToArray();
                var timespan = new TimeSpan(time[0], time[1], time[2]);

                totalTime += timespan.TotalSeconds;

                if (moviesData.ContainsKey(genre) == false)
                {
                    moviesData.Add(genre, new Dictionary<string, TimeSpan>());
                }

                if (moviesData[genre].ContainsKey(title) == false)
                {
                    moviesData[genre].Add(title, new TimeSpan());
                }

                moviesData[genre][title] = timespan;

                input = Console.ReadLine();
            }

            var matchingGenre = moviesData[favouriteGenre];
            var sortedMovies = matchingGenre;

            if (duration == "Short")
            {
                sortedMovies = matchingGenre.OrderBy(x => x.Value.TotalSeconds)
                                            .ThenBy(x => x.Key)
                                            .ToDictionary(x => x.Key, x => x.Value);
            }
            else if (duration == "Long")
            {
                sortedMovies = matchingGenre.OrderByDescending(x => x.Value.TotalSeconds)
                                            .ThenBy(x => x.Key)
                                            .ToDictionary(x => x.Key, x => x.Value);
            }

            string chosenMovie = null;
            string answer;

            foreach (var movie in sortedMovies)
            {
                string title = movie.Key;
                Console.WriteLine(title);

                answer = Console.ReadLine();

                if (answer == "Yes")
                {
                    chosenMovie = title;
                    break;
                }
            }

            var totalTimeSpan = TimeSpan.FromSeconds(totalTime);
            Console.WriteLine($"We're watching {chosenMovie} - {sortedMovies[chosenMovie].ToString()}");
            Console.WriteLine($"Total Playlist Duration: {totalTimeSpan}");
        }
    }
}
