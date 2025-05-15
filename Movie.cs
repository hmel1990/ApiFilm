using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ApiFilm
{
    public class Movie
    {      
            [JsonProperty("Title")]
            public string Title { get; set; }

            [JsonProperty("Year")]
            public int? Year { get; set; }

            [JsonProperty("Released")]
            public string? ReleaseDate { get; set; }

            [JsonProperty("Runtime")]
            public string? Runtime { get; set; }

            [JsonProperty("Metascore")]
            public string? Score { get; set; }

            [JsonProperty("Ratings")]
            public List<Rating> Ratings { get; set; }

            public override string ToString()
            {
                var ratingText = Score != null ? Score.ToString() : "Нет рейтингa";
                var ratings = Ratings != null ? string.Join("\n", Ratings.Select(r => $"{r.Source}: {r.Value}")) : "Нет рейтингов";

                return $"Название: {Title}\n" +
                       $"Год: {Year}\n" +
                       $"Дата выхода: {ReleaseDate}\n" +
                       $"Время: {Runtime}\n" +
                       $"Рейтинг общий: {ratingText}\n" +
                       $"Рейтинги: {ratings}\n";
            }

        public string MovieToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Название: {Title}");
            sb.AppendLine($"Год: {Year}");
            sb.AppendLine($"Дата выхода: {ReleaseDate}");
            sb.AppendLine($"Время: {Runtime}");
            sb.AppendLine($"Рейтинг общий: {Score}");

            if (Ratings != null)
            {
                sb.AppendLine("Рейтинги:");
                foreach (var rating in Ratings)
                {
                    sb.AppendLine($"{rating.Source}: {rating.Value}");
                }
            }

            return sb.ToString();
        }
    }
    }

