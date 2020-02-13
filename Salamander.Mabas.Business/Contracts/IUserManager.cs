using Salamander.Mabas.Model.Domain;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Salamander.Mabas.Business.Contracts
{
    /// <summary>
    /// IUserManager Interface.
    /// </summary>
    public interface IUserManager
    {
        /// <summary>
        /// Creates the user.
        /// </summary>
        /// <param name="token">The token.</param>
        /// <param name="records">The records.</param>
        /// <returns>Task<HttpStatusCode></returns>
        Task<HttpStatusCode> CreateUser(string token, List<CsvModel> records);
    }
}