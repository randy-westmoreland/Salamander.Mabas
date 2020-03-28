using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RestSharp;
using Salamander.Mabas.Business.Contracts;
using Salamander.Mabas.Model.AppSettings;
using Salamander.Mabas.Model.Domain;
using Salamander.Mabas.Model.Request;
using Salamander.Mabas.Model.Response;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Salamander.Mabas.Business.Managers
{
    /// <summary>
    /// ImageManager Class.
    /// </summary>
    /// <seealso cref="IImageManager" />
    public class ImageManager : IImageManager
    {
        private readonly IOptions<UserSettings> _userSettings;

        /// <summary>
        /// Initializes a new instance of the <see cref="ImageManager"/> class.
        /// </summary>
        /// <param name="userSettings">The user settings.</param>
        public ImageManager(IOptions<UserSettings> userSettings)
        {
            _userSettings = userSettings;
        }

        /// <summary>
        /// Saves the images.
        /// </summary>
        /// <param name="userResponse">The user response.</param>
        /// <param name="orgResponse">The org response.</param>
        /// <param name="records">The records.</param>
        /// <param name="token">The token.</param>
        public async Task SaveImages(List<UserResponse> userResponse, List<OrganizationResponse> orgResponse, List<CsvModel> records, string token)
        {
            var client = new RestClient(_userSettings.Value.Image.Endpoint);

            for (var i = 0; i < records.Count; i++)
            {
                var request = new RestRequest(Method.PUT) { RequestFormat = DataFormat.Xml };
                request = BuildImageRequest(userResponse, orgResponse, records, request, token, i);

                _ = await client.ExecuteAsync<ImageResponse>(request, CancellationToken.None).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Builds the image request.
        /// </summary>
        /// <param name="userResponse">The user response.</param>
        /// <param name="orgResponse">The org response.</param>
        /// <param name="records">The records.</param>
        /// <param name="request">The request.</param>
        /// <param name="token">The token.</param>
        /// <param name="index">The index.</param>
        /// <returns>RestRequest</returns>
        private RestRequest BuildImageRequest(List<UserResponse> userResponse, List<OrganizationResponse> orgResponse, List<CsvModel> records, RestRequest request, string token, int index)
        {
            request.AddHeader("authorization", $"Bearer {token}");

            var data = new ImageRequest
            {
                Id = userResponse[index].Data.PrimaryKey,
                Base64Data = records[index].Image,
                Organization = new OrganizationModel
                {
                    Id = orgResponse[index].PrimaryKey
                }
            };

            var body = JsonConvert.SerializeObject(data);
            request.AddJsonBody(body);

            return request;
        }
    }
}