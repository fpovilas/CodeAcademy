using CallsWithAPIKey.Models;
using CallsWithAPIKey.Models.DTO;

namespace CallsWithAPIKey.Extension.Interface
{
    public interface IHttpClientExtension
    {
        Task<List<CarDto>> GetCars(string jwtToken);
        Task<UserJWTToken> GetJWTToken(string username, string password, string apiKey);
    }
}
