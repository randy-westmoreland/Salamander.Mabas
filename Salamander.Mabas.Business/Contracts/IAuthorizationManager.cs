using RestSharp;
using Salamander.Mabas.Model.Domain;
using System.Threading.Tasks;

namespace Salamander.Mabas.Business.Contracts
{
    /// <summary>
    /// IAuthorizationManager Interface.
    /// </summary>
    public interface IAuthorizationManager
    {
        /// <summary>
        /// Requests the access token.
        /// </summary>
        /// <param name="endpoint">The endpoint.</param>
        /// <returns>Task<IRestResponse<TokenResponse>></returns>
        Task<IRestResponse<TokenResponse>> RequestAccessToken(string endpoint);
    }
}