using Salamander.Mabas.Model.Domain;
using System.Collections.Generic;

namespace Salamander.Mabas.Business.Contracts
{
    /// <summary>
    /// ICsvManager Class.
    /// </summary>
    public interface ICsvManager
    {
        /// <summary>
        /// Loads the CSV.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns>List<CsvModel></returns>
        List<CsvModel> LoadCsv(string path);
    }
}