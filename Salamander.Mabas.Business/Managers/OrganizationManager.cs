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
        /// <returns>Task<List<OrganizationResponse>></returns>
        public async Task<List<OrganizationResponse>> GetOrganization(string token, List<CsvModel> records)
        {
            var orgResponse = new List<OrganizationResponse>();
            var client = new RestClient(_orgSettings.Value.Endpoint);

            for (var i = 0; i < 10; i++)
            {
                var request = new RestRequest(Method.POST) { RequestFormat = DataFormat.Xml };
                request = BuildOrganizationRequest(records, request, token, i);

                var response = await client.ExecuteAsync<OrganizationResponse>(request, CancellationToken.None).ConfigureAwait(false);
                orgResponse.Add(response.Data);
            }

            return orgResponse;
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
                Item = new RequestData
                {
                    Filter = new List<FilterModel>
                    {
                        new FilterModel
                        {
                            Field = "Name",
                            Value = new List<string> { records?[index].DepartmentName },
                        },
                        new FilterModel
                        {
                            Field = "StateTerritoryCode",
                            Value = new List<string> { "IL" }
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