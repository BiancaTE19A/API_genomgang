using System;
using System.Text.Json;
using RestSharp;


namespace API_genomgang
{
    class Program
    {
        static void Main(string[] args)
        {
            Boolean good = true;
            RestClient pokeClient = new RestClient("https://pokeapi.co/api/v2/");//klient. via klient objektet kan vi skicka requests till den här databasen

            // RestRequest pokeRequest = new RestRequest("pokemon/turtwig");//requst. vad exakt i databasen är det jag vill hämta. man kan också låta användaren ange vilken pokemon den vill hämta
            // IRestResponse response = pokeClient.Get(pokeRequest);//request. variable för svaret
            while (good)
            {
                Console.WriteLine("What pokemon?");
                RestRequest request;
                request = GetUserInput();
                IRestResponse response = pokeClient.Get(request);

                // Console.WriteLine(response.StatusCode);//status kod visar hur det gick att hitta grejen. 200 = OK. 404 = NotFound.
                // Console.WriteLine(response.Content);//Json kod

                if (IsValid(response))
                {
                    Pokemon poke = JsonSerializer.Deserialize<Pokemon>(response.Content);//gör om koden till ett objekt. ta den response vi fick och deserializera det som en pokemon och lagrar resultatet i instansen av Pokemon
                    Console.WriteLine($"Name: {poke.name}   id: {poke.id}");//pekar mot en instans av Pokemon och visar informationen lagrad
                }
                else
                {
                    Console.WriteLine("Not Found! Please enter a valid input...");
                }
            }
        }
        static RestRequest GetUserInput()
        {
            string userInput = Console.ReadLine();

            RestRequest request = new RestRequest($"pokemon/{userInput}");

            return request;
        }

        static bool IsValid(IRestResponse resp)
        {
            if (resp.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
