﻿using Salamander.Mabas.Model.Domain;
using Salamander.Mabas.Model.Response;
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
        /// <param name="orgResponse">The org response.</param>
        /// <param name="records">The records.</param>
        /// <returns>Task<List<UserResponse>></returns>
        Task<List<UserResponse>> CreateUser(string token, List<OrganizationResponse> orgResponse, List<CsvModel> records);
    }
}