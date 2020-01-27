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
        /// Convertes bytes to Memory Stream.
        /// </summary>
        /// <param name="bytes">The bytes.</param>
        /// <returns>MemoryStream</returns>
        MemoryStream MemoryStream(byte[] bytes);
    }
}