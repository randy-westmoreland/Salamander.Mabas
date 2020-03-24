using Newtonsoft.Json;

namespace Salamander.Mabas.Model.Request
{
    /// <summary>
    /// UserRequest Class.
    /// </summary>
    public class UserRequest
    {
        /// <summary>
        /// Gets or sets the item.
        /// </summary>
        /// <value>
        /// The item.
        /// </value>
        public UserRequestModel Item { get; set; }
    }

    /// <summary>
    /// UserRequestData Class.
    /// </summary>
    public class UserRequestModel
    {
        /// <summary>
        /// Gets or sets the primary key.
        /// </summary>
        /// <value>
        /// The primary key.
        /// </value>
        [JsonProperty(PropertyName = "PK")]
        public int PrimaryKey { get; set; } = -1;

        /// <summary>
        /// Gets or sets the identity code.
        /// </summary>
        /// <value>
        /// The identity code.
        /// </value>
        public string IdentityCode { get; set; }

        /// <summary>
        /// Gets or sets the organization primary key.
        /// </summary>
        /// <value>
        /// The organization primary key.
        /// </value>
        [JsonProperty(PropertyName = "OrganizationPK")]
        public int OrganizationPrimaryKey { get; set; }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>
        /// The first name.
        /// </value>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>
        /// The last name.
        /// </value>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the note.
        /// </summary>
        /// <value>
        /// The note.
        /// </value>
        public string Note { get; set; } = "Created thru Cims Sync Program";

        /// <summary>
        /// Gets or sets the rank.
        /// </summary>
        /// <value>
        /// The rank.
        /// </value>
        public string Rank { get; set; }

        /// <summary>
        /// Gets or sets the station.
        /// </summary>
        /// <value>
        /// The station.
        /// </value>
        public string Station { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>
        /// The status.
        /// </value>
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets the rate information.
        /// </summary>
        /// <value>
        /// The rate information.
        /// </value>
        public RateInfoModel RateInfo { get; set; }
    }

    /// <summary>
    /// RateInfoModel Class.
    /// </summary>
    public class RateInfoModel
    {
        /// <summary>
        /// Gets or sets the standard.
        /// </summary>
        /// <value>
        /// The standard.
        /// </value>
        public string Standard { get; set; }
    }
}