using RestSharp.Deserializers;

namespace Salamander.Mabas.Model.Response
{
    /// <summary>
    /// OrganizationResponse Class.
    /// </summary>
    [DeserializeAs(Name = "ResponsePagedListOfOrganizationListDYHJjYxr")]
    public class OrganizationResponse
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the primary key.
        /// </summary>
        /// <value>
        /// The primary key.
        /// </value>
        [DeserializeAs(Name = "PK")]
        public int PrimaryKey { get; set; }
    }
}