using CsvHelper;
using System.Globalization;
using System.IO;

namespace Salamander.Mabas.Business.Contracts
{
    /// <summary>
    /// ICsvHelperWrapper Interface.
    /// </summary>
    public interface ICsvHelperWrapper
    {
        /// <summary>
        /// Reads the CSV stream.
        /// </summary>
        /// <param name="streamReader">The stream reader.</param>
        /// <param name="cultureInfo">The culture information.</param>
        /// <returns>CsvReader</returns>
        CsvReader CsvReader(StreamReader streamReader, CultureInfo cultureInfo);
    }
}