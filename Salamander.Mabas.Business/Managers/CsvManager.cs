using Salamander.Mabas.Business.Contracts;
using Salamander.Mabas.Common.Extensions;
using Salamander.Mabas.Model.Domain;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Salamander.Mabas.Business.Managers
{
    /// <summary>
    /// CsvManager Class.
    /// </summary>
    /// <seealso cref="ICsvManager" />
    public class CsvManager : ICsvManager
    {
        private readonly ICsvHelperWrapper _csvHelperWrapper;
        private readonly ISystemRuntimeExtWrapper _systemRuntimeExtWrapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="CsvManager"/> class.
        /// </summary>
        /// <param name="csvHelperWrapper">The CSV helper wrapper.</param>
        /// <param name="systemRuntimeExtWrapper">The system runtime ext wrapper.</param>
        public CsvManager(ICsvHelperWrapper csvHelperWrapper, ISystemRuntimeExtWrapper systemRuntimeExtWrapper)
        {
            _csvHelperWrapper = csvHelperWrapper;
            _systemRuntimeExtWrapper = systemRuntimeExtWrapper;
        }

        /// <summary>
        /// Loads the CSV.
        /// </summary>
        /// <param name="path">The path.</param>
        public void LoadCsv(string path)
        {
            using var reader = _systemRuntimeExtWrapper.StreamReader(path);
            using var csv = _csvHelperWrapper.CsvReader(reader, CultureInfo.InvariantCulture);

            var records = csv.GetRecords<CsvDomain>().ToList();
            var bytes = BuildByteList(records);
            var streams = BuildMemoryStreamList(bytes);

            SaveToFile(streams[1]);
        }

        /// <summary>
        /// Builds the byte list.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns>IList<byte[]></returns>
        private static IList<byte[]> BuildByteList(IList<CsvDomain> data)
        {
            var bytes = new List<byte[]>();
            data.ForEach(x => bytes.Add(ConvertHexToByteArray(x.ImageFieldAsHex)));

            return bytes;
        }

        /// <summary>
        /// Builds the memory stream list.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns>IList<MemoryStream></returns>
        private IList<MemoryStream> BuildMemoryStreamList(IList<byte[]> data)
        {
            var memStream = new List<MemoryStream>();
            data.ForEach(x => memStream.Add(_systemRuntimeExtWrapper.MemoryStream(x)));

            return memStream;
        }

        /// <summary>
        /// Converts the hexadecimal to byte array.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>byte[]</returns>
        private static byte[] ConvertHexToByteArray(string value)
        {
            var len = value.Length;
            if (len % 2 == 1)
            {
                value = "0" + value;
                len = value.Length;
            }

            var bytes = new byte[len / 2];

            for (var i = 0; i < len; i += 2)
            {
                bytes[i / 2] = Convert.ToByte(value.Substring(i, 2), 16);
            }

            return bytes;
        }

        /// <summary>
        /// Saves to file.
        /// </summary>
        /// <param name="stream">The stream.</param>
        private static void SaveToFile(MemoryStream stream)
        {
            using var memStream = new MemoryStream();
            stream?.CopyTo(memStream);
            memStream.Position = 0;

            using var bitmap = new Bitmap(memStream);
            bitmap.Save(Directory.GetCurrentDirectory() + "\\Files\\test.jpg", ImageFormat.Jpeg);
        }
    }
}