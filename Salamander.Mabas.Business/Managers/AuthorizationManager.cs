using Microsoft.Extensions.Options;
using RestSharp;
using Salamander.Mabas.Business.Contracts;
using Salamander.Mabas.Model.AppSettings;
using Salamander.Mabas.Model.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace Salamander.Mabas.Business.Managers
{
    /// <summary>
    /// AuthorizationManager Class.
    /// </summary>
    /// <seealso cref="IAuthorizationManager" />
    public class AuthorizationManager : IAuthorizationManager
    {
        private readonly IOptions<AuthorizationSettings> _authSettings;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthorizationManager"/> class.
        /// </summary>
        /// <param name="authSettings">The authentication settings.</param>
        public AuthorizationManager(IOptions<AuthorizationSettings> authSettings)
        {
            _authSettings = authSettings;
        }

        /// <summary>
        /// Requests the access token.
        /// </summary>
        /// <param name="endpoint">The endpoint.</param>
        /// <returns>Task<IRestResponse<TokenResponse>></returns>
        public async Task<IRestResponse<TokenResponse>> RequestAccessToken(string endpoint)
        {
            var client = new RestClient(_authSettings.Value.Endpoint);
            var request = new RestRequest(Method.POST);

            request.AddHeader("content-type", "application/json");
            request.AddParameter("application/json", _authSettings.Value.Body, ParameterType.RequestBody);

            request.RequestFormat = DataFormat.Xml;

            return await client.ExecuteAsync<TokenResponse>(request, CancellationToken.None).ConfigureAwait(false);
        }
    }
}