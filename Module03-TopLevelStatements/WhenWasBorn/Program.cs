using System;
using System.Net.Http;
using System.Net.Http.Json;

if (args.Length != 1)
{
    return PrintHelp();
}

using HttpClient client = new HttpClient();
var requestUri = $"https://swapi.dev/api/people/?search={args[0]}";
var response = await client.GetFromJsonAsync<PersonsDTO>(requestUri);

if (response?.Count != 1)
{
    Console.WriteLine("There is no single answer to your question!");
}
else
{
    foreach (var person in response.results)
    {
        Console.WriteLine($"Name: {person.Name}, Height: {person.Height}, Mass: {person.Mass}, Hair Color: {person.Hair_Color}, Skin Color: {person.Skin_Color}, Eye Color: {person.Eye_Color}");
    }
}
return 1;
int PrintHelp()
{
    Console.WriteLine("Print Name of Star Wars Hero as argument");
    return 1;
}

record PersonDTO(string Name, string Height, string Mass, string Hair_Color, string Skin_Color, string Eye_Color);

record PersonsDTO(int Count, string Next, string Previous, PersonDTO[] results);