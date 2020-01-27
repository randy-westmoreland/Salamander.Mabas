using CsvHelper;
using Salamander.Mabas.Business.Contracts;
using System.Globalization;
using System.IO;

namespace Salamander.Mabas.Business.Wrappers
{
    /// <summary>
    /// CsvHelperWrapper Class.
    /// </summary>
    /// <seealso cref="ICsvHelperWrapper" />
    public class CsvHelperWrapper : ICsvHelperWrapper
    {
        /// <summary>
        /// Reads the CSV stream.
        /// </summary>
        /// <param name="streamReader">The stream reader.</param>
        /// <param name="cultureInfo">The culture information.</param>
        /// <returns>
        /// CsvReader
        /// </returns>
        public CsvReader CsvReader(StreamReader streamReader, CultureInfo cultureInfo)
        {
            return new CsvReader(streamReader, cultureInfo);
        }
    }
}