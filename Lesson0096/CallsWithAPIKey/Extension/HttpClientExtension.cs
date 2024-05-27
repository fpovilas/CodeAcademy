using CallsWithAPIKey.Extension.Interface;
using CallsWithAPIKey.Models;
using CallsWithAPIKey.Models.DTO;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace CallsWithAPIKey.Extension
{
    public class HttpClientExtension(HttpClient httpClient) : IHttpClientExtension
    {
        public async Task<UserJWTToken> GetJWTToken(string username, string password, string apiKey)
        {
            try
            {
                string uri = $"https://localhost:7218/api/user/LogIn?username={username}&password={password}";

                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri(uri),
                    Headers =
                    {
                        {"ApiKey", apiKey}
                    }
                };

                var response = await httpClient.SendAsync(request);
                response.EnsureSuccessStatusCode();

                var body = await response.Content.ReadAsStringAsync();
                UserJWTToken deserilizationCall = new() { JWTToken = body };

                return deserilizationCall;
            }
            catch
            {
                return new UserJWTToken() { JWTToken = string.Empty };
            }
        }

        public async Task<List<CarDto>> GetCars(string jwtToken)
        {
            try
            {
                string uri = $"https://localhost:7218/GetCars";

                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri(uri),
                    Headers =
                    {
                        Authorization = new AuthenticationHeaderValue("Bearer", jwtToken)
                    }
                };

                var response = await httpClient.SendAsync(request);
                response.EnsureSuccessStatusCode();

                var body = await response.Content.ReadAsStringAsync();
                List<CarDto> deserilizationCall = JsonConvert.DeserializeObject<List<CarDto>>(body)!;

                return deserilizationCall;
            }
            catch
            {
                return [];
            }
        }
    }
}
