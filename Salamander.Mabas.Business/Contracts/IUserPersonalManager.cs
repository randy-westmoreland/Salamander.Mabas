using Salamander.Mabas.Model.Domain;
using Salamander.Mabas.Model.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Salamander.Mabas.Business.Contracts
{
    /// <summary>
    /// IUserPersonalManager Interface.
    /// </summary>
    public interface IUserPersonalManager
    {
        /// <summary>
        /// Saves the personal record.
        /// </summary>
        /// <param name="token">The token.</param>
        /// <param name="userResponse">The user response.</param>
        /// <param name="records">The records.</param>
        /// <returns>Task<List<UserPersonalResponse>></returns>
        Task<List<UserPersonalResponse>> SavePersonalRecord(string token, List<UserResponse> userResponse, List<CsvModel> records);
    }
}