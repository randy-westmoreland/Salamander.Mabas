using Microsoft.Extensions.Options;
using RestSharp;
using Salamander.Mabas.Business.Contracts;
using Salamander.Mabas.Model.AppSettings;
using Salamander.Mabas.Model.Domain;
using Salamander.Mabas.Model.Response;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Salamander.Mabas.Business.Managers
{
    public class UserManager : IUserManager
    {
        private readonly IOptions<UserSettings> _userSettings;

        public UserManager(IOptions<UserSettings> userSettings)
        {
            _userSettings = userSettings;
        }

        public async Task<HttpStatusCode> CreateUser(string token, List<CsvModel> records)
        {
            var client = new RestClient(_userSettings.Value.Endpoint);

            var request = new RestRequest(Method.PUT) { RequestFormat = DataFormat.Xml };
            request = BuildUserRequest();

            var response = await client.ExecuteAsync<UserResponse>(request, CancellationToken.None).ConfigureAwait(false);

            return null;
        }

        private RestRequest BuildUserRequest()
        {
            return null;
        }
    }
}