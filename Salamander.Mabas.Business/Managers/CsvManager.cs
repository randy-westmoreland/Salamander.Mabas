using Salamander.Mabas.Business.Contracts;
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
        /// <returns>List<CsvModel></returns>
        public List<CsvModel> LoadCsv(string path)
        {
            using var reader = _systemRuntimeExtWrapper.StreamReader(path);
            using var csv = _csvHelperWrapper.CsvReader(reader, CultureInfo.InvariantCulture);

            return csv.GetRecords<CsvModel>().ToList();
            //var images = Base64ToImage(records);

            //SaveToFile(images);
        }

        /// <summary>
        /// Base64s to image.
        /// </summary>
        /// <param name="records">The records.</param>
        /// <returns>List<Image></returns>
        private List<Image> Base64ToImage(List<CsvModel> records)
        {
            var imageList = new List<Image>();

            records.ForEach(x =>
            {
                var imageBytes = Convert.FromBase64String(x.Image);

                using var memoryStream = _systemRuntimeExtWrapper.MemoryStream(imageBytes, 0, imageBytes.Length);
                imageList.Add(Image.FromStream(memoryStream, true));
            });

            return imageList;
        }

        /// <summary>
        /// Saves to file.
        /// </summary>
        /// <param name="images">The images.</param>
        private void SaveToFile(List<Image> images)
        {
            var num = 1;
            images.ForEach(x =>
            {
                using var bitmap = new Bitmap(x);
                bitmap.Save(Directory.GetCurrentDirectory() + $"\\Files\\test{num}.jpg", ImageFormat.Jpeg);
                num++;
            });
        }
    }
}