using Salamander.Mabas.Business.Contracts;
using Salamander.Mabas.Model.Domain;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Salamander.Mabas.Business.Managers
{
    public class UserManager : IUserManager
    {
        public Task<HttpStatusCode> CreateUser(string token, List<CsvModel> records)
        {
            throw new NotImplementedException();
        }
    }
}