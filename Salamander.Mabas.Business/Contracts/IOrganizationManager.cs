using Salamander.Mabas.Model.Domain;
using Salamander.Mabas.Model.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Salamander.Mabas.Business.Contracts
{
    /// <summary>
    /// IOrganizationManager Interface.
    /// </summary>
    public interface IOrganizationManager
    {
        /// <summary>
        /// Gets the organization.
        /// </summary>
        /// <param name="token">The token.</param>
        /// <param name="records">The records.</param>
        /// <returns>List<OrganizationResponse>, List<CsvModel></returns>
        Task<(List<OrganizationResponse> orgResponse, List<CsvModel> records)> GetOrganization(string token, List<CsvModel> records);
    }
}