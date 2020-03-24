using RestSharp.Deserializers;
using System.Collections.Generic;

namespace Salamander.Mabas.Model.Response
{
    /// <summary>
    /// UserResposne Class.
    /// </summary>
    [DeserializeAs(Name = "TokenItemRequiredOfResponderUpdateDYHJjYxr")]
    public class UserResponse
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

        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        /// <value>
        /// The data.
        /// </value>
        public DataModel Data { get; set; }
    }

    /// <summary>
    /// DataModel Class.
    /// </summary>
    public class DataModel
    {
        /// <summary>
        /// Gets or sets the primary key.
        /// </summary>
        /// <value>
        /// The primary key.
        /// </value>
        [DeserializeAs(Name = "PK")]
        public int PrimaryKey { get; set; }

        /// <summary>
        /// Gets or sets the organization primary key.
        /// </summary>
        /// <value>
        /// The organization primary key.
        /// </value>
        [DeserializeAs(Name = "OrganizationPK")]
        public int OrganizationPrimaryKey { get; set; }

        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        public string UserId { get; set; }
    }
}