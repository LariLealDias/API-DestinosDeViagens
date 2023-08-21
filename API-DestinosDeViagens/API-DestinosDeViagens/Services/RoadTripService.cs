using API_DestinosDeViagens.Models;
using Newtonsoft.Json;
using System.Text;

namespace API_DestinosDeViagens.Services;

public class RoadTripService
{
    private IConfiguration _config;
    public RoadTripService(IConfiguration config)
    {
        _config = config;
    }

    public string GetResponseIAToSightsFildinRoadTripModel(RoadTripModel roadTrip)
    {
        string KeyOpenai = _config["ChaveAPIChatGPT"];
        string promptText = "";

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

            treatResponse = treatResponse.Replace("\n", "");

            return treatResponse;
        }
    }
}
