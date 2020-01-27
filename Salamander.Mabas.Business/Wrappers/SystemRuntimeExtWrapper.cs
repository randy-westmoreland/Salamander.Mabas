using Salamander.Mabas.Business.Contracts;
using System.IO;

namespace Salamander.Mabas.Business.Wrappers
{
    /// <summary>
    /// SystemRuntimeExtWrapper Class.
    /// </summary>
    /// <seealso cref="ISystemRuntimeExtWrapper" />
    public class SystemRuntimeExtWrapper : ISystemRuntimeExtWrapper
    {
        /// <summary>
        /// Convertes bytes to Memory Stream.
        /// </summary>
        /// <param name="bytes">The bytes.</param>
        /// <returns>
        /// MemoryStream
        /// </returns>
        public MemoryStream MemoryStream(byte[] bytes)
        {
            return new MemoryStream(bytes);
        }

        /// <summary>
        /// Reads the file stream.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns>
        /// StreamReader
        /// </returns>
        public StreamReader StreamReader(string path)
        {
            return new StreamReader(path);
        }
    }
}