using System.IO;

namespace Salamander.Mabas.Business.Contracts
{
    /// <summary>
    /// ISystemRuntimeExtWrappers Interface.
    /// </summary>
    public interface ISystemRuntimeExtWrapper
    {
        /// <summary>
        /// Reads the file stream.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns>StreamReader</returns>
        StreamReader StreamReader(string path);

        /// <summary>
        /// Strings the reader.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns>StringReader</returns>
        StringReader StringReader(string path);

        /// <summary>
        /// Converts bytes to Memory Stream.
        /// </summary>
        /// <param name="bytes">The bytes.</param>
        /// <returns>MemoryStream</returns>
        MemoryStream MemoryStream(byte[] bytes);

        /// <summary>
        /// Converts bytes to Memory Stream.
        /// </summary>
        /// <param name="bytes">The bytes.</param>
        /// <param name="index">The index.</param>
        /// <param name="count">The count.</param>
        /// <returns>MemoryStream</returns>
        MemoryStream MemoryStream(byte[] bytes, int index, int count);
    }
}