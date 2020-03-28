using Newtonsoft.Json;

namespace Salamander.Mabas.Model.Request
{
    /// <summary>
    /// ImageRequest Class.
    /// </summary>
    public class ImageRequest
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [JsonProperty(PropertyName = "ID")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the base64 data.
        /// </summary>
        /// <value>
        /// The base64 data.
        /// </value>
        public string Base64Data { get; set; }

        /// <summary>
        /// Gets or sets the organization.
        /// </summary>
        /// <value>
        /// The organization.
        /// </value>
        public OrganizationModel Organization { get; set; }
    }

    /// <summary>
    /// OrganizationModel Class.
    /// </summary>
    public class OrganizationModel
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [JsonProperty(PropertyName = "ID")]
        public int Id { get; set; }
    }
}