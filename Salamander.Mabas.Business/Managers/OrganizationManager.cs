using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RestSharp;
using Salamander.Mabas.Business.Contracts;
using Salamander.Mabas.Model.AppSettings;
using Salamander.Mabas.Model.Domain;
using Salamander.Mabas.Model.Response;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Salamander.Mabas.Business.Managers
{
    /// <summary>
    /// OrganizationManager Class.
    /// </summary>
    /// <seealso cref="IOrganizationManager" />
    public class OrganizationManager : IOrganizationManager
    {
        private readonly IOptions<OrganizationSettings> _orgSettings;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrganizationManager"/> class.
        /// </summary>
        /// <param name="orgSettings">The org settings.</param>
        public OrganizationManager(IOptions<OrganizationSettings> orgSettings)
        {
            _orgSettings = orgSettings;
        }

        /// <summary>
        /// Gets the organization.
        /// </summary>
        /// <param name="token">The token.</param>
        /// <param name="records">The records.</param>
        /// <returns>List<OrganizationResponse> orgResponse, List<CsvModel> records)</returns>
        public async Task<(List<OrganizationResponse> orgResponse, List<CsvModel> records)> GetOrganization(string token, List<CsvModel> records)
        {
            var orgResponse = new List<OrganizationResponse>();
            var client = new RestClient(_orgSettings.Value.Endpoint);

            for (var i = 0; i < records?.Count; i++)
            {
                if (string.Equals(records[i].IllinoisTaskForce, "yes", System.StringComparison.InvariantCultureIgnoreCase))
                {
                    records[i].TeamDescription = "ILTF-1";
                }

                var request = new RestRequest(Method.POST) { RequestFormat = DataFormat.Xml };
                request = BuildOrganizationRequest(records, request, token, i);

                var response = await client.ExecuteAsync<OrganizationResponse>(request, CancellationToken.None).ConfigureAwait(false);

                orgResponse.Add(response.Data);
                orgResponse[i].UserId = records[i].UserId;
            }

            return (orgResponse, records);
        }

        /// <summary>
        /// Builds the organization request.
        /// </summary>
        /// <param name="records">The records.</param>
        /// <param name="request">The request.</param>
        /// <param name="token">The token.</param>
        /// <param name="index">The index.</param>
        /// <returns>
        /// RestRequest
        /// </returns>
        private RestRequest BuildOrganizationRequest(List<CsvModel> records, RestRequest request, string token, int index)
        {
            request.AddHeader("authorization", $"Bearer {token}");

            var data = new OrganizationRequest
            {
                Item = new OrganizationRequestModel
                {
                    Filter = new List<FilterModel>
                    {
                        new FilterModel
                        {
                            Field = "IdentityCode",
                            Value = new List<string> { records?[index].FireDepartmentId.Trim() },
                        },
                        new FilterModel
                        {
                            Field = "StateTerritoryCode",
                            Value = new List<string> { records?[index].State }
                        }
                    }
                }
            };

            var body = JsonConvert.SerializeObject(data);
            request.AddJsonBody(body);

            return request;
        }
    }
}