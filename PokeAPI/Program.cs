using RestSharp;
using System.Text.Json;

namespace PokeAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            Mascote mascote = new Mascote();
            var client = new RestClient("https://pokeapi.co/api/v2/pokemon");
            RestRequest choose = new RestRequest("", Method.Get);
            var responseChoose = client.Execute(choose);

            if(responseChoose.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var i = 1;
                var poke = JsonSerializer.Deserialize<Mascote>(responseChoose.Content);
                foreach(var item in poke?.results)
                {
                    Console.Write("Pokemon: " + item.name + " ");
                    Console.WriteLine("---- Código: " + i++);

                }
            }
            Console.Write("Digite o código do Pokemon que deseja -> /Código : ");
            string code = Console.ReadLine();
            Console.WriteLine();


            RestRequest request = new RestRequest(code, Method.Get);
            var response = client.Execute(request);
            

            if(response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var poke = JsonSerializer.Deserialize<Mascote>(response.Content);
                Console.WriteLine("Nome do Pokemon: " + poke?.name);
                Console.WriteLine("Altura: " + poke?.height);
                Console.WriteLine("Peso: " + poke?.weight);
                Console.WriteLine("Habilidades: ");
                foreach (var item in poke?.abilities)
                {
                    Console.WriteLine(item?.ability?.name?.ToUpper());
                }
            }
            else
            { Console.WriteLine(response.ErrorMessage); }

            Console.ReadKey();
        }
    }
}