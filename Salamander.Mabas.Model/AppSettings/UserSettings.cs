namespace Salamander.Mabas.Model.AppSettings
{
    /// <summary>
    /// UserSettings Class.
    /// </summary>
    public class UserSettings
    {
        /// <summary>
        /// Gets or sets the endpoint.
        /// </summary>
        /// <value>
        /// The endpoint.
        /// </value>
        public string Endpoint { get; set; }

        /// <summary>
        /// Gets or sets the personal.
        /// </summary>
        /// <value>
        /// The personal.
        /// </value>
        public PersonalModel Personal { get; set; }
    }

    /// <summary>
    /// PersonalModel Class.
    /// </summary>
    public class PersonalModel
    {
        /// <summary>
        /// Gets or sets the endpoint.
        /// </summary>
        /// <value>
        /// The endpoint.
        /// </value>
        public string Endpoint { get; set; }
    }
}