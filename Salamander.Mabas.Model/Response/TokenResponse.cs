using RestSharp.Deserializers;

namespace Salamander.Mabas.Model.Domain
{
    /// <summary>
    /// AuthorizationResponseDto Class.
    /// </summary>
    public class TokenResponse
    {
        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        /// <value>
        /// The data.
        /// </value>
        [DeserializeAs(Name = "Data")]
        public Response Response { get; set; }
    }

    /// <summary>
    /// Response Class.
    /// </summary>
    public class Response
    {
        /// <summary>
        /// Gets or sets the time zone identifier.
        /// </summary>
        /// <value>
        /// The time zone identifier.
        /// </value>
        public string TimeZoneId { get; set; }

        /// <summary>
        /// Gets or sets the token identifier.
        /// </summary>
        /// <value>
        /// The token identifier.
        /// </value>
        public string TokenId { get; set; }

        /// <summary>
        /// Gets the change password remaining days.
        /// </summary>
        /// <value>
        /// The change password remaining days.
        /// </value>
        public string ChangePasswordRemainingDays { get; set; }
    }
}