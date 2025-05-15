using Newtonsoft.Json; // dotnet add package Newtonsoft.Json
using RestSharp; // dotnet add package RestSharp
using System.Drawing;
using Console = Colorful.Console; // dotnet add package Colorful.Console

namespace ApiFilm
{
    internal class Program
    {

        static async Task Main(string[] args)
        {
            var api = new MovieApi();
            Console.WriteLine("Введите название фильма: ");
            string? filmSearch = Console.ReadLine();
            var movie = await api.GetSearchedMovieAsync(filmSearch);
            string textMovie = movie.ToString();
            Console.WriteLine(movie);
            var emailSender = new SendEmailByGmail();
            emailSender.SendEmail("hmel408757595@gmail.com", textMovie);
        }
    }
}
