using API_DestinosDeViagens.Models;
using API_DestinosDeViagens.Repository.RepositoryRoadTrip;
using Newtonsoft.Json;
using System.Text;

namespace API_DestinosDeViagens.Services;

public class RoadTripService
{
    private IConfiguration _config;
    private IRoadTripRepository _iroadTripRepositoy;
    public RoadTripService(IConfiguration config, IRoadTripRepository roadTripRepositoy)
    {
        _config = config;
        _iroadTripRepositoy = roadTripRepositoy;
    }

    public string GetResponseIAToSightsFildInRoadTripModel(string title)
    {
        string KeyOpenai = _config["ChaveAPIChatGPT"];

        //RoadTripModel roadTrip = new RoadTripModel();
        //title = roadTrip.DestinationModel.Title;
        //Console.WriteLine("AQUI SERVICE" + title);

        string promptText = $"Gere 3 locais turisticos de {title}. O texto gerado pode conter até 35 caracteres. Seja objetivo e mande apenas os nomes dos locais.";

        using (HttpClient Client = new HttpClient())
        {
            Client.DefaultRequestHeaders.Add("authorization", $"Bearer {KeyOpenai}");

            var json = JsonConvert.SerializeObject(
              new
              {
                  model = "text-davinci-003",
                  prompt = promptText,
                  max_tokens = 500,
                  temperature = 1
              }
           );

            var httpResponse = Client.PostAsync("https://api.openai.com/v1/completions", new StringContent(json, Encoding.UTF8, "application/json")).GetAwaiter().GetResult();

            var data = httpResponse.Content.ReadAsStringAsync().GetAwaiter().GetResult();

            var response = JsonConvert.DeserializeObject<dynamic>(data);
            Console.WriteLine(response.choices[0].text);

            string treatResponse = response.choices[0].text;

            RoadTripModel roadTrip = new RoadTripModel();
            roadTrip.Sights = treatResponse;
            _iroadTripRepositoy.Add(roadTrip);


            treatResponse = treatResponse.Replace("\n", "");

            return treatResponse;
        }
    }
}
