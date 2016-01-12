using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Storage;

namespace TestWebApiService
{
    class Program
    {
        static void Main(string[] args)
        {
            RunAsync().Wait();
        }

        static async Task RunAsync()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:49159/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // HTTP GET
                HttpResponseMessage response = await client.GetAsync("api/warehouse");
                if (response.IsSuccessStatusCode)
                {
                    string outputString = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(outputString);

                    Console.WriteLine();
                    Cage[] cages = await response.Content.ReadAsAsync<Storage.Cage[]>();
                    foreach (Cage cage in cages)
                    {
                        string output = cage.CageNumber + " - " + cage.Status.ToString() + " - " + cage.TypeOfAnimal.ToString() + " - P:" + cage.Predator.ToString() + " - N2P:" + cage.NextToPredator.ToString() + " - " + cage.AnimalCount;
                        Console.WriteLine(output);
                    }
                }
                Console.Read();
            }
        }
    
    }
}
