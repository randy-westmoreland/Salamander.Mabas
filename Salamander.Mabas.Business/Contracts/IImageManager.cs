using Salamander.Mabas.Model.Domain;
using Salamander.Mabas.Model.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Salamander.Mabas.Business.Contracts
{
    /// <summary>
    /// IImageManager Interface.
    /// </summary>
    public interface IImageManager
    {
        /// <summary>
        /// Saves the images.
        /// </summary>
        /// <param name="userResponse">The user response.</param>
        /// <param name="orgResponse">The org response.</param>
        /// <param name="records">The records.</param>
        /// <param name="token">The token.</param>
        /// <returns>Task</returns>
        Task SaveImages(List<UserResponse> userResponse, List<OrganizationResponse> orgResponse, List<CsvModel> records, string token);
    }
}