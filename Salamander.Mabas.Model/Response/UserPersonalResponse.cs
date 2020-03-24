using RestSharp.Deserializers;
using System.Collections.Generic;

namespace Salamander.Mabas.Model.Response
{
    /// <summary>
    /// UserPersonalResponse Class.
    /// </summary>
    [DeserializeAs(Name = "TokenItemRequiredOfResponderPersonalDYHJjYxr")]
    public class UserPersonalResponse
    {
        /// <summary>
        /// Gets or sets the errors.
        /// </summary>
        /// <value>
        /// The errors.
        /// </value>
        public List<ErrorsModel> Errors { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="UserResponse"/> is result.
        /// </summary>
        /// <value>
        ///   <c>true</c> if result; otherwise, <c>false</c>.
        /// </value>
        public bool Result { get; set; }

        /// <summary>
        /// Gets or sets the time zone identifier.
        /// </summary>
        /// <value>
        /// The time zone identifier.
        /// </value>
        public string TimeZoneId { get; set; }

        /// <summary>
        /// Gets or sets the warnings.
        /// </summary>
        /// <value>
        /// The warnings.
        /// </value>
        public List<WarningsModel> Warnings { get; set; }
    }
}