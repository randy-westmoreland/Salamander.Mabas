using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RestSharp;
using Salamander.Mabas.Business.Contracts;
using Salamander.Mabas.Model.AppSettings;
using Salamander.Mabas.Model.Domain;
using Salamander.Mabas.Model.Request;
using Salamander.Mabas.Model.Response;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Salamander.Mabas.Business.Managers
{
    /// <summary>
    /// UserManager Class.
    /// </summary>
    /// <seealso cref="IUserManager" />
    public class UserManager : IUserManager
    {
        private readonly IOptions<UserSettings> _userSettings;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserManager"/> class.
        /// </summary>
        /// <param name="userSettings">The user settings.</param>
        public UserManager(IOptions<UserSettings> userSettings)
        {
            _userSettings = userSettings;
        }

        /// <summary>
        /// Creates the user.
        /// </summary>
        /// <param name="token">The token.</param>
        /// <param name="orgResponse">The org response.</param>
        /// <param name="records">The records.</param>
        /// <returns>Task<List<UserResponse>></returns>
        public async Task<List<UserResponse>> CreateUser(string token, List<OrganizationResponse> orgResponse, List<CsvModel> records)
        {
            var userResponse = new List<UserResponse>();
            var client = new RestClient(_userSettings.Value.Endpoint);

            for (var i = 0; i < 2; i++)
            {
                var record = records?.Where(x => x.UserId == orgResponse[i].UserId).FirstOrDefault();
                var request = new RestRequest(Method.PUT) { RequestFormat = DataFormat.Xml };

                request = BuildUserRequest(orgResponse?[i], record, request, token);

                var response = await client.ExecuteAsync<UserResponse>(request, CancellationToken.None).ConfigureAwait(false);

                userResponse.Add(response.Data);
                userResponse[i].Data.UserId = records[i].UserId;
            }

            return userResponse;
        }

        /// <summary>
        /// Builds the user request.
        /// </summary>
        /// <param name="orgResponse">The org response.</param>
        /// <param name="record">The record.</param>
        /// <param name="request">The request.</param>
        /// <param name="token">The token.</param>
        /// <returnsRestRequest></returns>
        private RestRequest BuildUserRequest(OrganizationResponse orgResponse, CsvModel record, RestRequest request, string token)
        {
            request.AddHeader("authorization", $"Bearer {token}");

            var data = new UserRequest
            {
                Item = new UserRequestModel
                {
                    IdentityCode = record.UserId,
                    OrganizationPrimaryKey = orgResponse.PrimaryKey,
                    FirstName = record.FirstName,
                    LastName = record.LastName,
                    Rank = record.Rank,
                    Station = record.TeamDescription,
                    Status = record.Status == "Approved" ? "Active" : "Inactive",
                    RateInfo = new RateInfoModel
                    {
                        Standard = record.Rate
                    }
                }
            };

            var body = JsonConvert.SerializeObject(data);
            request.AddJsonBody(body);

            return request;
        }
    }
}