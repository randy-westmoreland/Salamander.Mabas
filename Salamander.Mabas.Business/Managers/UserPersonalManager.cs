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
    /// UserPersonalManager Class.
    /// </summary>
    /// <seealso cref="IUserPersonalManager" />
    public class UserPersonalManager : IUserPersonalManager
    {
        private readonly IOptions<UserSettings> _userSettings;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserPersonalManager"/> class.
        /// </summary>
        /// <param name="userSettings">The user settings.</param>
        public UserPersonalManager(IOptions<UserSettings> userSettings)
        {
            _userSettings = userSettings;
        }

        /// <summary>
        /// Saves the personal record.
        /// </summary>
        /// <param name="token">The token.</param>
        /// <param name="userResponse">The user response.</param>
        /// <param name="records">The records.</param>
        /// <returns>Task<List<UserPersonalResponse>></returns>
        public async Task<List<UserPersonalResponse>> SavePersonalRecord(string token, List<UserResponse> userResponse, List<CsvModel> records)
        {
            var userPersonalResponse = new List<UserPersonalResponse>();
            var client = new RestClient(_userSettings.Value.Personal.Endpoint);

            for (var i = 0; i < records.Count; i++)
            {
                var record = records?.Where(x => x.UserId == userResponse[i].Data.UserId).FirstOrDefault();
                var request = new RestRequest(Method.PUT) { RequestFormat = DataFormat.Xml };

                request = BuildUserPersonalRequest(userResponse?[i], record, request, token);

                var response = await client.ExecuteAsync<UserPersonalResponse>(request, CancellationToken.None).ConfigureAwait(false);

                userPersonalResponse.Add(response.Data);
            }

            return userPersonalResponse;
        }

        /// <summary>
        /// Builds the user personal request.
        /// </summary>
        /// <param name="userResponse">The user response.</param>
        /// <param name="record">The record.</param>
        /// <param name="request">The request.</param>
        /// <param name="token">The token.</param>
        /// <returns>RestRequest</returns>
        private RestRequest BuildUserPersonalRequest(UserResponse userResponse, CsvModel record, RestRequest request, string token)
        {
            request.AddHeader("authorization", $"Bearer {token}");

            var data = new UserPersonalRequest
            {
                Item = new UserPersonalRequestModel
                {
                    Email = record.Email,
                    StudentId = record.Division,
                    BirthDate = record.DateofBirth,
                    OtherId = record.Tier2PersonID,
                    PhoneNumbers = new PhoneNumbersModel
                    {
                        Mobile = record.PhoneNumber
                    },
                    ResponderPk = userResponse.Data.PrimaryKey
                }
            };

            var body = JsonConvert.SerializeObject(data);
            request.AddJsonBody(body);

            return request;
        }
    }
}