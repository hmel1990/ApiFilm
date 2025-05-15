using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;

namespace ApiFilm
{
    public class MovieApi
    {
        private readonly RestClient client;
        private const string ApiKey = "8c7550ff";

        //Конструктор класса
        public MovieApi()
        {
            client = new RestClient("http://www.omdbapi.com/");
        }



        public async Task<Movie?> GetSearchedMovieAsync(string filmSearch)
        {
            var movie = new Movie();
            var request = new RestRequest("", Method.Get);
            request.AddParameter("apikey", ApiKey);
            //request.AddParameter("language", "ru-RU");
            request.AddParameter("t", filmSearch);



            var response = await client.ExecuteAsync(request);

            if (response.IsSuccessful)
            {
                try
                {
                    movie = JsonConvert.DeserializeObject<Movie>(response.Content ?? "");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка парсинга JSON: {ex.Message}", Color.Red);
                    Console.WriteLine("Ответ сервера:");
                    Console.WriteLine(response.Content);
                }
            }
            else
            {
                Console.WriteLine($"Ошибка запроса: {response.StatusCode} - {response.StatusDescription}", Color.Red);
                Console.WriteLine("Ответ сервера:");
                Console.WriteLine(response.Content);
            }

            return movie;
        }
    }
}
