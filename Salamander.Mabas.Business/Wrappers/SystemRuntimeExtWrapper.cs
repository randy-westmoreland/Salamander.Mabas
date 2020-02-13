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
        /// Converts bytes to Memory Stream.
        /// </summary>
        /// <param name="bytes">The bytes.</param>
        /// <param name="index">The index.</param>
        /// <param name="count">The count.</param>
        /// <returns>
        /// MemoryStream
        /// </returns>
        public MemoryStream MemoryStream(byte[] bytes, int index, int count)
        {
            return new MemoryStream(bytes, index, count);
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

        /// <summary>
        /// Strings the reader.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns>
        /// StringReader
        /// </returns>
        public StringReader StringReader(string path)
        {
            return new StringReader(path);
        }
    }
}